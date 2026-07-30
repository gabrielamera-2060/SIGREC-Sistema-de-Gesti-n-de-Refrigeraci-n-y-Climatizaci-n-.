using System;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class AireAcondicionado : Equipo
    {
        private string tipoFiltro;

        public AireAcondicionado() : base("Sin código", "Sin marca", "Sin modelo", 0, "Sin estado")
        {
            this.tipoFiltro = "Estandar";
        }

        public AireAcondicionado(string codigo, string marca, string modelo, int capacidadBTU, string estado, string tipoFiltro)
            : base(codigo, marca, modelo, capacidadBTU, estado)
        {
            this.tipoFiltro = tipoFiltro;
        }

        public string TipoFiltro
        {
            get => tipoFiltro;
            set => tipoFiltro = value;
        }

        public override void RealizarMantenimiento()
        {
            Console.WriteLine("Limpieza de filtros de aire acondicionado.");
            Console.WriteLine("Revisión del nivel de refrigerante.");
        }
    }
}