using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace time_and_attendance_system_api.Models
{
    public partial class tnasystemContext : DbContext
    {
        public tnasystemContext()
        {
        }

        public tnasystemContext(DbContextOptions<tnasystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<InType> InTypes { get; set; }
        public virtual DbSet<OutType> OutTypes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Name=TnaSystemDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendanceRecord>(entity =>
            {
                entity.ToTable("attendance_record");

                entity.HasIndex(e => e.EmployeeId, "employee_id");

                entity.HasIndex(e => e.InTypeId, "in_type_id");

                entity.HasIndex(e => e.OutTypeId, "out_type_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("employee_id");

                entity.Property(e => e.InTypeId)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("in_type_id");

                entity.Property(e => e.OutTypeId)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("out_type_id");

                entity.Property(e => e.Remark)
                    .HasColumnType("tinytext")
                    .HasColumnName("remark")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TimeIn)
                    .HasColumnName("time_in")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TimeOut)
                    .HasColumnName("time_out")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AttendanceRecords)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("attendance_record_ibfk_1");

                entity.HasOne(d => d.InType)
                    .WithMany(p => p.AttendanceRecords)
                    .HasForeignKey(d => d.InTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("attendance_record_ibfk_2");

                entity.HasOne(d => d.OutType)
                    .WithMany(p => p.AttendanceRecords)
                    .HasForeignKey(d => d.OutTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("attendance_record_ibfk_3");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.Id)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.PositionId, "position_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CardId)
                    .HasMaxLength(20)
                    .HasColumnName("card_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .HasColumnName("email")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phone_number")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PositionId)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("position_id");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employee_ibfk_1");
            });

            modelBuilder.Entity<InType>(entity =>
            {
                entity.ToTable("in_type");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<OutType>(entity =>
            {
                entity.ToTable("out_type");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.HasIndex(e => e.DepartmentId, "department_id");

                entity.Property(e => e.Id)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("department_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("position_ibfk_1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasIndex(e => e.Role1, "role")
                    .IsUnique();

                entity.HasIndex(e => e.Role1, "role_2");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(3) unsigned")
                    .HasColumnName("role_id");

                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasMaxLength(35)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.RoleId, "role_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phone_number")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(3) unsigned")
                    .HasColumnName("role_id");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
