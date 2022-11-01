namespace allSpice.Models;


public class Recipe : ICreated, IRepoItem<int>
{
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Title { get; set; }
  public string Instructions { get; set; }
  public string Img { get; set; }
  public string Category { get; set; }
}

// public class FavoritedRecipe : Recipe
// {
//   public int FavoriteId { get; set; }

// }
