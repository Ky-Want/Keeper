namespace Keeper.Controllers;


[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly Auth0Provider _a0;
  private readonly KeepsService _ks;

  public KeepsController(Auth0Provider a0, KeepsService ks)
  {
    _a0 = a0;
    _ks = ks;
  }





  [HttpGet]
  public ActionResult<Keep> GetKeeps()
  {
    try
    {
      List<Keep> keeps = _ks.GetKeeps();
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{id}")]
  public ActionResult<Keep> GetKeepById(int id)
  {
    try
    {
      var keep = _ks.GetKeepById(id);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }







  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep newKeep)
  {
    try
    {
      Account userInfo = await _a0.GetUserInfoAsync<Account>(HttpContext);
      newKeep.CreatorId = userInfo.Id;
      Keep createdKeep = _ks.CreateKeep(newKeep);
      createdKeep.Creator = userInfo;
      return Ok(createdKeep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}