﻿using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>()
                .HasKey(am => new { am.MovieId, am.ActorId });

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Movie)
                .WithMany(am => am.Actor_Movies)
                .HasForeignKey(am => am.MovieId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Actor)
                .WithMany(am => am.Actor_Movies)
                .HasForeignKey(am => am.ActorId)
                .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(modelBuilder);
        }
    }


}
