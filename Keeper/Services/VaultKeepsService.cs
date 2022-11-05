namespace Keeper.Services;


public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vkRepo;

  public VaultKeepsService(VaultKeepsRepository vkRepo)
  {
    _vkRepo = vkRepo;
  }




  internal VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
  {
    return _vkRepo.CreateVaultKeep(newVaultKeep);
  }







  internal void DeleteVaultKeep(int VaultKeepId, string userId)
  {
    VaultKeep foundKeep = _vkRepo.GetVaultKeepById(VaultKeepId);
    if (foundKeep == null)
    {
      throw new Exception("Unable to find Vault Keep");
    }

    if (foundKeep.AccountId != userId)
    {
      throw new Exception("Unauthorized request made to delete Vault Keep");
    }
  }
}