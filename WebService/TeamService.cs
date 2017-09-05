using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class TeamService
	{
		public List<TeamDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Team> teams = db.Teams.ToList();
				List<TeamDTO> dtos = new List<TeamDTO>();

				foreach (var team in teams)
				{
					TeamDTO dto = new TeamDTO();
					dto.Id = team.Id;
					dto.LocalMatchesIds = team.LocalMatches
						.Select(m => m.Id)
						.ToList();
					dto.AwayMatchesIds = team.AwayMatches
						.Select(m => m.Id)
						.ToList();
					dto.Name = team.Name;
					dto.GoalsIds = team.Goals
						.Select(m => m.Id)
						.ToList();
					dto.PlayersIds = team.Players
						.Select(m => m.Id)
						.ToList();
					dto.LogoId = team.Club != null ? team.Club.LogoId : null;
					dto.ClubId = team.ClubId;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public TeamDTO GetTeam(int id)
		{
			List<TeamDTO> teams = this.GetAll().Where(m => m.Id == id).ToList();
			return teams.FirstOrDefault();
		}

		public List<TeamDTO> GetTeamsByMatch(int matchId)
		{
			using (var db = new ModelContext())
			{
				List<Team> teams = db.Teams
					.Where(m => (m.AwayMatches
						.Select(p => p.Id)
						.Contains(matchId) || m.LocalMatches.Select(p => p.Id).Contains(matchId)))
					.ToList();
				List<TeamDTO> dtos = new List<TeamDTO>();

				foreach (var team in teams)
				{
					TeamDTO dto = new TeamDTO();
					dto.Id = team.Id;
					dto.LocalMatchesIds = team.LocalMatches
						.Select(m => m.Id)
						.ToList();
					dto.AwayMatchesIds = team.AwayMatches
						.Select(m => m.Id)
						.ToList();
					dto.Name = team.Name;
					dto.GoalsIds = team.Goals
						.Select(m => m.Id)
						.ToList();
					dto.PlayersIds = team.Players
						.Select(m => m.Id)
						.ToList();
					dto.LogoId = team.Club != null ? team.Club.LogoId : null;
					dto.ClubId = team.ClubId;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public TeamDTO GetTeamByMatch(int matchId, int id)
		{
			using (var db = new ModelContext())
			{
				List<Team> teams = db.Teams
					.Where(m => (m.AwayMatches
									.Select(p => p.Id)
									.Contains(matchId) ||
								m.LocalMatches
									.Select(p => p.Id)
									.Contains(matchId))
							&& m.Id == id)
					.ToList();
				List<TeamDTO> dtos = new List<TeamDTO>();

				foreach (var team in teams)
				{
					TeamDTO dto = new TeamDTO();
					dto.Id = team.Id;
					dto.LocalMatchesIds = team.LocalMatches
						.Select(m => m.Id)
						.ToList();
					dto.AwayMatchesIds = team.AwayMatches
						.Select(m => m.Id)
						.ToList();
					dto.Name = team.Name;
					dto.GoalsIds = team.Goals
						.Select(m => m.Id)
						.ToList();
					dto.PlayersIds = team.Players
						.Select(m => m.Id)
						.ToList();
					dto.LogoId = team.Club != null ? team.Club.LogoId : null;
					dto.ClubId = team.ClubId;
					dtos.Add(dto);
				}
				return dtos.FirstOrDefault();
			}
		}

		public void Create(TeamDTO teamDTO)
		{
			using (var db = new ModelContext())
			{
				Team team = db.Teams.Create();
				team.Name = teamDTO.Name;
				team.ClubId = teamDTO.ClubId;
				db.Teams.Add(team);
				db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var db = new ModelContext())
			{
				Team team = db.Teams
					.Where(m => m.Id == id)
					.FirstOrDefault();
				db.Entry(team).State = System.Data.EntityState.Deleted;

				/*	foreach (Position position in team.Positions)
					{
						db.Entry(position).State = System.Data.EntityState.Deleted;
					}*/

				db.SaveChanges();
			}
		}

		public void Put(TeamDTO teamDTO)
		{
			using (var db = new ModelContext())
			{
				Team existingTeam = db.Teams
					.Where(m => m.Id == teamDTO.Id)
					.FirstOrDefault();
				if (existingTeam != null)
				{
					existingTeam.Name = teamDTO.Name;
					existingTeam.ClubId = teamDTO.ClubId;
					db.SaveChanges();
				}
			}
		}
	}
}
