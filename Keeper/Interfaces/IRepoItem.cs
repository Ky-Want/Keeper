namespace Keeper.Interfaces;


public interface IRepoItem<T>
{
  // 'T' becomes the placeholder for the type we want to return.... interfaces say this is what the data 'looks like'
  T Id { get; set; }
  DateTime CreatedAt { get; set; }
  DateTime UpdatedAt { get; set; }
}