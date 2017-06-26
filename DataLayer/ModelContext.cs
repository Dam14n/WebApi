using System.Data.Entity;
using Model;

namespace DataLayer
{
	public class ModelContext : DbContext
	{
		public DbSet<Division> Divisions { get; set; }
		public DbSet<SubDivision> SubDivisions { get; set; }
		public DbSet<Category> Categorys { get; set; }
		public DbSet<Goal> Goals { get; set; }
		public DbSet<Match> Matchs { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Team> Teams { get; set; }
	}
}
