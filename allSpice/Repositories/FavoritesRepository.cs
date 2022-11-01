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
  internal List<FavoritedRecipe> GetFavRecipesByAccId(string Id)
  {

    string sql = @"
    SELECT 
      r.*,
      f.id AS favoriteId,
      a.*
    FROM favorites f
      JOIN recipes r ON r.id = f.recipeId
      JOIN accounts a ON r.creatorId = a.id
    WHERE accountId = @Id
    ;";
    return _db.Query<FavoritedRecipe, Profile, FavoritedRecipe>(sql, (FavRec, Profile) =>
    {
      FavRec.Creator = Profile;
      FavRec.CreatorId = Profile.Id;
      return FavRec;
    }, new { Id }).ToList();

  }
  // SELECT
  //   r.*
  //   a.*
  // FROM favorites f
  // NOTE where favorites joins recipes 
  // JOIN recipes r ON r.id = f.recipeId
  // NOTE where account joins recipes
  // JOIN account a ON r.creatorId = a.id
  // NOTE where favorites connects to user account 
  // WHERE accountId = @Id
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