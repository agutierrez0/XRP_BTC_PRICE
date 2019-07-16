using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestLibrary.Data.Models
{
    public partial class SystemmonitorContext : DbContext
    {
        public SystemmonitorContext()
        {
        }

        public SystemmonitorContext(DbContextOptions<SystemmonitorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BuildIdversionHistory> BuildIdversionHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<BuildIdversionHistory>(entity =>
            {
                entity.ToTable("BuildIDVersionHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BuildId).HasColumnName("BuildID");

                entity.Property(e => e.Environment)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}