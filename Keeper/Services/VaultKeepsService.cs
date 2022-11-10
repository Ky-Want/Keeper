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



  internal VaultKeep CreateVaultKeep(VaultKeep newVaultKeep, Account userInfo)
  {
    var vault = _vs.GetVaultById(newVaultKeep.VaultId, userInfo.Id);
    if (vault.CreatorId != userInfo.Id)
    {
      throw new Exception("create vaultKeep check");
    }

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