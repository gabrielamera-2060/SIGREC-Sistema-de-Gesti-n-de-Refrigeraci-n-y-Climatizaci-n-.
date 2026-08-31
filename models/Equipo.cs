using System;
using System.Collections.Generic;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Generales;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public abstract class Equipo
    {
        private int id;
        private string codigo = string.Empty;
        private string marca = string.Empty;
        private string modelo = string.Empty;
        private int capacidadBTU;
        private string estado = string.Empty;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Codigo
        {
            get => codigo;
            set => codigo = value ?? string.Empty;
        }

        public string Marca
        {
            get => marca;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("La marca es obligatoria");

                marca = value;
            }
        }

        public string Modelo
        {
            get => modelo;
            set => modelo = value ?? string.Empty;
        }

        public int CapacidadBTU
        {
            get => capacidadBTU;
            set
            {
                if (value <= 0)
                    throw new Exception("La capacidad debe ser mayor a 0");

                capacidadBTU = value;
            }
        }

        public string Estado
        {
            get => estado;
            set => estado = value ?? string.Empty;
        }

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        public List<Mantenimiento> Mantenimientos { get; set; }
            = new List<Mantenimiento>();

        protected Equipo() { }

        public Equipo(
            int id,
            string codigo,
            string marca,
            string modelo,
            int capacidadBTU,
            string estado,
            int clienteId)
        {
            Id = id;
            Codigo = codigo;
            Marca = marca;
            Modelo = modelo;
            CapacidadBTU = capacidadBTU;
            Estado = estado;
            ClienteId = clienteId;
        }

        protected Equipo(
            string codigo,
            string marca,
            string modelo,
            int capacidadBTU,
            string estado,
            int clienteId)
        {
            Codigo = codigo;
            Marca = marca;
            Modelo = modelo;
            CapacidadBTU = capacidadBTU;
            Estado = estado;
            ClienteId = clienteId;
        }

        public abstract void RealizarMantenimiento();

        public virtual void Imprimir()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Capacidad: {CapacidadBTU} BTU");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine($"ID Cliente: {ClienteId}");

            if (Cliente != null)
            {
                Console.WriteLine($"Cliente: {Cliente.Nombre}");
            }
        }
    }
}
