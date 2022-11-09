namespace Keeper.Services;


public class ProfileService
{
  private readonly ProfilesRepository _pRepo;
  public ProfileService(ProfilesRepository pRepo)
  {
    _pRepo = pRepo;
  }




  internal Profile GetUserById(string id)
  {
    var profile = _pRepo.GetUserById(id);
    if (profile == null)
    {
      throw new Exception("That user Id Does Not Exist");
    }
    return profile;
  }






  // public List<MyKeep> GetMyKeeps(string creatorId)
  // {
  //   return _pRepo.GetMyKeeps(creatorId);
  // }


  // get a users vaults
}