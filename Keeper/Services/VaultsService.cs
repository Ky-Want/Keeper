namespace Keeper.Services;


public class VaultsService
{
  private readonly VaultsRepository _vr;

  public VaultsService(VaultsRepository vr)
  {
    _vr = vr;
  }





  internal Vault GetVaultById(int vaultId, string userId)
  {
    Vault foundVault = _vr.GetVaultById(vaultId);
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



  // delete
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







  // edit
}