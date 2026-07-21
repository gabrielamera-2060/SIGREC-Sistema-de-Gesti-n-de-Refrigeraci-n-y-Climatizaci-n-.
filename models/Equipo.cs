using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public abstract class Equipo
    {
        public string Codigo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CapacidadBTU { get; set; }
        public string Estado { get; set; }


        public abstract void RealizarMantenimiento();


        public void MostrarEquipo()
        {
            Console.WriteLine("Codigo: " + Codigo);
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Capacidad: " + CapacidadBTU + " BTU");
            Console.WriteLine("Estado: " + Estado);
        }
    }
}
