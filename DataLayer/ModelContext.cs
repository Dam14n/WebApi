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

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Match>()
			   .HasRequired(c => c.LocalTeam)
			   .WithMany(p => p.Matches)
			   .HasForeignKey(c => c.LocalTeamId)
			   .WillCascadeOnDelete(false);
			// Otherwise you might get a "cascade causes cycles" error

			modelBuilder.Entity<Match>()
			   .HasRequired(c => c.EnemyTeam)
			   .WithMany() // No reverse navigation property
			   .HasForeignKey(c => c.EnemyTeamId)
			   .WillCascadeOnDelete(false);
		}
	}
}
