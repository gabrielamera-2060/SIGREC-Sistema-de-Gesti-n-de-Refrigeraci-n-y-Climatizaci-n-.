using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Mantenimiento
    {
        private int id;
        private string tipo;
        private string descripcion;
        private decimal costo;
        private string estado;
        private int duracionHoras;
        private string observaciones;

        public int Id { get => id; set => id = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Costo { get => costo; set => costo = value; }
        public string Estado { get => estado; set => estado = value; }
        public int DuracionHoras { get => duracionHoras; set => duracionHoras = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
    
    }
}
