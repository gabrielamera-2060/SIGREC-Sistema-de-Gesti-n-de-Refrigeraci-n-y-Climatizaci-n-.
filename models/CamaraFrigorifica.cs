using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class CamaraFrigorifica : Equipo
    {
        private double temperaturaMinima;

        public CamaraFrigorifica()
        {
        }

        public CamaraFrigorifica(string codigo, string marca, string modelo,
            int capacidadBTU, string estado, double temperaturaMinima)
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
            Console.WriteLine("Calibración del sistema.");
            Console.WriteLine("Revisión de sensores de temperatura.");
        }
    }
}
