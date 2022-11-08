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


  // create






  // delete
}