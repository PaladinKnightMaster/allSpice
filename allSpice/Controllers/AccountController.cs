namespace allSpice.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly FavoritesService _fs;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoritesService fs)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _fs = fs;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("favorites")]
  [Authorize]
  public async Task<ActionResult<List<FavoritedRecipe>>> GetFavoritesByAccountIdAsync()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<FavoritedRecipe> Favs = _fs.GetFavoritesByAccountId(userInfo.Id);
      return Ok(Favs);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
