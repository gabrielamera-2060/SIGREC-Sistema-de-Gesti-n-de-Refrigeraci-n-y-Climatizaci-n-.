using System;
using System.Collections.Generic;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Tecnico
    {
        private int id;
        private string nombre;
        private string cedula;
        private string telefono;
        private string especialidad;
        private int experiencia;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string Cedula
        {
            get => cedula;
            set => cedula = value;
        }

        public string Telefono
        {
            get => telefono;
            set => telefono = value;
        }

        public string Especialidad
        {
            get => especialidad;
            set => especialidad = value;
        }

        public int Experiencia
        {
            get => experiencia;
            set => experiencia = value;
        }

        public Tecnico()
        {
        }

        public Tecnico(
            int id,
            string nombre,
            string cedula,
            string telefono,
            string especialidad,
            int experiencia)
        {
            Id = id;
            Nombre = nombre;
            Cedula = cedula;
            Telefono = telefono;
            Especialidad = especialidad;
            Experiencia = experiencia;
        }

        public void Imprimir()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Cédula: {Cedula}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Especialidad: {Especialidad}");
            Console.WriteLine($"Experiencia: {Experiencia} años");
        }
    }
}