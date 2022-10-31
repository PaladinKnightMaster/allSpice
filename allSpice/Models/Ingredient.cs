namespace allSpice.Models;

public class Ingredient : ICreated, IRepoItem<int>
{
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Name { get; set; }
  public string Quantity { get; set; }
  public int RecipeId { get; set; }
}
