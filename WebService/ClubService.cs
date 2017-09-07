using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class ClubService
	{
		public List<ClubDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Club> clubs = db.Clubs.ToList();
				List<ClubDTO> dtos = new List<ClubDTO>();

				foreach (var club in clubs)
				{
					ClubDTO dto = new ClubDTO();
					dto.Id = club.Id;
					dto.Latitude = club.Latitude;
					dto.LogoId = club.LogoId;
					dto.Longitude = club.Longitude;
					dto.Name = club.Name;
					dto.TeamsIds = club.Teams
						.Select(t => t.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public ClubDTO GetClub(int id)
		{
			List<ClubDTO> Clubs = this.GetAll().Where(m => m.Id == id).ToList();
			return Clubs.FirstOrDefault();
		}

		public void Create(ClubDTO clubDTO)
		{
			using (var db = new ModelContext())
			{
				Club club = db.Clubs.Create();
				club.Latitude = clubDTO.Latitude;
				club.LogoId = clubDTO.LogoId;
				club.Longitude = clubDTO.Longitude;
				club.Name = clubDTO.Name;
				db.Clubs.Add(club);
				db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var db = new ModelContext())
			{
				Club Club = db.Clubs
					.Where(m => m.Id == id)
					.FirstOrDefault();
				db.Entry(Club).State = System.Data.Entity.EntityState.Deleted;
				db.SaveChanges();
			}
		}

		public void Put(ClubDTO clubDTO)
		{
			using (var db = new ModelContext())
			{
				Club existingClub = db.Clubs
					.Where(m => m.Id == clubDTO.Id)
					.FirstOrDefault();
				if (existingClub != null)
				{
					existingClub.Latitude = clubDTO.Latitude;
					existingClub.LogoId = clubDTO.LogoId;
					existingClub.Longitude = clubDTO.Longitude;
					existingClub.Name = clubDTO.Name;
					db.SaveChanges();
				}
			}
		}
	}
}
