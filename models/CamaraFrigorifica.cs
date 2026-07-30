using System;
using System.Collections.Generic;


namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class CamaraFrigorifica : Equipo
    {
        private double temperaturaMinima;

        public CamaraFrigorifica()
            : base("Sin código", "Sin marca", "Sin modelo", 0, "Sin estado")
        {
            this.temperaturaMinima = 0.0;
        }

       
        public CamaraFrigorifica(string codigo, string marca, string modelo, int capacidadBTU, string estado, double temperaturaMinima)
            : base(codigo, marca, modelo, capacidadBTU, estado)
        {
            this.temperaturaMinima = temperaturaMinima;
        }

        public double TemperaturaMinima
        {
            get { return temperaturaMinima; }
            set { temperaturaMinima = value; }
        }

        public override void RealizarMantenimiento()
        {
            Console.WriteLine("Descongelamiento y limpieza de evaporadores.");
            Console.WriteLine("Verificación de empaques de puerta y hermeticidad.");
        }

        public void MostrarEquipo()
        {
            Console.WriteLine($"Código: {Codigo} | Marca: {Marca} | Modelo: {Modelo}");
            Console.WriteLine($"BTU: {CapacidadBTU} | Estado: {Estado} | Temp. Mínima: {TemperaturaMinima}°C");
        }
    }
}