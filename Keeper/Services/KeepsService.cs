namespace Keeper.Services;


public class KeepsService
{
  private readonly KeepsRepository _keepsRepo;

  public KeepsService(KeepsRepository keepsRepo)
  {
    _keepsRepo = keepsRepo;
  }





  internal List<Keep> GetKeeps()
  {
    return _keepsRepo.GetKeeps();
  }






  internal Keep CreateKeep(Keep newKeep)
  {
    return _keepsRepo.CreateKeep(newKeep);
  }
}
