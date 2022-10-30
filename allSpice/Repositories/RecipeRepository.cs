
namespace allSpice.Repositories;

public class RecipeRepository
{
  private readonly IDbConnection _db;
  public RecipeRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
    select r.*, ac.* from recipes r
    join accounts ac on ac.id = r.creatorId
    ;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (Recipe, Profile) =>
    {
      Recipe.Creator = Profile;
      return Recipe;
    }).ToList();
  }

  internal Recipe GetRecipeById(int id)
  {
    string sql = @"
    select r.*, a.* from recipes r
    join accounts a on a.id = r.creatorId
    where r.id = @id
    ;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (r, p) =>
    {
      r.Creator = p;
      return r;
    }, new { id }).FirstOrDefault();
    // TODO does new Object{} do any thing different here?
  }

  internal Recipe PostRecipe(Recipe recipeData)
  {
    string sql = @"
    insert into recipes(creatorId, title, instructions, img, category)
    values(@CreatorId, @Title, @Instructions, @Img, @Category);
    select last_insert_id();";
    recipeData.Id = _db.ExecuteScalar<int>(sql, recipeData);
    return recipeData;
  }

  internal Recipe DeleteRecipe(Recipe recipe)
  {
    var rId = recipe.Id;
    string sql = @"
    delete from recipes r where r.id = @rId limit 1
    ;";
    _db.Execute(sql, new { rId });
    return recipe;
  }

  internal Recipe EditRecipe(Recipe EditedRecipe)
  {
    string sql = @"
    update recipes
    set title = @Title, 
    instructions = @Instructions,
    img = @Img, 
    category = @Category
    where id = @Id
    ;";
    var rowsAffected = _db.Execute(sql, EditedRecipe);
    if (rowsAffected == 0)
    {
      throw new Exception("Update did not go through");
    }
    return EditedRecipe;
  }
}