using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using DataLayer;
using Model;

namespace Updater
{
	public class UpdaterDates
	{
		public void startUpdate()
		{
			using (var db = new ModelContext())
			{
				List<Category> categories = db.Categorys.ToList();
				foreach (Category category in categories)
				{
					HttpWebRequest request = (HttpWebRequest)WebRequest.Create(category.url);
					HttpWebResponse response = (HttpWebResponse)request.GetResponse();

					if (response.StatusCode == HttpStatusCode.OK)
					{
						Stream receiveStream = response.GetResponseStream();
						StreamReader readStream = null;

						if (response.CharacterSet == null)
						{
							readStream = new StreamReader(receiveStream);
						}
						else
						{
							readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
						}

						string data = readStream.ReadToEnd();

						updateDates(data, category);

						response.Close();
						readStream.Close();
					}
				}
			}
		}

		private void updateDates(string data, Category category)
		{
			using (var db = new ModelContext())
			{
				HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
				doc.LoadHtml(data);

				List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table[@class='st dc fixture']")
							.Descendants("tr")
							.Skip(1)
					//.Where(tr => tr.Elements("td").Count() > 1)
							.Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
							.ToList();
				int dateNumber = 0;
				foreach (List<string> fecha in table)
				{
					if (fecha[0].Contains("Rueda"))
					{
						dateNumber = dateNumber + 1;
					}
					else
					{
						Date date = db.Dates.Where(m => m.DateNumber == dateNumber && m.CategoryId == category.Id).FirstOrDefault();
						if (date == null)
						{
							createDate(db, fecha, category, dateNumber);
						}
						else
						{
							updateDates(db, fecha, date);
						}
					}
				}
			}
		}

		private void updateDates(ModelContext db, List<string> fecha, Date date)
		{
			Team localTeam = getTeamOrCreate(db, fecha[2]);
			Team enemyTeam = getTeamOrCreate(db, fecha[5]);

			DateTime myDate = DateTime.ParseExact(fecha[1], "dd-MM-yyyy",
					System.Globalization.CultureInfo.InvariantCulture);

			Match match = getMatchOrCreate(db, date, localTeam, enemyTeam, myDate);

			if (match.Id == 0)
			{
				match.Played = false;
				int n;
				if (int.TryParse(fecha[3], out n))
				{
					insertGoals(db, match, localTeam, Int32.Parse(fecha[3]));
					match.Played = true;
				}
				int l;
				if (int.TryParse(fecha[4], out l))
				{
					insertGoals(db, match, enemyTeam, Int32.Parse(fecha[4]));
					match.Played = true;
				}

				db.Matchs.Add(match);
			}
			else
			{
				List<Goal> localGoals = db.Goals.Where(m => m.MatchId == match.Id && m.TeamId == localTeam.Id).ToList();
				match.Played = false;
				if (localGoals.Count != match.GetGoalsAgainst(enemyTeam.Id))
				{
					db.Goals.Where(m => m.MatchId == match.Id && m.TeamId == localTeam.Id).ToList().ForEach(goal => { db.Entry(goal).State = System.Data.Entity.EntityState.Deleted; });
					int n;
					if (int.TryParse(fecha[3], out n))
					{
						match.Played = true;
						insertGoals(db, match, localTeam, Int32.Parse(fecha[3]));
					}
				}

				List<Goal> enemyGoals = db.Goals.Where(m => m.MatchId == match.Id && m.TeamId == enemyTeam.Id).ToList();

				if (enemyGoals.Count != match.GetGoalsAgainst(localTeam.Id))
				{
					db.Goals.Where(m => m.MatchId == match.Id && m.TeamId == enemyTeam.Id).ToList().ForEach(goal => { db.Entry(goal).State = System.Data.Entity.EntityState.Deleted; });
					int l;
					if (int.TryParse(fecha[4], out l))
					{
						match.Played = true;
						insertGoals(db, match, enemyTeam, Int32.Parse(fecha[4]));
					}
				}
			}

			db.SaveChanges();
		}

		private void insertGoals(ModelContext db, Match match, Team team, int goals)
		{
			for (int x = 0; x < goals; x++)
			{
				Goal goal = db.Goals.Create();
				goal.Match = match;
				goal.Team = team;
				db.Goals.Add(goal);
			}
		}

		private void createDate(ModelContext db, List<string> fecha, Category category, int dateNumber)
		{
			DateTime myDate = DateTime.ParseExact(fecha[1], "dd-MM-yyyy",
									System.Globalization.CultureInfo.InvariantCulture);
			Date date = db.Dates.Create();
			date.DateNumber = dateNumber;
			date.CategoryId = category.Id;
			//date.DateMatch = myDate;

			Team localTeam = getTeamOrCreate(db, fecha[2]);
			Team enemyTeam = getTeamOrCreate(db, fecha[5]);

			Match match = getMatchOrCreate(db, date, localTeam, enemyTeam, myDate);

			match.Played = false;
			int n;
			if (int.TryParse(fecha[3], out n))
			{
				insertGoals(db, match, localTeam, Int32.Parse(fecha[3]));
				match.Played = true;
			}
			int l;
			if (int.TryParse(fecha[4], out l))
			{
				insertGoals(db, match, enemyTeam, Int32.Parse(fecha[4]));
				match.Played = true;
			}

			db.Matchs.Add(match);
			db.Dates.Add(date);

			db.SaveChanges();
		}

		private Match getMatchOrCreate(ModelContext db, Date date, Team localTeam, Team enemyTeam, DateTime dateMatch)
		{
			Match match = db.Matchs.Where(m => m.DateId == date.Id && m.LocalTeamId == localTeam.Id && m.EnemyTeamId == enemyTeam.Id && m.DateMatch == dateMatch).FirstOrDefault();

			if (match == null)
			{
				match = db.Matchs.Create();
				match.Date = date;
				match.EnemyTeam = enemyTeam;
				match.LocalTeam = localTeam;
				match.DateMatch = dateMatch;
			}

			return match;
		}

		private Team getTeamOrCreate(ModelContext db, string name)
		{
			Team team = db.Teams.Where(m => m.Name == name).FirstOrDefault();
			List<string> divisions = new List<string> { "-A", "-B", "-C", "-D", "-E", "-F" };
			string clubName = name;
			foreach (string division in divisions)
			{
				if (name.Contains(division))
				{
					clubName = name.Substring(0, name.IndexOf(division));
				}
			}

			Club club = getClubOrCreate(db, clubName);

			if (team == null)
			{
				team = db.Teams.Create();
				team.Name = name;
				team.Club = club;
			}
			return team;
		}

		private Club getClubOrCreate(ModelContext db, string clubName)
		{
			Club club = db.Clubs.Where(m => m.Name.Contains(clubName)).FirstOrDefault();
			if (club == null)
			{
				club = db.Clubs.Create();
				club.Name = clubName;

				db.Clubs.Add(club);
			}
			return club;
		}
	}
}
