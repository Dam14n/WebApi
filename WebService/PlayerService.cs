using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class PlayerService
	{
		public List<PlayerDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Player> players = db.Players.ToList();
				List<PlayerDTO> dtos = new List<PlayerDTO>();

				foreach (var player in players)
				{
					PlayerDTO dto = new PlayerDTO();
					dto.Id = player.Id;
					dto.Age = player.Age;
					dto.GoalsIds = player.Goals
						.Select(m => m.Id)
						.ToList();
					dto.Name = player.Name;
					dto.TeamId = player.TeamId;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public PlayerDTO GetPlayer(int id)
		{
			List<PlayerDTO> players = this.GetAll().Where(m => m.Id == id).ToList();
			return players.FirstOrDefault();
		}

		public List<PlayerDTO> GetPlayersByTeam(int teamId)
		{
			using (var db = new ModelContext())
			{
				List<Player> players = db.Players.Where(m => m.TeamId == teamId).ToList();
				List<PlayerDTO> dtos = new List<PlayerDTO>();

				foreach (var player in players)
				{
					PlayerDTO dto = new PlayerDTO();
					dto.Id = player.Id;
					dto.Age = player.Age;
					dto.GoalsIds = player.Goals
						.Select(m => m.Id)
						.ToList();
					dto.Name = player.Name;
					dto.TeamId = player.TeamId;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public PlayerDTO GetPlayerByTeam(int teamId, int id)
		{
			using (var db = new ModelContext())
			{
				List<Player> players = db.Players.Where(m => m.TeamId == teamId && m.Id == id).ToList();
				List<PlayerDTO> dtos = new List<PlayerDTO>();

				foreach (var player in players)
				{
					PlayerDTO dto = new PlayerDTO();
					dto.Id = player.Id;
					dto.Age = player.Age;
					dto.GoalsIds = player.Goals
						.Select(m => m.Id)
						.ToList();
					dto.Name = player.Name;
					dto.TeamId = player.TeamId;
					dtos.Add(dto);
				}
				return dtos.FirstOrDefault();
			}
		}

		public void Create(PlayerDTO playerDTO)
		{
			using (var db = new ModelContext())
			{
				Player player = db.Players.Create();
				player.Name = playerDTO.Name;
				player.Age = playerDTO.Age;
				player.TeamId = playerDTO.TeamId;
				db.Players.Add(player);
				db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var db = new ModelContext())
			{
				Player player = db.Players
					.Where(m => m.Id == id)
					.FirstOrDefault();
				db.Entry(player).State = System.Data.Entity.EntityState.Deleted;
				db.SaveChanges();
			}
		}

		public void Put(PlayerDTO playerDTO)
		{
			using (var db = new ModelContext())
			{
				Player existingPlayer = db.Players
					.Where(m => m.Id == playerDTO.Id)
					.FirstOrDefault();
				if (existingPlayer != null)
				{
					existingPlayer.Name = playerDTO.Name;
					existingPlayer.Age = playerDTO.Age;
					existingPlayer.TeamId = playerDTO.TeamId;
					db.SaveChanges();
				}
			}
		}
	}
}
