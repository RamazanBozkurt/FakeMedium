using FakeMedium.MODELS.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.DATA.Context
{
    public class FakeMediumDbContext : DbContext
    {
        public FakeMediumDbContext(DbContextOptions<FakeMediumDbContext> options) : base(options)
        {
        }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>().HasOne(p => p.Category)
                                          .WithMany(c => c.Contents)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);   // ürün silindiğinde kategori silinmesin
            modelBuilder.Entity<Content>().HasOne(c => c.User)
                                          .WithMany(c => c.Contents)
                                          .HasForeignKey(c => c.UserId)
                                          .OnDelete(DeleteBehavior.NoAction);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
