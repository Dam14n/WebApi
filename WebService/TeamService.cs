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
					dto.Location = team.Location;
					dto.Logo = team.Logo;
					dto.MatchesIds = team.LocalMatches
						.Select(m => m.Id)
						.ToList().Concat(team.AwayMatches
						.Select(m => m.Id)
						.ToList()).ToList();
					;
					dto.Name = team.Name;
					dto.PlayersIds = team.Players
						.Select(m => m.Id)
						.ToList();
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
					dto.Location = team.Location;
					dto.Logo = team.Logo;
					dto.MatchesIds = team.LocalMatches
						.Select(m => m.Id)
						.ToList().Concat(team.AwayMatches
						.Select(m => m.Id)
						.ToList()).ToList();
					dto.Name = team.Name;
					dto.PlayersIds = team.Players
						.Select(m => m.Id)
						.ToList();
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
						.Contains(matchId) || m.LocalMatches.Select(p => p.Id).Contains(matchId)) && m.Id == id)
					.ToList();
				List<TeamDTO> dtos = new List<TeamDTO>();

				foreach (var team in teams)
				{
					TeamDTO dto = new TeamDTO();
					dto.Id = team.Id;
					dto.Location = team.Location;
					dto.Logo = team.Logo;
					dto.MatchesIds = team.LocalMatches
						.Select(m => m.Id)
						.ToList().Concat(team.AwayMatches
						.Select(m => m.Id)
						.ToList()).ToList();
					dto.Name = team.Name;
					dto.PlayersIds = team.Players
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos.FirstOrDefault();
			}
		}
	}
}
