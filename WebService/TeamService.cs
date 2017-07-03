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
					dto.MatchesIds = team.Matches
						.Select(m => m.Id)
						.ToList();
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
	}
}
