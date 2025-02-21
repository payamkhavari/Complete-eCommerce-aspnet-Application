using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) 
        { 
            
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>()
                .HasKey(am => new { am.MovieId , am.ActorId });

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Movie)
                .WithMany(am =>am.Actor_Movies)
                .HasForeignKey(am => am.MovieId);

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Actor)
                .WithMany(am => am.Actor_Movies)
                .HasForeignKey(am => am.ActorId);

            base.OnModelCreating(modelBuilder);
        }
    }

    
}
