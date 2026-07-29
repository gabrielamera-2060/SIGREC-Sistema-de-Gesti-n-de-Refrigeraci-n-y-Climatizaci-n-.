namespace SIGREC_Sistema_de_Gestión_de_Refrigeración_y_Climatización_.Generales
{
    public class AireAcondicionado
    {
        internal string Estado;
        internal string Modelo;
        internal string Marca;

        public string Codigo { get; internal set; }
        public int CapacidadBTU { get; internal set; }

        public AireAcondicionado() { } // Constructor vacío

        // Constructor con parámetros para que sea más fácil
        public AireAcondicionado(string codigo, string marca, string modelo, int capacidadBTU, string estado)
        {
            Codigo = codigo;
            Marca = marca;
            Modelo = modelo;
            CapacidadBTU = capacidadBTU;
            Estado = estado;
        }

        internal void MostrarEquipo()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("        DATOS DEL AIRE ACONDICIONADO");
            Console.WriteLine("======================================");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Capacidad: {CapacidadBTU} BTU");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine("======================================");
        }
    }
}