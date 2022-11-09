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






  public List<MyKeeps> GetUsersKeeps(string id)
  {
    return _pRepo.GetUsersKeeps(id);
  }



  public List<Vault> GetMyVaults(string id)
  {
    return _pRepo.GetUsersVaults(id);
  }
}