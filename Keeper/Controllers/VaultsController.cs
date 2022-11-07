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




  [Authorize]
  [HttpGet]
  public ActionResult<Vault> GetVaultById(int vaultId)
  {
    try
    {
      Vault foundVault = _vs.GetVaultById(vaultId);
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







  // edit
}