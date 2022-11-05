using Keeper.Interfaces;

namespace Keeper.Models;


public class Vault : ICreated, IRepoItem<int>
{
  public int Id { get; set; }

  public string CreatorId { get; set; }
  public Profile Creator { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}