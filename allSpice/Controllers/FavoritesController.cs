namespace allSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
  private readonly FavoritesService _fs;
  private readonly Auth0Provider _auth0provider;
  public FavoritesController(FavoritesService fs, Auth0Provider auth0provider)
  {
    _fs = fs;
    _auth0provider = auth0provider;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Favorite>> Create([FromBody] Favorite FavData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      FavData.AccountId = userInfo.Id;
      Favorite Fav = _fs.PostFavorite(FavData);
      return Ok(Fav);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{Id}")]
  [Authorize]
  public async Task<ActionResult<string>> Delete(int Id)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _fs.DeleteFavorite(Id);
      return Ok("Delete Successful");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
