﻿using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;
using Model;

namespace WebService
{
	public class DateService
	{
		public List<DateDTO> GetAll()
		{
			using (var db = new ModelContext())
			{
				List<Date> dates = db.Dates.ToList();
				List<DateDTO> dtos = new List<DateDTO>();

				foreach (var date in dates)
				{
					DateDTO dto = new DateDTO();
					dto.Id = date.Id;
					dto.DateNumber = date.DateNumber;
					dto.CategoryId = date.CategoryId;
					dto.MatchesIds = date.Matches
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public DateDTO GetDate(int id)
		{
			List<DateDTO> dates = this.GetAll().Where(m => m.Id == id).ToList();
			return dates.FirstOrDefault();
		}

		public List<DateDTO> GetDatesByCategory(int categoryId)
		{
			using (var db = new ModelContext())
			{
				List<Date> dates = db.Dates.Where(m => m.CategoryId == categoryId).ToList();
				List<DateDTO> dtos = new List<DateDTO>();

				foreach (var date in dates)
				{
					DateDTO dto = new DateDTO();
					dto.Id = date.Id;
					dto.DateNumber = date.DateNumber;
					dto.CategoryId = date.CategoryId;
					dto.MatchesIds = date.Matches
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos;
			}
		}

		public DateDTO GetDateByCategory(int categoryId, int id)
		{
			using (var db = new ModelContext())
			{
				List<Date> dates = db.Dates.Where(m => m.CategoryId == categoryId && m.Id == id).ToList();
				List<DateDTO> dtos = new List<DateDTO>();

				foreach (var date in dates)
				{
					DateDTO dto = new DateDTO();
					dto.Id = date.Id;
					dto.DateNumber = date.DateNumber;
					dto.CategoryId = date.CategoryId;
					dto.MatchesIds = date.Matches
						.Select(m => m.Id)
						.ToList();
					dtos.Add(dto);
				}
				return dtos.FirstOrDefault();
			}
		}

		public void Create(DateDTO dateDTO)
		{
			using (var db = new ModelContext())
			{
				Date date = db.Dates.Create();
				date.DateNumber = dateDTO.DateNumber;
				date.CategoryId = dateDTO.CategoryId;
				db.Dates.Add(date);
				db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var db = new ModelContext())
			{
				Date date = db.Dates
					.Where(m => m.Id == id)
					.FirstOrDefault();
				db.Entry(date).State = System.Data.EntityState.Deleted;
				db.SaveChanges();
			}
		}

		public void Put(DateDTO dateDTO)
		{
			using (var db = new ModelContext())
			{
				Date existingDate = db.Dates
					.Where(m => m.Id == dateDTO.Id)
					.FirstOrDefault();
				if (existingDate != null)
				{
					existingDate.DateNumber = dateDTO.DateNumber;
					existingDate.CategoryId = dateDTO.CategoryId;
					db.SaveChanges();
				}
			}
		}
	}
}
