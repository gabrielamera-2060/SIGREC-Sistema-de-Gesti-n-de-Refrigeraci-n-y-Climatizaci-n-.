using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;

namespace SIGREC_Sistema_de_Gestion_de_Refrigeracion_y_Climatizacion__models
{
    public class Tecnico
    {
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Especialidad { get; set; } = "";

        public List<Equipo> EquiposAsignados { get; set; } = new List<Equipo>(); // Para guardar equipos
        public int Codigo { get; internal set; }

        public Tecnico() { }

        public void Imprimir()
        {
            Console.WriteLine("Tecnico: " + Nombre + " " + Apellido);
            Console.WriteLine("Telefono: " + Telefono);
            Console.WriteLine("Especialidad: " + Especialidad);
            Console.WriteLine($"Equipos Asignados: {EquiposAsignados.Count}");
        }

        internal void AsignarTrabajo(Equipo equipo) // Ya sin el throw
        {
            EquiposAsignados.Add(equipo);
            Console.WriteLine("=================================");
            Console.WriteLine($"TRABAJO ASIGNADO");
            Console.WriteLine($"Tecnico: {Nombre} {Apellido}");
            Console.WriteLine($"Equipo: {equipo.Marca} {equipo.Modelo}");
            Console.WriteLine("=================================");
        }

        internal void AsignarTrabajo()
        {
            throw new NotImplementedException();
        }
    }
}