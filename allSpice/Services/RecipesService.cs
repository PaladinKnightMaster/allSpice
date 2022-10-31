namespace allSpice.Services;

public class RecipesService
{
  private readonly RecipesRepository _rRepo;
  public RecipesService(RecipesRepository rRepo)
  {
    _rRepo = rRepo;
  }


  internal List<Recipe> GetAllRecipes()
  {
    return _rRepo.GetAllRecipes();
  }

  internal Recipe GetRecipeById(int id)
  {
    Recipe selectedRecipe = _rRepo.GetRecipeById(id);
    // TODO Why not !selectedRecipe
    if (selectedRecipe == null)
    {
      throw new Exception("this recipe does not exist");
    }
    return selectedRecipe;
  }

  internal Recipe PostRecipe(Recipe recipeData)
  {
    return _rRepo.PostRecipe(recipeData);
  }

  internal Recipe DeleteRecipe(int id, string cId)
  {
    Recipe selectedRecipe = _rRepo.GetRecipeById(id);
    if (selectedRecipe.CreatorId != cId)
    {
      throw new Exception("this recipe is not yours to delete");
    }
    return _rRepo.DeleteRecipe(selectedRecipe);
  }

  internal Recipe EditRecipe(Recipe recipeData, int id)
  {
    Recipe selectedRecipe = GetRecipeById(id);
    if (selectedRecipe.CreatorId != recipeData.CreatorId)
    {
      throw new Exception("this recipe is not yours to edit");
    }
    selectedRecipe.Category = recipeData.Category ?? selectedRecipe.Category;
    selectedRecipe.Img = recipeData.Img ?? selectedRecipe.Img;
    selectedRecipe.Instructions = recipeData.Instructions ?? selectedRecipe.Instructions;
    selectedRecipe.Title = recipeData.Title ?? selectedRecipe.Title;

    return _rRepo.EditRecipe(selectedRecipe);
  }
}