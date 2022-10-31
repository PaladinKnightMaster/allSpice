namespace allSpice.Repositories;

public class IngredientRepository
{
  private readonly IDbConnection _db;
  public IngredientRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Ingredient PostIngredient(Ingredient iData)
  {
    string sql = @"
    insert into 
    ingredients(name, quantity, recipeId)
    values(@Name, @Quantity, @RecipeId);
    select last_insert_id();
    ";
    iData.Id = _db.ExecuteScalar<int>(sql, iData);
    return iData;


  }

  internal List<Ingredient> GetIngredientByRecipeId(int rId)
  {
    string sql = @"
    select i.* from ingredients i
    where recipeId = @rId;
    ";
    return _db.Query<Ingredient>(sql, new { rId }).ToList();

  }
}