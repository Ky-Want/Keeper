namespace Keeper.Controllers;


[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  private readonly Auth0Provider _a0;
  private readonly VaultKeepsService _vks;

  public VaultKeepsController(Auth0Provider a0, VaultKeepsService vks)
  {
    _a0 = a0;
    _vks = vks;
  }





  [HttpPost]
  public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep newVaultKeep)
  {
    try
    {
      Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
      newVaultKeep.AccountId = userInfo.Id;
      VaultKeep createdVaultKeep = _vks.CreateVaultKeep(newVaultKeep);
      return Ok(createdVaultKeep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }






  [HttpDelete("{VaultId}")]
  public async Task<ActionResult<VaultKeep>> DeleteVaultKeep(int VaultKeepId)
  {
    try
    {
      Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
      _vks.DeleteVaultKeep(VaultKeepId, userInfo.Id);
      return Ok("Vault Keep Successfully Deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}