using System;
using System.Collections.Generic;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Cliente
    {
        // =====================================================
        // ATRIBUTOS
        // =====================================================

        private int id;

        private string cedula = string.Empty;

        private string nombre = string.Empty;

        private string telefono = string.Empty;

        private string? correo;

        private string direccion = string.Empty;


        // =====================================================
        // PROPIEDADES
        // =====================================================

        public int Id
        {
            get => id;
            set => id = value;
        }


        public string Cedula
        {
            get => cedula;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(
                        "La cédula es obligatoria");
                }

                if (value.Length != 10)
                {
                    throw new Exception(
                        "La cédula debe tener 10 dígitos");
                }

                if (!long.TryParse(value, out _))
                {
                    throw new Exception(
                        "La cédula solo debe contener números");
                }

                cedula = value;
            }
        }


        public string Nombre
        {
            get => nombre;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(
                        "El nombre es obligatorio");
                }

                nombre = value;
            }
        }


        public string Telefono
        {
            get => telefono;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(
                        "El teléfono es obligatorio");
                }

                telefono = value;
            }
        }


        // =====================================================
        // CORREO ELECTRÓNICO
        // OPCIONAL
        // =====================================================

        public string? Correo
        {
            get => correo;

            set
            {
                // Se permite NULL o vacío
                // porque pueden existir clientes antiguos
                // sin correo registrado.

                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (!value.Contains("@") ||
                        !value.Contains("."))
                    {
                        throw new Exception(
                            "El correo electrónico no es válido");
                    }
                }

                correo = value;
            }
        }


        public string Direccion
        {
            get => direccion;

            set
            {
                direccion =
                    value ?? string.Empty;
            }
        }


        // =====================================================
        // RELACIÓN
        // UN CLIENTE PUEDE TENER VARIOS EQUIPOS
        // =====================================================

        public List<Equipo> Equipos { get; set; }
            = new List<Equipo>();


        // =====================================================
        // CONSTRUCTOR VACÍO
        // NECESARIO PARA ENTITY FRAMEWORK
        // =====================================================

        public Cliente()
        {
        }


        // =====================================================
        // CONSTRUCTOR ORIGINAL
        // SE MANTIENE PARA NO DAÑAR EL PROGRAM.CS EXISTENTE
        // =====================================================

        public Cliente(
            string cedula,
            string nombre,
            string telefono,
            string direccion,
            int id)
        {
            Cedula = cedula;

            Nombre = nombre;

            Telefono = telefono;

            Direccion = direccion;

            Id = id;
        }


        // =====================================================
        // CONSTRUCTOR NUEVO CON CORREO
        // =====================================================

        public Cliente(
            string cedula,
            string nombre,
            string telefono,
            string? correo,
            string direccion,
            int id)
        {
            Cedula = cedula;

            Nombre = nombre;

            Telefono = telefono;

            Correo = correo;

            Direccion = direccion;

            Id = id;
        }


        // =====================================================
        // MOSTRAR INFORMACIÓN DEL CLIENTE
        // =====================================================

        public void MostrarCliente()
        {
            Console.WriteLine(
                "Id: " + Id);

            Console.WriteLine(
                "Cliente: " + Nombre);

            Console.WriteLine(
                "Cédula: " + Cedula);

            Console.WriteLine(
                "Teléfono: " + Telefono);


            if (string.IsNullOrWhiteSpace(
                Correo))
            {
                Console.WriteLine(
                    "Correo: No registrado");
            }
            else
            {
                Console.WriteLine(
                    "Correo: " + Correo);
            }


            Console.WriteLine(
                "Dirección: " + Direccion);
        }


        // =====================================================
        // MÉTODO IMPRIMIR
        // =====================================================

        public void Imprimir()
        {
            MostrarCliente();
        }
    }
}