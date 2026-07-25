using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Timers;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Cliente
    {
        private int id;
        private string cedula;
        private string nombre;
        private string telefono;
        private string direccion;

        public string Cedula
        { get => cedula;
            set
            {
                if (value.Length != 10)
                {
                    throw new Exception("La cédula debe tener 10 dígitos");
                }
                cedula = value;
            }
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono 
        { get => telefono; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("el teleono es obligatorio");
                }
                telefono = value;
            } 
        }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Id { get => id; set => id = value; }

        public Cliente(string cedula, string nombre, string telefono, string direccion, int id)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Id = id;
        }

        public void MostrarCliente()
        {
            Console.WriteLine("Cliente: " + Nombre);
            Console.WriteLine("Cedula: " + Cedula);
            Console.WriteLine("Telefono: " + Telefono);
            Console.WriteLine("Direccion: " + Direccion);
        }
    }
}
