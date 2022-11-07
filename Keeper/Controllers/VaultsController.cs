namespace Keeper.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly Auth0Provider _a0;
  private readonly VaultsService _vs;

  public VaultsController(Auth0Provider a0, VaultsService vs)
  {
    _a0 = a0;
    _vs = vs;
  }




  [HttpGet("{vaultId}")]
  public async Task<ActionResult<Vault>> GetVaultByIdAsync(int vaultId)
  {
    try
    {
      Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
      Vault foundVault = _vs.GetVaultById(vaultId, userInfo?.Id);
      return Ok(foundVault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }







  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault newVault)
  {
    try
    {
      Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
      newVault.CreatorId = userInfo.Id;

      Vault createdVault = _vs.CreateVault(newVault);
      createdVault.Creator = userInfo;
      return Ok(createdVault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  // delete
  [Authorize]
  [HttpDelete]
  public async Task<ActionResult<Vault>> DeleteVault(int id)
  {
    try
    {
      var userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
      _vs.DeleteVault(id, userInfo?.Id);
      return Ok("Deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }







  // edit
}