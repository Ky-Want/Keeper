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







}