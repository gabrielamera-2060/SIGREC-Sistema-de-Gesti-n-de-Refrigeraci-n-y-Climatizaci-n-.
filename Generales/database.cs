using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Generales
{
    public static class DATABASE
    {
        public static List<Cliente> Clientes { get; set; } = new();
        public static List<Equipo> Equipos { get; set; } = new();
        public static List<Tecnico> Tecnicos { get; set; } = new();
        public static List<Repuesto> Repuestos { get; set; } = new();
        public static List<Mantenimiento> Mantenimientos { get; set; } = new();
        public static List<Refrigerador> refrigeradors { get; set; } = new();
        public static List<CamaraFrigorifica> CamaraFrigorificas { get; set; } = new();
        public static List<AireAcondicionado> AireAcondicionados { get; set; } = new();
    }
}
