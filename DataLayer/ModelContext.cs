using System.Data.Entity;
using Model;

namespace DataLayer
{
	public class ModelContext : DbContext
	{
		public ModelContext()
			: base("name=PasionHockey")
		{
		}

		public DbSet<Division> Divisions { get; set; }
		public DbSet<SubDivision> SubDivisions { get; set; }
		public DbSet<Category> Categorys { get; set; }
		public DbSet<Goal> Goals { get; set; }
		public DbSet<Match> Matchs { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Favorite> Favorites { get; set; }
		public DbSet<Date> Dates { get; set; }
		public DbSet<Logo> Logos { get; set; }
		public DbSet<Club> Clubs { get; set; }
		public DbSet<Board> Boards { get; set; }
		public DbSet<Position> Positions { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Match>()
			   .HasRequired<Team>(c => c.LocalTeam)
			   .WithMany(p => p.LocalMatches)
			   .HasForeignKey(c => c.LocalTeamId)
			   .WillCascadeOnDelete(false);
			// Otherwise you might get a "cascade causes cycles" error

			modelBuilder.Entity<Match>()
			   .HasRequired<Team>(c => c.EnemyTeam)
			   .WithMany(p => p.AwayMatches) // No reverse navigation property
			   .HasForeignKey(c => c.EnemyTeamId)
			   .WillCascadeOnDelete(false);

			modelBuilder.Entity<Goal>()
				.HasRequired(c => c.Team)
				.WithMany(p => p.Goals)
				.HasForeignKey(c => c.TeamId)
				.WillCascadeOnDelete(false);
		}
	}
}
