using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/clubs")]
	public class ClubController : ApiController
	{
		private ClubService clubService = new ClubService();

		[Route("")]
		public List<ClubDTO> Get()
		{
			return clubService.GetAll();
		}

		[Route("{id:int}")]
		public ClubDTO Get(int id)
		{
			return clubService.GetClub(id);
		}

		[Route("create")]
		[HttpPost]
		public IHttpActionResult Create(ClubDTO clubDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			clubService.Create(clubDTO);
			return Ok();
		}

		[Route("delete/{id:int}")]
		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			if (id <= 0)
			{
				return BadRequest("Not a valid division id");
			}
			clubService.Delete(id);
			return Ok();
		}

		[Route("put")]
		[HttpPut]
		public IHttpActionResult Put(ClubDTO clubDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not a valid model");
			}
			clubService.Put(clubDTO);
			return Ok();
		}
	}
}
