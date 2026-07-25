using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public abstract class Equipo
    {
        private int id;
        private string codigo;
        private string marca;
        private string modelo;
        private int capacidadBTU;
        private string estado;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int CapacidadBTU { get => capacidadBTU; set => capacidadBTU = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Id { get => id; set => id = value; }

        public abstract void RealizarMantenimiento();

        public Equipo(int id, string codigo, string marca, string modelo, int capacidadBTU, string estado)
        {
            Id = id;
            Codigo = codigo;
            Marca = marca;
            Modelo = modelo;
            CapacidadBTU = capacidadBTU;
            Estado = estado;
        }

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
