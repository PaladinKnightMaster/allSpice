namespace allSpice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _iRepo;

  public IngredientsService(IngredientsRepository iRepo)
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