using Microsoft.EntityFrameworkCore;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;
using System;
using System.Collections.Generic;
using System.Text;

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


        // =====================================================
        // CONEXIÓN A SQL SERVER
        // =====================================================

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-18VAGMV\\SQLEXPRESS;Database=PROYECTO_SIGREC;User Id=sa;Password=1234;TrustServerCertificate=True;");
            }
        }


        // =====================================================
        // CONFIGURACIÓN DEL MODELO
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
                .HasMaxLength(100);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Telefono)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Direccion)
                .HasMaxLength(200);

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
                .HasMaxLength(100);

            modelBuilder.Entity<Tecnico>()
                .Property(t => t.Cedula)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Tecnico>()
                .Property(t => t.Telefono)
                .HasMaxLength(20);

            modelBuilder.Entity<Tecnico>()
                .Property(t => t.Especialidad)
                .HasMaxLength(100);

            modelBuilder.Entity<Tecnico>()
                .Property(t => t.Experiencia);

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
                .HasMaxLength(100);

            modelBuilder.Entity<Repuesto>()
                .Property(r => r.Marca)
                .HasMaxLength(100);

            modelBuilder.Entity<Repuesto>()
                .Property(r => r.TipoRepuesto)
                .HasMaxLength(100);

            modelBuilder.Entity<Repuesto>()
                .Property(r => r.Cantidad);

            modelBuilder.Entity<Repuesto>()
                .Property(r => r.Precio)
                .HasPrecision(10, 2);


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
                .Property(e => e.CapacidadBTU);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Estado)
                .HasMaxLength(50);

            modelBuilder.Entity<Equipo>()
                .HasIndex(e => e.Codigo)
                .IsUnique();


            // =================================================
            // HERENCIA DE EQUIPO
            // TPH = Table Per Hierarchy
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
            // AIRE ACONDICIONADO
            // =================================================

            modelBuilder.Entity<AireAcondicionado>()
                .Property(a => a.TipoFiltro)
                .HasMaxLength(100);


            // =================================================
            // CÁMARA FRIGORÍFICA
            // =================================================

            modelBuilder.Entity<CamaraFrigorifica>()
                .Property(c => c.TemperaturaMinima);


            // =================================================
            // REFRIGERADOR
            // =================================================

            modelBuilder.Entity<Refrigerador>()
                .Property(r => r.NumeroPuertas);


            // =================================================
            // RELACIÓN CLIENTE - EQUIPO
            // UN CLIENTE PUEDE TENER MUCHOS EQUIPOS
            // =================================================

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Equipos)
                .WithOne(e => e.Cliente)
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
                .Property(m => m.TipoMantenimiento)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Mantenimiento>()
                .Property(m => m.Descripcion)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Mantenimiento>()
                .Property(m => m.Costo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Mantenimiento>()
                .Property(m => m.Estado)
                .HasMaxLength(50);

            modelBuilder.Entity<Mantenimiento>()
                .Property(m => m.DuracionHoras);


            // =================================================
            // RELACIÓN EQUIPO - MANTENIMIENTO
            // UN EQUIPO PUEDE TENER MUCHOS MANTENIMIENTOS
            // =================================================

            modelBuilder.Entity<Equipo>()
                .HasMany(e => e.Mantenimientos)
                .WithOne(m => m.Equipo)
                .HasForeignKey(m => m.EquipoId)
                .OnDelete(DeleteBehavior.Restrict);


            // =================================================
            // RELACIÓN TÉCNICO - MANTENIMIENTO
            // UN TÉCNICO PUEDE REALIZAR MUCHOS MANTENIMIENTOS
            // =================================================

            modelBuilder.Entity<Tecnico>()
                .HasMany(t => t.Mantenimientos)
                .WithOne(m => m.Tecnico)
                .HasForeignKey(m => m.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}