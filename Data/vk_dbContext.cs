using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using hackatonbb.Models;

#nullable disable

namespace hackatonbb.Data
{
    public partial class vk_dbContext : DbContext
    {
        public vk_dbContext(DbContextOptions<vk_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Main> Main { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Main>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Main");

                entity.Property(e => e.CountQuest)
                    .HasColumnName("count_quest")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CurrentQuest)
                    .HasColumnName("current_quest")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Step).HasDefaultValueSql("'0'");

                entity.Property(e => e.StudentId)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("Student_id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Vuz)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("VUZ")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
