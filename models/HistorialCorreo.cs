using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class HistorialCorreo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string CorreoDestino { get; set; } = string.Empty;
        public string Asunto { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "Simulado";
        public Cliente? Cliente { get; set; }
    }
}
