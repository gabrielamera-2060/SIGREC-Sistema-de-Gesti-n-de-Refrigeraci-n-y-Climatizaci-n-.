using System;
using System.Collections.Generic;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class Refrigerador : Equipo
    {
        private int numeroPuertas;

        public Refrigerador() : base("Sin código", "Sin marca", "Sin modelo", 0, "Sin estado")
        {
            this.numeroPuertas = 0;
        }

        public Refrigerador(string codigo, string marca, string modelo,
            int capacidadBTU, string estado, int numeroPuertas)
            : base(codigo, marca, modelo, capacidadBTU, estado)
        {
            this.numeroPuertas = numeroPuertas;
        }

        public int NumeroPuertas
        {
            get { return numeroPuertas; }
            set { numeroPuertas = value; }
        }

        public override void RealizarMantenimiento()
        {
            Console.WriteLine("Revisión del compresor.");
            Console.WriteLine("Verificación de temperatura.");
        }
    }
}