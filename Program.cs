using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Generales;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;
using SIGREC_Sistema_de_Gestion_de_Refrigeracion_y_Climatizacion__models;
using System;

namespace SIGREC_Refrigeracion
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.CargarDatos();

            int opcion = 0;
            do
            {
                Console.Clear();

                Console.WriteLine("========================================");
                Console.WriteLine("              SIGREC");
                Console.WriteLine(" Sistema de Refrigeracion y Climatizacion");
                Console.WriteLine("========================================");
                Console.WriteLine();

                Console.WriteLine("1. Registrar Cliente");
                Console.WriteLine("2. Registrar Equipo");
                Console.WriteLine("3. Registrar Tecnico");
                Console.WriteLine("4. Registrar Mantenimiento");
                Console.WriteLine("5. Consultar Equipos");
                Console.WriteLine("6. Generar Reportes");
                Console.WriteLine("7. Salir");

                Console.WriteLine();
                Console.Write("Seleccione una opcion: ");

                opcion = int.Parse(Console.ReadLine());


                switch (opcion)
                {

                    case 1:

                        Console.Clear();

                        Cliente cliente = new Cliente();

                        Console.WriteLine("=== REGISTRO DE CLIENTE ===");

                        Console.Write("Cedula: ");
                        cliente.Cedula = Console.ReadLine();

                        Console.Write("Nombre: ");
                        cliente.Nombre = Console.ReadLine();

                        Console.Write("Telefono: ");
                        cliente.Telefono = Console.ReadLine();

                        Console.Write("Direccion: ");
                        cliente.Direccion = Console.ReadLine();


                        Console.WriteLine();
                        Console.WriteLine("Cliente registrado correctamente.");

                        cliente.MostrarCliente();

                        Console.ReadKey();

                        break;


                    case 2:

                        Console.Clear();

                        AireAcondicionado aire = new AireAcondicionado();

                        Console.WriteLine("=== REGISTRO DE EQUIPO ===");


                        Console.Write("Codigo del equipo: ");
                        aire.Codigo = Console.ReadLine();


                        Console.Write("Marca: ");
                        aire.Marca = Console.ReadLine();


                        Console.Write("Modelo: ");
                        aire.Modelo = Console.ReadLine();


                        Console.Write("Capacidad BTU: ");
                        aire.CapacidadBTU = int.Parse(Console.ReadLine());


                        aire.Estado = "Operativo";


                        Console.WriteLine();

                        Console.WriteLine("Equipo registrado correctamente.");

                        aire.MostrarEquipo();


                        Console.ReadKey();

                        break;


                    case 3:

                        Console.Clear();

                        Tecnico tecnico = new Tecnico();


                        Console.WriteLine("=== REGISTRO DE TECNICO ===");


                        Console.Write("Codigo: ");
                        tecnico.Codigo = int.Parse(Console.ReadLine());


                        Console.Write("Nombre: ");
                        tecnico.Nombre = Console.ReadLine();


                        Console.Write("Especialidad: ");
                        tecnico.Especialidad = Console.ReadLine();


                        Console.WriteLine();

                        tecnico.AsignarTrabajo();


                        Console.ReadKey();

                        break;


                    case 4:

                        Console.Clear();

                        Mantenimiento mantenimiento = new Mantenimiento();


                        Console.WriteLine("=== REGISTRO DE MANTENIMIENTO ===");


                        Console.Write("Codigo: ");
                        mantenimiento.Codigo = int.Parse(Console.ReadLine());


                        Console.Write("Tipo de mantenimiento: ");
                        mantenimiento.Tipo = Console.ReadLine();


                        Console.Write("Costo: ");
                        mantenimiento.Costo = (decimal)double.Parse(Console.ReadLine());


                        mantenimiento.Fecha = DateTime.Now;


                        Console.WriteLine();

                        mantenimiento.MostrarMantenimiento();


                        Console.ReadKey();

                        break;


                    case 5:

                        Console.Clear();


                        Console.WriteLine("=== CONSULTA DE EQUIPOS ===");


                        AireAcondicionado equipo = new AireAcondicionado();


                        equipo.Codigo = "AC001";
                        equipo.Marca = "Carrier";
                        equipo.Modelo = "X200";
                        equipo.CapacidadBTU = 24000;
                        equipo.Estado = "Operativo";


                        equipo.MostrarEquipo();


                        Console.ReadKey();

                        break;


                    case 6:

                        Console.Clear();


                        Console.WriteLine("=== REPORTES DEL SISTEMA ===");

                        Console.WriteLine();
                        Console.WriteLine("Total de clientes registrados: 1");
                        Console.WriteLine("Total de equipos registrados: 1");
                        Console.WriteLine("Mantenimientos realizados: 1");


                        Console.ReadKey();

                        break;


                    case 7:

                        Console.Clear();

                        Console.WriteLine("Gracias por utilizar SIGREC");

                        Console.WriteLine("Sistema cerrado correctamente.");


                        break;


                    default:

                        Console.WriteLine("Opcion no valida.");

                        Console.ReadKey();

                        break;
                }


            } while (opcion != 7);


        }
    }
}