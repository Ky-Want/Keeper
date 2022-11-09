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






  [HttpGet("{id}/keeps")]
  public ActionResult<List<MyKeeps>> GetUsersKeeps(string id)
  {
    try
    {
      var myKeeps = _ps.GetUsersKeeps(id);

      return Ok(myKeeps);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



  [HttpGet("{id}/vaults")]
  public ActionResult<List<Vault>> GetUsersVaults(string id)
  {
    try
    {
      var myVaults = _ps.GetMyVaults(id);
      return Ok(myVaults);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}