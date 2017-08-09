using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class BoardService
	{
		public void AddPositions()
		{
			using (var db = new ModelContext())
			{
				Board board = db.Boards.Where(m => m.Id == 1).FirstOrDefault();
				List<Team> teams = db.Teams.Include(m => m.AwayMatches).Include(m => m.LocalMatches).ToList();

				foreach (var team in teams)
				{
					Position position = db.Positions.Create();
					//var lazyloadlocalmatches = team.LocalMatches.ToList();
					//var lazyloadawaymatches = team.AwayMatches.ToList();
					position.Team = team;
					team.Positions.Add(position);
					board.Positions.Add(position);
				}

				db.SaveChanges();
			}
		}

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
	}
}
