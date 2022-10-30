namespace allSpice.Interfaces;

public interface IRepoItem<T>
{
  T Id { get; set; }
  DateTime CreatedAt { get; set; }
  DateTime UpdatedAt { get; set; }
}
