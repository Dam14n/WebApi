using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class UserService
	{
		public List<UserDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<User> users = db.Users.ToList();
				List<UserDTO> dtos = new List<UserDTO>();

				foreach (var user in users)
				{
					UserDTO dto = new UserDTO();
					dto.Id = user.Id;
					dto.CategoriesIds = user.Categories
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public UserDTO GetUser(int id)
		{
			List<UserDTO> users = this.GetAll().Where(m => m.Id == id).ToList();
			return users.FirstOrDefault();
		}
	}
}
