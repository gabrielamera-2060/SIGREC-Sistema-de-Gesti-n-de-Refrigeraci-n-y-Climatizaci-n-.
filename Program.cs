using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Generales;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;


Database.CargarDatos();
int opcion = 0;
do
{
    Console.Clear();
    Console.WriteLine("========================================");
    Console.WriteLine("               SIGREC");
    Console.WriteLine(" Sistema de Refrigeracion y Climatizacion");
    Console.WriteLine("========================================");
    Console.WriteLine("Menú de Opciones:\n");

    Console.WriteLine("1.- Crear Cliente");
    Console.WriteLine("2.- Listar Clientes");
    Console.WriteLine("3.- Buscar Cliente");
    Console.WriteLine("4.- Actualizar Cliente");
    Console.WriteLine("5.- Eliminar Cliente");

    Console.WriteLine("6.- Crear Técnico");
    Console.WriteLine("7.- Listar Técnicos");
    Console.WriteLine("8.- Buscar Técnico");
    Console.WriteLine("9.- Actualizar Técnico");
    Console.WriteLine("10.- Eliminar Técnico");

    Console.WriteLine("11.- Crear Repuesto");
    Console.WriteLine("12.- Listar Repuestos");
    Console.WriteLine("13.- Buscar Repuesto");
    Console.WriteLine("14.- Actualizar Repuesto");
    Console.WriteLine("15.- Eliminar Repuesto");

    Console.WriteLine("16.- Crear Equipo");
    Console.WriteLine("17.- Listar Equipos");
    Console.WriteLine("18.- Buscar Equipo");
    Console.WriteLine("19.- Actualizar Equipo");
    Console.WriteLine("20.- Eliminar Equipo");

    Console.WriteLine("21.- Crear Mantenimiento");
    Console.WriteLine("22.- Listar Mantenimientos");
    Console.WriteLine("23.- Buscar Mantenimiento");
    Console.WriteLine("24.- Actualizar Mantenimiento");
    Console.WriteLine("25.- Eliminar Mantenimiento");

    Console.WriteLine("26.- Salir\n");
    Console.Write("Ingrese una opción: ");
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
            CrearTecnico(); 
            break;
        case 7: 
            ListarTecnicos(); 
            break;
        case 8: 
            BuscarTecnico(); 
            break;
        case 9: 
            ActualizarTecnico(); 
            break;
        case 10: 
            EliminarTecnico(); 
            break;

        case 11: 
            CrearRepuesto(); 
            break;
        case 12: 
            ListarRepuesto(); 
            break;
        case 13: 
            BuscarRepuesto(); 
            break;
        case 14: 
            ActualizarRepuesto(); 
            break;
        case 15: 
            EliminarRepuesto(); 
            break;
        case 16: 
            CrearEquipo(); 
            break; 
        case 17: 
            ListarEquipos(); 
            break;
        case 18: 
            BuscarEquipo(); 
            break;
        case 19: 
            ActualizarEquipo(); 
            break;
        case 20: 
            EliminarEquipo(); 
            break;

        case 21: 
            CrearMantenimiento(); 
            break;
        case 22: 
            ListarMantenimientos(); 
            break;
        case 23: 
            BuscarMantenimiento(); 
            break;
        case 24: 
            ActualizarMantenimiento(); 
            break;
        case 25: 
            EliminarMantenimiento(); 
            break;
        case 26:
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
    Console.ReadLine();
} while (opcion != 26);

void EliminarRepuesto()
{
    Console.Clear();
    Console.WriteLine("===== ELIMINAR REPUESTO =====");
    Console.Write("Ingrese el ID: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Repuesto repuesto = Database.Repuestos.Find(r => r.Id == id);
        if (repuesto == null)
        {
            Console.WriteLine("No existe ese repuesto.");
        }
        else
        {
            Database.Repuestos.Remove(repuesto);
            Database.GuardarRepuestos();
            Console.WriteLine("Repuesto eliminado correctamente.");
        }
    }
    Console.ReadKey();
}

void ActualizarRepuesto()
{
    Console.Clear();
    Console.WriteLine("===== EDITAR REPUESTO =====");
    Console.Write("Ingrese el ID del repuesto: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Repuesto repuesto = Database.Repuestos.Find(r => r.Id == id);
        if (repuesto == null)
        {
            Console.WriteLine("No existe ese repuesto.");
            Console.ReadKey();
            return;
        }

        Console.Write("Nuevo Nombre: ");
        repuesto.Nombre = Console.ReadLine();

        Console.Write("Nueva Marca: ");
        repuesto.Marca = Console.ReadLine();

        Console.Write("Nuevo Tipo: ");
        repuesto.TipoRepuesto = Console.ReadLine();

        Console.Write("Nueva Cantidad: ");
        int.TryParse(Console.ReadLine(), out int cantidad);
        repuesto.Cantidad = cantidad;

        Console.Write("Nuevo Precio: ");
        decimal.TryParse(Console.ReadLine(), out decimal precio);
        repuesto.Precio = precio;

        Database.GuardarRepuestos();
        Console.WriteLine("Repuesto actualizado correctamente.");
    }
    Console.ReadKey();
}

void BuscarRepuesto()
{
    Console.Clear();
    Console.WriteLine("===== BUSCAR REPUESTO =====");
    Console.Write("Ingrese el ID del repuesto: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        Repuesto repuesto = Database.Repuestos.Find(r => r.Id == id);
        if (repuesto == null)
        {
            Console.WriteLine("\nNo se encontró el repuesto.");
        }
        else
        {
            Console.WriteLine("\nRepuesto encontrado:");
            Console.WriteLine("-----------------------------");
            repuesto.Imprimir();
        }
    }
    Console.ReadKey();
}

void ListarRepuesto()
{
    Console.Clear();
    Console.WriteLine("===== LISTA DE REPUESTOS =====");
    if (Database.Repuestos.Count == 0)
    {
        Console.WriteLine("No existen repuestos registrados.");
    }
    else
    {
        foreach (var repuesto in Database.Repuestos)
        {
            repuesto.Imprimir();
            Console.WriteLine("----------------------------");
        }
    }
    Console.ReadKey();
}

void CrearRepuesto()
{
    Console.Clear();
    Console.WriteLine("===== REGISTRAR REPUESTO =====");
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

    Repuesto nuevo = new Repuesto(id, nombre, marca, tipo, cantidad, precio);
    Database.Repuestos.Add(nuevo);
    Database.GuardarRepuestos();
    Console.WriteLine("\nRepuesto registrado correctamente.");
    Console.ReadKey();
}

void CrearCliente()
{
    Console.Clear();
    Console.WriteLine("******** CREAR CLIENTE ********");
    Console.Write("Ingrese ID: ");
    int.TryParse(Console.ReadLine(), out int id);

    Console.Write("Ingrese cédula: ");
    string cedula = Console.ReadLine();

    Console.Write("Ingrese nombre: "); 
    string nombre = Console.ReadLine();

    Console.Write("Ingrese teléfono: "); 
    string telefono = Console.ReadLine();

    Console.Write("Ingrese dirección: ");
    string direccion = Console.ReadLine();

    Cliente cliente = new Cliente(cedula, nombre, telefono, direccion, id);
    Database.Clientes.Add(cliente);
    Database.GuardarClientes();
    Console.WriteLine("Cliente creado correctamente.");
    Console.ReadLine();
}

void ListarClientes()
{
    Console.Clear();
    Console.WriteLine("******** CLIENTES REGISTRADOS ********");
    foreach (Cliente cliente in Database.Clientes)
    {
        cliente.Imprimir();
        Console.WriteLine("-----------------------------------");
    }
    Console.ReadLine();
}

void BuscarCliente()
{
    Console.Clear();
    Console.WriteLine("******** BUSCAR CLIENTE ********");
    Console.Write("Ingrese la cédula del cliente: ");
    string cedula = Console.ReadLine();
    Cliente objCliente = Database.Clientes.Find(x => x.Cedula == cedula);
    if (objCliente != null)
    {
        Console.WriteLine("Cliente encontrado:");
        objCliente.Imprimir();
    }
    else
    {
        Console.WriteLine("Cliente no encontrado.");
    }
    Console.ReadLine();
}

void ActualizarCliente()
{
    Console.Clear();
    Console.WriteLine("******** ACTUALIZAR CLIENTE ********");
    Console.Write("Ingrese la cédula del cliente: ");
    string cedula = Console.ReadLine();
    Cliente objCliente = Database.Clientes.Find(x => x.Cedula == cedula);
    if (objCliente != null)
    {
        Console.Write("Nuevo nombre: ");
        objCliente.Nombre = Console.ReadLine();

        Console.Write("Nuevo teléfono: ");
        objCliente.Telefono = Console.ReadLine();

        Console.Write("Nueva dirección: ");
        objCliente.Direccion = Console.ReadLine();

        Database.GuardarClientes();
        Console.WriteLine("Cliente actualizado correctamente.");
    }
    else
    {
        Console.WriteLine("Cliente no encontrado.");
    }
    Console.ReadLine();
}

void EliminarCliente()
{
    Console.Clear();
    Console.WriteLine("******** ELIMINAR CLIENTE ********");
    Console.Write("Ingrese la cédula del cliente: ");
    string cedula = Console.ReadLine();
    Cliente objCliente = Database.Clientes.Find(x => x.Cedula == cedula);
    if (objCliente != null)
    {
        objCliente.Imprimir();
        Console.WriteLine("¿Desea eliminar este cliente? S/N");
        if (Console.ReadLine()?.ToUpper() == "S")
        {
            Database.Clientes.Remove(objCliente);
            Database.GuardarClientes();
            Console.WriteLine("Cliente eliminado.");
        }
        else
        {
            Console.WriteLine("Operación cancelada.");
        }
    }
    else
    {
        Console.WriteLine("Cliente no encontrado.");
    }
    Console.ReadLine();
}

void CrearTecnico()
{
    Console.Clear();
    Console.WriteLine("******** CREAR TÉCNICO ********");
    Console.Write("ID del técnico: ");
    int.TryParse(Console.ReadLine(), out int id);

    Console.Write("Nombre del técnico: ");
    string nombre = Console.ReadLine();

    Console.Write("Teléfono: ");
    string telefono = Console.ReadLine();

    Console.Write("Especialidad: ");
    string especialidad = Console.ReadLine();

    Console.Write("Años de experiencia: ");
    int.TryParse(Console.ReadLine(), out int experiencia);

    
    Tecnico tecnico = new Tecnico(id, nombre, telefono, especialidad, experiencia.ToString());
    Database.Tecnicos.Add(tecnico);
    Database.GuardarTecnicos();
    Console.WriteLine("Técnico creado correctamente.");
    Console.ReadLine();
}

void ListarTecnicos()
{
    Console.Clear();
    Console.WriteLine("******** TÉCNICOS REGISTRADOS ********");
    foreach (Tecnico tecnico in Database.Tecnicos)
    {
        tecnico.Imprimir();
        Console.WriteLine("-----------------------------------");
    }
    Console.ReadLine();
}

void BuscarTecnico()
{
    Console.Clear();
    Console.WriteLine("******** BUSCAR TÉCNICO ********");
    Console.Write("Ingrese el nombre del técnico: ");
    string nombre = Console.ReadLine();
    Tecnico tecnico = Database.Tecnicos.Find(x => x.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    if (tecnico != null)
    {
        tecnico.Imprimir();
    }
    else
    {
        Console.WriteLine("Técnico no encontrado.");
    }
    Console.ReadLine();
}

void ActualizarTecnico()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("    ACTUALIZAR TECNICO   ");
    Console.WriteLine("=================================\n");
    Console.Write("Ingrese nombre del técnico: ");
    string nombre = Console.ReadLine();
    Tecnico tecnico = Database.Tecnicos.Find(x => x.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    if (tecnico != null)
    {
        Console.Write("Nueva especialidad: ");
        tecnico.Especialidad = Console.ReadLine();
        Database.GuardarTecnicos();
        Console.WriteLine("Técnico actualizado.");
    }
    else
    {
        Console.WriteLine("Técnico no encontrado.");
    }
    Console.ReadLine();
}

void EliminarTecnico()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("   ELIMINAR TECNICO    ");
    Console.WriteLine("=================================\n");
    Console.Write("Nombre del técnico: ");
    string nombre = Console.ReadLine();

    Tecnico tecnico = Database.Tecnicos.Find(x => x.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

    if (tecnico != null)
    {
        Database.Tecnicos.Remove(tecnico);
        Database.GuardarTecnicos();
        Console.WriteLine("Técnico eliminado.");
    }
    else
    {
        Console.WriteLine("Técnico no encontrado.");
    }
    Console.ReadLine();
}

void CrearEquipo() 
{
    void CrearEquipo()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("    Crear Equipo    ");
        Console.WriteLine("=================================\n");

        Console.Write("Código: ");
        string codigo = Console.ReadLine();

        Console.Write("Marca: ");
        string marca = Console.ReadLine();

        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();

        Console.Write("Capacidad BTU: ");
        int.TryParse(Console.ReadLine(), out int capacidad);

        Console.Write("Estado (Ej: Operativo / En Reparación): ");
        string estado = Console.ReadLine();

        Console.Write("Tipo de filtro (Ej: Estándar / HEPA): ");
        string tipoFiltro = Console.ReadLine();

        AireAcondicionado equipo = new AireAcondicionado(codigo, marca, modelo, capacidad, estado, tipoFiltro);

        Database.AireAcondicionados.Add(equipo);
        Database.Equipos.Add(equipo);

        Database.GuardarAiresAcondicionados();
        Database.GuardarEquipos();

        Console.WriteLine("\n¡Equipo creado y guardado correctamente!");
        Console.ReadLine();
    }
}

void ListarEquipos()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("    LISTAR EQUIPO    ");
    Console.WriteLine("=================================\n");
    foreach (Equipo equipo in Database.Equipos)
    {
        equipo.Imprimir();
        Console.WriteLine("-----------------------------------");
    }
    Console.ReadLine();
}

void BuscarEquipo()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("    BUSCAR EQUIPO   ");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese el código: ");
    string codigo = Console.ReadLine();

    
    AireAcondicionado equipo = Database.AireAcondicionados.Find(x => x.Codigo == codigo);

    if (equipo != null)
    {
        Console.WriteLine("Equipo encontrado:");
        equipo.Imprimir();
    }
    else
    {
        Console.WriteLine("Equipo no encontrado.");
    }
    Console.ReadLine();
}

void ActualizarEquipo()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("  ACTUALIZAR EQUIPO    ");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese el código: ");
    string codigo = Console.ReadLine();

    AireAcondicionado equipo = Database.AireAcondicionados.Find(x => x.Codigo == codigo);

    if (equipo != null)
    {
        Console.Write("Nueva marca: ");
        equipo.Marca = Console.ReadLine();

        Console.Write("Nuevo modelo: ");
        equipo.Modelo = Console.ReadLine();

        Console.Write("Nuevo estado: ");
        equipo.Estado = Console.ReadLine();

        Database.GuardarAiresAcondicionados();
        Console.WriteLine("Equipo actualizado correctamente.");
    }
    else
    {
        Console.WriteLine("Equipo no encontrado.");
    }
    Console.ReadLine();
}

void EliminarEquipo()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("    ELIMINAR EQUIPO    ");
    Console.WriteLine("=================================\n");
    Console.Write("Ingrese el código del equipo: ");
    string codigo = Console.ReadLine();

    Equipo equipo = Database.Equipos.Find(x => x.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));

    if (equipo != null)
    {
        equipo.Imprimir();
        Console.WriteLine("¿Desea eliminar este equipo? S/N");

        if (Console.ReadLine()?.ToUpper() == "S")
        {
            Database.Equipos.Remove(equipo);
            Database.GuardarEquipos();
            Console.WriteLine("Equipo eliminado correctamente.");
        }
    }
    else
    {
        Console.WriteLine("Equipo no encontrado.");
    }
    Console.ReadLine();
}

static void CrearMantenimiento()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("     REGISTRAR MANTENIMIENTO     ");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese ID del mantenimiento: ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("Ingrese Código del Equipo: ");
    string codigoEquipo = Console.ReadLine();

    Console.Write("Ingrese Descripción del trabajo: ");
    string descripcion = Console.ReadLine();

    Console.Write("Ingrese Costo ($): ");
    double costo = double.Parse(Console.ReadLine());

    Console.Write("Ingrese Estado (Pendiente/Completado): ");
    string estado = Console.ReadLine();

    Console.WriteLine("\n¡Mantenimiento registrado con éxito!");
    Console.ReadKey();
}

static void ListarMantenimientos()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("    LISTAR MANTENIMIENTO    ");
    Console.WriteLine("=================================\n");
    
    Console.ReadLine();
    if (Database.Mantenimientos.Count == 1)
    {
        Console.WriteLine("No hay mantenimientos registrados.");
    }
    else
    {
        foreach (Mantenimiento mantenimiento in Database.Mantenimientos)
        {
            Mantenimiento.Imprimir();
            Console.WriteLine("-----------------------------------");
        }
        Console.ReadLine();
    }
    Console.ReadKey();
}

static void BuscarMantenimiento()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("       BUSCAR MANTENIMIENTO      ");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese ID del mantenimiento a buscar: ");
    int id = int.Parse(Console.ReadLine());

    Mantenimiento encontrado = Database.Mantenimientos.Find(m => m.Id == id);

    if (encontrado != null)
    {
        Console.WriteLine("\n¡Mantenimiento encontrado!\n");
        encontrado.Imprimir();
    }
    else
    {
        Console.WriteLine("\nNo se encontró ningún mantenimiento con ese ID.");
    }
    Console.ReadKey();
}

static void ActualizarMantenimiento()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("     ACTUALIZAR MANTENIMIENTO    ");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese ID del mantenimiento a actualizar: ");
    int id = int.Parse(Console.ReadLine());

    Mantenimiento m = Database.Mantenimientos.Find(x => x.Id == id);

    if (m != null)
    {
        Console.Write($"Nueva Descripción (Actual: {m.Descripcion}): ");
        string nuevaDesc = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevaDesc)) m.Descripcion = nuevaDesc;

        Console.Write($"Nuevo Costo (Actual: ${m.Costo}): ");
        string nuevoCostoStr = Console.ReadLine();
        if (decimal.TryParse(nuevoCostoStr, out decimal nuevoCosto)) m.Costo = nuevoCosto;

        Console.Write($"Nuevo Estado (Actual: {m.Estado}): ");
        string nuevoEstado = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoEstado)) m.Estado = nuevoEstado;

        Console.WriteLine("\n¡Mantenimiento actualizado con éxito!");
    }
    else
    {
        Console.WriteLine("\nNo se encontró el mantenimiento.");
    }
    Console.ReadKey();
}

static void EliminarMantenimiento()
{
    Console.Clear();
    Console.WriteLine("=================================");
    Console.WriteLine("      ELIMINAR MANTENIMIENTO     ");
    Console.WriteLine("=================================\n");

    Console.Write("Ingrese ID del mantenimiento a eliminar: ");
    int id = int.Parse(Console.ReadLine());

    Mantenimiento m = Database.Mantenimientos.Find(x => x.Id == id);

    if (m != null)
    {
        Database.Mantenimientos.Remove(m);
        Console.WriteLine("\n¡Mantenimiento eliminado con éxito!");
    }
    else
    {
        Console.WriteLine("\nNo se encontró el mantenimiento.");
    }
    Console.ReadKey();
}
