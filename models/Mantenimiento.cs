using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Mantenimiento
    {
        // =====================================================
        // ATRIBUTOS
        // =====================================================

        private int id;

        private int equipoId;

        private int tecnicoId;

        private string tipoMantenimiento = string.Empty;

        private string descripcion = string.Empty;

        private decimal costo;

        private string estado = string.Empty;

        private int duracionHoras;


        // =====================================================
        // PROPIEDADES
        // =====================================================

        public int Id
        {
            get => id;
            set => id = value;
        }


        // =====================================================
        // CLAVE FORÁNEA EQUIPO
        // =====================================================

        public int EquipoId
        {
            get => equipoId;

            set
            {
                if (value < 0)
                {
                    throw new Exception(
                        "El ID del equipo no puede ser negativo.");
                }

                equipoId = value;
            }
        }


        // =====================================================
        // CLAVE FORÁNEA TÉCNICO
        // =====================================================

        public int TecnicoId
        {
            get => tecnicoId;

            set
            {
                if (value < 0)
                {
                    throw new Exception(
                        "El ID del técnico no puede ser negativo.");
                }

                tecnicoId = value;
            }
        }


        // =====================================================
        // TIPO DE MANTENIMIENTO
        // IMPORTANTE:
        // Program.cs utiliza TipoMantenimiento
        // =====================================================

        public string TipoMantenimiento
        {
            get => tipoMantenimiento;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(
                        "El tipo de mantenimiento es obligatorio.");
                }

                tipoMantenimiento = value;
            }
        }


        public string Descripcion
        {
            get => descripcion;

            set
            {
                descripcion =
                    value ?? string.Empty;
            }
        }


        // =====================================================
        // COSTO
        // SQL Server: decimal(18,2)
        // =====================================================

        public decimal Costo
        {
            get => costo;

            set
            {
                if (value < 0)
                {
                    throw new Exception(
                        "El costo no puede ser negativo.");
                }

                costo = value;
            }
        }


        public string Estado
        {
            get => estado;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(
                        "El estado del mantenimiento es obligatorio.");
                }

                estado = value;
            }
        }


        public int DuracionHoras
        {
            get => duracionHoras;

            set
            {
                if (value < 0)
                {
                    throw new Exception(
                        "La duración no puede ser negativa.");
                }

                duracionHoras = value;
            }
        }


        // =====================================================
        // RELACIÓN CON EQUIPO
        // =====================================================

        public Equipo? Equipo { get; set; }


        // =====================================================
        // RELACIÓN CON TÉCNICO
        // =====================================================

        public Tecnico? Tecnico { get; set; }


        // =====================================================
        // CONSTRUCTOR VACÍO
        // NECESARIO PARA ENTITY FRAMEWORK
        // =====================================================

        public Mantenimiento()
        {
        }


        // =====================================================
        // CONSTRUCTOR CON PARÁMETROS
        // Compatible con Program.cs
        // =====================================================

        public Mantenimiento(
            int id,
            int equipoId,
            int tecnicoId,
            string tipoMantenimiento,
            string descripcion,
            decimal costo,
            string estado,
            int duracionHoras)
        {
            Id = id;

            EquipoId = equipoId;

            TecnicoId = tecnicoId;

            TipoMantenimiento =
                tipoMantenimiento;

            Descripcion =
                descripcion;

            Costo =
                costo;

            Estado =
                estado;

            DuracionHoras =
                duracionHoras;
        }


        // =====================================================
        // MOSTRAR MANTENIMIENTO
        // =====================================================

        public void MostrarMantenimiento()
        {
            Console.WriteLine(
                "ID: " + Id);

            Console.WriteLine(
                "Tipo de mantenimiento: " +
                TipoMantenimiento);

            Console.WriteLine(
                "Descripción: " +
                Descripcion);

            Console.WriteLine(
                "Costo: $" +
                Costo.ToString("0.00"));

            Console.WriteLine(
                "Estado: " +
                Estado);

            Console.WriteLine(
                "Duración: " +
                DuracionHoras +
                " horas");


            if (Equipo != null)
            {
                Console.WriteLine(
                    "Equipo: " +
                    Equipo.Codigo);
            }
            else
            {
                Console.WriteLine(
                    "Equipo ID: " +
                    EquipoId);
            }


            if (Tecnico != null)
            {
                Console.WriteLine(
                    "Técnico: " +
                    Tecnico.Nombre);
            }
            else
            {
                Console.WriteLine(
                    "Técnico ID: " +
                    TecnicoId);
            }
        }


        // =====================================================
        // MÉTODO IMPRIMIR
        // =====================================================

        public void Imprimir()
        {
            MostrarMantenimiento();
        }
    }
}