using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class UsersController : ApiController
	{
		private UserService userService = new UserService();

		// GET api/values
		public List<UserDTO> Get()
		{
			return userService.GetAll();
		}

		// GET api/values/5
		public UserDTO Get(int id)
		{
			return userService.GetUser(id);
		}
	}
}
