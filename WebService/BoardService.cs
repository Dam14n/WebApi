using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class BoardService
	{
		public List<BoardDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Board> boards = db.Boards.ToList();
				List<BoardDTO> dtos = new List<BoardDTO>();

				foreach (var board in boards)
				{
					BoardDTO dto = new BoardDTO();
					dto.Id = board.Id;
					dto.PositionsIds = board.Positions
						.Select(m => m.Id)
						.ToList();
					dto.Name = board.Name;
					dto.CategoryId = board.CategoryId;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public BoardDTO GetBoard(int id)
		{
			List<BoardDTO> boards = this.GetAll().Where(m => m.Id == id).ToList();
			return boards.FirstOrDefault();
		}

		public List<BoardDTO> GetBoardsByCategory(int categoryId)
		{
			return this.GetAll().Where(m => m.CategoryId == categoryId).ToList();
		}
	}
}
