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
	}
}
