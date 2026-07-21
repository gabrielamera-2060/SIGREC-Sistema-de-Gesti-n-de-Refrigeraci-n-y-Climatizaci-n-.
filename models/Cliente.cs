using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Cliente
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public void MostrarCliente()
        {
            Console.WriteLine("Cliente: " + Nombre);
            Console.WriteLine("Cedula: " + Cedula);
            Console.WriteLine("Telefono: " + Telefono);
            Console.WriteLine("Direccion: " + Direccion);
        }
    }
}
