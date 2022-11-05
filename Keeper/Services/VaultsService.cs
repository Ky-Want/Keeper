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
}