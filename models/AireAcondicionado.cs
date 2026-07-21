using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models
{
    public class AireAcondicionado : Equipo
    {

        public override void RealizarMantenimiento()
        {
            Console.WriteLine("Mantenimiento de aire acondicionado:");
            Console.WriteLine("- Limpieza de filtros");
            Console.WriteLine("- Revision de refrigerante");
        }

    }
}
