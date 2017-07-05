using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	[RoutePrefix("api/favorites")]
	public class FavoritesController : ApiController
	{
		private FavoriteService favoriteService = new FavoriteService();

		[Route("")]
		public List<FavoriteDTO> Get()
		{
			return favoriteService.GetAll();
		}

		[Route("{id:int}")]
		public FavoriteDTO Get(int id)
		{
			return favoriteService.GetFavorite(id);
		}
	}
}
