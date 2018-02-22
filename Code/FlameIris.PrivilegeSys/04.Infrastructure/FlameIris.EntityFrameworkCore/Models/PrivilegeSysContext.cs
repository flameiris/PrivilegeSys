using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlameIris.EntityFrameworkCore.Models
{
    public partial class PrivilegeSysContext : DbContext
    {
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<ManagerRoles> ManagerRoles { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<Privileges> Privileges { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.;User ID=sa;pwd=123456;Initial Catalog=PrivilegeSys;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.Property(e => e.DeptType).HasDefaultValueSql("((1))");

                entity.Property(e => e.Layer).HasDefaultValueSql("((1))");

                entity.Property(e => e.ParentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ManagerRoles>(entity =>
            {
                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ManagerRoles)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManagerRoles_Managers");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ManagerRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManagerRoles_Roles");
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.Property(e => e.NickName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Managers_Departments");
            });

            modelBuilder.Entity<Modules>(entity =>
            {
                entity.Property(e => e.Layer).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModuleType).HasDefaultValueSql("((1))");

                entity.Property(e => e.ParentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Remark).HasMaxLength(300);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
