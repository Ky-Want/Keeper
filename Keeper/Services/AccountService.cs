namespace Keeper.Services;

public class AccountService
{
  private readonly AccountRepository _repo;
  private readonly ProfilesRepository _pr;

  public AccountService(AccountRepository repo, ProfilesRepository pr)
  {
    _repo = repo;
    _pr = pr;
  }





  // get my vaults
  internal List<Vault> GetMyVaults(string id)
  {
    List<Vault> vaults = _pr.GetUsersVaults(id);
    return vaults;
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




  internal Account GetById(string id)
  {
    var account = _repo.GetById(id);
    if (account == null)
    {
      throw new Exception("That account Id Does Not Exist");
    }
    return account;
  }



  internal Account EditAccount(Account account, Account user)
  {
    var original = GetById(user.Id);

    original.Name = account.Name;
    original.Picture = account.Picture;
    original.coverImg = account.coverImg;

    var updated = _repo.EditAccount(original);
    return updated;
  }
}
