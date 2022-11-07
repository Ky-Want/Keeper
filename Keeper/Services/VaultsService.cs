namespace Keeper.Services;


public class VaultsService
{
  private readonly VaultsRepository _vr;
  private readonly VaultKeepsRepository _vkRepo;

  public VaultsService(VaultsRepository vr, VaultKeepsRepository vkRepo)
  {
    _vr = vr;
    _vkRepo = vkRepo;
  }





  // get by id







  internal Vault CreateVault(Vault newVault)
  {
    return _vr.CreateVault(newVault);
  }


  // delete







  // edit
}