namespace allSpice.Services;

public class IngredientService
{
  private readonly IngredientRepository _iRepo;

  public IngredientService(IngredientRepository iRepo)
  {
    _iRepo = iRepo;
  }

  internal Ingredient PostIngredient(Ingredient iData)
  {
    return _iRepo.PostIngredient(iData);
  }
}