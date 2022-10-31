namespace allSpice.Repositories;

public class IngredientsRepository
{
  private readonly IDbConnection _db;
  public IngredientsRepository(IDbConnection db)
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

  internal void DeleteIngredient(int Id)
  {
    string sql = @"
    delete from ingredients i where i.id = @Id limit 1
    ;";
    _db.Execute(sql, new { Id });
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int rId)
  {
    string sql = @"
    select i.* from ingredients i
    where recipeId = @rId;
    ";
    return _db.Query<Ingredient>(sql, new { rId }).ToList();

  }

  internal Ingredient GetIngredientById(int Id)
  {
    string sql = @"
    select i.* from ingredients i where i.id = @Id limit 1
    ;";
    Ingredient I = _db.Query<Ingredient>(sql, new { Id }).FirstOrDefault();
    return I;
  }
}