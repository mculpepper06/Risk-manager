using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using PortfolioRiskManager.Domain;

namespace PortfolioRiskManager.DataAccess
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class PrmContext : DbContext
    {
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Price> Prices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            var cs = ConfigurationManager.ConnectionStrings["PortfolioRiskManager"];
            optionBuilder.UseSqlServer(cs.ConnectionString);
        }

        public static PrmContext BuildPrmContext()
        {
            var repo = new PrmContext();
            return repo;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.HasKey(p => p.PortfolioId);
                entity.ToTable("Portfolio");

                entity.HasMany(p => p.Positions).WithOne(p => p.PortFolio).HasForeignKey(pos => pos.PortFolioId);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(p => p.PositionId);
                entity.ToTable("Position");

                entity.Ignore(p => p.Weight);
                entity.HasOne(p => p.Security)
                    .WithMany()
                    .HasForeignKey(s => s.SecurityId);
            });

            modelBuilder.Entity<Security>(entity =>
            {
                entity.HasKey(s => s.SecurityId);
                entity.Property(s => s.SecurityId);
                entity.ToTable("Security");

                entity.HasOne(s => s.Industry).WithMany().HasForeignKey(i => i.IndustryId);

                entity.HasOne(s => s.Country).WithMany().HasForeignKey(s => s.CountryId);

                entity.HasMany(s => s.Prices).WithOne(p => p.Security);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.CountryId);
                entity.ToTable("Country");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.HasKey(c => c.IndustryId);
                entity.ToTable("Industry");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(c => c.PriceId);
                entity.ToTable("Price");
            });
        }
    }
}