using System;
using Microsoft.EntityFrameworkCore;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Datos
{
    public class SigrecDbContext : DbContext
    {
        // =====================================================
        // TABLAS
        // =====================================================

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Tecnico> Tecnicos { get; set; }

        public DbSet<Repuesto> Repuestos { get; set; }

        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<AireAcondicionado> AiresAcondicionados { get; set; }

        public DbSet<CamaraFrigorifica> CamarasFrigorificas { get; set; }

        public DbSet<Refrigerador> Refrigeradores { get; set; }

        public DbSet<Mantenimiento> Mantenimientos { get; set; }

        public DbSet<ConsultaIA> ConsultasIA { get; set; }


        // =====================================================
        // CONSTRUCTORES
        // =====================================================

        public SigrecDbContext()
        {
        }

        public SigrecDbContext(
            DbContextOptions<SigrecDbContext> options)
            : base(options)
        {
        }


        // =====================================================
        // CONEXIÓN SQL SERVER
        // =====================================================

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string? password =
                    Environment.GetEnvironmentVariable(
                        "SIGREC_DB_PASSWORD");

                if (string.IsNullOrWhiteSpace(password))
                {
                    password =
                        Environment.GetEnvironmentVariable(
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

                optionsBuilder.UseSqlServer(
                    conexion);
            }
        }


        // =====================================================
        // CONFIGURACIÓN DE ENTIDADES
        // =====================================================

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // =================================================
            // CLIENTE
            // =================================================

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Cedula)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Telefono)
                .IsRequired()
                .HasMaxLength(20);

            // NUEVO CAMPO CORREO
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Correo)
                .HasMaxLength(150);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Direccion)
                .HasMaxLength(250);

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Cedula)
                .IsUnique();


            // =================================================
            // TÉCNICO
            // =================================================

            modelBuilder.Entity<Tecnico>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Tecnico>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Tecnico>()
                .Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Tecnico>()
                .Property(t => t.Cedula)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Tecnico>()
                .Property(t => t.Telefono)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Tecnico>()
                .Property(t => t.Especialidad)
                .HasMaxLength(150);

            modelBuilder.Entity<Tecnico>()
                .HasIndex(t => t.Cedula)
                .IsUnique();


            // =================================================
            // REPUESTO
            // =================================================

            modelBuilder.Entity<Repuesto>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Repuesto>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Repuesto>()
                .Property(r => r.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Repuesto>()
                .Property(r => r.Marca)
                .HasMaxLength(100);

            // SE ELIMINÓ:
            // .Property(r => r.Tipo)
            //
            // porque tu clase Repuesto actualmente
            // no contiene una propiedad llamada Tipo.


            // =================================================
            // EQUIPO
            // =================================================

            modelBuilder.Entity<Equipo>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Marca)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Modelo)
                .HasMaxLength(100);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Estado)
                .HasMaxLength(100);

            modelBuilder.Entity<Equipo>()
                .HasIndex(e => e.Codigo)
                .IsUnique();


            // =================================================
            // HERENCIA DE EQUIPOS - TPH
            // =================================================

            modelBuilder.Entity<Equipo>()
                .HasDiscriminator<string>("TipoEquipo")
                .HasValue<AireAcondicionado>(
                    "AireAcondicionado")
                .HasValue<CamaraFrigorifica>(
                    "CamaraFrigorifica")
                .HasValue<Refrigerador>(
                    "Refrigerador");


            // =================================================
            // RELACIÓN CLIENTE - EQUIPO
            // =================================================

            modelBuilder.Entity<Equipo>()
                .HasOne(e => e.Cliente)
                .WithMany(c => c.Equipos)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);


            // =================================================
            // MANTENIMIENTO
            // =================================================

            modelBuilder.Entity<Mantenimiento>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Mantenimiento>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Mantenimiento>()
                .Property(m => m.Descripcion)
                .HasMaxLength(1000);

            modelBuilder.Entity<Mantenimiento>()
                .Property(m => m.Estado)
                .HasMaxLength(100);

            // SE ELIMINÓ:
            // .Property(m => m.Tipo)
            //
            // porque tu clase Mantenimiento actualmente
            // no contiene una propiedad llamada Tipo.


            // =================================================
            // RELACIÓN EQUIPO - MANTENIMIENTO
            // =================================================

            modelBuilder.Entity<Mantenimiento>()
                .HasOne(m => m.Equipo)
                .WithMany(e => e.Mantenimientos)
                .HasForeignKey(m => m.EquipoId)
                .OnDelete(DeleteBehavior.Restrict);


            // =================================================
            // RELACIÓN TÉCNICO - MANTENIMIENTO
            // =================================================

            modelBuilder.Entity<Mantenimiento>()
                .HasOne(m => m.Tecnico)
                .WithMany(t => t.Mantenimientos)
                .HasForeignKey(m => m.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);


            // =================================================
            // CONSULTA IA
            // =================================================

            modelBuilder.Entity<ConsultaIA>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<ConsultaIA>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ConsultaIA>()
                .Property(c => c.Pregunta)
                .IsRequired()
                .HasMaxLength(1000);

            modelBuilder.Entity<ConsultaIA>()
                .Property(c => c.Respuesta)
                .IsRequired();

            modelBuilder.Entity<ConsultaIA>()
                .Property(c => c.Modelo)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<ConsultaIA>()
                .Property(c => c.Fecha)
                .IsRequired();
        }
    }
}