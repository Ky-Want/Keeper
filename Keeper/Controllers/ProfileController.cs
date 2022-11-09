namespace Keeper.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
  private readonly VaultsService _vs;
  private readonly Auth0Provider _a0;

  public ProfileController(VaultsService vs, Auth0Provider a0)
  {
    _a0 = a0;
    _vs = vs;
  }




  // get a users profile






  // get a users keeps


  // get a users vaults
}