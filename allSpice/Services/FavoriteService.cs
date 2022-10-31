namespace allSpice.Services;

public class FavoriteService
{
  private readonly FavoriteRepository _fRepo;

  internal List<Favorite> GetFavoritesByAccountId(string Id)
  {
    return _fRepo.GetFavoritesByAccountId(Id);
  }

  internal Favorite PostFavorite(Favorite favData)
  {
    return _fRepo.PostFavorite(favData);
  }

  internal void DeleteFavorite(int Id)
  {
    _fRepo.DeleteFavorite(Id);
  }
}