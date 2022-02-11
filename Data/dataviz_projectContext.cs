using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataVisualizationAPI
{
    public partial class DataViz_ProjectContext : DbContext
    {
        public DataViz_ProjectContext()
        {
        }

        public DataViz_ProjectContext(DbContextOptions<DataViz_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FairMarketRent> Fairmarketrents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=ConnectionStrings:DataVizProject", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.5-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<FairMarketRent>(entity =>
            {
                entity.ToTable("fairmarketrents");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Areaname).HasMaxLength(255);

                entity.Property(e => e.Bedrooms).HasMaxLength(255);

                entity.Property(e => e.Pmsaname)
                    .HasMaxLength(255)
                    .HasColumnName("PMSAname");

                entity.Property(e => e.Pop2017).HasColumnType("int(11)");

                entity.Property(e => e.Rent).HasColumnType("decimal(65,0) unsigned");

                entity.Property(e => e.State).HasMaxLength(255);

                entity.Property(e => e.Year).HasColumnType("year(4)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
