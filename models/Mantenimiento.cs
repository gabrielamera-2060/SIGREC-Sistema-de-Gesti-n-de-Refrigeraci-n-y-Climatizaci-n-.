using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Mantenimiento
    {
        private int id;
        private int equipoId;
        private int tecnicoId;
        private string tipoMantenimiento = string.Empty;
        private string descripcion = string.Empty;
        private decimal costo;
        private string estado = string.Empty;
        private int duracionHoras;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int EquipoId
        {
            get => equipoId;
            set
            {
                if (value < 0)
                    throw new Exception("El ID del equipo no puede ser negativo.");

                equipoId = value;
            }
        }

        public int TecnicoId
        {
            get => tecnicoId;
            set
            {
                if (value < 0)
                    throw new Exception("El ID del técnico no puede ser negativo.");

                tecnicoId = value;
            }
        }

        public string TipoMantenimiento
        {
            get => tipoMantenimiento;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("El tipo de mantenimiento es obligatorio.");

                tipoMantenimiento = value;
            }
        }

        public string Descripcion
        {
            get => descripcion;
            set => descripcion = value ?? string.Empty;
        }

        public decimal Costo
        {
            get => costo;
            set
            {
                if (value < 0)
                    throw new Exception("El costo no puede ser negativo.");

                costo = value;
            }
        }

        public string Estado
        {
            get => estado;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("El estado del mantenimiento es obligatorio.");

                estado = value;
            }
        }

        public int DuracionHoras
        {
            get => duracionHoras;
            set
            {
                if (value < 0)
                    throw new Exception("La duración no puede ser negativa.");

                duracionHoras = value;
            }
        }

        public Equipo? Equipo { get; set; }
        public Tecnico? Tecnico { get; set; }

        public Mantenimiento() { }

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
            TipoMantenimiento = tipoMantenimiento;
            Descripcion = descripcion;
            Costo = costo;
            Estado = estado;
            DuracionHoras = duracionHoras;
        }

        public void MostrarMantenimiento()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Tipo de mantenimiento: " + TipoMantenimiento);
            Console.WriteLine("Descripción: " + Descripcion);
            Console.WriteLine("Costo: $" + Costo.ToString("0.00"));
            Console.WriteLine("Estado: " + Estado);
            Console.WriteLine("Duración: " + DuracionHoras + " horas");

            Console.WriteLine(
                Equipo != null
                    ? "Equipo: " + Equipo.Codigo
                    : "Equipo ID: " + EquipoId);

            Console.WriteLine(
                Tecnico != null
                    ? "Técnico: " + Tecnico.Nombre
                    : "Técnico ID: " + TecnicoId);
        }

        public void Imprimir()
        {
            MostrarMantenimiento();
        }
    }
}
