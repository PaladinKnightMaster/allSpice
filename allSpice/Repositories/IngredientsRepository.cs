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
    throw new NotImplementedException();
  }
}