namespace Keeper.Services;


public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vkRepo;
  private readonly VaultKeepsRepository _vaultRepo;
  private readonly VaultsService _vs;

  public VaultKeepsService(VaultKeepsRepository vkRepo, VaultKeepsRepository vaultRepo, VaultsService vs)
  {
    _vkRepo = vkRepo;
    _vaultRepo = vaultRepo;
    _vs = vs;
  }



  internal VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
  {

    // FIXME check if the vault creator 
    // is the currently logged in user
    // to do this you will need to get 
    // the vault...



    return _vkRepo.CreateVaultKeep(newVaultKeep);
  }











  internal void DeleteVaultKeep(int id, string userId)
  {
    VaultKeep foundVK = _vkRepo.GetById(id);
    if (foundVK == null)
    {
      throw new Exception("Unable to find vault keep");
    }
    if (foundVK.CreatorId != userId)
    {
      throw new Exception("Unauthorized to remove vault keep");
    }
    _vkRepo.DeleteVaultKeep(foundVK);
  }
}