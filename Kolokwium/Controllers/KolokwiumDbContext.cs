using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers
{
    public class KolokwiumDbContext : DbContext
    {
        public DbSet<Team> Team { get; set; }

        public DbSet<Championship_Team> Champinship_Team { get; set; }

        public DbSet<Player> Player { get; set; }

        public DbSet<Player_Team> Player_Team { get; set; }

        public DbSet<Championship> Championship { get; set; }

        public KolokwiumDbContext()
        {

        }

        public KolokwiumDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Championship_Team>()
                .HasKey(z => new { z.IdTeam, z.IdChampionship });

            modelBuilder.Entity<Player_Team>()
                .HasKey(z => new { z.IdPlayer, z.IdTeam });

        }
    }
}
