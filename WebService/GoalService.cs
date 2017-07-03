using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class GoalService
	{
		public List<GoalDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Goal> goals = db.Goals.ToList();
				List<GoalDTO> dtos = new List<GoalDTO>();

				foreach (var goal in goals)
				{
					GoalDTO dto = new GoalDTO();
					dto.Id = goal.Id;
					dto.MatchId = goal.MatchId;
					dto.PlayerId = goal.PlayerId;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public GoalDTO GetGoal(int id)
		{
			List<GoalDTO> goals = this.GetAll().Where(m => m.Id == id).ToList();
			return goals.FirstOrDefault();
		}
	}
}
