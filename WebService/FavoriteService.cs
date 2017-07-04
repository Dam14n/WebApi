using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class FavoriteService
	{
		public List<FavoriteDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Favorite> favorites = db.Favorites.ToList();
				List<FavoriteDTO> dtos = new List<FavoriteDTO>();

				foreach (var favorite in favorites)
				{
					FavoriteDTO dto = new FavoriteDTO();
					dto.Id = favorite.Id;
					dto.CategoriesIds = favorite.Categories
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public FavoriteDTO GetFavorite(int id)
		{
			List<FavoriteDTO> favorites = this.GetAll().Where(m => m.Id == id).ToList();
			return favorites.FirstOrDefault();
		}
	}
}
