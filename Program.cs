using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Generales;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;

Database.CargarDatos();

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Title = "SIGREC - Sistema de Gestión de Refrigeración y Climatización";

int opcionPrincipal = 0;

do
{
    Console.Clear();

    MostrarEncabezadoPrincipal();

    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("   ╔══════════════════════════════════════════════╗");
    Console.WriteLine("   ║               MENÚ PRINCIPAL                 ║");
    Console.WriteLine("   ╠══════════════════════════════════════════════╣");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("   ║  [1] Gestión de Clientes                     ║");
    Console.WriteLine("   ║  [2] Gestión de Técnicos                     ║");
    Console.WriteLine("   ║  [3] Gestión de Repuestos                    ║");
    Console.WriteLine("   ║  [4] Gestión de Equipos                      ║");
    Console.WriteLine("   ║  [5] Gestión de Mantenimientos               ║");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("   ║  [6] Salir del Sistema                       ║");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("   ╚══════════════════════════════════════════════╝");

    Console.ResetColor();

    Console.Write("\n   Seleccione una opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcionPrincipal))
    {
        opcionPrincipal = 0;
    }

    switch (opcionPrincipal)
    {
        case 1:
            MenuClientes();
            break;

        case 2:
            MenuTecnicos();
            break;

        case 3:
            MenuRepuestos();
            break;

        case 4:
            MenuEquipos();
            break;

        case 5:
            MenuMantenimientos();
            break;

        case 6:
            MostrarSalida();
            break;

        default:
            MostrarError("Opción inválida.");
            break;
    }

} while (opcionPrincipal != 6);


// ================================================================
// ENCABEZADO PRINCIPAL
// ================================================================

void MostrarEncabezadoPrincipal()
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;

    Console.WriteLine();
    Console.WriteLine("      ███████╗██╗ ██████╗ ██████╗ ███████╗ ██████╗");
    Console.WriteLine("      ██╔════╝██║██╔════╝ ██╔══██╗██╔════╝██╔════╝");
    Console.WriteLine("      ███████╗██║██║  ███╗██████╔╝█████╗  ██║     ");
    Console.WriteLine("      ╚════██║██║██║   ██║██╔══██╗██╔══╝  ██║     ");
    Console.WriteLine("      ███████║██║╚██████╔╝██║  ██║███████╗╚██████╗");
    Console.WriteLine("      ╚══════╝╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝");

    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.WriteLine();
    Console.WriteLine("   ╔══════════════════════════════════════════════╗");
    Console.WriteLine("   ║ SISTEMA DE GESTIÓN DE REFRIGERACIÓN          ║");
    Console.WriteLine("   ║              Y CLIMATIZACIÓN                 ║");
    Console.WriteLine("   ╚══════════════════════════════════════════════╝");

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("      ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");

    Console.ResetColor();
}


// ================================================================
// MENÚ CLIENTES
// ================================================================

void MenuClientes()
{
    int opcion;

    do
    {
        Console.Clear();

        MostrarEncabezadoModulo(
            "GESTIÓN DE CLIENTES",
            "Administración y control de clientes");

        MostrarMenuCrud();

        Console.Write("\n   Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            opcion = 0;
        }

        switch (opcion)
        {
            case 1:
                CrearCliente();
                break;

            case 2:
                ListarClientes();
                break;

            case 3:
                BuscarCliente();
                break;

            case 4:
                ActualizarCliente();
                break;

            case 5:
                EliminarCliente();
                break;

            case 6:
                break;

            default:
                MostrarError("Opción inválida.");
                break;
        }

    } while (opcion != 6);
}


// ================================================================
// MENÚ TÉCNICOS
// ================================================================

void MenuTecnicos()
{
    int opcion;

    do
    {
        Console.Clear();

        MostrarEncabezadoModulo(
            "GESTIÓN DE TÉCNICOS",
            "Administración del personal técnico");

        MostrarMenuCrud();

        Console.Write("\n   Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            opcion = 0;
        }

        switch (opcion)
        {
            case 1:
                CrearTecnico();
                break;

            case 2:
                ListarTecnicos();
                break;

            case 3:
                BuscarTecnico();
                break;

            case 4:
                ActualizarTecnico();
                break;

            case 5:
                EliminarTecnico();
                break;

            case 6:
                break;

            default:
                MostrarError("Opción inválida.");
                break;
        }

    } while (opcion != 6);
}


// ================================================================
// MENÚ REPUESTOS
// ================================================================

void MenuRepuestos()
{
    int opcion;

    do
    {
        Console.Clear();

        MostrarEncabezadoModulo(
            "GESTIÓN DE REPUESTOS",
            "Control del inventario de repuestos");

        MostrarMenuCrud();

        Console.Write("\n   Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            opcion = 0;
        }

        switch (opcion)
        {
            case 1:
                CrearRepuesto();
                break;

            case 2:
                ListarRepuesto();
                break;

            case 3:
                BuscarRepuesto();
                break;

            case 4:
                ActualizarRepuesto();
                break;

            case 5:
                EliminarRepuesto();
                break;

            case 6:
                break;

            default:
                MostrarError("Opción inválida.");
                break;
        }

    } while (opcion != 6);
}


// ================================================================
// MENÚ EQUIPOS
// ================================================================

void MenuEquipos()
{
    int opcion;

    do
    {
        Console.Clear();

        MostrarEncabezadoModulo(
            "GESTIÓN DE EQUIPOS",
            "Control de equipos de refrigeración y climatización");

        MostrarMenuCrud();

        Console.Write("\n   Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            opcion = 0;
        }

        switch (opcion)
        {
            case 1:
                CrearEquipo();
                break;

            case 2:
                ListarEquipos();
                break;

            case 3:
                BuscarEquipo();
                break;

            case 4:
                ActualizarEquipo();
                break;

            case 5:
                EliminarEquipo();
                break;

            case 6:
                break;

            default:
                MostrarError("Opción inválida.");
                break;
        }

    } while (opcion != 6);
}


// ================================================================
// MENÚ MANTENIMIENTOS
// ================================================================

void MenuMantenimientos()
{
    int opcion;

    do
    {
        Console.Clear();

        MostrarEncabezadoModulo(
            "GESTIÓN DE MANTENIMIENTOS",
            "Control de mantenimientos preventivos y correctivos");

        MostrarMenuCrud();

        Console.Write("\n   Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            opcion = 0;
        }

        switch (opcion)
        {
            case 1:
                CrearMantenimiento();
                break;

            case 2:
                ListarMantenimientos();
                break;

            case 3:
                BuscarMantenimiento();
                break;

            case 4:
                ActualizarMantenimiento();
                break;

            case 5:
                EliminarMantenimiento();
                break;

            case 6:
                break;

            default:
                MostrarError("Opción inválida.");
                break;
        }

    } while (opcion != 6);
}


// ================================================================
// MENÚ CRUD GENÉRICO
// ================================================================

void MostrarMenuCrud()
{
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("   ╔══════════════════════════════════════╗");

    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.WriteLine("   ║  [1] Crear                           ║");
    Console.WriteLine("   ║  [2] Listar                          ║");
    Console.WriteLine("   ║  [3] Buscar                          ║");
    Console.WriteLine("   ║  [4] Actualizar                      ║");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("   ║  [5] Eliminar                        ║");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("   ║  [6] Volver al Menú Principal        ║");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("   ╚══════════════════════════════════════╝");

    Console.ResetColor();
}


// ================================================================
// ENCABEZADO SUBMENÚ
// ================================================================

void MostrarEncabezadoModulo(string titulo, string subtitulo)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;

    Console.WriteLine();
    Console.WriteLine("   ╔══════════════════════════════════════════════╗");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("   ║                    SIGREC                     ║");

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("   ╠══════════════════════════════════════════════╣");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"   ║  {titulo,-44}║");

    Console.ForegroundColor = ConsoleColor.Gray;

    if (subtitulo.Length > 44)
    {
        subtitulo = subtitulo.Substring(0, 44);
    }

    Console.WriteLine($"   ║  {subtitulo,-44}║");

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("   ╚══════════════════════════════════════════════╝");

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("      ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");

    Console.ResetColor();

    Console.WriteLine();
}


// ================================================================
// ERROR
// ================================================================

void MostrarError(string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine();
    Console.WriteLine("   ╔════════════════════════════════════════════╗");
    Console.WriteLine("   ║                  ERROR                     ║");
    Console.WriteLine("   ╚════════════════════════════════════════════╝");

    Console.WriteLine("\n   " + mensaje);

    Console.ResetColor();

    Console.WriteLine("\nPresione una tecla para continuar...");
    Console.ReadKey();
}


// ================================================================
// SALIDA
// ================================================================

void MostrarSalida()
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.DarkCyan;

    Console.WriteLine();
    Console.WriteLine("   ╔══════════════════════════════════════════════╗");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("   ║                    SIGREC                     ║");

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("   ╠══════════════════════════════════════════════╣");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("   ║       SISTEMA CERRADO CORRECTAMENTE          ║");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("   ║                                              ║");
    Console.WriteLine("   ║          Gracias por utilizar SIGREC         ║");

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("   ╚══════════════════════════════════════════════╝");

    Console.ResetColor();
}


// ================================================================
// CRUD CLIENTES
// ================================================================

void CrearCliente()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("         CREAR CLIENTE");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Console.Write("Ingrese cédula: ");
    string cedula = Console.ReadLine();

    Console.Write("Ingrese nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Ingrese teléfono: ");
    string telefono = Console.ReadLine();

    Console.Write("Ingrese dirección: ");
    string direccion = Console.ReadLine();

    Cliente cliente =
        new Cliente(
            cedula,
            nombre,
            telefono,
            direccion,
            id);

    Database.Clientes.Add(cliente);
    Database.GuardarClientes();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nCliente creado correctamente.");
    Console.ResetColor();

    Console.ReadKey();
}


void ListarClientes()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("        LISTAR CLIENTES");
    Console.WriteLine("=================================\n");

    if (Database.Clientes.Count == 0)
    {
        Console.WriteLine("No existen clientes registrados.");
    }
    else
    {
        foreach (Cliente cliente in Database.Clientes)
        {
            cliente.Imprimir();
            Console.WriteLine("-----------------------------------");
        }
    }

    Console.ReadKey();
}


void BuscarCliente()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("         BUSCAR CLIENTE");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese la cédula del cliente: ");
    string cedula = Console.ReadLine();

    Cliente cliente =
        Database.Clientes.Find(x => x.Cedula == cedula);

    if (cliente != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nCliente encontrado:");
        Console.ResetColor();

        cliente.Imprimir();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nCliente no encontrado.");
        Console.ResetColor();
    }

    Console.ReadKey();
}


void ActualizarCliente()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("       ACTUALIZAR CLIENTE");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese la cédula del cliente: ");
    string cedula = Console.ReadLine();

    Cliente cliente =
        Database.Clientes.Find(x => x.Cedula == cedula);

    if (cliente != null)
    {
        cliente.Imprimir();

        Console.Write("\nNuevo nombre: ");
        cliente.Nombre = Console.ReadLine();

        Console.Write("Nuevo teléfono: ");
        cliente.Telefono = Console.ReadLine();

        Console.Write("Nueva dirección: ");
        cliente.Direccion = Console.ReadLine();

        Database.GuardarClientes();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nCliente actualizado correctamente.");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("\nCliente no encontrado.");
    }

    Console.ReadKey();
}


void EliminarCliente()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("        ELIMINAR CLIENTE");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese la cédula: ");
    string cedula = Console.ReadLine();

    Cliente cliente =
        Database.Clientes.Find(x => x.Cedula == cedula);

    if (cliente != null)
    {
        cliente.Imprimir();

        Console.Write("\n¿Desea eliminar este cliente? S/N: ");

        if (Console.ReadLine()?.ToUpper() == "S")
        {
            Database.Clientes.Remove(cliente);
            Database.GuardarClientes();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCliente eliminado correctamente.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\nOperación cancelada.");
        }
    }
    else
    {
        Console.WriteLine("\nCliente no encontrado.");
    }

    Console.ReadKey();
}


// ================================================================
// CRUD TÉCNICOS
// ================================================================

void CrearTecnico()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("          CREAR TÉCNICO");
    Console.WriteLine("=================================\n");

    Console.Write("ID del técnico: ");
    int.TryParse(Console.ReadLine(), out int id);

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Cédula: ");
    string cedula = Console.ReadLine();

    Console.Write("Teléfono: ");
    string telefono = Console.ReadLine();

    Console.Write("Especialidad: ");
    string especialidad = Console.ReadLine();

    Console.Write("Años de experiencia: ");
    int.TryParse(Console.ReadLine(), out int experiencia);

    Tecnico tecnico =
        new Tecnico(
            id,
            nombre,
            cedula,
            telefono,
            especialidad,
            experiencia);

    Database.Tecnicos.Add(tecnico);
    Database.GuardarTecnicos();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nTécnico creado correctamente.");
    Console.ResetColor();

    Console.ReadKey();
}


void ListarTecnicos()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("         LISTAR TÉCNICOS");
    Console.WriteLine("=================================\n");

    if (Database.Tecnicos.Count == 0)
    {
        Console.WriteLine("No existen técnicos registrados.");
    }
    else
    {
        foreach (Tecnico tecnico in Database.Tecnicos)
        {
            tecnico.Imprimir();
            Console.WriteLine("-----------------------------------");
        }
    }

    Console.ReadKey();
}


void BuscarTecnico()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("         BUSCAR TÉCNICO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese la cédula del técnico: ");
    string cedula = Console.ReadLine();

    Tecnico tecnico =
        Database.Tecnicos.Find(x => x.Cedula == cedula);

    if (tecnico != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nTécnico encontrado:");
        Console.ResetColor();

        tecnico.Imprimir();
    }
    else
    {
        Console.WriteLine("\nTécnico no encontrado.");
    }

    Console.ReadKey();
}


void ActualizarTecnico()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("       ACTUALIZAR TÉCNICO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese la cédula del técnico: ");
    string cedula = Console.ReadLine();

    Tecnico tecnico =
        Database.Tecnicos.Find(x => x.Cedula == cedula);

    if (tecnico != null)
    {
        tecnico.Imprimir();

        Console.Write("\nNuevo nombre: ");
        tecnico.Nombre = Console.ReadLine();

        Console.Write("Nueva cédula: ");
        tecnico.Cedula = Console.ReadLine();

        Console.Write("Nuevo teléfono: ");
        tecnico.Telefono = Console.ReadLine();

        Console.Write("Nueva especialidad: ");
        tecnico.Especialidad = Console.ReadLine();

        Console.Write("Nuevos años de experiencia: ");

        if (int.TryParse(Console.ReadLine(), out int experiencia))
        {
            tecnico.Experiencia = experiencia;
        }

        Database.GuardarTecnicos();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nTécnico actualizado correctamente.");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("\nTécnico no encontrado.");
    }

    Console.ReadKey();
}


void EliminarTecnico()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("        ELIMINAR TÉCNICO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese la cédula del técnico: ");
    string cedula = Console.ReadLine();

    Tecnico tecnico =
        Database.Tecnicos.Find(x => x.Cedula == cedula);

    if (tecnico != null)
    {
        tecnico.Imprimir();

        Console.Write("\n¿Desea eliminar este técnico? S/N: ");

        if (Console.ReadLine()?.ToUpper() == "S")
        {
            Database.Tecnicos.Remove(tecnico);
            Database.GuardarTecnicos();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTécnico eliminado correctamente.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\nOperación cancelada.");
        }
    }
    else
    {
        Console.WriteLine("\nTécnico no encontrado.");
    }

    Console.ReadKey();
}


// ================================================================
// CRUD REPUESTOS
// ================================================================

void CrearRepuesto()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("         CREAR REPUESTO");
    Console.WriteLine("=================================\n");

    Console.Write("ID: ");
    int.TryParse(Console.ReadLine(), out int id);

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Marca: ");
    string marca = Console.ReadLine();

    Console.Write("Tipo: ");
    string tipo = Console.ReadLine();

    Console.Write("Cantidad: ");
    int.TryParse(Console.ReadLine(), out int cantidad);

    Console.Write("Precio: ");
    decimal.TryParse(Console.ReadLine(), out decimal precio);

    Repuesto repuesto =
        new Repuesto(
            id,
            nombre,
            marca,
            tipo,
            cantidad,
            precio);

    Database.Repuestos.Add(repuesto);
    Database.GuardarRepuestos();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nRepuesto creado correctamente.");
    Console.ResetColor();

    Console.ReadKey();
}


void ListarRepuesto()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("        LISTAR REPUESTOS");
    Console.WriteLine("=================================\n");

    if (Database.Repuestos.Count == 0)
    {
        Console.WriteLine("No existen repuestos registrados.");
    }
    else
    {
        foreach (Repuesto repuesto in Database.Repuestos)
        {
            repuesto.Imprimir();
            Console.WriteLine("-----------------------------------");
        }
    }

    Console.ReadKey();
}


void BuscarRepuesto()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("         BUSCAR REPUESTO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese el ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Repuesto repuesto =
        Database.Repuestos.Find(r => r.Id == id);

    if (repuesto != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nRepuesto encontrado:");
        Console.ResetColor();

        repuesto.Imprimir();
    }
    else
    {
        Console.WriteLine("\nRepuesto no encontrado.");
    }

    Console.ReadKey();
}


void ActualizarRepuesto()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("       ACTUALIZAR REPUESTO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese el ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Repuesto repuesto =
        Database.Repuestos.Find(r => r.Id == id);

    if (repuesto != null)
    {
        repuesto.Imprimir();

        Console.Write("\nNuevo nombre: ");
        repuesto.Nombre = Console.ReadLine();

        Console.Write("Nueva marca: ");
        repuesto.Marca = Console.ReadLine();

        Console.Write("Nuevo tipo: ");
        repuesto.TipoRepuesto = Console.ReadLine();

        Console.Write("Nueva cantidad: ");
        int.TryParse(Console.ReadLine(), out int cantidad);
        repuesto.Cantidad = cantidad;

        Console.Write("Nuevo precio: ");
        decimal.TryParse(Console.ReadLine(), out decimal precio);
        repuesto.Precio = precio;

        Database.GuardarRepuestos();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nRepuesto actualizado correctamente.");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("\nRepuesto no encontrado.");
    }

    Console.ReadKey();
}


void EliminarRepuesto()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("        ELIMINAR REPUESTO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese el ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Repuesto repuesto =
        Database.Repuestos.Find(r => r.Id == id);

    if (repuesto != null)
    {
        repuesto.Imprimir();

        Console.Write("\n¿Desea eliminar este repuesto? S/N: ");

        if (Console.ReadLine()?.ToUpper() == "S")
        {
            Database.Repuestos.Remove(repuesto);
            Database.GuardarRepuestos();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRepuesto eliminado correctamente.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\nOperación cancelada.");
        }
    }
    else
    {
        Console.WriteLine("\nRepuesto no encontrado.");
    }

    Console.ReadKey();
}


// ================================================================
// CRUD EQUIPOS
// ================================================================

void CrearEquipo()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("          CREAR EQUIPO");
    Console.WriteLine("=================================\n");

    Console.Write("Código: ");
    string codigo = Console.ReadLine();

    Console.Write("Marca: ");
    string marca = Console.ReadLine();

    Console.Write("Modelo: ");
    string modelo = Console.ReadLine();

    Console.Write("Capacidad BTU: ");
    int.TryParse(Console.ReadLine(), out int capacidad);

    Console.Write("Estado: ");
    string estado = Console.ReadLine();

    Console.Write("Tipo de filtro: ");
    string tipoFiltro = Console.ReadLine();

    AireAcondicionado equipo =
        new AireAcondicionado(
            codigo,
            marca,
            modelo,
            capacidad,
            estado,
            tipoFiltro);

    Database.AireAcondicionados.Add(equipo);
    Database.Equipos.Add(equipo);

    Database.GuardarAiresAcondicionados();
    Database.GuardarEquipos();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nEquipo creado correctamente.");
    Console.ResetColor();

    Console.ReadKey();
}


void ListarEquipos()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("         LISTAR EQUIPOS");
    Console.WriteLine("=================================\n");

    if (Database.Equipos.Count == 0)
    {
        Console.WriteLine("No existen equipos registrados.");
    }
    else
    {
        foreach (Equipo equipo in Database.Equipos)
        {
            equipo.Imprimir();
            Console.WriteLine("-----------------------------------");
        }
    }

    Console.ReadKey();
}


void BuscarEquipo()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("          BUSCAR EQUIPO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese el código: ");
    string codigo = Console.ReadLine();

    AireAcondicionado equipo =
        Database.AireAcondicionados.Find(
            x => x.Codigo.Equals(
                codigo,
                StringComparison.OrdinalIgnoreCase));

    if (equipo != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nEquipo encontrado:");
        Console.ResetColor();

        equipo.Imprimir();
    }
    else
    {
        Console.WriteLine("\nEquipo no encontrado.");
    }

    Console.ReadKey();
}


void ActualizarEquipo()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("       ACTUALIZAR EQUIPO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese el código: ");
    string codigo = Console.ReadLine();

    AireAcondicionado equipo =
        Database.AireAcondicionados.Find(
            x => x.Codigo.Equals(
                codigo,
                StringComparison.OrdinalIgnoreCase));

    if (equipo != null)
    {
        equipo.Imprimir();

        Console.Write("\nNueva marca: ");
        equipo.Marca = Console.ReadLine();

        Console.Write("Nuevo modelo: ");
        equipo.Modelo = Console.ReadLine();

        Console.Write("Nuevo estado: ");
        equipo.Estado = Console.ReadLine();

        Database.GuardarAiresAcondicionados();
        Database.GuardarEquipos();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nEquipo actualizado correctamente.");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("\nEquipo no encontrado.");
    }

    Console.ReadKey();
}


void EliminarEquipo()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("        ELIMINAR EQUIPO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese el código: ");
    string codigo = Console.ReadLine();

    Equipo equipo =
        Database.Equipos.Find(
            x => x.Codigo.Equals(
                codigo,
                StringComparison.OrdinalIgnoreCase));

    if (equipo != null)
    {
        equipo.Imprimir();

        Console.Write("\n¿Desea eliminar este equipo? S/N: ");

        if (Console.ReadLine()?.ToUpper() == "S")
        {
            Database.Equipos.Remove(equipo);

            AireAcondicionado aire =
                Database.AireAcondicionados.Find(
                    x => x.Codigo.Equals(
                        codigo,
                        StringComparison.OrdinalIgnoreCase));

            if (aire != null)
            {
                Database.AireAcondicionados.Remove(aire);
                Database.GuardarAiresAcondicionados();
            }

            Database.GuardarEquipos();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEquipo eliminado correctamente.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\nOperación cancelada.");
        }
    }
    else
    {
        Console.WriteLine("\nEquipo no encontrado.");
    }

    Console.ReadKey();
}


// ================================================================
// CRUD MANTENIMIENTOS
// ================================================================

void CrearMantenimiento()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("      CREAR MANTENIMIENTO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Mantenimiento existente =
        Database.Mantenimientos.Find(m => m.Id == id);

    if (existente != null)
    {
        MostrarError("Ya existe un mantenimiento con ese ID.");
        return;
    }

    Console.Write("Código del equipo: ");
    string codigoEquipo = Console.ReadLine();

    Equipo equipo =
        Database.Equipos.Find(
            e => e.Codigo.Equals(
                codigoEquipo,
                StringComparison.OrdinalIgnoreCase));

    if (equipo == null)
    {
        MostrarError("El equipo ingresado no existe.");
        return;
    }

    Console.Write("Tipo (Preventivo/Correctivo): ");
    string tipo = Console.ReadLine();

    Console.Write("Descripción: ");
    string descripcion = Console.ReadLine();

    Console.Write("Costo: ");

    if (!decimal.TryParse(Console.ReadLine(), out decimal costo))
    {
        MostrarError("Costo inválido.");
        return;
    }

    Console.Write("Estado (Pendiente/Completado): ");
    string estado = Console.ReadLine();

    Console.Write("Duración en horas: ");

    if (!int.TryParse(Console.ReadLine(), out int duracion))
    {
        MostrarError("Duración inválida.");
        return;
    }

    Mantenimiento mantenimiento =
        new Mantenimiento(
            id,
            codigoEquipo,
            tipo,
            descripcion,
            costo,
            estado,
            duracion);

    Database.Mantenimientos.Add(mantenimiento);
    Database.GuardarMantenimientos();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nMantenimiento creado correctamente.");
    Console.ResetColor();

    Console.ReadKey();
}


void ListarMantenimientos()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("      LISTAR MANTENIMIENTOS");
    Console.WriteLine("=================================\n");

    if (Database.Mantenimientos.Count == 0)
    {
        Console.WriteLine("No existen mantenimientos registrados.");
    }
    else
    {
        foreach (Mantenimiento mantenimiento
                 in Database.Mantenimientos)
        {
            mantenimiento.Imprimir();

            Console.WriteLine("-----------------------------------");
        }
    }

    Console.ReadKey();
}


void BuscarMantenimiento()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("       BUSCAR MANTENIMIENTO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Mantenimiento mantenimiento =
        Database.Mantenimientos.Find(m => m.Id == id);

    if (mantenimiento != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nMantenimiento encontrado:");
        Console.ResetColor();

        mantenimiento.Imprimir();
    }
    else
    {
        Console.WriteLine("\nMantenimiento no encontrado.");
    }

    Console.ReadKey();
}


void ActualizarMantenimiento()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("     ACTUALIZAR MANTENIMIENTO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Mantenimiento mantenimiento =
        Database.Mantenimientos.Find(m => m.Id == id);

    if (mantenimiento != null)
    {
        mantenimiento.Imprimir();

        Console.Write(
            $"\nNuevo tipo ({mantenimiento.TipoMantenimiento}): ");

        string tipo = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(tipo))
        {
            mantenimiento.TipoMantenimiento = tipo;
        }

        Console.Write(
            $"Nueva descripción ({mantenimiento.Descripcion}): ");

        string descripcion = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(descripcion))
        {
            mantenimiento.Descripcion = descripcion;
        }

        Console.Write(
            $"Nuevo costo (${mantenimiento.Costo}): ");

        string costoTexto = Console.ReadLine();

        if (decimal.TryParse(costoTexto, out decimal costo))
        {
            mantenimiento.Costo = costo;
        }

        Console.Write(
            $"Nuevo estado ({mantenimiento.Estado}): ");

        string estado = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(estado))
        {
            mantenimiento.Estado = estado;
        }

        Console.Write(
            $"Nueva duración ({mantenimiento.DuracionHoras} horas): ");

        string duracionTexto = Console.ReadLine();

        if (int.TryParse(duracionTexto, out int duracion))
        {
            mantenimiento.DuracionHoras = duracion;
        }

        Database.GuardarMantenimientos();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nMantenimiento actualizado correctamente.");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("\nMantenimiento no encontrado.");
    }

    Console.ReadKey();
}


void EliminarMantenimiento()
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("      ELIMINAR MANTENIMIENTO");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Mantenimiento mantenimiento =
        Database.Mantenimientos.Find(m => m.Id == id);

    if (mantenimiento != null)
    {
        mantenimiento.Imprimir();

        Console.Write(
            "\n¿Desea eliminar este mantenimiento? S/N: ");

        if (Console.ReadLine()?.ToUpper() == "S")
        {
            Database.Mantenimientos.Remove(mantenimiento);
            Database.GuardarMantenimientos();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMantenimiento eliminado correctamente.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\nOperación cancelada.");
        }
    }
    else
    {
        Console.WriteLine("\nMantenimiento no encontrado.");
    }

    Console.ReadKey();
}