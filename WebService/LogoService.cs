using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class LogoService
	{
		public List<LogoDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Logo> logos = db.Logos.ToList();
				List<LogoDTO> dtos = new List<LogoDTO>();

				foreach (var logo in logos)
				{
					LogoDTO dto = new LogoDTO();
					dto.Id = logo.Id;
					dto.Image = logo.Image;
					dto.Height = logo.Height;
					dto.Width = logo.Width;
					dto.Name = logo.Name;
					dto.Size = logo.Size;
					dto.Type = logo.Type;
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public LogoDTO GetLogo(int id)
		{
			List<LogoDTO> logos = this.GetAll().Where(l => l.Id == id).ToList();
			return logos.FirstOrDefault();
		}

		public void Create(LogoDTO logoDTO)
		{
			using (var db = new ModelContext())
			{
				Logo logo = db.Logos.Create();
				logo.Image = logoDTO.Image;
				logo.Height = logoDTO.Height;
				logo.Width = logoDTO.Width;
				logo.Name = logoDTO.Name;
				logo.Size = logoDTO.Size;
				logo.Type = logoDTO.Type;
				db.Logos.Add(logo);
				db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var db = new ModelContext())
			{
				Logo Logo = db.Logos
					.Where(m => m.Id == id)
					.FirstOrDefault();
				db.Entry(Logo).State = System.Data.EntityState.Deleted;
				db.SaveChanges();
			}
		}

		public void Put(LogoDTO logoDTO)
		{
			using (var db = new ModelContext())
			{
				Logo existingLogo = db.Logos
					.Where(m => m.Id == logoDTO.Id)
					.FirstOrDefault();
				if (existingLogo != null)
				{
					existingLogo.Image = logoDTO.Image;
					existingLogo.Height = logoDTO.Height;
					existingLogo.Width = logoDTO.Width;
					existingLogo.Name = logoDTO.Name;
					existingLogo.Size = logoDTO.Size;
					existingLogo.Type = logoDTO.Type;
					db.SaveChanges();
				}
			}
		}
	}
}
