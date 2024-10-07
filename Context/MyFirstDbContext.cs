using System;
using GameMovie.Entities;
using Microsoft.SqlServer;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
namespace GameMovie.Context
{
	public class MyFirstDbContext:DbContext
	{
        public MyFirstDbContext(DbContextOptions<MyFirstDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost; database=GameMovieDb; TrustServerCertificate=true;
            uid=sa; pwd=MyPass@word;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<Movie> Movies => Set<Movie>();
    }
}

