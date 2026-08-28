using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class ConsultaIA
    {
        public int Id { get; set; }

        public string Pregunta { get; set; } = string.Empty;

        public string Respuesta { get; set; } = string.Empty;

        public string Modelo { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public ConsultaIA()
        {
        }

        public ConsultaIA(
            string pregunta,
            string respuesta,
            string modelo)
        {
            Pregunta = pregunta;
            Respuesta = respuesta;
            Modelo = modelo;
            Fecha = DateTime.Now;
        }
    }
}
