using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Generales
{
    public static class DATABASE
    {
        private static readonly string rutaCarpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos");
        private static readonly string rutaArchivoClientes = Path.Combine(rutaCarpeta, "clientes.json");
        private static readonly string rutaArchivoEquipos = Path.Combine(rutaCarpeta, "equipos.json");
        private static readonly string rutaArchivoTecnicos = Path.Combine(rutaCarpeta, "tecnicos.json");
        private static readonly string rutaArchivoRepuestos = Path.Combine(rutaCarpeta, "repuestos.json");
        private static readonly string rutaArchivoMantenimientos = Path.Combine(rutaCarpeta, "mantenimientos.json");
        private static readonly string rutaArchivoRefrigeradores = Path.Combine(rutaCarpeta, "refrigeradores.json");
        private static readonly string rutaArchivoCamaras = Path.Combine(rutaCarpeta, "camarasFrigorificas.json");
        private static readonly string rutaArchivoAires = Path.Combine(rutaCarpeta, "airesAcondicionados.json");

        public static List<Cliente> Clientes { get; set; } = new();
        public static List<Equipo> Equipos { get; set; } = new();
        public static List<Tecnico> Tecnicos { get; set; } = new();
        public static List<Repuesto> Repuestos { get; set; } = new();
        public static List<Mantenimiento> Mantenimientos { get; set; } = new();
        public static List<Refrigerador> refrigeradors { get; set; } = new();
        public static List<CamaraFrigorifica> CamaraFrigorificas { get; set; } = new();
        public static List<AireAcondicionado> AireAcondicionados { get; set; } = new();
        public static void CargarDatos()
        {
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            Clientes = ArchivoJson.Cargar<Cliente>(rutaArchivoClientes);
            Equipos = ArchivoJson.Cargar<Equipo>(rutaArchivoEquipos);
            Tecnicos = ArchivoJson.Cargar<Tecnico>(rutaArchivoTecnicos);
            Repuestos = ArchivoJson.Cargar<Repuesto>(rutaArchivoRepuestos);
            Mantenimientos = ArchivoJson.Cargar<Mantenimiento>(rutaArchivoMantenimientos);
            Refrigeradores = ArchivoJson.Cargar<Refrigerador>(rutaArchivoRefrigeradores);
            CamaraFrigorificas = ArchivoJson.Cargar<CamaraFrigorifica>(rutaArchivoCamaras);
            AireAcondicionados = ArchivoJson.Cargar<AireAcondicionado>(rutaArchivoAires);
        }

        public static void GuardarDatos()
        {
            ArchivoJson.Guardar(rutaArchivoClientes, Clientes);
            ArchivoJson.Guardar(rutaArchivoEquipos, Equipos);
            ArchivoJson.Guardar(rutaArchivoTecnicos, Tecnicos);
            ArchivoJson.Guardar(rutaArchivoRepuestos, Repuestos);
            ArchivoJson.Guardar(rutaArchivoMantenimientos, Mantenimientos);
            ArchivoJson.Guardar(rutaArchivoRefrigeradores, Refrigeradores);
            ArchivoJson.Guardar(rutaArchivoCamaras, CamaraFrigorificas);
            ArchivoJson.Guardar(rutaArchivoAires, AireAcondicionados);
        }

        public static void GuardarClientes()
        {
            ArchivoJson.Guardar(rutaArchivoClientes, Clientes);
        }

        public static void GuardarEquipos()
        {
            ArchivoJson.Guardar(rutaArchivoEquipos, Equipos);
        }

        public static void GuardarTecnicos()
        {
            ArchivoJson.Guardar(rutaArchivoTecnicos, Tecnicos);
        }

        public static void GuardarRepuestos()
        {
            ArchivoJson.Guardar(rutaArchivoRepuestos, Repuestos);
        }

        public static void GuardarMantenimientos()
        {
            ArchivoJson.Guardar(rutaArchivoMantenimientos, Mantenimientos);
        }

        public static void GuardarRefrigeradores()
        {
            ArchivoJson.Guardar(rutaArchivoRefrigeradores, Refrigeradores);
        }

        public static void GuardarCamarasFrigorificas()
        {
            ArchivoJson.Guardar(rutaArchivoCamaras, CamaraFrigorificas);
        }

        public static void GuardarAiresAcondicionados()
        {
            ArchivoJson.Guardar(rutaArchivoAires, AireAcondicionados);
        }
    }
}
}
