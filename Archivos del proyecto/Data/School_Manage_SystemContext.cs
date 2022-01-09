using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data
{
    public partial class School_Manage_SystemContext : DbContext
    {

        public School_Manage_SystemContext()
        {
        }

        public School_Manage_SystemContext(DbContextOptions<School_Manage_SystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AreasTecnica> AreasTecnicas { get; set; }
        public virtual DbSet<AvisosAdministración> AvisosAdministracións { get; set; }
        public virtual DbSet<AvisosCurso> AvisosCursos { get; set; }
        public virtual DbSet<AvisosMaestro> AvisosMaestros { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<EstudiantesCalificacione> EstudiantesCalificaciones { get; set; }
        public virtual DbSet<Excusa> Excusas { get; set; }
        public virtual DbSet<HistorialAsistencium> HistorialAsistencia { get; set; }
        public virtual DbSet<Maestro> Maestros { get; set; }
        public virtual DbSet<MaestrosAula> MaestrosAulas { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<MateriasMaestro> MateriasMaestros { get; set; }
        public virtual DbSet<ReportesAestudiante> ReportesAestudiantes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Seccione> Secciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
////                optionsBuilder.UseSqlServer("Server=BFLORENTINO\\SQLBRYAN;Database=School_Manage_System;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AreasTecnica>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("PK__AreasTec__2FC141AAEA07F306");

                entity.Property(e => e.IdArea).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AvisosAdministración>(entity =>
            {
                entity.HasKey(e => e.IdAviso)
                    .HasName("PK__AvisosAd__5CBDD9A7B6833335");

                entity.ToTable("AvisosAdministración");

                entity.Property(e => e.IdAviso).ValueGeneratedNever();

                entity.Property(e => e.DetalleAviso)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.DirigidoA)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.VigenciaHasta).HasColumnType("date");
            });

            modelBuilder.Entity<AvisosCurso>(entity =>
            {
                entity.HasKey(e => new { e.IdAviso, e.CodigoSeccion })
                    .HasName("PK__AvisosCu__0C79BB736FB997D8");

                entity.Property(e => e.CodigoSeccion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Seccion");

                entity.HasOne(d => d.CodigoSeccionNavigation)
                    .WithMany(p => p.AvisosCursos)
                    .HasForeignKey(d => d.CodigoSeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AvisosCur__Codig__7E37BEF6");

                entity.HasOne(d => d.IdAvisoNavigation)
                    .WithMany(p => p.AvisosCursos)
                    .HasForeignKey(d => d.IdAviso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AvisosCur__IdAvi__7D439ABD");
            });

            modelBuilder.Entity<AvisosMaestro>(entity =>
            {
                entity.HasKey(e => e.IdAviso)
                    .HasName("PK__AvisosMa__5CBDD9A790551EB7");

                entity.Property(e => e.IdAviso).ValueGeneratedNever();

                entity.Property(e => e.CedulaMaestro)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DetalleAviso)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.VigenciaHasta).HasColumnType("date");

                entity.HasOne(d => d.CedulaMaestroNavigation)
                    .WithMany(p => p.AvisosMaestros)
                    .HasForeignKey(d => d.CedulaMaestro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AvisosMae__Vigen__7A672E12");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Matricula)
                    .HasName("PK__Estudian__0FB9FB4E3BE4E93E");

                entity.HasIndex(e => e.CedulaMadre, "UQ__Estudian__1B098D364B9D68F1")
                    .IsUnique();

                entity.HasIndex(e => e.CedulaPadre, "UQ__Estudian__5F0FD337C99B4D63")
                    .IsUnique();

                entity.Property(e => e.Matricula)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaMadre)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaPadre)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSeccion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Seccion");

                entity.Property(e => e.CorreoElectronico).IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Foto2x2)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreMadre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePadre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoSeccionNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.CodigoSeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estudiant__Codig__02084FDA");
            });

            modelBuilder.Entity<EstudiantesCalificacione>(entity =>
            {
                entity.HasKey(e => e.CodigoCalificacion)
                    .HasName("PK__Estudian__73E7358DA1EB1EBC");

                entity.Property(e => e.CodigoCalificacion)
                    .ValueGeneratedNever()
                    .HasColumnName("Codigo_Calificacion");

                entity.Property(e => e.CodigoMateria)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Materia");

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoMateriaNavigation)
                    .WithMany(p => p.EstudiantesCalificaciones)
                    .HasForeignKey(d => d.CodigoMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estudiant__Codig__693CA210");

                entity.HasOne(d => d.MatriculaNavigation)
                    .WithMany(p => p.EstudiantesCalificaciones)
                    .HasForeignKey(d => d.Matricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estudiant__Matri__68487DD7");
            });

            modelBuilder.Entity<Excusa>(entity =>
            {
                entity.HasKey(e => e.IdExcusa)
                    .HasName("PK__Excusas__24C3B9CC188DD5F3");

                entity.Property(e => e.IdExcusa).ValueGeneratedNever();

                entity.Property(e => e.Detalles)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MatriculaNavigation)
                    .WithMany(p => p.Excusas)
                    .HasForeignKey(d => d.Matricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Excusas__Matricu__74AE54BC");
            });

            modelBuilder.Entity<HistorialAsistencium>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Historia__06370DADCE22F0FC");

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.CodigoMateria)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Materia");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoMateriaNavigation)
                    .WithMany(p => p.HistorialAsistencia)
                    .HasForeignKey(d => d.CodigoMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historial__Codig__6D0D32F4");

                entity.HasOne(d => d.MatriculaNavigation)
                    .WithMany(p => p.HistorialAsistencia)
                    .HasForeignKey(d => d.Matricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historial__Asist__6C190EBB");
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__Maestros__B4ADFE3952BB3895");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Maestros)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK__Maestros__IdArea__5812160E");
            });

            modelBuilder.Entity<MaestrosAula>(entity =>
            {
                entity.HasKey(e => new { e.IdAsignacion, e.CodigoSeccion })
                    .HasName("PK__Maestros__F7E73F2BA7E10335");

                entity.Property(e => e.CodigoSeccion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Seccion");

                entity.HasOne(d => d.CodigoSeccionNavigation)
                    .WithMany(p => p.MaestrosAulas)
                    .HasForeignKey(d => d.CodigoSeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MaestrosA__Codig__5FB337D6");

                entity.HasOne(d => d.IdAsignacionNavigation)
                    .WithMany(p => p.MaestrosAulas)
                    .HasForeignKey(d => d.IdAsignacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MaestrosA__IdAsi__5EBF139D");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.CodigoMateria)
                    .HasName("PK__Materias__0C5ABAA66A589531");

                entity.Property(e => e.CodigoMateria)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Materia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK__Materias__IdArea__5070F446");
            });

            modelBuilder.Entity<MateriasMaestro>(entity =>
            {
                entity.HasKey(e => e.IdAsignacion)
                    .HasName("PK__Materias__A7235DFFB6952936");

                entity.Property(e => e.IdAsignacion).ValueGeneratedNever();

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoMateria)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Materia");

                entity.HasOne(d => d.CedulaNavigation)
                    .WithMany(p => p.MateriasMaestros)
                    .HasForeignKey(d => d.Cedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MateriasM__Codig__5AEE82B9");

                entity.HasOne(d => d.CodigoMateriaNavigation)
                    .WithMany(p => p.MateriasMaestros)
                    .HasForeignKey(d => d.CodigoMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MateriasM__Codig__5BE2A6F2");
            });

            modelBuilder.Entity<ReportesAestudiante>(entity =>
            {
                entity.HasKey(e => e.CodigoReporte)
                    .HasName("PK__Reportes__2760293DA5D55DEF");

                entity.ToTable("ReportesAEstudiantes");

                entity.Property(e => e.CodigoReporte)
                    .ValueGeneratedNever()
                    .HasColumnName("Codigo_Reporte");

                entity.Property(e => e.Causa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaMaestro)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CedulaMaestroNavigation)
                    .WithMany(p => p.ReportesAestudiantes)
                    .HasForeignKey(d => d.CedulaMaestro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReportesA__Cedul__71D1E811");

                entity.HasOne(d => d.MatriculaNavigation)
                    .WithMany(p => p.ReportesAestudiantes)
                    .HasForeignKey(d => d.Matricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReportesA__Fecha__70DDC3D8");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__2A49584CB5BD805E");

                entity.Property(e => e.IdRol).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seccione>(entity =>
            {
                entity.HasKey(e => e.CodigoSeccion)
                    .HasName("PK__Seccione__0C462D44B817172A");

                entity.HasIndex(e => e.Aula, "UQ__Seccione__5D78645BBC5D56E2")
                    .IsUnique();

                entity.Property(e => e.CodigoSeccion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Codigo_Seccion");

                entity.Property(e => e.Nivel)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Seccion)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Secciones)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Secciones__IdAre__4D94879B");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.NombreUsuario)
                    .HasName("PK__Usuarios__6B0F5AE12BF79DDB");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FotoPerfil)
                    .IsUnicode(false)
                    .HasColumnName("fotoPerfil");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__IdRol__6477ECF3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
