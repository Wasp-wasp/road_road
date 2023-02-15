using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace road_road.Data.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brigades> Brigades { get; set; }
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<Highways> Highways { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        public virtual DbSet<Objects> Objects { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Streets> Streets { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Technics> Technics { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }
        public virtual DbSet<TypeOfTechnic> TypeOfTechnic { get; set; }
        public virtual DbSet<TypeTask> TypeTask { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("database=ro;data source=localhost;user id=root;password=1243", x => x.ServerVersion("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brigades>(entity =>
            {
                entity.HasKey(e => e.IdBrigade)
                    .HasName("PRIMARY");

                entity.ToTable("brigades");

                entity.Property(e => e.IdBrigade)
                    .HasColumnName("id_brigade")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameOfBrigade)
                    .HasColumnName("name_of_brigade")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Genders>(entity =>
            {
                entity.HasKey(e => e.IdGender)
                    .HasName("PRIMARY");

                entity.ToTable("genders");

                entity.Property(e => e.IdGender)
                    .HasColumnName("id_gender")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameOfGender)
                    .HasColumnName("name_of_gender")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Highways>(entity =>
            {
                entity.HasKey(e => e.IdHighway)
                    .HasName("PRIMARY");

                entity.ToTable("highways");

                entity.Property(e => e.IdHighway)
                    .HasColumnName("id_highway")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameOfHighway)
                    .HasColumnName("name_of_highway")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Materials>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PRIMARY");

                entity.ToTable("materials");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("id_material")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameOfMaterial)
                    .HasColumnName("name_of_material")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Objects>(entity =>
            {
                entity.HasKey(e => e.IdObject)
                    .HasName("PRIMARY");

                entity.ToTable("objects");

                entity.Property(e => e.IdObject)
                    .HasColumnName("id_object")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameOfObject)
                    .HasColumnName("name_of_object")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.HasKey(e => e.IdPlace)
                    .HasName("PRIMARY");

                entity.ToTable("place");

                entity.HasIndex(e => e.IdHighway)
                    .HasName("id_highway_idx");

                entity.HasIndex(e => e.IdStreet)
                    .HasName("id_street_idx");

                entity.HasIndex(e => e.IdTown)
                    .HasName("id_town_idx");

                entity.Property(e => e.IdPlace)
                    .HasColumnName("id_place")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdHighway).HasColumnName("id_highway");

                entity.Property(e => e.IdStreet).HasColumnName("id_street");

                entity.Property(e => e.IdTown).HasColumnName("id_town");

                entity.Property(e => e.PlaceDiscription)
                    .HasColumnName("place_discription")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdHighwayNavigation)
                    .WithMany(p => p.Place)
                    .HasForeignKey(d => d.IdHighway)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_highway");

                entity.HasOne(d => d.IdStreetNavigation)
                    .WithMany(p => p.Place)
                    .HasForeignKey(d => d.IdStreet)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_street");

                entity.HasOne(d => d.IdTownNavigation)
                    .WithMany(p => p.Place)
                    .HasForeignKey(d => d.IdTown)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_town");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasKey(e => e.IdPosition)
                    .HasName("PRIMARY");

                entity.ToTable("positions");

                entity.Property(e => e.IdPosition)
                    .HasColumnName("id_position")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameOfPosition)
                    .HasColumnName("name_of_position")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.IdRole)
                    .HasColumnName("id_role")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameOfRole)
                    .HasColumnName("name_of_role")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Streets>(entity =>
            {
                entity.HasKey(e => e.IdStreet)
                    .HasName("PRIMARY");

                entity.ToTable("streets");

                entity.Property(e => e.IdStreet)
                    .HasColumnName("id_street")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameOfStreet)
                    .HasColumnName("name_of_street")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.IdTask)
                    .HasName("PRIMARY");

                entity.ToTable("tasks");

                entity.HasIndex(e => e.IdBriade)
                    .HasName("id_brigade_task_idx");

                entity.HasIndex(e => e.IdMaterial)
                    .HasName("id_material_idx");

                entity.HasIndex(e => e.IdObject)
                    .HasName("id_object_idx");

                entity.HasIndex(e => e.IdPlace)
                    .HasName("id_place_idx");

                entity.HasIndex(e => e.IdTechnic)
                    .HasName("id_technic_idx");

                entity.HasIndex(e => e.IdTypeTask)
                    .HasName("id_type_task_idx");

                entity.Property(e => e.IdTask)
                    .HasColumnName("id_task")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateTimeBegin)
                    .HasColumnName("date_time_begin")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTimeEnd)
                    .HasColumnName("date_time_end")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdBriade).HasColumnName("id_briade");

                entity.Property(e => e.IdMaterial).HasColumnName("id_material");

                entity.Property(e => e.IdObject).HasColumnName("id_object");

                entity.Property(e => e.IdPlace).HasColumnName("id_place");

                entity.Property(e => e.IdTechnic).HasColumnName("id_technic");

                entity.Property(e => e.IdTypeTask).HasColumnName("id_type_task");

                entity.HasOne(d => d.IdBriadeNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdBriade)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_brigade_task");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_material");

                entity.HasOne(d => d.IdObjectNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdObject)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_object");

                entity.HasOne(d => d.IdPlaceNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdPlace)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_place");

                entity.HasOne(d => d.IdTechnicNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdTechnic)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_technic");

                entity.HasOne(d => d.IdTypeTaskNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdTypeTask)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_type_task");
            });

            modelBuilder.Entity<Technics>(entity =>
            {
                entity.HasKey(e => e.IdTechnic)
                    .HasName("PRIMARY");

                entity.ToTable("technics");

                entity.HasIndex(e => e.IdTypeOfTechnic)
                    .HasName("id_type_of_technic_idx");

                entity.Property(e => e.IdTechnic)
                    .HasColumnName("id_technic")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTypeOfTechnic).HasColumnName("id_type_of_technic");

                entity.Property(e => e.NameOfTechnic)
                    .HasColumnName("name_of_technic")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdTypeOfTechnicNavigation)
                    .WithMany(p => p.Technics)
                    .HasForeignKey(d => d.IdTypeOfTechnic)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_type_of_technic");
            });

            modelBuilder.Entity<Towns>(entity =>
            {
                entity.HasKey(e => e.IdTown)
                    .HasName("PRIMARY");

                entity.ToTable("towns");

                entity.Property(e => e.IdTown)
                    .HasColumnName("id_town")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameOfTown)
                    .HasColumnName("name_of_town")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TypeOfTechnic>(entity =>
            {
                entity.HasKey(e => e.IdTypeOfTechnic)
                    .HasName("PRIMARY");

                entity.ToTable("type_of_technic");

                entity.Property(e => e.IdTypeOfTechnic)
                    .HasColumnName("id_type_of_technic")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameTypeOfTechnic)
                    .HasColumnName("name_type_of_technic")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TypeTask>(entity =>
            {
                entity.HasKey(e => e.IdTypeTask)
                    .HasName("PRIMARY");

                entity.ToTable("type_task");

                entity.Property(e => e.IdTypeTask)
                    .HasColumnName("id_type_task")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameTypeTask)
                    .HasColumnName("name_type_task")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.IdGender)
                    .HasName("id_gender_user_idx");

                entity.HasIndex(e => e.IdRole)
                    .HasName("id_role_idx");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfBers)
                    .HasColumnName("date_of_bers")
                    .HasColumnType("date");

                entity.Property(e => e.EMail)
                    .HasColumnName("e-mail")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdGender).HasColumnName("id_gender");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SecondName)
                    .HasColumnName("second_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdGenderNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdGender)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_gender_user");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_role");
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.HasKey(e => e.IdWorker)
                    .HasName("PRIMARY");

                entity.ToTable("workers");

                entity.HasIndex(e => e.IdBrigade)
                    .HasName("id_brigade_idx");

                entity.HasIndex(e => e.IdGender)
                    .HasName("id_gender_idx");

                entity.HasIndex(e => e.IdPosition)
                    .HasName("id_psition_idx");

                entity.Property(e => e.IdWorker)
                    .HasColumnName("id_worker")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfBers)
                    .HasColumnName("date_of_bers")
                    .HasColumnType("date");

                entity.Property(e => e.EMail)
                    .HasColumnName("e-mail")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdBrigade).HasColumnName("id_brigade");

                entity.Property(e => e.IdGender).HasColumnName("id_gender");

                entity.Property(e => e.IdPosition).HasColumnName("id_position");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SecondName)
                    .HasColumnName("second_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Telephon)
                    .HasColumnName("telephon")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdBrigadeNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.IdBrigade)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_brigade");

                entity.HasOne(d => d.IdGenderNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.IdGender)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_gender");

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_psition");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
