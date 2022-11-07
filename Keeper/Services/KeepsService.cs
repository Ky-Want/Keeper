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


  internal Keep GetKeepById(int id)
  {
    var keep = _keepsRepo.GetKeepById(id);
    if (keep == null)
    {
      throw new Exception("That Keep Id Does Not Exist");
    }
    keep.Views++;
    // EditKeep(keep);

    return keep;
  }






  internal Keep CreateKeep(Keep newKeep)
  {
    return _keepsRepo.CreateKeep(newKeep);
  }
}
