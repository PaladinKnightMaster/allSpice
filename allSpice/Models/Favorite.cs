namespace allSpice.Models;

public class Favorite : IRepoItem<int>
{
  public string AccountId { get; set; }
  public Profile Creator { get; set; }
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public int RecipeId { get; set; }
}
