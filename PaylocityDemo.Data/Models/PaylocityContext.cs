using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PaylocityDemo.Domain.Models
{
    public partial class PaylocityContext : DbContext
    {
        public PaylocityContext()
        {
        }

        public PaylocityContext(DbContextOptions<PaylocityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Benefit> Benefits { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=localhost;Database=Paylocity;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Benefit>(entity =>
            //{
            //    entity.ToTable("benefit");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.BenefitType).HasColumnName("benefit_type");

            //    entity.Property(e => e.Cost)
            //        .HasColumnName("cost")
            //        .HasColumnType("smallmoney");

            //    entity.Property(e => e.Description)
            //        .HasColumnName("description")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.ToTable("dependent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BenefitDiscount)
                    .HasColumnName("benefit_discount")
                    .HasColumnType("decimal(4, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BenefitId).HasColumnName("benefit_id");

                entity.Property(e => e.DependentName)
                    .HasColumnName("dependent_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Dependents)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_dependent_employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BenefitDiscount)
                    .HasColumnName("benefit_discount")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.BenefitId).HasColumnName("benefit_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("smallmoney");

                entity.HasOne(d => d.Benefit)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.BenefitId)
                    .HasConstraintName("FK_employee_benefit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
