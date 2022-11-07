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


  public void DeleteKeep(int id, string userId)
  {
    var keep = GetKeepById(id);
    if (keep.CreatorId != userId)
    {
      throw new Exception("You are not authorized to delete this Keep.");
    }

    _keepsRepo.DeleteKeep(id);
  }







  public Keep EditKeep(Keep keep, Account userId)
  {
    var original = GetKeepById(keep.Id);
    if (original.CreatorId != userId.Id)
    {
      throw new Exception("You are not authorized to change this Keep.");
    }

    original.Name = keep.Name;
    original.Description = keep.Description;
    original.Kept = keep.Kept;

    var updated = _keepsRepo.EditKeep(original);
    return updated;
  }
}
