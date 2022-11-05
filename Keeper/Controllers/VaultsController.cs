namespace Keeper.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly Auth0Provider _a0;
  private readonly VaultsService _vs;
  private readonly KeepsService _ks;

  public VaultsController(Auth0Provider a0, VaultsService vs, KeepsService ks)
  {
    _a0 = a0;
    _ks = ks;
    _vs = vs;
  }
}