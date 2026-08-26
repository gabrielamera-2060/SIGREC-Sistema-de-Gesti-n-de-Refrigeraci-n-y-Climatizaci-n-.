using System;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class AireAcondicionado : Equipo
    {
        // ATRIBUTO
        private string tipoFiltro;

        // PROPIEDAD
        public string TipoFiltro
        {
            get => tipoFiltro;
            set => tipoFiltro = value;
        }

        // CONSTRUCTOR VACÍO
        // Importante para cargar los datos desde JSON
        public AireAcondicionado() : base()
        {
        }

        // CONSTRUCTOR CON PARÁMETROS
        public AireAcondicionado(
            string codigo,
            string marca,
            string modelo,
            int capacidadBTU,
            string estado,
            string tipoFiltro)
            : base(
                codigo,
                marca,
                modelo,
                capacidadBTU,
                estado)
        {
            TipoFiltro = tipoFiltro;
        }

        public override void RealizarMantenimiento()
        {
            Console.WriteLine(
                "Limpieza de filtros de aire acondicionado.");

            Console.WriteLine(
                "Revisión del nivel de refrigerante.");
        }

        public override void Imprimir()
        {
            base.Imprimir();

            Console.WriteLine(
                $"Tipo de filtro: {TipoFiltro}");
        }
    }
}