using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeReviewAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeReviewAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AnimeCategory> AnimeCategories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Studio> Studios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeCategory>()
                .HasKey(ac => new{ac.AnimeId,ac.CategoryId});
            modelBuilder.Entity<AnimeCategory>()
                .HasOne(a=>a.Anime)
                .WithMany(ac=>ac.AnimeCategories)
                .HasForeignKey(a=>a.AnimeId);
            modelBuilder.Entity<AnimeCategory>()
                .HasOne(a=>a.Category)
                .WithMany(ac=>ac.AnimeCategories)
                .HasForeignKey(a=>a.CategoryId);
            
        }
    }
}