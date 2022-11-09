namespace Keeper.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private readonly VaultsService _vs;
  private readonly Auth0Provider _a0;
  private readonly ProfileService _ps;

  public ProfilesController(VaultsService vs, Auth0Provider a0, ProfileService ps)
  {
    _a0 = a0;
    _vs = vs;
    _ps = ps;
  }




  [HttpGet("{id}")]
  public ActionResult<Profile> GetUserById(string id)
  {
    try
    {
      var profile = _ps.GetUserById(id);
      return Ok(profile);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }






  // [HttpGet("{id}/keeps")]
  // public async Task<ActionResult<List<Profile>>> GetMyKeeps()
  // {
  //   try
  //   {
  //     var userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
  //     var myKeeps = _ps.GetMyKeeps(userInfo?.Id);

  //     return Ok(myKeeps);

  //   }
  //   catch (Exception e)
  //   {
  //     return BadRequest(e.Message);
  //   }
  // }


  // get a users vaults
}