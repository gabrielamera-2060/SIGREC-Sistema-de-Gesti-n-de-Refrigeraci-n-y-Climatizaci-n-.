using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Cliente
    {
        private int id;
        private string cedula;
        private string nombre;
        private string telefono;
        private string direccion;

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Id { get => id; set => id = value; }

        public void MostrarCliente()
        {
            Console.WriteLine("Cliente: " + Nombre);
            Console.WriteLine("Cedula: " + Cedula);
            Console.WriteLine("Telefono: " + Telefono);
            Console.WriteLine("Direccion: " + Direccion);
        }
    }
}
