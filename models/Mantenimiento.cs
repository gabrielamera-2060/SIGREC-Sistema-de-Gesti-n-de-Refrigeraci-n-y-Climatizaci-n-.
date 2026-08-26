using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Mantenimiento
    {
        // ATRIBUTOS
        private int id;
        private string tipoMantenimiento;
        private string descripcion;
        private decimal costo;
        private string estado;
        private int duracionHoras;
        private string codigoEquipo;

        // PROPIEDADES
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string CodigoEquipo
        {
            get => codigoEquipo;
            set => codigoEquipo = value;
        }

        public string TipoMantenimiento
        {
            get => tipoMantenimiento;
            set => tipoMantenimiento = value;
        }

        public string Descripcion
        {
            get => descripcion;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(
                        "La descripción es obligatoria.");
                }

                descripcion = value;
            }
        }

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
            set => estado = value;
        }

        public int DuracionHoras
        {
            get => duracionHoras;
            set => duracionHoras = value;
        }

        // CONSTRUCTOR VACÍO
        // IMPORTANTE PARA CARGAR DESDE JSON
        public Mantenimiento()
        {
        }

        // CONSTRUCTOR CON PARÁMETROS
        public Mantenimiento(
            int id,
            string codigoEquipo,
            string tipoMantenimiento,
            string descripcion,
            decimal costo,
            string estado,
            int duracionHoras)
        {
            Id = id;
            CodigoEquipo = codigoEquipo;
            TipoMantenimiento = tipoMantenimiento;
            Descripcion = descripcion;
            Costo = costo;
            Estado = estado;
            DuracionHoras = duracionHoras;
        }

        // MÉTODO IMPRIMIR
        public void Imprimir()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Código Equipo: " + CodigoEquipo);
            Console.WriteLine("Tipo: " + TipoMantenimiento);
            Console.WriteLine("Descripción: " + Descripcion);
            Console.WriteLine("Costo: $ " + Costo);
            Console.WriteLine("Duración: " + DuracionHoras + " horas");
            Console.WriteLine("Estado: " + Estado);
        }
    }
}