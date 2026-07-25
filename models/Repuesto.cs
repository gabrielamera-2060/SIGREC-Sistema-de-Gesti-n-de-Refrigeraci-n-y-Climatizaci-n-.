using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Repuesto
    {
        private int id;
        private string nombre;
        private string marca;
        private string tipoRepuesto;
        private int cantidad;
        private decimal precio;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Marca { get => marca; set => marca = value;}
        public string TipoRepuesto { get => tipoRepuesto; set => tipoRepuesto = value; }
        public int Cantidad 
        { 
            get => cantidad;
            set 
            { 
                if (value < 0)
                {
                    throw new Exception("La cantidad no puede ser negativa");
                }
                cantidad = value; 
            }
        }
        public decimal Precio 
        { 
            get => precio;
            set 
            {
                if (value <= 0)
                {
                    throw new Exception("El precio debe ser mayor 0");
                }
                precio = value; 
            }
        }
        public Repuesto (int id, string nombre,string marca,string tipoRepuesto, int cantidad, decimal precio)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Marca = marca;
            this.tipoRepuesto = tipoRepuesto;
            this.Cantidad = cantidad;
            this.Precio = precio;

        }
        public void Imprimir()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Tipo: " + TipoRepuesto);
            Console.WriteLine("Cantidad: " + Cantidad);
            Console.WriteLine("Precio: $" + Precio);
        }

    }
       
}
