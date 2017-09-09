using System.Collections.Generic;
using System.Web.Http;
using DTO;
using WebService;

namespace WebApiHockey.Http
{
	[RoutePrefix("api/boards")]
	public class BoardsController : ApiController
	{
		private BoardService boardService = new BoardService();

		[Route("")]
		public List<BoardDTO> Get()
		{
			return boardService.GetAll();
		}

		[Route("{id:int}")]
		public BoardDTO Get(int id)
		{
			return boardService.GetBoard(id);
		}

		[Route("~/api/categories/{categoryId:int}/boards")]
		public List<BoardDTO> GetBoardsByCategory(int categoryId)
		{
			return boardService.GetBoardsByCategory(categoryId);
		}
	}
}
