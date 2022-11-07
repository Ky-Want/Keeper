namespace Keeper.Services;


public class VaultsService
{
  private readonly VaultsRepository _vr;

  public VaultsService(VaultsRepository vr)
  {
    _vr = vr;
  }





  internal Vault GetVaultById(int vaultId)
  {
    Vault foundVault = _vr.GetVaultById(vaultId);
    if (foundVault == null)
    {
      throw new Exception("Vault does not exist.");
    }
    return foundVault;
  }







  internal Vault CreateVault(Vault newVault)
  {
    return _vr.CreateVault(newVault);
  }



  // delete







  // edit
}