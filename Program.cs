using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Generales;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;


// ================================================================
// INICIO DEL SISTEMA
// ================================================================

Database.CargarDatos();

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Title = "SIGREC - Sistema de Gestión de Refrigeración y Climatización";

int opcionPrincipal;

do
{
    Console.Clear();

    MostrarEncabezadoPrincipal();

    MostrarMenuPrincipal();

    opcionPrincipal = LeerOpcionCentrada("Seleccione una opción");

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
            MostrarError("Opción inválida. Intente nuevamente.");
            break;
    }

} while (opcionPrincipal != 6);


// ================================================================
// MENÚ PRINCIPAL
// ================================================================

void MostrarMenuPrincipal()
{
    int ancho = ObtenerAnchoCaja(80);

    Console.WriteLine();

    DibujarBordeSuperior(ancho);

    EscribirFilaCentrada(
        "MENÚ PRINCIPAL",
        ancho,
        ConsoleColor.White);

    DibujarSeparador(ancho);

    EscribirFila(
        "[1]  Gestión de Clientes",
        ancho,
        ConsoleColor.Cyan);

    EscribirFila(
        "[2]  Gestión de Técnicos",
        ancho,
        ConsoleColor.Cyan);

    EscribirFila(
        "[3]  Gestión de Repuestos",
        ancho,
        ConsoleColor.Cyan);

    EscribirFila(
        "[4]  Gestión de Equipos",
        ancho,
        ConsoleColor.Cyan);

    EscribirFila(
        "[5]  Gestión de Mantenimientos",
        ancho,
        ConsoleColor.Cyan);

    EscribirFila(
        "[6]  Salir del Sistema",
        ancho,
        ConsoleColor.Red);

    DibujarBordeInferior(ancho);

    Console.ResetColor();
}


// ================================================================
// SUBMENÚ CLIENTES
// ================================================================

void MenuClientes()
{
    EjecutarMenuCrud(
        "GESTIÓN DE CLIENTES",
        "Administración y control de clientes",
        CrearCliente,
        ListarClientes,
        BuscarCliente,
        ActualizarCliente,
        EliminarCliente
    );
}


// ================================================================
// SUBMENÚ TÉCNICOS
// ================================================================

void MenuTecnicos()
{
    EjecutarMenuCrud(
        "GESTIÓN DE TÉCNICOS",
        "Administración del personal técnico",
        CrearTecnico,
        ListarTecnicos,
        BuscarTecnico,
        ActualizarTecnico,
        EliminarTecnico
    );
}


// ================================================================
// SUBMENÚ REPUESTOS
// ================================================================

void MenuRepuestos()
{
    EjecutarMenuCrud(
        "GESTIÓN DE REPUESTOS",
        "Control del inventario de repuestos",
        CrearRepuesto,
        ListarRepuesto,
        BuscarRepuesto,
        ActualizarRepuesto,
        EliminarRepuesto
    );
}


// ================================================================
// SUBMENÚ EQUIPOS
// ================================================================

void MenuEquipos()
{
    EjecutarMenuCrud(
        "GESTIÓN DE EQUIPOS",
        "Control de equipos de refrigeración y climatización",
        CrearEquipo,
        ListarEquipos,
        BuscarEquipo,
        ActualizarEquipo,
        EliminarEquipo
    );
}


// ================================================================
// SUBMENÚ MANTENIMIENTOS
// ================================================================

void MenuMantenimientos()
{
    EjecutarMenuCrud(
        "GESTIÓN DE MANTENIMIENTOS",
        "Control de mantenimientos preventivos y correctivos",
        CrearMantenimiento,
        ListarMantenimientos,
        BuscarMantenimiento,
        ActualizarMantenimiento,
        EliminarMantenimiento
    );
}


// ================================================================
// MENÚ CRUD REUTILIZABLE
// ================================================================

void EjecutarMenuCrud(
    string titulo,
    string subtitulo,
    Action crear,
    Action listar,
    Action buscar,
    Action actualizar,
    Action eliminar)
{
    int opcion;

    do
    {
        Console.Clear();

        MostrarEncabezadoModulo(titulo, subtitulo);

        int ancho = ObtenerAnchoCaja(70);

        DibujarBordeSuperior(ancho);

        EscribirFila(
            "[1] Crear",
            ancho,
            ConsoleColor.Cyan);

        EscribirFila(
            "[2] Listar",
            ancho,
            ConsoleColor.Cyan);

        EscribirFila(
            "[3] Buscar",
            ancho,
            ConsoleColor.Cyan);

        EscribirFila(
            "[4] Actualizar",
            ancho,
            ConsoleColor.Yellow);

        EscribirFila(
            "[5] Eliminar",
            ancho,
            ConsoleColor.Red);

        EscribirFila(
            "[6] Volver al Menú Principal",
            ancho,
            ConsoleColor.Green);

        DibujarBordeInferior(ancho);

        opcion = LeerOpcionCentrada("Seleccione una opción");

        switch (opcion)
        {
            case 1:
                crear();
                break;

            case 2:
                listar();
                break;

            case 3:
                buscar();
                break;

            case 4:
                actualizar();
                break;

            case 5:
                eliminar();
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
// ENCABEZADO PRINCIPAL ADAPTABLE
// ================================================================

void MostrarEncabezadoPrincipal()
{
    int anchoConsola = Console.WindowWidth;

    Console.WriteLine();

    // Logo grande solamente cuando existe espacio suficiente
    if (anchoConsola >= 75)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        CentrarTexto(
            "███████╗██╗ ██████╗ ██████╗ ███████╗ ██████╗");

        CentrarTexto(
            "██╔════╝██║██╔════╝ ██╔══██╗██╔════╝██╔════╝");

        Console.ForegroundColor = ConsoleColor.Cyan;

        CentrarTexto(
            "███████╗██║██║  ███╗██████╔╝█████╗  ██║     ");

        CentrarTexto(
            "╚════██║██║██║   ██║██╔══██╗██╔══╝  ██║     ");

        Console.ForegroundColor = ConsoleColor.White;

        CentrarTexto(
            "███████║██║╚██████╔╝██║  ██║███████╗╚██████╗");

        CentrarTexto(
            "╚══════╝╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        CentrarTexto("███████╗██╗ ██████╗ ██████╗ ███████╗ ██████╗");
        CentrarTexto("                 SIGREC");
    }

    Console.WriteLine();

    int ancho = ObtenerAnchoCaja(90);

    DibujarBordeSuperior(ancho);

    EscribirFilaCentrada(
        "SIGREC",
        ancho,
        ConsoleColor.Cyan);

    DibujarSeparador(ancho);

    EscribirFilaCentrada(
        "SISTEMA DE GESTIÓN DE REFRIGERACIÓN",
        ancho,
        ConsoleColor.White);

    EscribirFilaCentrada(
        "Y CLIMATIZACIÓN",
        ancho,
        ConsoleColor.White);

    DibujarBordeInferior(ancho);

    // Efecto sombra
    Console.ForegroundColor = ConsoleColor.DarkGray;

    string sombra =
        new string('░', Math.Max(1, ancho - 4));

    CentrarTexto("   " + sombra);

    Console.ResetColor();
}


// ================================================================
// ENCABEZADOS DE LOS MÓDULOS
// ================================================================

void MostrarEncabezadoModulo(
    string titulo,
    string subtitulo)
{
    Console.WriteLine();

    int ancho = ObtenerAnchoCaja(90);

    DibujarBordeSuperior(ancho);

    EscribirFilaCentrada(
        "SIGREC",
        ancho,
        ConsoleColor.Cyan);

    DibujarSeparador(ancho);

    EscribirFilaCentrada(
        titulo,
        ancho,
        ConsoleColor.White);

    EscribirFilaCentrada(
        subtitulo,
        ancho,
        ConsoleColor.Gray);

    DibujarBordeInferior(ancho);

    Console.ForegroundColor = ConsoleColor.DarkGray;

    string sombra =
        new string('░', Math.Max(1, ancho - 4));

    CentrarTexto("   " + sombra);

    Console.ResetColor();

    Console.WriteLine();
}


// ================================================================
// ENCABEZADO PARA CADA OPERACIÓN CRUD
// ================================================================

void MostrarPantallaOperacion(
    string modulo,
    string operacion)
{
    Console.Clear();

    int ancho = ObtenerAnchoCaja(80);

    Console.WriteLine();

    DibujarBordeSuperior(ancho);

    EscribirFilaCentrada(
        "SIGREC",
        ancho,
        ConsoleColor.Cyan);

    DibujarSeparador(ancho);

    EscribirFilaCentrada(
        modulo,
        ancho,
        ConsoleColor.White);

    EscribirFilaCentrada(
        operacion,
        ancho,
        ConsoleColor.Yellow);

    DibujarBordeInferior(ancho);

    Console.WriteLine();
}


// ================================================================
// FUNCIONES VISUALES ADAPTABLES
// ================================================================

int ObtenerAnchoCaja(int maximo)
{
    int disponible;

    try
    {
        disponible = Console.WindowWidth - 6;
    }
    catch
    {
        disponible = 70;
    }

    if (disponible < 32)
    {
        disponible = 32;
    }

    if (disponible > maximo)
    {
        disponible = maximo;
    }

    return disponible;
}


void CentrarTexto(string texto)
{
    int ancho;

    try
    {
        ancho = Console.WindowWidth;
    }
    catch
    {
        ancho = 100;
    }

    int espacios =
        Math.Max(0, (ancho - texto.Length) / 2);

    Console.WriteLine(
        new string(' ', espacios) + texto);
}


void DibujarBordeSuperior(int ancho)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;

    CentrarTexto(
        "╔" +
        new string('═', ancho - 2) +
        "╗");

    Console.ResetColor();
}


void DibujarSeparador(int ancho)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;

    CentrarTexto(
        "╠" +
        new string('═', ancho - 2) +
        "╣");

    Console.ResetColor();
}


void DibujarBordeInferior(int ancho)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;

    CentrarTexto(
        "╚" +
        new string('═', ancho - 2) +
        "╝");

    Console.ResetColor();
}


void EscribirFila(
    string texto,
    int ancho,
    ConsoleColor color)
{
    int interior = ancho - 2;

    if (texto.Length > interior - 4)
    {
        texto =
            texto.Substring(
                0,
                Math.Max(1, interior - 7))
            + "...";
    }

    string contenido =
        "  " + texto;

    contenido =
        contenido.PadRight(interior);

    Console.ForegroundColor = color;

    CentrarTexto(
        "║" +
        contenido +
        "║");

    Console.ResetColor();
}


void EscribirFilaCentrada(
    string texto,
    int ancho,
    ConsoleColor color)
{
    int interior = ancho - 2;

    if (texto.Length > interior)
    {
        texto =
            texto.Substring(
                0,
                Math.Max(1, interior - 3))
            + "...";
    }

    int espaciosTotales =
        interior - texto.Length;

    int izquierda =
        espaciosTotales / 2;

    int derecha =
        espaciosTotales - izquierda;

    string contenido =
        new string(' ', izquierda) +
        texto +
        new string(' ', derecha);

    Console.ForegroundColor = color;

    CentrarTexto(
        "║" +
        contenido +
        "║");

    Console.ResetColor();
}


int LeerOpcionCentrada(string mensaje)
{
    Console.WriteLine();

    string texto =
        mensaje + ": ";

    int ancho;

    try
    {
        ancho = Console.WindowWidth;
    }
    catch
    {
        ancho = 80;
    }

    int espacios =
        Math.Max(
            0,
            (ancho - texto.Length - 4) / 2);

    Console.ForegroundColor = ConsoleColor.Green;

    Console.Write(
        new string(' ', espacios) +
        "► " +
        texto);

    Console.ResetColor();

    if (int.TryParse(
        Console.ReadLine(),
        out int opcion))
    {
        return opcion;
    }

    return 0;
}


// ================================================================
// MENSAJES
// ================================================================

void MostrarError(string mensaje)
{
    Console.WriteLine();

    int ancho = ObtenerAnchoCaja(65);

    DibujarBordeSuperior(ancho);

    EscribirFilaCentrada(
        "ERROR",
        ancho,
        ConsoleColor.Red);

    DibujarSeparador(ancho);

    EscribirFilaCentrada(
        mensaje,
        ancho,
        ConsoleColor.Red);

    DibujarBordeInferior(ancho);

    Pausar();
}


void MostrarExito(string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine();
    CentrarTexto("✔ " + mensaje);

    Console.ResetColor();
}


void MostrarAdvertencia(string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine();
    CentrarTexto("⚠ " + mensaje);

    Console.ResetColor();
}


void Pausar()
{
    Console.ResetColor();

    Console.WriteLine();

    CentrarTexto(
        "Presione una tecla para continuar...");

    Console.ReadKey();
}


// ================================================================
// SALIDA
// ================================================================

void MostrarSalida()
{
    Console.Clear();

    int ancho = ObtenerAnchoCaja(80);

    Console.WriteLine();
    Console.WriteLine();

    DibujarBordeSuperior(ancho);

    EscribirFilaCentrada(
        "SIGREC",
        ancho,
        ConsoleColor.Cyan);

    DibujarSeparador(ancho);

    EscribirFilaCentrada(
        "SISTEMA CERRADO CORRECTAMENTE",
        ancho,
        ConsoleColor.Green);

    EscribirFilaCentrada(
        "",
        ancho,
        ConsoleColor.White);

    EscribirFilaCentrada(
        "Gracias por utilizar SIGREC",
        ancho,
        ConsoleColor.White);

    DibujarBordeInferior(ancho);

    Console.WriteLine();
}


// ================================================================
// CRUD CLIENTES
// ================================================================

void CrearCliente()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE CLIENTES",
        "CREAR CLIENTE");

    Console.Write("Ingrese ID: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
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

    Cliente existente =
        Database.Clientes.Find(
            x => x.Cedula == cedula);

    if (existente != null)
    {
        MostrarAdvertencia(
            "Ya existe un cliente con esa cédula.");

        Pausar();
        return;
    }

    try
    {
        Cliente cliente =
            new Cliente(
                cedula,
                nombre,
                telefono,
                direccion,
                id);

        Database.Clientes.Add(cliente);

        Database.GuardarClientes();

        MostrarExito(
            "Cliente creado correctamente.");
    }
    catch (Exception ex)
    {
        MostrarError(ex.Message);
        return;
    }

    Pausar();
}


void ListarClientes()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE CLIENTES",
        "LISTAR CLIENTES");

    if (Database.Clientes.Count == 0)
    {
        MostrarAdvertencia(
            "No existen clientes registrados.");
    }
    else
    {
        foreach (Cliente cliente
                 in Database.Clientes)
        {
            cliente.Imprimir();

            Console.ForegroundColor =
                ConsoleColor.DarkGray;

            Console.WriteLine(
                new string('-', 45));

            Console.ResetColor();
        }
    }

    Pausar();
}


void BuscarCliente()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE CLIENTES",
        "BUSCAR CLIENTE");

    Console.Write(
        "Ingrese la cédula del cliente: ");

    string cedula =
        Console.ReadLine();

    Cliente cliente =
        Database.Clientes.Find(
            x => x.Cedula == cedula);

    if (cliente != null)
    {
        MostrarExito(
            "Cliente encontrado.");

        Console.WriteLine();

        cliente.Imprimir();
    }
    else
    {
        MostrarAdvertencia(
            "Cliente no encontrado.");
    }

    Pausar();
}


void ActualizarCliente()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE CLIENTES",
        "ACTUALIZAR CLIENTE");

    Console.Write(
        "Ingrese la cédula del cliente: ");

    string cedula =
        Console.ReadLine();

    Cliente cliente =
        Database.Clientes.Find(
            x => x.Cedula == cedula);

    if (cliente == null)
    {
        MostrarAdvertencia(
            "Cliente no encontrado.");

        Pausar();
        return;
    }

    Console.WriteLine();

    cliente.Imprimir();

    Console.WriteLine();

    Console.Write("Nuevo nombre: ");
    string nuevoNombre =
        Console.ReadLine();

    Console.Write("Nuevo teléfono: ");
    string nuevoTelefono =
        Console.ReadLine();

    Console.Write("Nueva dirección: ");
    string nuevaDireccion =
        Console.ReadLine();

    try
    {
        if (!string.IsNullOrWhiteSpace(nuevoNombre))
            cliente.Nombre = nuevoNombre;

        if (!string.IsNullOrWhiteSpace(nuevoTelefono))
            cliente.Telefono = nuevoTelefono;

        if (!string.IsNullOrWhiteSpace(nuevaDireccion))
            cliente.Direccion = nuevaDireccion;

        Database.GuardarClientes();

        MostrarExito(
            "Cliente actualizado correctamente.");
    }
    catch (Exception ex)
    {
        MostrarError(ex.Message);
        return;
    }

    Pausar();
}


void EliminarCliente()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE CLIENTES",
        "ELIMINAR CLIENTE");

    Console.Write(
        "Ingrese la cédula del cliente: ");

    string cedula =
        Console.ReadLine();

    Cliente cliente =
        Database.Clientes.Find(
            x => x.Cedula == cedula);

    if (cliente == null)
    {
        MostrarAdvertencia(
            "Cliente no encontrado.");

        Pausar();
        return;
    }

    Console.WriteLine();

    cliente.Imprimir();

    Console.ForegroundColor =
        ConsoleColor.Yellow;

    Console.Write(
        "\n¿Desea eliminar este cliente? S/N: ");

    Console.ResetColor();

    string respuesta =
        Console.ReadLine()?.ToUpper();

    if (respuesta == "S")
    {
        Database.Clientes.Remove(cliente);

        Database.GuardarClientes();

        MostrarExito(
            "Cliente eliminado correctamente.");
    }
    else
    {
        MostrarAdvertencia(
            "Operación cancelada.");
    }

    Pausar();
}


// ================================================================
// CRUD TÉCNICOS
// ================================================================

void CrearTecnico()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE TÉCNICOS",
        "CREAR TÉCNICO");

    Console.Write("ID del técnico: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Console.Write("Nombre: ");
    string nombre =
        Console.ReadLine();

    Console.Write("Cédula: ");
    string cedula =
        Console.ReadLine();

    Console.Write("Teléfono: ");
    string telefono =
        Console.ReadLine();

    Console.Write("Especialidad: ");
    string especialidad =
        Console.ReadLine();

    Console.Write("Años de experiencia: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int experiencia))
    {
        MostrarError(
            "Los años de experiencia son inválidos.");

        return;
    }

    Tecnico existente =
        Database.Tecnicos.Find(
            x => x.Cedula == cedula);

    if (existente != null)
    {
        MostrarAdvertencia(
            "Ya existe un técnico con esa cédula.");

        Pausar();
        return;
    }

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

    MostrarExito(
        "Técnico creado correctamente.");

    Pausar();
}


void ListarTecnicos()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE TÉCNICOS",
        "LISTAR TÉCNICOS");

    if (Database.Tecnicos.Count == 0)
    {
        MostrarAdvertencia(
            "No existen técnicos registrados.");
    }
    else
    {
        foreach (Tecnico tecnico
                 in Database.Tecnicos)
        {
            tecnico.Imprimir();

            Console.ForegroundColor =
                ConsoleColor.DarkGray;

            Console.WriteLine(
                new string('-', 45));

            Console.ResetColor();
        }
    }

    Pausar();
}


void BuscarTecnico()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE TÉCNICOS",
        "BUSCAR TÉCNICO");

    Console.Write(
        "Ingrese la cédula del técnico: ");

    string cedula =
        Console.ReadLine();

    Tecnico tecnico =
        Database.Tecnicos.Find(
            x => x.Cedula == cedula);

    if (tecnico != null)
    {
        MostrarExito(
            "Técnico encontrado.");

        Console.WriteLine();

        tecnico.Imprimir();
    }
    else
    {
        MostrarAdvertencia(
            "Técnico no encontrado.");
    }

    Pausar();
}


void ActualizarTecnico()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE TÉCNICOS",
        "ACTUALIZAR TÉCNICO");

    Console.Write(
        "Ingrese la cédula del técnico: ");

    string cedula =
        Console.ReadLine();

    Tecnico tecnico =
        Database.Tecnicos.Find(
            x => x.Cedula == cedula);

    if (tecnico == null)
    {
        MostrarAdvertencia(
            "Técnico no encontrado.");

        Pausar();
        return;
    }

    Console.WriteLine();

    tecnico.Imprimir();

    Console.WriteLine();

    Console.Write("Nuevo nombre: ");
    string nombre =
        Console.ReadLine();

    Console.Write("Nueva cédula: ");
    string nuevaCedula =
        Console.ReadLine();

    Console.Write("Nuevo teléfono: ");
    string telefono =
        Console.ReadLine();

    Console.Write("Nueva especialidad: ");
    string especialidad =
        Console.ReadLine();

    Console.Write(
        "Nuevos años de experiencia: ");

    string experienciaTexto =
        Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(nombre))
        tecnico.Nombre = nombre;

    if (!string.IsNullOrWhiteSpace(nuevaCedula))
        tecnico.Cedula = nuevaCedula;

    if (!string.IsNullOrWhiteSpace(telefono))
        tecnico.Telefono = telefono;

    if (!string.IsNullOrWhiteSpace(especialidad))
        tecnico.Especialidad = especialidad;

    if (int.TryParse(
        experienciaTexto,
        out int experiencia))
    {
        tecnico.Experiencia =
            experiencia;
    }

    Database.GuardarTecnicos();

    MostrarExito(
        "Técnico actualizado correctamente.");

    Pausar();
}


void EliminarTecnico()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE TÉCNICOS",
        "ELIMINAR TÉCNICO");

    Console.Write(
        "Ingrese la cédula del técnico: ");

    string cedula =
        Console.ReadLine();

    Tecnico tecnico =
        Database.Tecnicos.Find(
            x => x.Cedula == cedula);

    if (tecnico == null)
    {
        MostrarAdvertencia(
            "Técnico no encontrado.");

        Pausar();
        return;
    }

    Console.WriteLine();

    tecnico.Imprimir();

    Console.ForegroundColor =
        ConsoleColor.Yellow;

    Console.Write(
        "\n¿Desea eliminar este técnico? S/N: ");

    Console.ResetColor();

    if (Console.ReadLine()?.ToUpper() == "S")
    {
        Database.Tecnicos.Remove(tecnico);

        Database.GuardarTecnicos();

        MostrarExito(
            "Técnico eliminado correctamente.");
    }
    else
    {
        MostrarAdvertencia(
            "Operación cancelada.");
    }

    Pausar();
}


// ================================================================
// CRUD REPUESTOS
// ================================================================

void CrearRepuesto()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE REPUESTOS",
        "CREAR REPUESTO");

    Console.Write("ID: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Console.Write("Nombre: ");
    string nombre =
        Console.ReadLine();

    Console.Write("Marca: ");
    string marca =
        Console.ReadLine();

    Console.Write("Tipo: ");
    string tipo =
        Console.ReadLine();

    Console.Write("Cantidad: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int cantidad))
    {
        MostrarError(
            "Cantidad inválida.");

        return;
    }

    Console.Write("Precio: ");

    if (!decimal.TryParse(
        Console.ReadLine(),
        out decimal precio))
    {
        MostrarError(
            "Precio inválido.");

        return;
    }

    Repuesto existente =
        Database.Repuestos.Find(
            r => r.Id == id);

    if (existente != null)
    {
        MostrarAdvertencia(
            "Ya existe un repuesto con ese ID.");

        Pausar();
        return;
    }

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

    MostrarExito(
        "Repuesto registrado correctamente.");

    Pausar();
}


void ListarRepuesto()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE REPUESTOS",
        "LISTAR REPUESTOS");

    if (Database.Repuestos.Count == 0)
    {
        MostrarAdvertencia(
            "No existen repuestos registrados.");
    }
    else
    {
        foreach (Repuesto repuesto
                 in Database.Repuestos)
        {
            repuesto.Imprimir();

            Console.ForegroundColor =
                ConsoleColor.DarkGray;

            Console.WriteLine(
                new string('-', 45));

            Console.ResetColor();
        }
    }

    Pausar();
}


void BuscarRepuesto()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE REPUESTOS",
        "BUSCAR REPUESTO");

    Console.Write(
        "Ingrese el ID del repuesto: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Repuesto repuesto =
        Database.Repuestos.Find(
            r => r.Id == id);

    if (repuesto != null)
    {
        MostrarExito(
            "Repuesto encontrado.");

        Console.WriteLine();

        repuesto.Imprimir();
    }
    else
    {
        MostrarAdvertencia(
            "Repuesto no encontrado.");
    }

    Pausar();
}


void ActualizarRepuesto()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE REPUESTOS",
        "ACTUALIZAR REPUESTO");

    Console.Write(
        "Ingrese el ID del repuesto: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Repuesto repuesto =
        Database.Repuestos.Find(
            r => r.Id == id);

    if (repuesto == null)
    {
        MostrarAdvertencia(
            "Repuesto no encontrado.");

        Pausar();
        return;
    }

    Console.WriteLine();

    repuesto.Imprimir();

    Console.WriteLine();

    Console.Write("Nuevo nombre: ");
    string nombre =
        Console.ReadLine();

    Console.Write("Nueva marca: ");
    string marca =
        Console.ReadLine();

    Console.Write("Nuevo tipo: ");
    string tipo =
        Console.ReadLine();

    Console.Write("Nueva cantidad: ");
    string cantidadTexto =
        Console.ReadLine();

    Console.Write("Nuevo precio: ");
    string precioTexto =
        Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(nombre))
        repuesto.Nombre = nombre;

    if (!string.IsNullOrWhiteSpace(marca))
        repuesto.Marca = marca;

    if (!string.IsNullOrWhiteSpace(tipo))
        repuesto.TipoRepuesto = tipo;

    if (int.TryParse(
        cantidadTexto,
        out int cantidad))
    {
        repuesto.Cantidad =
            cantidad;
    }

    if (decimal.TryParse(
        precioTexto,
        out decimal precio))
    {
        repuesto.Precio =
            precio;
    }

    Database.GuardarRepuestos();

    MostrarExito(
        "Repuesto actualizado correctamente.");

    Pausar();
}


void EliminarRepuesto()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE REPUESTOS",
        "ELIMINAR REPUESTO");

    Console.Write(
        "Ingrese el ID del repuesto: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
    {
        MostrarError("ID inválido.");
        return;
    }

    Repuesto repuesto =
        Database.Repuestos.Find(
            r => r.Id == id);

    if (repuesto == null)
    {
        MostrarAdvertencia(
            "Repuesto no encontrado.");

        Pausar();
        return;
    }

    Console.WriteLine();

    repuesto.Imprimir();

    Console.ForegroundColor =
        ConsoleColor.Yellow;

    Console.Write(
        "\n¿Desea eliminar este repuesto? S/N: ");

    Console.ResetColor();

    if (Console.ReadLine()?.ToUpper() == "S")
    {
        Database.Repuestos.Remove(repuesto);

        Database.GuardarRepuestos();

        MostrarExito(
            "Repuesto eliminado correctamente.");
    }
    else
    {
        MostrarAdvertencia(
            "Operación cancelada.");
    }

    Pausar();
}


// ================================================================
// CRUD EQUIPOS
// ================================================================

void CrearEquipo()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE EQUIPOS",
        "CREAR EQUIPO");

    Console.Write("Código: ");
    string codigo =
        Console.ReadLine();

    Equipo existente =
        Database.Equipos.Find(
            e => e.Codigo.Equals(
                codigo,
                StringComparison.OrdinalIgnoreCase));

    if (existente != null)
    {
        MostrarAdvertencia(
            "Ya existe un equipo con ese código.");

        Pausar();
        return;
    }

    Console.Write("Marca: ");
    string marca =
        Console.ReadLine();

    Console.Write("Modelo: ");
    string modelo =
        Console.ReadLine();

    Console.Write("Capacidad BTU: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int capacidad))
    {
        MostrarError(
            "Capacidad BTU inválida.");

        return;
    }

    Console.Write(
        "Estado (Operativo / En Reparación): ");

    string estado =
        Console.ReadLine();

    Console.Write(
        "Tipo de filtro (Estándar / HEPA): ");

    string tipoFiltro =
        Console.ReadLine();

    AireAcondicionado equipo =
        new AireAcondicionado(
            codigo,
            marca,
            modelo,
            capacidad,
            estado,
            tipoFiltro);

    Database.AireAcondicionados.Add(
        equipo);

    Database.Equipos.Add(
        equipo);

    Database.GuardarAiresAcondicionados();

    Database.GuardarEquipos();

    MostrarExito(
        "Equipo creado y guardado correctamente.");

    Pausar();
}


void ListarEquipos()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE EQUIPOS",
        "LISTAR EQUIPOS");

    if (Database.Equipos.Count == 0)
    {
        MostrarAdvertencia(
            "No existen equipos registrados.");
    }
    else
    {
        foreach (Equipo equipo
                 in Database.Equipos)
        {
            equipo.Imprimir();

            Console.ForegroundColor =
                ConsoleColor.DarkGray;

            Console.WriteLine(
                new string('-', 45));

            Console.ResetColor();
        }
    }

    Pausar();
}


void BuscarEquipo()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE EQUIPOS",
        "BUSCAR EQUIPO");

    Console.Write(
        "Ingrese el código del equipo: ");

    string codigo =
        Console.ReadLine();

    Equipo equipo =
        Database.Equipos.Find(
            x => x.Codigo.Equals(
                codigo,
                StringComparison.OrdinalIgnoreCase));

    if (equipo != null)
    {
        MostrarExito(
            "Equipo encontrado.");

        Console.WriteLine();

        equipo.Imprimir();
    }
    else
    {
        MostrarAdvertencia(
            "Equipo no encontrado.");
    }

    Pausar();
}


void ActualizarEquipo()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE EQUIPOS",
        "ACTUALIZAR EQUIPO");

    Console.Write("Ingrese el código del equipo: ");
    string codigo = Console.ReadLine();

    // Buscar en la lista principal
    Equipo equipo = Database.Equipos.Find(
        e => e.Codigo.Equals(
            codigo,
            StringComparison.OrdinalIgnoreCase));

    if (equipo == null)
    {
        MostrarAdvertencia("Equipo no encontrado.");
        Pausar();
        return;
    }

    Console.WriteLine("\nEquipo encontrado:");
    Console.WriteLine("-----------------------------------");
    equipo.Imprimir();
    Console.WriteLine("-----------------------------------");

    Console.Write("\nNueva marca: ");
    string nuevaMarca = Console.ReadLine();

    Console.Write("Nuevo modelo: ");
    string nuevoModelo = Console.ReadLine();

    Console.Write("Nueva capacidad BTU: ");
    string capacidadTexto = Console.ReadLine();

    Console.Write("Nuevo estado: ");
    string nuevoEstado = Console.ReadLine();

    // ACTUALIZAR LISTA EQUIPOS
    if (!string.IsNullOrWhiteSpace(nuevaMarca))
    {
        equipo.Marca = nuevaMarca;
    }

    if (!string.IsNullOrWhiteSpace(nuevoModelo))
    {
        equipo.Modelo = nuevoModelo;
    }

    if (int.TryParse(capacidadTexto, out int nuevaCapacidad))
    {
        equipo.CapacidadBTU = nuevaCapacidad;
    }

    if (!string.IsNullOrWhiteSpace(nuevoEstado))
    {
        equipo.Estado = nuevoEstado;
    }

    // BUSCAR EL MISMO EQUIPO EN AIRE ACONDICIONADO
    AireAcondicionado aire = Database.AireAcondicionados.Find(
        a => a.Codigo.Equals(
            codigo,
            StringComparison.OrdinalIgnoreCase));

    // SINCRONIZAR LA SEGUNDA LISTA
    if (aire != null)
    {
        aire.Marca = equipo.Marca;
        aire.Modelo = equipo.Modelo;
        aire.CapacidadBTU = equipo.CapacidadBTU;
        aire.Estado = equipo.Estado;

        Console.Write("Nuevo tipo de filtro: ");
        string nuevoFiltro = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(nuevoFiltro))
        {
            aire.TipoFiltro = nuevoFiltro;
        }
    }

    // GUARDAR LOS DOS ARCHIVOS JSON
    Database.GuardarEquipos();
    Database.GuardarAiresAcondicionados();

    MostrarExito("Equipo actualizado correctamente.");

    Pausar();
}


void EliminarEquipo()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE EQUIPOS",
        "ELIMINAR EQUIPO");

    Console.Write(
        "Ingrese el código del equipo: ");

    string codigo =
        Console.ReadLine();

    Equipo equipo =
        Database.Equipos.Find(
            x => x.Codigo.Equals(
                codigo,
                StringComparison.OrdinalIgnoreCase));

    if (equipo == null)
    {
        MostrarAdvertencia(
            "Equipo no encontrado.");

        Pausar();
        return;
    }

    Console.WriteLine();

    equipo.Imprimir();

    Console.ForegroundColor =
        ConsoleColor.Yellow;

    Console.Write(
        "\n¿Desea eliminar este equipo? S/N: ");

    Console.ResetColor();

    if (Console.ReadLine()?.ToUpper() == "S")
    {
        Database.Equipos.Remove(
            equipo);

        AireAcondicionado aire =
            Database.AireAcondicionados.Find(
                x => x.Codigo.Equals(
                    codigo,
                    StringComparison.OrdinalIgnoreCase));

        if (aire != null)
        {
            Database.AireAcondicionados.Remove(
                aire);

            Database.GuardarAiresAcondicionados();
        }

        Database.GuardarEquipos();

        MostrarExito(
            "Equipo eliminado correctamente.");
    }
    else
    {
        MostrarAdvertencia(
            "Operación cancelada.");
    }

    Pausar();
}


// ================================================================
// CRUD MANTENIMIENTOS
// ================================================================

void CrearMantenimiento()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE MANTENIMIENTOS",
        "REGISTRAR MANTENIMIENTO");

    Console.Write(
        "Ingrese ID del mantenimiento: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
    {
        MostrarError(
            "ID inválido.");

        return;
    }

    Mantenimiento existente =
        Database.Mantenimientos.Find(
            m => m.Id == id);

    if (existente != null)
    {
        MostrarAdvertencia(
            "Ya existe un mantenimiento con ese ID.");

        Pausar();
        return;
    }

    Console.Write(
        "Ingrese código del equipo: ");

    string codigoEquipo =
        Console.ReadLine();

    Equipo equipo =
        Database.Equipos.Find(
            e => e.Codigo.Equals(
                codigoEquipo,
                StringComparison.OrdinalIgnoreCase));

    if (equipo == null)
    {
        MostrarAdvertencia(
            "No existe un equipo con ese código.");

        Pausar();
        return;
    }

    Console.Write(
        "Tipo de mantenimiento (Preventivo/Correctivo): ");

    string tipo =
        Console.ReadLine();

    Console.Write(
        "Descripción del trabajo: ");

    string descripcion =
        Console.ReadLine();

    Console.Write(
        "Costo ($): ");

    if (!decimal.TryParse(
        Console.ReadLine(),
        out decimal costo))
    {
        MostrarError(
            "Costo inválido.");

        return;
    }

    Console.Write(
        "Estado (Pendiente/Completado): ");

    string estado =
        Console.ReadLine();

    Console.Write(
        "Duración en horas: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int duracion))
    {
        MostrarError(
            "Duración inválida.");

        return;
    }

    try
    {
        Mantenimiento mantenimiento =
            new Mantenimiento(
                id,
                codigoEquipo,
                tipo,
                descripcion,
                costo,
                estado,
                duracion);

        Database.Mantenimientos.Add(
            mantenimiento);

        Database.GuardarMantenimientos();

        MostrarExito(
            "Mantenimiento registrado correctamente.");
    }
    catch (Exception ex)
    {
        MostrarError(ex.Message);
        return;
    }

    Pausar();
}


void ListarMantenimientos()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE MANTENIMIENTOS",
        "LISTAR MANTENIMIENTOS");

    if (Database.Mantenimientos.Count == 0)
    {
        MostrarAdvertencia(
            "No existen mantenimientos registrados.");
    }
    else
    {
        foreach (Mantenimiento mantenimiento
                 in Database.Mantenimientos)
        {
            mantenimiento.Imprimir();

            Console.ForegroundColor =
                ConsoleColor.DarkGray;

            Console.WriteLine(
                new string('-', 50));

            Console.ResetColor();
        }
    }

    Pausar();
}


void BuscarMantenimiento()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE MANTENIMIENTOS",
        "BUSCAR MANTENIMIENTO");

    Console.Write(
        "Ingrese ID del mantenimiento: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
    {
        MostrarError(
            "ID inválido.");

        return;
    }

    Mantenimiento mantenimiento =
        Database.Mantenimientos.Find(
            m => m.Id == id);

    if (mantenimiento != null)
    {
        MostrarExito(
            "Mantenimiento encontrado.");

        Console.WriteLine();

        mantenimiento.Imprimir();
    }
    else
    {
        MostrarAdvertencia(
            "Mantenimiento no encontrado.");
    }

    Pausar();
}


void ActualizarMantenimiento()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE MANTENIMIENTOS",
        "ACTUALIZAR MANTENIMIENTO");

    Console.Write(
        "Ingrese ID del mantenimiento: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
    {
        MostrarError(
            "ID inválido.");

        return;
    }

    Mantenimiento mantenimiento =
        Database.Mantenimientos.Find(
            m => m.Id == id);

    if (mantenimiento == null)
    {
        MostrarAdvertencia(
            "Mantenimiento no encontrado.");

        Pausar();
        return;
    }

    Console.WriteLine();

    mantenimiento.Imprimir();

    Console.WriteLine();

    Console.Write(
        $"Nuevo tipo (Actual: {mantenimiento.TipoMantenimiento}): ");

    string tipo =
        Console.ReadLine();

    Console.Write(
        $"Nueva descripción (Actual: {mantenimiento.Descripcion}): ");

    string descripcion =
        Console.ReadLine();

    Console.Write(
        $"Nuevo costo (Actual: ${mantenimiento.Costo}): ");

    string costoTexto =
        Console.ReadLine();

    Console.Write(
        $"Nuevo estado (Actual: {mantenimiento.Estado}): ");

    string estado =
        Console.ReadLine();

    Console.Write(
        $"Nueva duración (Actual: {mantenimiento.DuracionHoras} horas): ");

    string duracionTexto =
        Console.ReadLine();

    try
    {
        if (!string.IsNullOrWhiteSpace(tipo))
            mantenimiento.TipoMantenimiento = tipo;

        if (!string.IsNullOrWhiteSpace(descripcion))
            mantenimiento.Descripcion = descripcion;

        if (decimal.TryParse(
            costoTexto,
            out decimal costo))
        {
            mantenimiento.Costo = costo;
        }

        if (!string.IsNullOrWhiteSpace(estado))
            mantenimiento.Estado = estado;

        if (int.TryParse(
            duracionTexto,
            out int duracion))
        {
            mantenimiento.DuracionHoras =
                duracion;
        }

        Database.GuardarMantenimientos();

        MostrarExito(
            "Mantenimiento actualizado correctamente.");
    }
    catch (Exception ex)
    {
        MostrarError(ex.Message);
        return;
    }

    Pausar();
}


void EliminarMantenimiento()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE MANTENIMIENTOS",
        "ELIMINAR MANTENIMIENTO");

    Console.Write(
        "Ingrese ID del mantenimiento: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
    {
        MostrarError(
            "ID inválido.");

        return;
    }

    Mantenimiento mantenimiento =
        Database.Mantenimientos.Find(
            m => m.Id == id);

    if (mantenimiento == null)
    {
        MostrarAdvertencia(
            "Mantenimiento no encontrado.");

        Pausar();
        return;
    }

    Console.WriteLine();

    mantenimiento.Imprimir();

    Console.ForegroundColor =
        ConsoleColor.Yellow;

    Console.Write(
        "\n¿Desea eliminar este mantenimiento? S/N: ");

    Console.ResetColor();

    if (Console.ReadLine()?.ToUpper() == "S")
    {
        Database.Mantenimientos.Remove(
            mantenimiento);

        Database.GuardarMantenimientos();

        MostrarExito(
            "Mantenimiento eliminado correctamente.");
    }
    else
    {
        MostrarAdvertencia(
            "Operación cancelada.");
    }

    Pausar();
}