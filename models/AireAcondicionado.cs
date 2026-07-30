using System;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class AireAcondicionado : Equipo
    {
        // Atributo propio de esta clase
        private string tipoFiltro;

        // Constructor vacío
        public AireAcondicionado() : base("Sin código", "Sin marca", "Sin modelo", 0, "Sin estado")
        {
            this.tipoFiltro = "Estandar";
        }

        // Constructor con parámetros
        public AireAcondicionado(string codigo, string marca, string modelo, int capacidadBTU, string estado, string tipoFiltro)
            : base(codigo, marca, modelo, capacidadBTU, estado)
        {
            this.tipoFiltro = tipoFiltro;
        }

        // Propiedad propia de esta clase
        public string TipoFiltro
        {
            get => tipoFiltro;
            set => tipoFiltro = value;
        }

        // Implementación obligatoria del método abstracto de Equipo
        public override void RealizarMantenimiento()
        {
            Console.WriteLine("Limpieza de filtros de aire acondicionado.");
            Console.WriteLine("Revisión del nivel de refrigerante.");
        }
    }
}