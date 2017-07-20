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
					dto.TeamId = goal.TeamId;
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

		public List<GoalDTO> GetGoalsByPlayer(int playerId)
		{
			using (var db = new ModelContext())
			{
				List<Goal> goals = db.Goals.Where(m => m.PlayerId == playerId).ToList();
				List<GoalDTO> dtos = new List<GoalDTO>();

				foreach (var goal in goals)
				{
					GoalDTO dto = new GoalDTO();
					dto.Id = goal.Id;
					dto.MatchId = goal.MatchId;
					dto.PlayerId = goal.PlayerId;
					dto.TeamId = goal.TeamId;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public GoalDTO GetGoalByPlayer(int playerId, int id)
		{
			using (var db = new ModelContext())
			{
				List<Goal> goals = db.Goals.Where(m => m.PlayerId == playerId && m.Id == id).ToList();
				List<GoalDTO> dtos = new List<GoalDTO>();

				foreach (var goal in goals)
				{
					GoalDTO dto = new GoalDTO();
					dto.Id = goal.Id;
					dto.MatchId = goal.MatchId;
					dto.PlayerId = goal.PlayerId;
					dto.TeamId = goal.TeamId;
					dtos.Add(dto);
				}
				return dtos.FirstOrDefault();
			}
		}

		public List<GoalDTO> GetGoalsByMatch(int matchId)
		{
			using (var db = new ModelContext())
			{
				List<Goal> goals = db.Goals.Where(m => m.MatchId == matchId).ToList();
				List<GoalDTO> dtos = new List<GoalDTO>();

				foreach (var goal in goals)
				{
					GoalDTO dto = new GoalDTO();
					dto.Id = goal.Id;
					dto.MatchId = goal.MatchId;
					dto.PlayerId = goal.PlayerId;
					dto.TeamId = goal.TeamId;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public GoalDTO GetGoalByMatch(int matchId, int id)
		{
			using (var db = new ModelContext())
			{
				List<Goal> goals = db.Goals.Where(m => m.MatchId == matchId && m.Id == id).ToList();
				List<GoalDTO> dtos = new List<GoalDTO>();

				foreach (var goal in goals)
				{
					GoalDTO dto = new GoalDTO();
					dto.Id = goal.Id;
					dto.MatchId = goal.MatchId;
					dto.PlayerId = goal.PlayerId;
					dto.TeamId = goal.TeamId;
					dtos.Add(dto);
				}
				return dtos.FirstOrDefault();
			}
		}

		public List<GoalDTO> GetGoalsByMatchAndTeam(int matchId, int teamId)
		{
			using (var db = new ModelContext())
			{
				List<Goal> goals = db.Goals.Where(m => m.MatchId == matchId && m.TeamId == teamId).ToList();
				List<GoalDTO> dtos = new List<GoalDTO>();

				foreach (var goal in goals)
				{
					GoalDTO dto = new GoalDTO();
					dto.Id = goal.Id;
					dto.MatchId = goal.MatchId;
					dto.PlayerId = goal.PlayerId;
					dto.TeamId = goal.TeamId;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public List<GoalDTO> GetGoalsByTeam(int teamId)
		{
			using (var db = new ModelContext())
			{
				List<Goal> goals = db.Goals.Where(m => m.TeamId == teamId).ToList();
				List<GoalDTO> dtos = new List<GoalDTO>();

				foreach (var goal in goals)
				{
					GoalDTO dto = new GoalDTO();
					dto.Id = goal.Id;
					dto.MatchId = goal.MatchId;
					dto.PlayerId = goal.PlayerId;
					dto.TeamId = goal.TeamId;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public GoalDTO GetGoalByTeam(int teamId, int id)
		{
			using (var db = new ModelContext())
			{
				List<Goal> goals = db.Goals.Where(m => m.TeamId == teamId && m.Id == id).ToList();
				List<GoalDTO> dtos = new List<GoalDTO>();

				foreach (var goal in goals)
				{
					GoalDTO dto = new GoalDTO();
					dto.Id = goal.Id;
					dto.MatchId = goal.MatchId;
					dto.PlayerId = goal.PlayerId;
					dto.TeamId = goal.TeamId;
					dtos.Add(dto);
				}
				return dtos.FirstOrDefault();
			}
		}

		public void Create(GoalDTO goalDTO)
		{
			using (var db = new ModelContext())
			{
				Goal goal = db.Goals.Create();
				goal.MatchId = goalDTO.MatchId;
				goal.PlayerId = goalDTO.PlayerId;
				goal.TeamId = goalDTO.TeamId;
				db.Goals.Add(goal);
				db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var db = new ModelContext())
			{
				Goal goal = db.Goals
					.Where(m => m.Id == id)
					.FirstOrDefault();
				db.Entry(goal).State = System.Data.EntityState.Deleted;
				db.SaveChanges();
			}
		}

		public void Put(GoalDTO goalDTO)
		{
			using (var db = new ModelContext())
			{
				Goal existingGoal = db.Goals
					.Where(m => m.Id == goalDTO.Id)
					.FirstOrDefault();
				if (existingGoal != null)
				{
					existingGoal.TeamId = goalDTO.TeamId;
					existingGoal.MatchId = goalDTO.MatchId;
					existingGoal.PlayerId = goalDTO.PlayerId;
					db.SaveChanges();
				}
			}
		}
	}
}
