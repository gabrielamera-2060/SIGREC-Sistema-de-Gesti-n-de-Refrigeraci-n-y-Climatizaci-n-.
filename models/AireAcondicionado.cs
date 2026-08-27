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


        // =====================================================
        // CONSTRUCTOR VACÍO
        // =====================================================

        public AireAcondicionado() : base()
        {
        }


        // =====================================================
        // CONSTRUCTOR CON PARÁMETROS
        // =====================================================

        public AireAcondicionado(
            string codigo,
            string marca,
            string modelo,
            int capacidadBTU,
            string estado,
            string tipoFiltro,
            int clienteId)
            : base(
                codigo,
                marca,
                modelo,
                capacidadBTU,
                estado,
                clienteId)
        {
            TipoFiltro = tipoFiltro;
        }


        // =====================================================
        // MÉTODO HEREDADO
        // =====================================================

        public override void RealizarMantenimiento()
        {
            Console.WriteLine(
                "Limpieza de filtros de aire acondicionado.");

            Console.WriteLine(
                "Revisión del nivel de refrigerante.");
        }


        // =====================================================
        // IMPRIMIR
        // =====================================================

        public override void Imprimir()
        {
            base.Imprimir();

            Console.WriteLine(
                $"Tipo de filtro: {TipoFiltro}");
        }
    }
}