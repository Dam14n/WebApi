﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataLayer;
using Model;

namespace Updater
{
	public class UpdaterPositions
	{
		public void startUpdate()
		{
			using (var db = new ModelContext())
			{
				foreach (Category category in db.Categorys.ToList())
				{
					Board board = getBoardOrCreate(db, category);

					DateTime today = DateTime.Today;

					List<Team> teams = db.Teams
						.Include(m => m.AwayMatches)
						.Include(m => m.LocalMatches)
						.Where(m => m.AwayMatches
							.Where(y => y.Date.CategoryId == category.Id && y.DateMatch <= today)
							.Select(y => y.EnemyTeamId)
							.Contains(m.Id))
						.Where(m => m.LocalMatches
							.Where(y => y.Date.CategoryId == category.Id && y.DateMatch <= today)
							.Select(y => y.LocalTeamId)
							.Contains(m.Id))
						.ToList();

					if (board.Id == 0)
					{
						createPositions(db, board, teams);
					}
					else
					{
						updatePositions(db, board, teams);
					}

					orderPositions(db, board);
					if (board.Id == 0)
					{
						db.Boards.Add(board);
					}
				}
				db.SaveChanges();
			}
		}

		private void updatePositions(ModelContext db, Board board, List<Team> teams)
		{
			foreach (var position in board.Positions)
			{
				db.Entry(position).State = EntityState.Modified;
			}
		}

		private void createPositions(ModelContext db, Board board, List<Team> teams)
		{
			foreach (var team in teams)
			{
				Position position = db.Positions.Create();
				position.Team = team;
				team.Positions.Add(position);
				board.Positions.Add(position);
			}
		}

		private Board getBoardOrCreate(ModelContext db, Category category)
		{
			Board board = db.Boards.Where(m => m.CategoryId == category.Id).FirstOrDefault();
			DateTime startDate = db.Matchs
				.Where(m => db.Dates.Any(n => (n.CategoryId == category.Id) && (n.Id == m.DateId)))
				.Select(m => m.DateMatch)
				.Min();
			DateTime endDate = db.Matchs
				.Where(m => db.Dates.Any(n => (n.CategoryId == category.Id) && (n.Id == m.DateId)))
				.Select(m => m.DateMatch)
				.Max();
			if (board == null)
			{
				board = db.Boards.Create();
				board.Category = category;
				board.Name = category.Name;
				board.startDate = startDate;
				board.endDate = endDate;
			}
			return board;
		}

		public void orderPositions(ModelContext db, Board board)
		{
			List<Position> orderedPositions = board.Positions.Where(m => m.BoardId == board.Id).OrderByDescending(m => m.Points).ThenByDescending(m => m.DifferenceGoals).ToList();

			foreach (Position position in orderedPositions)
			{
				position.Rank = orderedPositions.IndexOf(position) + 1;
			}
		}
	}
}
