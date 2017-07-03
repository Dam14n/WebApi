using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class MatchService
	{
		public List<MatchDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Match> matchs = db.Matchs.ToList();
				List<MatchDTO> dtos = new List<MatchDTO>();

				foreach (var match in matchs)
				{
					MatchDTO dto = new MatchDTO();
					dto.Id = match.Id;
					dto.CategoryId = match.CategoryId;
					dto.EnemyGoalsIds = match.EnemyGoals
						.Select(m => m.Id)
						.ToList();
					dto.LocalGoalsIds = match.LocalGoals
						.Select(m => m.Id)
						.ToList();
					dto.EnemyTeamId = match.EnemyTeamId ?? 0;
					dto.LocalTeamId = match.LocalTeamId ?? 0;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public MatchDTO GetMatch(int id)
		{
			List<MatchDTO> Matchs = this.GetAll().Where(m => m.Id == id).ToList();
			return Matchs.FirstOrDefault();
		}
	}
}
