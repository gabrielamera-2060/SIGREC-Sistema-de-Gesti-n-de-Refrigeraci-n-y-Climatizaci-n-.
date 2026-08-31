using System;
using Microsoft.EntityFrameworkCore;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Datos
{
    public class SigrecDbContext : DbContext
    {
        public SigrecDbContext() { }

        public SigrecDbContext(DbContextOptions<SigrecDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Repuesto> Repuestos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<AireAcondicionado> AiresAcondicionados { get; set; }
        public DbSet<CamaraFrigorifica> CamarasFrigorificas { get; set; }
        public DbSet<Refrigerador> Refrigeradores { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<ConsultaIA> ConsultasIA { get; set; }
        public DbSet<HistorialCorreo> HistorialCorreos { get; set; }
        public DbSet<HistorialWhatsApp> HistorialWhatsApp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string? password =
                    Environment.GetEnvironmentVariable("SIGREC_DB_PASSWORD");

                if (string.IsNullOrWhiteSpace(password))
                {
                    password = Environment.GetEnvironmentVariable(
                        "SIGREC_DB_PASSWORD",
                        EnvironmentVariableTarget.User);
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception(
                        "No se encontró la variable de entorno SIGREC_DB_PASSWORD.");
                }

                string conexion =
                    "Server=DESKTOP-18VAGMV\\SQLEXPRESS;" +
                    "Database=PROYECTO_SIGREC;" +
                    "User Id=sa;" +
                    $"Password={password};" +
                    "TrustServerCertificate=True;";

                optionsBuilder.UseSqlServer(conexion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Cedula).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Nombre).HasMaxLength(150).IsRequired();
                entity.Property(e => e.Telefono).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Correo).HasMaxLength(150).IsRequired(false);
                entity.Property(e => e.Direccion).HasMaxLength(250).IsRequired();
                entity.HasIndex(e => e.Cedula).IsUnique();
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).HasMaxLength(150).IsRequired();
                entity.Property(e => e.Cedula).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Telefono).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Especialidad).HasMaxLength(150).IsRequired();
                entity.HasIndex(e => e.Cedula).IsUnique();
            });

            modelBuilder.Entity<Repuesto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).HasMaxLength(150).IsRequired();
                entity.Property(e => e.Marca).HasMaxLength(100).IsRequired();
                entity.Property(e => e.TipoRepuesto).IsRequired();
                entity.Property(e => e.Cantidad).IsRequired();
                entity.Property(e => e.Precio).HasPrecision(18, 2).IsRequired();
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Codigo).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Marca).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Modelo).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Estado).HasMaxLength(100).IsRequired();
                entity.HasIndex(e => e.Codigo).IsUnique();

                entity.HasDiscriminator<string>("TipoEquipo")
                    .HasValue<AireAcondicionado>("AireAcondicionado")
                    .HasValue<CamaraFrigorifica>("CamaraFrigorifica")
                    .HasValue<Refrigerador>("Refrigerador");

                entity.HasOne(e => e.Cliente)
                    .WithMany(c => c.Equipos)
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Mantenimiento>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.TipoMantenimiento).IsRequired();
                entity.Property(e => e.Descripcion).HasMaxLength(1000).IsRequired();
                entity.Property(e => e.Costo).HasPrecision(18, 2).IsRequired();
                entity.Property(e => e.Estado).HasMaxLength(100).IsRequired();
                entity.Property(e => e.DuracionHoras).IsRequired();

                entity.HasOne(m => m.Equipo)
                    .WithMany(e => e.Mantenimientos)
                    .HasForeignKey(m => m.EquipoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Tecnico)
                    .WithMany(t => t.Mantenimientos)
                    .HasForeignKey(m => m.TecnicoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ConsultaIA>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Pregunta).HasMaxLength(1000).IsRequired();
                entity.Property(e => e.Respuesta).IsRequired();
                entity.Property(e => e.Modelo).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Fecha).IsRequired();
            });

            modelBuilder.Entity<HistorialCorreo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CorreoDestino).HasMaxLength(150).IsRequired();
                entity.Property(e => e.Asunto).HasMaxLength(250).IsRequired();
                entity.Property(e => e.Mensaje).HasMaxLength(2000).IsRequired();
                entity.Property(e => e.Fecha).IsRequired();
                entity.Property(e => e.Estado).HasMaxLength(50).IsRequired();

                entity.HasOne(e => e.Cliente)
                    .WithMany()
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<HistorialWhatsApp>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.TelefonoDestino).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Mensaje).HasMaxLength(2000).IsRequired();
                entity.Property(e => e.Fecha).IsRequired();
                entity.Property(e => e.Estado).HasMaxLength(50).IsRequired();
                entity.Property(e => e.TipoMensaje).HasMaxLength(50).IsRequired();
                entity.Property(e => e.MensajeId).HasMaxLength(300).IsRequired(false);
                entity.Property(e => e.Detalle).IsRequired(false);

                entity.HasOne(e => e.Cliente)
                    .WithMany()
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
