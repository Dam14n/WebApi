using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Controllers
{
	public class PlayersController : ApiController
	{
		private PlayerService PlayerService = new PlayerService();

		// GET api/values
		public List<PlayerDTO> Get()
		{
			return PlayerService.GetAll();
		}

		// GET api/values/5
		public PlayerDTO Get(int id)
		{
			return PlayerService.GetPlayer(id);
		}
	}
}
