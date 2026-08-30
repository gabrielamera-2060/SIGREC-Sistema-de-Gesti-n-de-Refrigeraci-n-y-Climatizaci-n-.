using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class HistorialWhatsApp
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public string TelefonoDestino { get; set; } = string.Empty;

        public string Mensaje { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public string Estado { get; set; } = string.Empty;

        public string TipoMensaje { get; set; } = string.Empty;

        public string? MensajeId { get; set; }

        public string? Detalle { get; set; }

        public Cliente? Cliente { get; set; }
    }
}