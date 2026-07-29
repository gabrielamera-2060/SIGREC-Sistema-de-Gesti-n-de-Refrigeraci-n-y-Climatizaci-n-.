namespace SIGREC_Sistema_de_Gestión_de_Refrigeración_y_Climatización_.Generales
{
    public class AireAcondicionado
    {
        private string codigo;
        private string marca;
        private string modelo;
        private string estado;
        private int capacidadBTU;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Estado { get => estado; set => estado = value; }
        public int CapacidadBTU { get => capacidadBTU; set => capacidadBTU = value; }
        public string? Id { get; internal set; }

        public AireAcondicionado()
        {
        }

        public AireAcondicionado(string codigo, string marca, string modelo, int capacidadBTU, string estado)
        {
            Codigo = codigo;
            Marca = marca;
            Modelo = modelo;
            CapacidadBTU = capacidadBTU;
            Estado = estado;
        }

        public void MostrarEquipo()
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