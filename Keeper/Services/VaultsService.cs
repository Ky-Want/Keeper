namespace Keeper.Services;


public class VaultsService
{
  private readonly VaultsRepository _vr;

  public VaultsService(VaultsRepository vr)
  {
    _vr = vr;
  }





  // get by id







  internal Vault CreateVault(Vault newVault)
  {
    return _vr.CreateVault(newVault);
  }


  // delete







  // edit
}