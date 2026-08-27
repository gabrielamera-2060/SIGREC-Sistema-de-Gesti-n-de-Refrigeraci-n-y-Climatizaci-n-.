using System;
using System.Collections.Generic;


namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class CamaraFrigorifica : Equipo
    {
        private double temperaturaMinima;

        // =====================================================
        // PROPIEDAD
        // =====================================================

        public double TemperaturaMinima
        {
            get => temperaturaMinima;
            set => temperaturaMinima = value;
        }


        // =====================================================
        // CONSTRUCTOR VACÍO PARA ENTITY FRAMEWORK
        // =====================================================

        public CamaraFrigorifica()
            : base()
        {
            TemperaturaMinima = 0.0;
        }


        // =====================================================
        // CONSTRUCTOR PRINCIPAL
        // =====================================================

        public CamaraFrigorifica(
            string codigo,
            string marca,
            string modelo,
            int capacidadBTU,
            string estado,
            double temperaturaMinima,
            int clienteId)
            : base(
                  codigo,
                  marca,
                  modelo,
                  capacidadBTU,
                  estado,
                  clienteId)
        {
            TemperaturaMinima = temperaturaMinima;
        }


        // =====================================================
        // MANTENIMIENTO
        // =====================================================

        public override void RealizarMantenimiento()
        {
            Console.WriteLine(
                "Descongelamiento y limpieza de evaporadores.");

            Console.WriteLine(
                "Verificación de empaques de puerta y hermeticidad.");
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
                $"Temperatura mínima: {TemperaturaMinima} °C");

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
                $"Temperatura mínima: {TemperaturaMinima} °C");
        }
    }
}