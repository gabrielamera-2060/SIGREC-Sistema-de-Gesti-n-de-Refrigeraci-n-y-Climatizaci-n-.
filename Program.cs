using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Datos;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Services;


// ================================================================
// INICIO DEL SISTEMA
// ================================================================

Console.OutputEncoding = Encoding.UTF8;

Console.Title =
    "SIGREC - Sistema de Gestión de Refrigeración y Climatización";

// Comprobar conexión con SQL Server
try
{
    using (var context = new SigrecDbContext())
    {
        context.Database.CanConnect();
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine(
        "No se pudo establecer conexión con SQL Server.");

    Console.WriteLine(ex.Message);

    Console.ResetColor();

    Console.ReadKey();

    return;
}


int opcionPrincipal;

do
{
    Console.Clear();

    MostrarEncabezadoPrincipal();

    MostrarMenuPrincipal();

    opcionPrincipal =
        LeerOpcionCentrada("Seleccione una opción");

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
            await MenuAsistenteIA();
            break;

        case 7:
            await MenuComunicaciones();
            break;

        case 8:
            MostrarSalida();
            break;

        default:
            MostrarError(
                "Opción inválida. Intente nuevamente.");
            break;
    }

} while (opcionPrincipal != 8);


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
        "[6]  Asistente Inteligente SIGREC",
        ancho,
        ConsoleColor.Magenta);

    EscribirFila(
        "[7]  Comunicaciones - Correo y WhatsApp",
        ancho,
        ConsoleColor.Yellow);

    EscribirFila(
        "[8]  Salir del Sistema",
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
        ListarRepuestos,
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
// ASISTENTE INTELIGENTE SIGREC
// ================================================================

async Task MenuAsistenteIA()
{
    Console.Clear();

    MostrarEncabezadoModulo(
        "ASISTENTE INTELIGENTE SIGREC",
        "Asistente técnico con Inteligencia Artificial");

    int ancho =
        ObtenerAnchoCaja(80);

    DibujarBordeSuperior(ancho);

    EscribirFilaCentrada(
        "ASISTENTE IA",
        ancho,
        ConsoleColor.Magenta);

    DibujarSeparador(ancho);

    EscribirFilaCentrada(
        "Realice una consulta técnica",
        ancho,
        ConsoleColor.White);

    DibujarBordeInferior(ancho);

    Console.WriteLine();

    Console.ForegroundColor =
        ConsoleColor.Cyan;

    Console.Write("Ingrese su pregunta: ");

    Console.ResetColor();

    string pregunta =
        Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(
        pregunta))
    {
        MostrarAdvertencia(
            "Debe ingresar una pregunta.");

        Pausar();
        return;
    }

    try
    {
        Console.WriteLine();

        Console.ForegroundColor =
            ConsoleColor.Yellow;

        Console.WriteLine(
            "Consultando al Asistente SIGREC...");

        Console.ResetColor();

        OpenAIService asistente =
            new OpenAIService();

        string respuesta =
            await asistente.PreguntarAsync(
                pregunta);

        Console.WriteLine();

        DibujarBordeSuperior(ancho);

        EscribirFilaCentrada(
            "RESPUESTA DEL ASISTENTE",
            ancho,
            ConsoleColor.Green);

        DibujarBordeInferior(ancho);

        Console.WriteLine();

        Console.ForegroundColor =
            ConsoleColor.White;

        Console.WriteLine(respuesta);

        Console.ResetColor();
    }
    catch (Exception ex)
    {
        MostrarError(
            "Error con el Asistente IA: " +
            ObtenerMensajeError(ex));

        return;
    }

    Pausar();
}


// ================================================================
// COMUNICACIONES - CORREO Y WHATSAPP SIMULADOS
// ================================================================

async Task MenuComunicaciones()
{
    int opcion;

    do
    {
        Console.Clear();

        MostrarEncabezadoModulo(
            "COMUNICACIONES SIGREC",
            "Gestión de correo electrónico y WhatsApp");

        int ancho = ObtenerAnchoCaja(80);

        DibujarBordeSuperior(ancho);

        EscribirFila(
            "[1] Enviar correo electrónico",
            ancho,
            ConsoleColor.Cyan);

        EscribirFila(
            "[2] Consultar historial de correos",
            ancho,
            ConsoleColor.Magenta);

        EscribirFila(
            "[3] Registrar WhatsApp de cliente",
            ancho,
            ConsoleColor.Blue);

        EscribirFila(
            "[4] Consultar historial de WhatsApp",
            ancho,
            ConsoleColor.Blue);

        EscribirFila(
            "[5] Volver al Menú Principal",
            ancho,
            ConsoleColor.Yellow);

        DibujarBordeInferior(ancho);

        opcion = LeerOpcionCentrada("Seleccione una opción");

        switch (opcion)
        {
            case 1:
                await RegistrarCorreoCliente();
                break;

            case 2:
                await ListarHistorialCorreos();
                break;

            case 3:
                await RegistrarWhatsAppCliente();
                break;

            case 4:
                await ListarHistorialWhatsApp();
                break;

            case 5:
                break;

            default:
                MostrarError("Opción inválida. Intente nuevamente.");
                break;
        }

    } while (opcion != 5);
}


async Task RegistrarCorreoCliente()
{
    Console.Clear();

    MostrarEncabezadoModulo(
        "CORREO ELECTRÓNICO",
        "Envío real de correo y registro en SQL Server");

    Console.Write("Ingrese la cédula del cliente: ");
    string cedula = Console.ReadLine() ?? "";

    try
    {
        using var context = new SigrecDbContext();

        Cliente? cliente = await context.Clientes
            .FirstOrDefaultAsync(c => c.Cedula == cedula);

        if (cliente == null)
        {
            MostrarAdvertencia("Cliente no encontrado.");
            Pausar();
            return;
        }

        if (string.IsNullOrWhiteSpace(cliente.Correo))
        {
            MostrarAdvertencia("El cliente no tiene correo registrado.");
            Pausar();
            return;
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Cliente: {cliente.Nombre}");
        Console.WriteLine($"Correo: {cliente.Correo}");
        Console.ResetColor();
        Console.WriteLine();

        Console.Write("Asunto: ");
        string asunto = Console.ReadLine() ?? "";

        Console.Write("Mensaje: ");
        string mensaje = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(asunto) ||
            string.IsNullOrWhiteSpace(mensaje))
        {
            MostrarAdvertencia("El asunto y el mensaje son obligatorios.");
            Pausar();
            return;
        }

        await CorreoService.EnviarAsync(
            cliente.Correo,
            asunto,
            mensaje);

        HistorialCorreo registro = new HistorialCorreo
        {
            ClienteId = cliente.Id,
            CorreoDestino = cliente.Correo,
            Asunto = asunto,
            Mensaje = mensaje,
            Fecha = DateTime.Now,
            Estado = "Enviado"
        };

        context.HistorialCorreos.Add(registro);
        await context.SaveChangesAsync();

        MostrarExito(
            "Correo enviado correctamente y registrado en SQL Server.");
    }
    catch (Exception ex)
    {
        MostrarError(
            "No fue posible enviar el correo: " +
            ObtenerMensajeError(ex));
    }

    Pausar();
}


async Task ListarHistorialCorreos()
{
    Console.Clear();

    MostrarEncabezadoModulo(
        "HISTORIAL DE CORREOS",
        "Comunicaciones registradas en SQL Server");

    try
    {
        using var context = new SigrecDbContext();

        List<HistorialCorreo> correos = await context.HistorialCorreos
            .AsNoTracking()
            .Include(h => h.Cliente)
            .OrderByDescending(h => h.Fecha)
            .ToListAsync();

        if (correos.Count == 0)
        {
            MostrarAdvertencia("No existen correos registrados.");
            Pausar();
            return;
        }

        foreach (HistorialCorreo correo in correos)
        {
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"ID: {correo.Id}");
            Console.WriteLine($"Cliente: {correo.Cliente?.Nombre ?? "No disponible"}");
            Console.WriteLine($"Correo: {correo.CorreoDestino}");
            Console.WriteLine($"Asunto: {correo.Asunto}");
            Console.WriteLine($"Mensaje: {correo.Mensaje}");
            Console.WriteLine($"Fecha: {correo.Fecha:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine($"Estado: {correo.Estado}");
        }

        Console.WriteLine(new string('-', 70));
    }
    catch (Exception ex)
    {
        MostrarError(
            "No fue posible consultar el historial: " +
            ObtenerMensajeError(ex));
    }

    Pausar();
}


async Task RegistrarWhatsAppCliente()
{
    Console.Clear();

    MostrarEncabezadoModulo(
        "WHATSAPP",
        "Registro académico de mensaje en modo simulado");

    Console.Write("Ingrese la cédula del cliente: ");
    string cedula = Console.ReadLine() ?? "";

    try
    {
        using var context = new SigrecDbContext();

        Cliente? cliente = await context.Clientes
            .FirstOrDefaultAsync(c => c.Cedula == cedula);

        if (cliente == null)
        {
            MostrarAdvertencia("Cliente no encontrado.");
            Pausar();
            return;
        }

        if (string.IsNullOrWhiteSpace(cliente.Telefono))
        {
            MostrarAdvertencia(
                "El cliente no tiene teléfono registrado.");
            Pausar();
            return;
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Cliente: {cliente.Nombre}");
        Console.WriteLine($"Teléfono: {cliente.Telefono}");
        Console.ResetColor();
        Console.WriteLine();

        Console.Write("Mensaje: ");
        string mensaje = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(mensaje))
        {
            MostrarAdvertencia("Debe ingresar un mensaje.");
            Pausar();
            return;
        }

        string telefono =
            PrepararTelefonoEcuador(cliente.Telefono);

        HistorialWhatsApp registro =
            new HistorialWhatsApp
            {
                ClienteId = cliente.Id,
                TelefonoDestino = telefono,
                Mensaje = mensaje,
                Fecha = DateTime.Now,
                Estado = "Simulado",
                TipoMensaje = "WhatsApp",
                MensajeId = null,
                Detalle = "Registro académico POO"
            };

        context.HistorialWhatsApp.Add(registro);
        await context.SaveChangesAsync();

        MostrarExito(
            "Mensaje WhatsApp registrado correctamente en SQL Server. Estado: SIMULADO.");

        Console.WriteLine();
        Console.WriteLine($"Cliente: {cliente.Nombre}");
        Console.WriteLine($"Destino: {telefono}");
        Console.WriteLine($"Mensaje: {mensaje}");
    }
    catch (Exception ex)
    {
        MostrarError(
            "No fue posible registrar el WhatsApp: " +
            ObtenerMensajeError(ex));
    }

    Pausar();
}


async Task ListarHistorialWhatsApp()
{
    Console.Clear();

    MostrarEncabezadoModulo(
        "HISTORIAL DE WHATSAPP",
        "Mensajes simulados registrados en SQL Server");

    try
    {
        using var context = new SigrecDbContext();

        List<HistorialWhatsApp> mensajes =
            await context.HistorialWhatsApp
                .AsNoTracking()
                .Include(h => h.Cliente)
                .OrderByDescending(h => h.Fecha)
                .ToListAsync();

        if (mensajes.Count == 0)
        {
            MostrarAdvertencia(
                "No existen registros de WhatsApp.");

            Pausar();
            return;
        }

        foreach (HistorialWhatsApp registro in mensajes)
        {
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"ID: {registro.Id}");
            Console.WriteLine(
                $"Cliente: {registro.Cliente?.Nombre ?? "No disponible"}");
            Console.WriteLine(
                $"Teléfono: {registro.TelefonoDestino}");
            Console.WriteLine(
                $"Tipo: {registro.TipoMensaje}");
            Console.WriteLine(
                $"Mensaje: {registro.Mensaje}");
            Console.WriteLine(
                $"Fecha: {registro.Fecha:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine(
                $"Estado: {registro.Estado}");

            if (!string.IsNullOrWhiteSpace(registro.Detalle))
            {
                Console.WriteLine(
                    $"Detalle: {registro.Detalle}");
            }
        }

        Console.WriteLine(new string('-', 70));
    }
    catch (Exception ex)
    {
        MostrarError(
            "No fue posible consultar el historial de WhatsApp: " +
            ObtenerMensajeError(ex));
    }

    Pausar();
}


string PrepararTelefonoEcuador(
    string telefono)
{
    string numero =
        telefono
            .Replace("+", "")
            .Replace(" ", "")
            .Replace("-", "")
            .Replace("(", "")
            .Replace(")", "");

    if (numero.StartsWith("0") &&
        numero.Length == 10)
    {
        numero =
            "593" +
            numero.Substring(1);
    }

    return numero;
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

        MostrarEncabezadoModulo(
            titulo,
            subtitulo);

        int ancho =
            ObtenerAnchoCaja(70);

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

        opcion =
            LeerOpcionCentrada(
                "Seleccione una opción");

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
                MostrarError(
                    "Opción inválida.");
                break;
        }

    } while (opcion != 6);
}


// ================================================================
// ENCABEZADO PRINCIPAL
// ================================================================

void MostrarEncabezadoPrincipal()
{
    int anchoConsola;

    try
    {
        anchoConsola =
            Console.WindowWidth;
    }
    catch
    {
        anchoConsola = 100;
    }

    Console.WriteLine();

    if (anchoConsola >= 75)
    {
        Console.ForegroundColor =
            ConsoleColor.DarkCyan;

        CentrarTexto(
            "███████╗██╗ ██████╗ ██████╗ ███████╗ ██████╗");

        CentrarTexto(
            "██╔════╝██║██╔════╝ ██╔══██╗██╔════╝██╔════╝");

        Console.ForegroundColor =
            ConsoleColor.Cyan;

        CentrarTexto(
            "███████╗██║██║  ███╗██████╔╝█████╗  ██║     ");

        CentrarTexto(
            "╚════██║██║██║   ██║██╔══██╗██╔══╝  ██║     ");

        Console.ForegroundColor =
            ConsoleColor.White;

        CentrarTexto(
            "███████║██║╚██████╔╝██║  ██║███████╗╚██████╗");

        CentrarTexto(
            "╚══════╝╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝");
    }
    else
    {
        Console.ForegroundColor =
            ConsoleColor.Cyan;

        CentrarTexto("SIGREC");
    }

    Console.WriteLine();

    int ancho =
        ObtenerAnchoCaja(90);

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

    Console.ForegroundColor =
        ConsoleColor.DarkGray;

    string sombra =
        new string(
            '░',
            Math.Max(1, ancho - 4));

    CentrarTexto(
        "   " + sombra);

    Console.ResetColor();
}


// ================================================================
// ENCABEZADO MÓDULO
// ================================================================

void MostrarEncabezadoModulo(
    string titulo,
    string subtitulo)
{
    Console.WriteLine();

    int ancho =
        ObtenerAnchoCaja(90);

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

    Console.WriteLine();
}


// ================================================================
// PANTALLA OPERACIÓN
// ================================================================

void MostrarPantallaOperacion(
    string modulo,
    string operacion)
{
    Console.Clear();

    int ancho =
        ObtenerAnchoCaja(80);

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
// FUNCIONES VISUALES
// ================================================================

int ObtenerAnchoCaja(int maximo)
{
    int disponible;

    try
    {
        disponible =
            Console.WindowWidth - 6;
    }
    catch
    {
        disponible = 70;
    }

    if (disponible < 32)
        disponible = 32;

    if (disponible > maximo)
        disponible = maximo;

    return disponible;
}


void CentrarTexto(string texto)
{
    int ancho;

    try
    {
        ancho =
            Console.WindowWidth;
    }
    catch
    {
        ancho = 100;
    }

    int espacios =
        Math.Max(
            0,
            (ancho - texto.Length) / 2);

    Console.WriteLine(
        new string(
            ' ',
            espacios)
        + texto);
}


void DibujarBordeSuperior(int ancho)
{
    Console.ForegroundColor =
        ConsoleColor.DarkCyan;

    CentrarTexto(
        "╔" +
        new string(
            '═',
            ancho - 2) +
        "╗");

    Console.ResetColor();
}


void DibujarSeparador(int ancho)
{
    Console.ForegroundColor =
        ConsoleColor.DarkCyan;

    CentrarTexto(
        "╠" +
        new string(
            '═',
            ancho - 2) +
        "╣");

    Console.ResetColor();
}


void DibujarBordeInferior(int ancho)
{
    Console.ForegroundColor =
        ConsoleColor.DarkCyan;

    CentrarTexto(
        "╚" +
        new string(
            '═',
            ancho - 2) +
        "╝");

    Console.ResetColor();
}


void EscribirFila(
    string texto,
    int ancho,
    ConsoleColor color)
{
    int interior =
        ancho - 2;

    if (texto.Length > interior - 4)
    {
        texto =
            texto.Substring(
                0,
                Math.Max(
                    1,
                    interior - 7))
            + "...";
    }

    string contenido =
        "  " + texto;

    contenido =
        contenido.PadRight(
            interior);

    Console.ForegroundColor =
        color;

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
    int interior =
        ancho - 2;

    if (texto.Length > interior)
    {
        texto =
            texto.Substring(
                0,
                Math.Max(
                    1,
                    interior - 3))
            + "...";
    }

    int espaciosTotales =
        interior - texto.Length;

    int izquierda =
        espaciosTotales / 2;

    int derecha =
        espaciosTotales - izquierda;

    string contenido =
        new string(
            ' ',
            izquierda)
        + texto
        + new string(
            ' ',
            derecha);

    Console.ForegroundColor =
        color;

    CentrarTexto(
        "║" +
        contenido +
        "║");

    Console.ResetColor();
}


int LeerOpcionCentrada(
    string mensaje)
{
    Console.WriteLine();

    string texto =
        mensaje + ": ";

    int ancho;

    try
    {
        ancho =
            Console.WindowWidth;
    }
    catch
    {
        ancho = 80;
    }

    int espacios =
        Math.Max(
            0,
            (ancho -
             texto.Length -
             4) / 2);

    Console.ForegroundColor =
        ConsoleColor.Green;

    Console.Write(
        new string(
            ' ',
            espacios)
        + "► "
        + texto);

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

void MostrarError(
    string mensaje)
{
    Console.WriteLine();

    int ancho =
        ObtenerAnchoCaja(65);

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


void MostrarExito(
    string mensaje)
{
    Console.ForegroundColor =
        ConsoleColor.Green;

    Console.WriteLine();

    CentrarTexto(
        "✔ " + mensaje);

    Console.ResetColor();
}


void MostrarAdvertencia(
    string mensaje)
{
    Console.ForegroundColor =
        ConsoleColor.Yellow;

    Console.WriteLine();

    CentrarTexto(
        "⚠ " + mensaje);

    Console.ResetColor();
}


void Pausar()
{
    Console.ResetColor();

    Console.WriteLine();

    CentrarTexto(
        "Presione una tecla para continuar...");

    Console.ReadKey(true);
}


// ================================================================
// SALIDA
// ================================================================

void MostrarSalida()
{
    Console.Clear();

    int ancho =
        ObtenerAnchoCaja(80);

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

    Console.Write(
        "Ingrese cédula: ");

    string cedula =
        Console.ReadLine() ?? "";

    Console.Write(
        "Ingrese nombre: ");

    string nombre =
        Console.ReadLine() ?? "";

    Console.Write(
        "Ingrese teléfono: ");

    string telefono =
        Console.ReadLine() ?? "";

    Console.Write(
        "Ingrese correo electrónico: ");

    string? correo =
        Console.ReadLine();

    if (string.IsNullOrWhiteSpace(correo))
    {
        correo = null;
    }

    Console.Write(
        "Ingrese dirección: ");

    string direccion =
        Console.ReadLine() ?? "";

    try
    {
        using var context =
            new SigrecDbContext();

        Cliente existente =
            context.Clientes
                .FirstOrDefault(
                    c =>
                    c.Cedula == cedula);

        if (existente != null)
        {
            MostrarAdvertencia(
                "Ya existe un cliente con esa cédula.");

            Pausar();
            return;
        }

        Cliente cliente =
            new Cliente(
                cedula,
                nombre,
                telefono,
                direccion,
                0);

        cliente.Correo = correo;

        context.Clientes.Add(
            cliente);

        context.SaveChanges();

        MostrarExito(
            $"Cliente creado correctamente. ID: {cliente.Id}");
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
    }

    Pausar();
}


void ListarClientes()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE CLIENTES",
        "LISTAR CLIENTES");

    try
    {
        using var context =
            new SigrecDbContext();

        List<Cliente> clientes =
            context.Clientes
                .OrderBy(c => c.Nombre)
                .ToList();

        if (clientes.Count == 0)
        {
            MostrarAdvertencia(
                "No existen clientes registrados.");
        }
        else
        {
            foreach (
                Cliente cliente
                in clientes)
            {
                cliente.Imprimir();

                Console.ForegroundColor =
                    ConsoleColor.DarkGray;

                Console.WriteLine(
                    new string(
                        '-',
                        45));

                Console.ResetColor();
            }
        }
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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
        Console.ReadLine() ?? "";

    try
    {
        using var context =
            new SigrecDbContext();

        Cliente cliente =
            context.Clientes
                .FirstOrDefault(
                    c =>
                    c.Cedula == cedula);

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
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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
        Console.ReadLine() ?? "";

    try
    {
        using var context =
            new SigrecDbContext();

        Cliente cliente =
            context.Clientes
                .FirstOrDefault(
                    c =>
                    c.Cedula == cedula);

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

        Console.Write(
            "Nuevo nombre (Enter para mantener): ");

        string nuevoNombre =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nuevo teléfono (Enter para mantener): ");

        string nuevoTelefono =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nuevo correo (Enter para mantener): ");

        string nuevoCorreo =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nueva dirección (Enter para mantener): ");

        string nuevaDireccion =
            Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(
            nuevoNombre))
        {
            cliente.Nombre =
                nuevoNombre;
        }

        if (!string.IsNullOrWhiteSpace(
            nuevoTelefono))
        {
            cliente.Telefono =
                nuevoTelefono;
        }

        if (!string.IsNullOrWhiteSpace(
            nuevoCorreo))
        {
            cliente.Correo =
                nuevoCorreo;
        }

        if (!string.IsNullOrWhiteSpace(
            nuevaDireccion))
        {
            cliente.Direccion =
                nuevaDireccion;
        }

        context.SaveChanges();

        MostrarExito(
            "Cliente actualizado correctamente.");
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

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
        Console.ReadLine() ?? "";

    try
    {
        using var context =
            new SigrecDbContext();

        Cliente cliente =
            context.Clientes
                .Include(c => c.Equipos)
                .FirstOrDefault(
                    c =>
                    c.Cedula == cedula);

        if (cliente == null)
        {
            MostrarAdvertencia(
                "Cliente no encontrado.");

            Pausar();
            return;
        }

        Console.WriteLine();

        cliente.Imprimir();

        if (cliente.Equipos != null &&
            cliente.Equipos.Count > 0)
        {
            MostrarAdvertencia(
                "No se puede eliminar porque tiene equipos registrados.");

            Pausar();
            return;
        }

        Console.ForegroundColor =
            ConsoleColor.Yellow;

        Console.Write(
            "\n¿Desea eliminar este cliente? S/N: ");

        Console.ResetColor();

        string respuesta =
            (Console.ReadLine() ?? "")
            .Trim()
            .ToUpper();

        if (respuesta == "S")
        {
            context.Clientes.Remove(
                cliente);

            context.SaveChanges();

            MostrarExito(
                "Cliente eliminado correctamente.");
        }
        else
        {
            MostrarAdvertencia(
                "Operación cancelada.");
        }
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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

    Console.Write(
        "Nombre: ");

    string nombre =
        Console.ReadLine() ?? "";

    Console.Write(
        "Cédula: ");

    string cedula =
        Console.ReadLine() ?? "";

    Console.Write(
        "Teléfono: ");

    string telefono =
        Console.ReadLine() ?? "";

    Console.Write(
        "Especialidad: ");

    string especialidad =
        Console.ReadLine() ?? "";

    Console.Write(
        "Años de experiencia: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int experiencia))
    {
        MostrarError(
            "Los años de experiencia son inválidos.");

        return;
    }

    if (experiencia < 0)
    {
        MostrarError(
            "La experiencia no puede ser negativa.");

        return;
    }

    try
    {
        using var context =
            new SigrecDbContext();

        Tecnico existente =
            context.Tecnicos
                .FirstOrDefault(
                    t =>
                    t.Cedula == cedula);

        if (existente != null)
        {
            MostrarAdvertencia(
                "Ya existe un técnico con esa cédula.");

            Pausar();
            return;
        }

        Tecnico tecnico =
            new Tecnico(
                0,
                nombre,
                cedula,
                telefono,
                especialidad,
                experiencia);

        context.Tecnicos.Add(
            tecnico);

        context.SaveChanges();

        MostrarExito(
            $"Técnico creado correctamente. ID: {tecnico.Id}");
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
    }

    Pausar();
}


void ListarTecnicos()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE TÉCNICOS",
        "LISTAR TÉCNICOS");

    try
    {
        using var context =
            new SigrecDbContext();

        List<Tecnico> tecnicos =
            context.Tecnicos
                .OrderBy(t => t.Nombre)
                .ToList();

        if (tecnicos.Count == 0)
        {
            MostrarAdvertencia(
                "No existen técnicos registrados.");
        }
        else
        {
            foreach (
                Tecnico tecnico
                in tecnicos)
            {
                tecnico.Imprimir();

                Console.ForegroundColor =
                    ConsoleColor.DarkGray;

                Console.WriteLine(
                    new string(
                        '-',
                        45));

                Console.ResetColor();
            }
        }
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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
        Console.ReadLine() ?? "";

    try
    {
        using var context =
            new SigrecDbContext();

        Tecnico tecnico =
            context.Tecnicos
                .FirstOrDefault(
                    t =>
                    t.Cedula == cedula);

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
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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
        Console.ReadLine() ?? "";

    try
    {
        using var context =
            new SigrecDbContext();

        Tecnico tecnico =
            context.Tecnicos
                .FirstOrDefault(
                    t =>
                    t.Cedula == cedula);

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

        Console.Write(
            "Nuevo nombre: ");

        string nombre =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nueva cédula: ");

        string nuevaCedula =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nuevo teléfono: ");

        string telefono =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nueva especialidad: ");

        string especialidad =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nuevos años de experiencia: ");

        string experienciaTexto =
            Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(
            nuevaCedula))
        {
            bool existeCedula =
                context.Tecnicos.Any(
                    t =>
                    t.Cedula == nuevaCedula &&
                    t.Id != tecnico.Id);

            if (existeCedula)
            {
                MostrarAdvertencia(
                    "La nueva cédula ya pertenece a otro técnico.");

                Pausar();
                return;
            }

            tecnico.Cedula =
                nuevaCedula;
        }

        if (!string.IsNullOrWhiteSpace(
            nombre))
        {
            tecnico.Nombre =
                nombre;
        }

        if (!string.IsNullOrWhiteSpace(
            telefono))
        {
            tecnico.Telefono =
                telefono;
        }

        if (!string.IsNullOrWhiteSpace(
            especialidad))
        {
            tecnico.Especialidad =
                especialidad;
        }

        if (!string.IsNullOrWhiteSpace(
            experienciaTexto))
        {
            if (!int.TryParse(
                experienciaTexto,
                out int experiencia) ||
                experiencia < 0)
            {
                MostrarAdvertencia(
                    "Experiencia inválida.");

                Pausar();
                return;
            }

            tecnico.Experiencia =
                experiencia;
        }

        context.SaveChanges();

        MostrarExito(
            "Técnico actualizado correctamente.");
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
    }

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
        Console.ReadLine() ?? "";

    try
    {
        using var context =
            new SigrecDbContext();

        Tecnico tecnico =
            context.Tecnicos
                .Include(
                    t =>
                    t.Mantenimientos)
                .FirstOrDefault(
                    t =>
                    t.Cedula == cedula);

        if (tecnico == null)
        {
            MostrarAdvertencia(
                "Técnico no encontrado.");

            Pausar();
            return;
        }

        tecnico.Imprimir();

        if (tecnico.Mantenimientos != null &&
            tecnico.Mantenimientos.Count > 0)
        {
            MostrarAdvertencia(
                "No se puede eliminar porque tiene mantenimientos registrados.");

            Pausar();
            return;
        }

        Console.ForegroundColor =
            ConsoleColor.Yellow;

        Console.Write(
            "\n¿Desea eliminar este técnico? S/N: ");

        Console.ResetColor();

        if ((Console.ReadLine() ?? "")
            .Trim()
            .ToUpper() == "S")
        {
            context.Tecnicos.Remove(
                tecnico);

            context.SaveChanges();

            MostrarExito(
                "Técnico eliminado correctamente.");
        }
        else
        {
            MostrarAdvertencia(
                "Operación cancelada.");
        }
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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

    Console.Write(
        "Nombre: ");

    string nombre =
        Console.ReadLine() ?? "";

    Console.Write(
        "Marca: ");

    string marca =
        Console.ReadLine() ?? "";

    Console.Write(
        "Tipo: ");

    string tipo =
        Console.ReadLine() ?? "";

    Console.Write(
        "Cantidad: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int cantidad))
    {
        MostrarError(
            "Cantidad inválida.");

        return;
    }

    Console.Write(
        "Precio: ");

    if (!decimal.TryParse(
        Console.ReadLine(),
        out decimal precio))
    {
        MostrarError(
            "Precio inválido.");

        return;
    }

    try
    {
        Repuesto repuesto =
            new Repuesto(
                0,
                nombre,
                marca,
                tipo,
                cantidad,
                precio);

        using var context =
            new SigrecDbContext();

        context.Repuestos.Add(
            repuesto);

        context.SaveChanges();

        MostrarExito(
            $"Repuesto registrado correctamente. ID: {repuesto.Id}");
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
    }

    Pausar();
}


void ListarRepuestos()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE REPUESTOS",
        "LISTAR REPUESTOS");

    try
    {
        using var context =
            new SigrecDbContext();

        List<Repuesto> repuestos =
            context.Repuestos
                .OrderBy(r => r.Nombre)
                .ToList();

        if (repuestos.Count == 0)
        {
            MostrarAdvertencia(
                "No existen repuestos registrados.");
        }
        else
        {
            foreach (
                Repuesto repuesto
                in repuestos)
            {
                repuesto.Imprimir();

                Console.ForegroundColor =
                    ConsoleColor.DarkGray;

                Console.WriteLine(
                    new string(
                        '-',
                        45));

                Console.ResetColor();
            }
        }
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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
        MostrarError(
            "ID inválido.");

        return;
    }

    try
    {
        using var context =
            new SigrecDbContext();

        Repuesto repuesto =
            context.Repuestos.Find(id);

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
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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
        MostrarError(
            "ID inválido.");

        return;
    }

    try
    {
        using var context =
            new SigrecDbContext();

        Repuesto repuesto =
            context.Repuestos.Find(id);

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

        Console.Write(
            "Nuevo nombre: ");

        string nombre =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nueva marca: ");

        string marca =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nuevo tipo: ");

        string tipo =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nueva cantidad: ");

        string cantidadTexto =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nuevo precio: ");

        string precioTexto =
            Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(
            nombre))
        {
            repuesto.Nombre =
                nombre;
        }

        if (!string.IsNullOrWhiteSpace(
            marca))
        {
            repuesto.Marca =
                marca;
        }

        if (!string.IsNullOrWhiteSpace(
            tipo))
        {
            repuesto.TipoRepuesto =
                tipo;
        }

        if (!string.IsNullOrWhiteSpace(
            cantidadTexto))
        {
            if (!int.TryParse(
                cantidadTexto,
                out int cantidad))
            {
                MostrarAdvertencia(
                    "Cantidad inválida.");

                Pausar();
                return;
            }

            repuesto.Cantidad =
                cantidad;
        }

        if (!string.IsNullOrWhiteSpace(
            precioTexto))
        {
            if (!decimal.TryParse(
                precioTexto,
                out decimal precio))
            {
                MostrarAdvertencia(
                    "Precio inválido.");

                Pausar();
                return;
            }

            repuesto.Precio =
                precio;
        }

        context.SaveChanges();

        MostrarExito(
            "Repuesto actualizado correctamente.");
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
    }

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
        MostrarError(
            "ID inválido.");

        return;
    }

    try
    {
        using var context =
            new SigrecDbContext();

        Repuesto repuesto =
            context.Repuestos.Find(id);

        if (repuesto == null)
        {
            MostrarAdvertencia(
                "Repuesto no encontrado.");

            Pausar();
            return;
        }

        repuesto.Imprimir();

        Console.ForegroundColor =
            ConsoleColor.Yellow;

        Console.Write(
            "\n¿Desea eliminar este repuesto? S/N: ");

        Console.ResetColor();

        if ((Console.ReadLine() ?? "")
            .Trim()
            .ToUpper() == "S")
        {
            context.Repuestos.Remove(
                repuesto);

            context.SaveChanges();

            MostrarExito(
                "Repuesto eliminado correctamente.");
        }
        else
        {
            MostrarAdvertencia(
                "Operación cancelada.");
        }
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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

    try
    {
        using var context =
            new SigrecDbContext();

        if (!context.Clientes.Any())
        {
            MostrarAdvertencia(
                "Primero debe registrar al menos un cliente.");

            Pausar();
            return;
        }

        Console.Write(
            "Cédula del cliente propietario: ");

        string cedula =
            Console.ReadLine() ?? "";

        Cliente cliente =
            context.Clientes
                .FirstOrDefault(
                    c =>
                    c.Cedula == cedula);

        if (cliente == null)
        {
            MostrarAdvertencia(
                "No existe un cliente con esa cédula.");

            Pausar();
            return;
        }

        Console.Write(
            "Código: ");

        string codigo =
            Console.ReadLine() ?? "";

        Equipo existente =
            context.Equipos
                .FirstOrDefault(
                    e =>
                    e.Codigo == codigo);

        if (existente != null)
        {
            MostrarAdvertencia(
                "Ya existe un equipo con ese código.");

            Pausar();
            return;
        }

        Console.Write(
            "Marca: ");

        string marca =
            Console.ReadLine() ?? "";

        Console.Write(
            "Modelo: ");

        string modelo =
            Console.ReadLine() ?? "";

        Console.Write(
            "Capacidad BTU: ");

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
            Console.ReadLine() ?? "";

        Console.Write(
            "Tipo de filtro (Estándar / HEPA): ");

        string tipoFiltro =
            Console.ReadLine() ?? "";

        AireAcondicionado equipo =
            new AireAcondicionado(
                codigo,
                marca,
                modelo,
                capacidad,
                estado,
                tipoFiltro,
                cliente.Id);

        context.Equipos.Add(
            equipo);

        context.SaveChanges();

        MostrarExito(
            $"Equipo creado correctamente. ID: {equipo.Id}");
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
    }

    Pausar();
}


void ListarEquipos()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE EQUIPOS",
        "LISTAR EQUIPOS");

    try
    {
        using var context =
            new SigrecDbContext();

        List<Equipo> equipos =
            context.Equipos
                .Include(e => e.Cliente)
                .OrderBy(e => e.Codigo)
                .ToList();

        if (equipos.Count == 0)
        {
            MostrarAdvertencia(
                "No existen equipos registrados.");
        }
        else
        {
            foreach (
                Equipo equipo
                in equipos)
            {
                equipo.Imprimir();

                Console.ForegroundColor =
                    ConsoleColor.DarkGray;

                Console.WriteLine(
                    new string(
                        '-',
                        50));

                Console.ResetColor();
            }
        }
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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
        Console.ReadLine() ?? "";

    try
    {
        using var context =
            new SigrecDbContext();

        Equipo equipo =
            context.Equipos
                .Include(e => e.Cliente)
                .FirstOrDefault(
                    e =>
                    e.Codigo == codigo);

        if (equipo != null)
        {
            MostrarExito(
                "Equipo encontrado.");

            Console.WriteLine();

            equipo.Imprimir();

            if (equipo is
                AireAcondicionado aire)
            {
                Console.WriteLine(
                    $"Tipo de filtro: {aire.TipoFiltro}");
            }
        }
        else
        {
            MostrarAdvertencia(
                "Equipo no encontrado.");
        }
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
    }

    Pausar();
}


void ActualizarEquipo()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE EQUIPOS",
        "ACTUALIZAR EQUIPO");

    Console.Write(
        "Ingrese el código del equipo: ");

    string codigo =
        Console.ReadLine() ?? "";

    try
    {
        using var context =
            new SigrecDbContext();

        AireAcondicionado equipo =
            context.AiresAcondicionados
                .Include(e => e.Cliente)
                .FirstOrDefault(
                    e =>
                    e.Codigo == codigo);

        if (equipo == null)
        {
            MostrarAdvertencia(
                "Equipo no encontrado.");

            Pausar();
            return;
        }

        Console.WriteLine(
            "\nEquipo encontrado:");

        Console.WriteLine(
            "-----------------------------------");

        equipo.Imprimir();

        Console.WriteLine(
            "-----------------------------------");

        Console.Write(
            "\nNueva marca: ");

        string nuevaMarca =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nuevo modelo: ");

        string nuevoModelo =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nueva capacidad BTU: ");

        string capacidadTexto =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nuevo estado: ");

        string nuevoEstado =
            Console.ReadLine() ?? "";

        Console.Write(
            "Nuevo tipo de filtro: ");

        string nuevoFiltro =
            Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(
            nuevaMarca))
        {
            equipo.Marca =
                nuevaMarca;
        }

        if (!string.IsNullOrWhiteSpace(
            nuevoModelo))
        {
            equipo.Modelo =
                nuevoModelo;
        }

        if (!string.IsNullOrWhiteSpace(
            capacidadTexto))
        {
            if (!int.TryParse(
                capacidadTexto,
                out int nuevaCapacidad))
            {
                MostrarAdvertencia(
                    "Capacidad BTU inválida.");

                Pausar();
                return;
            }

            equipo.CapacidadBTU =
                nuevaCapacidad;
        }

        if (!string.IsNullOrWhiteSpace(
            nuevoEstado))
        {
            equipo.Estado =
                nuevoEstado;
        }

        if (!string.IsNullOrWhiteSpace(
            nuevoFiltro))
        {
            equipo.TipoFiltro =
                nuevoFiltro;
        }

        context.SaveChanges();

        MostrarExito(
            "Equipo actualizado correctamente.");
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
    }

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
        Console.ReadLine() ?? "";

    try
    {
        using var context =
            new SigrecDbContext();

        Equipo equipo =
            context.Equipos
                .Include(
                    e =>
                    e.Mantenimientos)
                .Include(
                    e =>
                    e.Cliente)
                .FirstOrDefault(
                    e =>
                    e.Codigo == codigo);

        if (equipo == null)
        {
            MostrarAdvertencia(
                "Equipo no encontrado.");

            Pausar();
            return;
        }

        equipo.Imprimir();

        if (equipo.Mantenimientos != null &&
            equipo.Mantenimientos.Count > 0)
        {
            MostrarAdvertencia(
                "No se puede eliminar porque tiene mantenimientos registrados.");

            Pausar();
            return;
        }

        Console.ForegroundColor =
            ConsoleColor.Yellow;

        Console.Write(
            "\n¿Desea eliminar este equipo? S/N: ");

        Console.ResetColor();

        if ((Console.ReadLine() ?? "")
            .Trim()
            .ToUpper() == "S")
        {
            context.Equipos.Remove(
                equipo);

            context.SaveChanges();

            MostrarExito(
                "Equipo eliminado correctamente.");
        }
        else
        {
            MostrarAdvertencia(
                "Operación cancelada.");
        }
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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

    try
    {
        using var context =
            new SigrecDbContext();

        if (!context.Equipos.Any())
        {
            MostrarAdvertencia(
                "No existen equipos registrados.");

            Pausar();
            return;
        }

        if (!context.Tecnicos.Any())
        {
            MostrarAdvertencia(
                "No existen técnicos registrados.");

            Pausar();
            return;
        }

        Console.Write(
            "Ingrese código del equipo: ");

        string codigoEquipo =
            Console.ReadLine() ?? "";

        Equipo equipo =
            context.Equipos
                .FirstOrDefault(
                    e =>
                    e.Codigo == codigoEquipo);

        if (equipo == null)
        {
            MostrarAdvertencia(
                "No existe un equipo con ese código.");

            Pausar();
            return;
        }

        Console.Write(
            "Ingrese cédula del técnico: ");

        string cedulaTecnico =
            Console.ReadLine() ?? "";

        Tecnico tecnico =
            context.Tecnicos
                .FirstOrDefault(
                    t =>
                    t.Cedula == cedulaTecnico);

        if (tecnico == null)
        {
            MostrarAdvertencia(
                "No existe un técnico con esa cédula.");

            Pausar();
            return;
        }

        Console.Write(
            "Tipo de mantenimiento (Preventivo/Correctivo): ");

        string tipo =
            Console.ReadLine() ?? "";

        Console.Write(
            "Descripción del trabajo: ");

        string descripcion =
            Console.ReadLine() ?? "";

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
            Console.ReadLine() ?? "";

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

        Mantenimiento mantenimiento =
            new Mantenimiento(
                0,
                equipo.Id,
                tecnico.Id,
                tipo,
                descripcion,
                costo,
                estado,
                duracion);

        context.Mantenimientos.Add(
            mantenimiento);

        context.SaveChanges();

        MostrarExito(
            $"Mantenimiento registrado correctamente. ID: {mantenimiento.Id}");
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
    }

    Pausar();
}


void ListarMantenimientos()
{
    MostrarPantallaOperacion(
        "GESTIÓN DE MANTENIMIENTOS",
        "LISTAR MANTENIMIENTOS");

    try
    {
        using var context =
            new SigrecDbContext();

        List<Mantenimiento> mantenimientos =
            context.Mantenimientos
                .Include(m => m.Equipo)
                .Include(m => m.Tecnico)
                .OrderBy(m => m.Id)
                .ToList();

        if (mantenimientos.Count == 0)
        {
            MostrarAdvertencia(
                "No existen mantenimientos registrados.");
        }
        else
        {
            foreach (
                Mantenimiento mantenimiento
                in mantenimientos)
            {
                mantenimiento.Imprimir();

                Console.ForegroundColor =
                    ConsoleColor.DarkGray;

                Console.WriteLine(
                    new string(
                        '-',
                        55));

                Console.ResetColor();
            }
        }
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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

    try
    {
        using var context =
            new SigrecDbContext();

        Mantenimiento mantenimiento =
            context.Mantenimientos
                .Include(m => m.Equipo)
                .Include(m => m.Tecnico)
                .FirstOrDefault(
                    m =>
                    m.Id == id);

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
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
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

    try
    {
        using var context =
            new SigrecDbContext();

        Mantenimiento mantenimiento =
            context.Mantenimientos
                .Include(m => m.Equipo)
                .Include(m => m.Tecnico)
                .FirstOrDefault(
                    m =>
                    m.Id == id);

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
            Console.ReadLine() ?? "";

        Console.Write(
            $"Nueva descripción (Actual: {mantenimiento.Descripcion}): ");

        string descripcion =
            Console.ReadLine() ?? "";

        Console.Write(
            $"Nuevo costo (Actual: ${mantenimiento.Costo}): ");

        string costoTexto =
            Console.ReadLine() ?? "";

        Console.Write(
            $"Nuevo estado (Actual: {mantenimiento.Estado}): ");

        string estado =
            Console.ReadLine() ?? "";

        Console.Write(
            $"Nueva duración (Actual: {mantenimiento.DuracionHoras} horas): ");

        string duracionTexto =
            Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(
            tipo))
        {
            mantenimiento.TipoMantenimiento =
                tipo;
        }

        if (!string.IsNullOrWhiteSpace(
            descripcion))
        {
            mantenimiento.Descripcion =
                descripcion;
        }

        if (!string.IsNullOrWhiteSpace(
            costoTexto))
        {
            if (!decimal.TryParse(
                costoTexto,
                out decimal costo))
            {
                MostrarAdvertencia(
                    "Costo inválido.");

                Pausar();
                return;
            }

            mantenimiento.Costo =
                costo;
        }

        if (!string.IsNullOrWhiteSpace(
            estado))
        {
            mantenimiento.Estado =
                estado;
        }

        if (!string.IsNullOrWhiteSpace(
            duracionTexto))
        {
            if (!int.TryParse(
                duracionTexto,
                out int duracion))
            {
                MostrarAdvertencia(
                    "Duración inválida.");

                Pausar();
                return;
            }

            mantenimiento.DuracionHoras =
                duracion;
        }

        context.SaveChanges();

        MostrarExito(
            "Mantenimiento actualizado correctamente.");
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

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

    try
    {
        using var context =
            new SigrecDbContext();

        Mantenimiento mantenimiento =
            context.Mantenimientos
                .Include(m => m.Equipo)
                .Include(m => m.Tecnico)
                .FirstOrDefault(
                    m =>
                    m.Id == id);

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

        if ((Console.ReadLine() ?? "")
            .Trim()
            .ToUpper() == "S")
        {
            context.Mantenimientos.Remove(
                mantenimiento);

            context.SaveChanges();

            MostrarExito(
                "Mantenimiento eliminado correctamente.");
        }
        else
        {
            MostrarAdvertencia(
                "Operación cancelada.");
        }
    }
    catch (Exception ex)
    {
        MostrarError(
            ObtenerMensajeError(ex));

        return;
    }

    Pausar();
}


// ================================================================
// OBTENER MENSAJE REAL DE ERROR SQL
// ================================================================

string ObtenerMensajeError(
    Exception ex)
{
    Exception error = ex;

    while (error.InnerException != null)
    {
        error =
            error.InnerException;
    }

    return error.Message;
}   