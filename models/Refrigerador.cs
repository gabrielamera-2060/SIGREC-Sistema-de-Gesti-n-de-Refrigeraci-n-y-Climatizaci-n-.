using System;
using System.Collections.Generic;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Refrigerador : Equipo
    {
        private int numeroPuertas;


        // =====================================================
        // PROPIEDAD
        // =====================================================

        public int NumeroPuertas
        {
            get => numeroPuertas;
            set
            {
                if (value < 0)
                    throw new Exception(
                        "El número de puertas no puede ser negativo.");

                numeroPuertas = value;
            }
        }


        // =====================================================
        // CONSTRUCTOR VACÍO PARA ENTITY FRAMEWORK
        // =====================================================

        public Refrigerador()
            : base()
        {
            NumeroPuertas = 0;
        }


        // =====================================================
        // CONSTRUCTOR PRINCIPAL
        // =====================================================

        public Refrigerador(
            string codigo,
            string marca,
            string modelo,
            int capacidadBTU,
            string estado,
            int numeroPuertas,
            int clienteId)
            : base(
                  codigo,
                  marca,
                  modelo,
                  capacidadBTU,
                  estado,
                  clienteId)
        {
            NumeroPuertas = numeroPuertas;
        }


        // =====================================================
        // MANTENIMIENTO
        // =====================================================

        public override void RealizarMantenimiento()
        {
            Console.WriteLine(
                "Revisión del compresor.");

            Console.WriteLine(
                "Verificación de temperatura.");
        }


        // =====================================================
        // MOSTRAR INFORMACIÓN
        // =====================================================

        public void MostrarEquipo()
        {
            Console.WriteLine(
                $"Código: {Codigo}");

            Console.WriteLine(
                $"Marca: {Marca}");

            Console.WriteLine(
                $"Modelo: {Modelo}");

            Console.WriteLine(
                $"Capacidad: {CapacidadBTU} BTU");

            Console.WriteLine(
                $"Estado: {Estado}");

            Console.WriteLine(
                $"Número de puertas: {NumeroPuertas}");

            Console.WriteLine(
                $"ID Cliente: {ClienteId}");
        }


        // =====================================================
        // IMPRIMIR
        // =====================================================

        public override void Imprimir()
        {
            base.Imprimir();

            Console.WriteLine(
                $"Número de puertas: {NumeroPuertas}");
        }
    }
}