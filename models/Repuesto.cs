using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Repuesto
    {
        // =====================================================
        // ATRIBUTOS
        // =====================================================

        private int id;

        private string nombre = string.Empty;

        private string marca = string.Empty;

        private string tipoRepuesto = string.Empty;

        private int cantidad;

        private decimal precio;


        // =====================================================
        // PROPIEDADES
        // =====================================================

        public int Id
        {
            get => id;
            set => id = value;
        }


        public string Nombre
        {
            get => nombre;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(
                        "El nombre del repuesto es obligatorio.");
                }

                nombre = value;
            }
        }


        public string Marca
        {
            get => marca;

            set
            {
                marca =
                    value ?? string.Empty;
            }
        }


        // =====================================================
        // TIPO DE REPUESTO
        // IMPORTANTE:
        // Se llama TipoRepuesto porque así lo usa Program.cs
        // =====================================================

        public string TipoRepuesto
        {
            get => tipoRepuesto;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(
                        "El tipo de repuesto es obligatorio.");
                }

                tipoRepuesto = value;
            }
        }


        public int Cantidad
        {
            get => cantidad;

            set
            {
                if (value < 0)
                {
                    throw new Exception(
                        "La cantidad no puede ser negativa.");
                }

                cantidad = value;
            }
        }


        // =====================================================
        // PRECIO
        // En SQL Server lo configuraremos decimal(18,2)
        // =====================================================

        public decimal Precio
        {
            get => precio;

            set
            {
                if (value < 0)
                {
                    throw new Exception(
                        "El precio no puede ser negativo.");
                }

                precio = value;
            }
        }


        // =====================================================
        // CONSTRUCTOR VACÍO
        // NECESARIO PARA ENTITY FRAMEWORK
        // =====================================================

        public Repuesto()
        {
        }


        // =====================================================
        // CONSTRUCTOR CON PARÁMETROS
        // Compatible con Program.cs
        // =====================================================

        public Repuesto(
            int id,
            string nombre,
            string marca,
            string tipoRepuesto,
            int cantidad,
            decimal precio)
        {
            Id = id;

            Nombre = nombre;

            Marca = marca;

            TipoRepuesto = tipoRepuesto;

            Cantidad = cantidad;

            Precio = precio;
        }


        // =====================================================
        // MOSTRAR REPUESTO
        // =====================================================

        public void MostrarRepuesto()
        {
            Console.WriteLine(
                "ID: " + Id);

            Console.WriteLine(
                "Repuesto: " + Nombre);

            Console.WriteLine(
                "Marca: " + Marca);

            Console.WriteLine(
                "Tipo: " + TipoRepuesto);

            Console.WriteLine(
                "Cantidad: " + Cantidad);

            Console.WriteLine(
                "Precio: $" +
                Precio.ToString("0.00"));
        }


        // =====================================================
        // MÉTODO IMPRIMIR
        // =====================================================

        public void Imprimir()
        {
            MostrarRepuesto();
        }
    }
}