namespace Keeper.Services;

public class AccountService
{
  private readonly AccountRepository _repo;

  public AccountService(AccountRepository repo)
  {
    _repo = repo;
  }





  // get my vaults
  public List<MyKeeps> GetMyVaults(string id)
  {
    return _repo.GetMyVaults(id);
  }





















  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }


  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }







  internal Account Edit(Account editData, string userEmail)
  {
    Account original = GetProfileByEmail(userEmail);
    original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
    original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
    return _repo.Edit(original);
  }
}
