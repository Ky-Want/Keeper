namespace Keeper.Services;


public class VaultsService
{
  private readonly VaultsRepository _vr;
  private readonly VaultKeepsRepository _vkr;

  public VaultsService(VaultsRepository vr, VaultKeepsRepository vkr)
  {
    _vr = vr;
    _vkr = vkr;
  }






  internal List<KeepsInVault> GetVaultKeepsByVaultId(int id, string userId)
  {
    // vaults = vaults.FindAll(v => v.IsPrivate == false || v.CreatorId != id);
    GetVaultById(id, userId);
    List<KeepsInVault> vaultKeeps = _vkr.GetVaultKeepsByVaultId(id);

    return vaultKeeps;
  }














  internal Vault GetVaultById(int id, string userId)
  {
    Vault foundVault = _vr.GetVaultById(id);
    if (foundVault == null)
    {
      throw new Exception("Vault does not exist.");
    }
    if (foundVault.IsPrivate == true && foundVault.CreatorId != userId)
    {
      throw new Exception("You are not authorized to view that vault.");
    }
    return foundVault;
  }




  internal Vault CreateVault(Vault newVault)
  {
    return _vr.CreateVault(newVault);
  }


  public string DeleteVault(int vaultId, string userId)
  {
    var vault = GetVaultById(vaultId, userId);
    if (vault.CreatorId != userId)
    {
      throw new Exception("You are not authorized to delete this vault.");
    }

    var deleted = _vr.DeleteVault(vaultId);
    if (!deleted)
    {
      throw new Exception("Delete vault failed");
    }
    return "Successfully deleted vault";
  }




  internal Vault EditVault(Vault vault, Account userInfo)
  {
    var original = GetVaultById(vault.Id, userInfo.Id);
    if (original.CreatorId != userInfo.Id)
    {
      throw new Exception("You are not authorized to edit this vault.");
    }

    original.Name = vault.Name;
    original.IsPrivate = vault.IsPrivate;
    original.Img = vault.Img;
    original.Description = vault.Description;

    var updated = _vr.EditVault(original);
    return updated;
  }

}