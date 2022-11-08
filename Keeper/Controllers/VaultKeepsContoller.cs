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




  [HttpGet("{id}/vaultkeeps")]
  public ActionResult<List<VaultKeep>> GetVaultKeepByVaultId(int id)
  {
    try
    {
      var vaultKeeps = _vks.GetVaultKeepByVaultId(id);
      return Ok(vaultKeeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }







  // [HttpPost]
  // public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep newVaultKeep)
  // {
  //   try
  //   {
  //     Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
  //     newVaultKeep.AccountId = userInfo.Id;
  //     VaultKeep createdVaultKeep = _vks.CreateVaultKeep(newVaultKeep);
  //     return Ok(createdVaultKeep);
  //   }
  //   catch (Exception e)
  //   {
  //     return BadRequest(e.Message);
  //   }
  // }






  // [HttpDelete("{id}")]
  // public async Task<ActionResult<string>> DeleteVaultKeep(int id)
  // {
  //   try
  //   {
  //     var userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
  //     _vks.DeleteVaultKeep(id, userInfo?.Id);
  //     return Ok("Vault Keep Successfully Deleted");
  //   }
  //   catch (Exception e)
  //   {
  //     return BadRequest(e.Message);
  //   }
  // }
}