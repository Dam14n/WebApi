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
					dto.DateId = match.DateId;

					dto.EnemyTeamId = match.EnemyTeamId ?? 0;
					dto.EnemyTeamName = match.EnemyTeam.Name;
					dto.EnemyTeamLogo = db.Logos
						.Where(l => l.Id == match.EnemyTeam.Club.LogoId)
						.Select(p => new LogoDTO { Id = p.Id, Height = p.Height, Image = p.Image, Name = p.Name, Size = p.Size, Type = p.Type, Width = p.Width })
						.FirstOrDefault();

					dto.LocalTeamId = match.LocalTeamId ?? 0;
					dto.LocalTeamName = match.LocalTeam.Name;
					dto.LocalTeamLogo = db.Logos
						.Where(l => l.Id == match.LocalTeam.Club.LogoId)
						.Select(p => new LogoDTO { Id = p.Id, Height = p.Height, Image = p.Image, Name = p.Name, Size = p.Size, Type = p.Type, Width = p.Width })
						.FirstOrDefault();

					dto.EnemyGoalsIds = match.EnemyTeam.Goals
						.Where(m => m.MatchId == match.Id && m.TeamId == match.EnemyTeamId)
						.Select(m => m.Id)
						.ToList();
					dto.LocalGoalsIds = match.LocalTeam.Goals
						.Where(m => m.MatchId == match.Id && m.TeamId == match.LocalTeamId)
						.Select(m => m.Id)
						.ToList();
					dto.Played = match.Played;
					dto.DateMatch = match.DateMatch;
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

		public List<MatchDTO> GetMatchesByDate(int dateId)
		{
			using (var db = new ModelContext())
			{
				List<Match> matchs = db.Matchs.Where(m => m.DateId == dateId).ToList();
				List<MatchDTO> dtos = new List<MatchDTO>();

				foreach (var match in matchs)
				{
					MatchDTO dto = new MatchDTO();
					dto.Id = match.Id;
					dto.DateId = match.DateId;

					dto.EnemyTeamId = match.EnemyTeamId ?? 0;
					dto.EnemyTeamName = match.EnemyTeam.Name;
					dto.EnemyTeamLogo = db.Logos
						.Where(l => l.Id == match.EnemyTeam.Club.LogoId)
						.Select(p => new LogoDTO { Id = p.Id, Height = p.Height, Image = p.Image, Name = p.Name, Size = p.Size, Type = p.Type, Width = p.Width })
						.FirstOrDefault();

					dto.LocalTeamId = match.LocalTeamId ?? 0;
					dto.LocalTeamName = match.LocalTeam.Name;
					dto.LocalTeamLogo = db.Logos
						.Where(l => l.Id == match.LocalTeam.Club.LogoId)
						.Select(p => new LogoDTO { Id = p.Id, Height = p.Height, Image = p.Image, Name = p.Name, Size = p.Size, Type = p.Type, Width = p.Width })
						.FirstOrDefault();

					dto.EnemyGoalsIds = match.EnemyTeam.Goals
						.Where(m => m.MatchId == match.Id && m.TeamId == match.EnemyTeamId)
						.Select(m => m.Id)
						.ToList();
					dto.LocalGoalsIds = match.LocalTeam.Goals
						.Where(m => m.MatchId == match.Id && m.TeamId == match.LocalTeamId)
						.Select(m => m.Id)
						.ToList();
					dto.Played = match.Played;
					dto.DateMatch = match.DateMatch;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public MatchDTO GetMatchByDate(int dateId, int id)
		{
			using (var db = new ModelContext())
			{
				List<Match> matchs = db.Matchs.Where(m => m.DateId == dateId && m.Id == id).ToList();
				List<MatchDTO> dtos = new List<MatchDTO>();

				foreach (var match in matchs)
				{
					MatchDTO dto = new MatchDTO();
					dto.Id = match.Id;
					dto.DateId = match.DateId;

					dto.EnemyTeamId = match.EnemyTeamId ?? 0;
					dto.EnemyTeamName = match.EnemyTeam.Name;
					dto.EnemyTeamLogo = db.Logos
						.Where(l => l.Id == match.EnemyTeam.Club.LogoId)
						.Select(p => new LogoDTO { Id = p.Id, Height = p.Height, Image = p.Image, Name = p.Name, Size = p.Size, Type = p.Type, Width = p.Width })
						.FirstOrDefault();

					dto.LocalTeamId = match.LocalTeamId ?? 0;
					dto.LocalTeamName = match.LocalTeam.Name;
					dto.LocalTeamLogo = db.Logos
						.Where(l => l.Id == match.LocalTeam.Club.LogoId)
						.Select(p => new LogoDTO { Id = p.Id, Height = p.Height, Image = p.Image, Name = p.Name, Size = p.Size, Type = p.Type, Width = p.Width })
						.FirstOrDefault();

					dto.EnemyGoalsIds = match.EnemyTeam.Goals
						.Where(m => m.MatchId == match.Id && m.TeamId == match.EnemyTeamId)
						.Select(m => m.Id)
						.ToList();
					dto.LocalGoalsIds = match.LocalTeam.Goals
						.Where(m => m.MatchId == match.Id && m.TeamId == match.LocalTeamId)
						.Select(m => m.Id)
						.ToList();
					dto.Played = match.Played;
					dto.DateMatch = match.DateMatch;
					dtos.Add(dto);
				}
				return dtos.FirstOrDefault();
			}
		}

		public void Create(MatchDTO matchDTO)
		{
			using (var db = new ModelContext())
			{
				Match match = db.Matchs.Create();
				match.DateId = matchDTO.DateId;
				match.EnemyTeamId = matchDTO.EnemyTeamId;
				match.LocalTeamId = matchDTO.LocalTeamId;
				db.Matchs.Add(match);
				db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var db = new ModelContext())
			{
				Match match = db.Matchs
					.Where(m => m.Id == id)
					.FirstOrDefault();
				db.Entry(match).State = System.Data.Entity.EntityState.Deleted;
				db.SaveChanges();
			}
		}

		public void Put(MatchDTO matchDTO)
		{
			using (var db = new ModelContext())
			{
				Match existingMatch = db.Matchs
					.Where(m => m.Id == matchDTO.Id)
					.FirstOrDefault();
				if (existingMatch != null)
				{
					existingMatch.DateId = matchDTO.DateId;
					existingMatch.EnemyTeamId = matchDTO.EnemyTeamId;
					existingMatch.LocalTeamId = matchDTO.LocalTeamId;
					db.SaveChanges();
				}
			}
		}
	}
}
