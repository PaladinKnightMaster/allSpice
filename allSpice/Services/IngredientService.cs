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

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    return _iRepo.GetIngredientsByRecipeId(recipeId);
  }

  internal void DeleteIngredient(int Id)
  {
    Ingredient ChosenI = _iRepo.GetIngredientById(Id);
    if (ChosenI == null)
    {
      throw new Exception("There is no Ingredient that matches this Id");
    }
    _iRepo.DeleteIngredient(Id);
  }
}