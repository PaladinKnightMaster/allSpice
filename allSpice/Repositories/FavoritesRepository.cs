namespace allSpice.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;
  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Favorite PostFavorite(Favorite favData)
  {
    string sql = @"
    insert into favorites
    (accountId, recipeId)
    values
    (@AccountId, @RecipeId);
    select last_insert_id()
    ;";
    favData.Id = _db.ExecuteScalar<int>(sql, favData);
    return favData;
  }
  internal List<FavoritedRecipe> GetFavoritesByAccountId(string Id)
  {
    string sql = @"
    select f.* from favorites f 
    where accountId = @Id;
    ";
    List<FavoritedRecipe> Favs = _db.Query<FavoritedRecipe>(sql, new { Id }).ToList();
    return Favs;
  }

  internal void DeleteFavorite(int id)
  {
    string sql = @"
    delete from favorites f where f.id = @id limit 1
    ;";
    var rows = _db.Execute(sql, new { id });
    if (rows < 1)
    {
      throw new Exception("This didnt work...");
    }


  }

}