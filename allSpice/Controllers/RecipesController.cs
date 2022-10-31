namespace allSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly RecipeService _rs;
  private readonly IngredientService _is;

  public RecipesController(Auth0Provider auth0provider, RecipeService rs, IngredientService @is)
  {
    _auth0provider = auth0provider;
    _rs = rs;
    _is = @is;
  }

  [HttpGet]
  public ActionResult<Recipe> GetAllRecipes()
  {
    try
    {
      List<Recipe> Recipes = _rs.GetAllRecipes();
      return Ok(Recipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{recipeId}")]
  public ActionResult<Recipe> GetRecipeById(int recipeId)
  {
    try
    {
      Recipe recipe = _rs.GetRecipeById(recipeId);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> PostRecipe([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe NewRecipe = _rs.PostRecipe(recipeData);
      return Ok(NewRecipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<Recipe>> DeleteRecipe(int recipeId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      var CreatorId = userInfo.Id;
      Recipe DeletedRecipe = _rs.DeleteRecipe(recipeId, CreatorId);
      return Ok(DeletedRecipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<Recipe>> EditRecipe([FromBody] Recipe recipeData, int recipeId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe EditedRecipe = _rs.EditRecipe(recipeData, recipeId);
      return Ok(EditedRecipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{recipeId}/ingredients")]
  public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
  {
    try
    {
      List<Ingredient> iList = _is.GetIngredientsByRecipeId(recipeId);
      return Ok(iList);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}