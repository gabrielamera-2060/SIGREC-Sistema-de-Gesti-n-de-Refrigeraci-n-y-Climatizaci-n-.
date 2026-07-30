using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Mantenimiento
    {
        private int id;
        private string tipoMantenimiento;
        private string descripcion;
        private decimal costo;
        private string estado;
        private int duracionHoras;

        public int? Id { get; set; } = 0;
        public string TipoMantenimiento { get => tipoMantenimiento; set => tipoMantenimiento = value; }
        public string Descripcion
        {
            get => descripcion;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("La descripcion es obligatoria");
                }
                descripcion = value;
            }

        }
        public decimal Costo
        {
            get => costo;
            set
            {
                if (value < 0)
                {
                    throw new Exception("El costo no puede ser negativo");
                }
                costo = value;
            }
        }
        public string Estado { get => estado; set => estado = value; }

        public int DuracionHoras { get => duracionHoras; set => duracionHoras = value; }


        public Mantenimiento(int id, string tipoMantenimiento, string descripcion, decimal costo, string estado, int duracionHoras)
        {
            this.Id = id;
            this.TipoMantenimiento = tipoMantenimiento;
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.Costo = costo;
            this.DuracionHoras = duracionHoras;
            this.Descripcion = descripcion;
        }

        public void Imprimir()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Tipo: " + TipoMantenimiento);
            Console.WriteLine("Descripcion: " + Descripcion);
            Console.WriteLine("Costo: $ " + costo);
            Console.WriteLine("Duracion: " + DuracionHoras + "horas");
            Console.WriteLine("Estado " + Estado);
  
        }
    }
}
