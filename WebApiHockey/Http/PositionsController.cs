using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/positions")]
	public class PositionsController : ApiController
	{
		private PositionService positionService = new PositionService();

		[Route("")]
		public List<PositionDTO> Get()
		{
			return positionService.GetAll();
		}

		[Route("{id:int}")]
		public PositionDTO GetPosition(int id)
		{
			return positionService.GetPosition(id);
		}

		[Route("~/api/boards/{boardId:int}/positions")]
		public List<PositionDTO> GetPositionsByBoard(int boardId)
		{
			return positionService.GetPositionsByBoard(boardId);
		}
	}
}
