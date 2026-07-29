using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class AireAcondicionado : Equipo
    {
        // Atributo
        private string tipoFiltro;

        // Constructor vacío
        public AireAcondicionado() : base("Sin marca ", "Sin modelo ", "Sin código ", 0, "Sin estado ")
        {
            this.tipoFiltro = "Estandar";
        }

        // Constructor con parámetros
        public AireAcondicionado(string codigo, string marca, string modelo,
            int capacidadBTU, string estado, string tipoFiltro)
            : base(codigo, marca, modelo, capacidadBTU, estado)
        {
            this.tipoFiltro = tipoFiltro;
        }

        // Propiedad
        public string TipoFiltro
        {
            get { return tipoFiltro; }
            set { tipoFiltro = value; }
        }

        public override void RealizarMantenimiento()
        {
            Console.WriteLine("Limpieza de filtros.");
            Console.WriteLine("Revisión del nivel de refrigerante.");
        }

        internal void MostrarEquipo()
        {
            throw new NotImplementedException();
        }
    }
}
