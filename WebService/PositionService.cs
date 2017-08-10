using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class PositionService
	{
		public List<PositionDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Position> positions = db.Positions.Include(m => m.Team.AwayMatches).Include(m => m.Team.LocalMatches).OrderBy(m => m.Rank).ToList();
				List<PositionDTO> dtos = new List<PositionDTO>();

				foreach (var position in positions)
				{
					PositionDTO dto = new PositionDTO();
					dto.Id = position.Id;
					dto.AgainstGoals = position.AgainstGoals;
					dto.BoardId = position.BoardId;
					dto.DifferenceGoals = position.DifferenceGoals;
					dto.FavorGoals = position.FavorGoals;
					dto.LoseMatches = position.LoseMatches;
					dto.PlayedMatches = position.PlayedMatches;
					dto.Points = position.Points;
					dto.TeamId = position.TeamId;
					dto.TieMatches = position.TieMatches;
					dto.WinMatches = position.WinMatches;
					dto.Rank = position.Rank;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public PositionDTO GetPosition(int id)
		{
			List<PositionDTO> positions = this.GetAll().Where(m => m.Id == id).ToList();
			return positions.FirstOrDefault();
		}

		public List<PositionDTO> GetPositionsByBoard(int boardId)
		{
			return this.GetAll().Where(m => m.BoardId == boardId).ToList();
		}
	}
}
