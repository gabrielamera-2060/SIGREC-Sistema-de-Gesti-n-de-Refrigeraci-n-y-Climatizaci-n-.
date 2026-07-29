using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Tecnico
    {
        private int id;
        private string nombre;
        private string apellido;
        private string telefono;
        private string especialidad;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => nombre = value; }
        public string Telefono 
        { 
            get => telefono;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("el teleono es obligatorio");
                }
                telefono = value;
            }
        }

        public string Especialidad { get => especialidad; set => especialidad = value; }
        public int Codigo { get; internal set; }

        public Tecnico (int id, string nombre, string apellido, string telefono, string especialidad)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Especialidad = especialidad;
        }

        public Tecnico()
        {
        }

        public void Imprimir()
        {
            Console.WriteLine("Tecnico" + Nombre);
            Console.WriteLine("Apellido: " + Apellido);
            Console.WriteLine("Telefono " + Telefono);
            Console.WriteLine("Especialidad:" + Especialidad);

        }

        internal void AsignarTrabajo()
        {
            throw new NotImplementedException();
        }
    }
}
