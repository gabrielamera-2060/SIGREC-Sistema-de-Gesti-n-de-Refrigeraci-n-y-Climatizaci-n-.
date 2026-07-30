using System;
using System.Collections.Generic;

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
        public string Marca 
        { get => marca; 
          set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("La marca es obligatoria");
                }
                marca = value;
            }    
        }
        public string Modelo { get => modelo; set => modelo = value; }
        public int CapacidadBTU 
        { get => capacidadBTU;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("La capacidad debe ser mayor a 0");
                }
                capacidadBTU = value;
            }
        }
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

        protected Equipo(string codigo, string marca, string modelo, int capacidadBTU, string estado)
        {
            this.codigo = codigo;
            this.marca = marca;
            this.modelo = modelo;
            this.capacidadBTU = capacidadBTU;
            this.estado = estado;
        }

        public void Imprimir()
        {
            Console.WriteLine("Codigo: " + Codigo);
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Capacidad: " + CapacidadBTU + " BTU");
            Console.WriteLine("Estado: " + Estado);
        }
    }
}
