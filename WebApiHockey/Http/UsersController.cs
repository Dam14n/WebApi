using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/users")]
	public class UsersController : ApiController
	{
		private UserService userService = new UserService();

		[Route("")]
		public List<UserDTO> Get()
		{
			return userService.GetAll();
		}

		[Route("{id:int}")]
		public UserDTO Get(int id)
		{
			return userService.GetUser(id);
		}
	}
}
