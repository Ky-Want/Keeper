using Keeper.Interfaces;
namespace Keeper.Models;


public class Keep : ICreated, IRepoItem<int>
{
  public int Id { get; set; }

  public Profile Creator { get; set; }
  public string CreatorId { get; set; }

  public string Img { get; set; }
  public string Description { get; set; }
  public string Name { get; set; }
  public int Views { get; set; }
  public int Kept { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}



public class KeepsInVault : Keep
{
  public int VaultKeepId { get; set; }
}