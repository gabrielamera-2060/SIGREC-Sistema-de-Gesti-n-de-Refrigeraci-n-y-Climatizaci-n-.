#pragma warning disable OPENAI001

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenAI.Responses;

using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Datos;
using SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.models;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Services
{
    public class OpenAIService
    {
        private readonly string modelo;

        public OpenAIService(string modelo = "gpt-5.2")
        {
            this.modelo = modelo;
        }

        // =====================================================
        // MÉTODO PRINCIPAL
        // =====================================================

        public async Task<string> PreguntarAsync(string pregunta)
        {
            if (string.IsNullOrWhiteSpace(pregunta))
            {
                return "La pregunta no puede estar vacía.";
            }

            string preguntaNormalizada =
                NormalizarPregunta(pregunta);

            // =================================================
            // 1. BUSCAR PREGUNTA REPETIDA
            // =================================================

            using (var context = new SigrecDbContext())
            {
                ConsultaIA? consultaExistente =
                    context.ConsultasIA
                        .OrderBy(c => c.Id)
                        .AsEnumerable()
                        .FirstOrDefault(c =>
                            NormalizarPregunta(c.Pregunta)
                            == preguntaNormalizada);

                if (consultaExistente != null)
                {
                    return
                        "==================================================\n" +
                        "⚠ PREGUNTA REPETIDA\n" +
                        "==================================================\n\n" +
                        "Esta pregunta ya fue realizada anteriormente.\n" +
                        "SIGREC escogerá la primera respuesta registrada.\n\n" +
                        "PRIMERA RESPUESTA REGISTRADA:\n" +
                        "--------------------------------------------------\n\n" +
                        consultaExistente.Respuesta;
                }
            }

            // =================================================
            // 2. OBTENER API KEY
            // =================================================

            string? apiKey =
                Environment.GetEnvironmentVariable(
                    "OPENAI_API_KEY");

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                apiKey =
                    Environment.GetEnvironmentVariable(
                        "OPENAI_API_KEY",
                        EnvironmentVariableTarget.User);
            }

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return
                    "No se encontró la variable OPENAI_API_KEY.";
            }

            // =================================================
            // 3. DETECTAR TIPO DE PREGUNTA
            // =================================================

            string tipoConsulta =
                DetectarTipoConsulta(preguntaNormalizada);

            string contextoSigrec;

            try
            {
                contextoSigrec =
                    await ConstruirContextoSegunPreguntaAsync(
                        tipoConsulta);
            }
            catch (Exception ex)
            {
                return
                    "No fue posible consultar SQL Server.\n\n" +
                    ObtenerMensajeError(ex);
            }

            // =================================================
            // 4. CONSULTAR OPENAI
            // =================================================

            try
            {
                ResponsesClient client =
                    new ResponsesClient(apiKey);

                string instrucciones =
                    """
                    Eres el Asistente Inteligente del sistema SIGREC.

                    SIGREC significa:
                    Sistema de Gestión de Refrigeración y
                    Climatización.

                    Responde siempre en español.

                    Debes responder de manera clara,
                    profesional y sencilla.

                    Puedes ayudar con:

                    - Refrigeración.
                    - Climatización.
                    - Aires acondicionados.
                    - Refrigeradores.
                    - Cámaras frigoríficas.
                    - Equipos.
                    - Técnicos.
                    - Repuestos.
                    - Mantenimientos preventivos.
                    - Mantenimientos correctivos.

                    También recibirás información almacenada
                    en la base de datos SIGREC.

                    REGLAS:

                    1. Si la pregunta se refiere a SIGREC,
                       utiliza exclusivamente los datos
                       proporcionados.

                    2. No inventes equipos, técnicos,
                       mantenimientos o repuestos.

                    3. Si la información no existe,
                       indica claramente:
                       "No se encontró información registrada
                       en SIGREC."

                    4. No muestres cédulas, teléfonos,
                       contraseñas ni información privada.

                    5. Para preguntas técnicas generales,
                       puedes utilizar tus conocimientos.

                    6. Responde de forma breve y entendible.
                    """;

                string prompt =
                    instrucciones +
                    "\n\n" +
                    "TIPO DE CONSULTA DETECTADA:\n" +
                    tipoConsulta +
                    "\n\n" +
                    "========================================\n" +
                    "INFORMACIÓN DE SIGREC\n" +
                    "========================================\n\n" +
                    contextoSigrec +
                    "\n\n" +
                    "========================================\n" +
                    "PREGUNTA DEL USUARIO\n" +
                    "========================================\n\n" +
                    pregunta;

                ResponseResult response =
                    await client.CreateResponseAsync(
                        modelo,
                        prompt);

                string respuesta =
                    response.GetOutputText();

                if (string.IsNullOrWhiteSpace(respuesta))
                {
                    return "OpenAI no devolvió una respuesta.";
                }

                // =================================================
                // 5. GUARDAR RESPUESTA
                // =================================================

                using (var context =
                       new SigrecDbContext())
                {
                    ConsultaIA consulta =
                        new ConsultaIA(
                            pregunta,
                            respuesta,
                            modelo);

                    context.ConsultasIA.Add(consulta);

                    await context.SaveChangesAsync();
                }

                return
                    "==================================================\n" +
                    "✓ CONSULTA PROCESADA POR SIGREC\n" +
                    "==================================================\n\n" +
                    "Tipo detectado: " +
                    tipoConsulta +
                    "\n\n" +
                    respuesta +
                    "\n\n" +
                    "--------------------------------------------------\n" +
                    "Consulta guardada correctamente.";
            }
            catch (Exception ex)
            {
                return
                    "No fue posible consultar OpenAI.\n\n" +
                    ObtenerMensajeError(ex);
            }
        }

        // =====================================================
        // DETECTAR TIPO DE CONSULTA
        // =====================================================

        private string DetectarTipoConsulta(
            string pregunta)
        {
            if (pregunta.Contains("mantenimiento") ||
                pregunta.Contains("mantenimientos") ||
                pregunta.Contains("reparacion") ||
                pregunta.Contains("reparación"))
            {
                return "MANTENIMIENTO";
            }

            if (pregunta.Contains("repuesto") ||
                pregunta.Contains("repuestos") ||
                pregunta.Contains("pieza") ||
                pregunta.Contains("inventario"))
            {
                return "REPUESTO";
            }

            if (pregunta.Contains("tecnico") ||
                pregunta.Contains("técnico") ||
                pregunta.Contains("tecnicos") ||
                pregunta.Contains("técnicos"))
            {
                return "TECNICO";
            }

            if (pregunta.Contains("equipo") ||
                pregunta.Contains("equipos") ||
                pregunta.Contains("aire acondicionado") ||
                pregunta.Contains("refrigerador") ||
                pregunta.Contains("camara") ||
                pregunta.Contains("cámara"))
            {
                return "EQUIPO";
            }

            return "GENERAL";
        }

        // =====================================================
        // CONSTRUIR CONTEXTO SEGÚN LA PREGUNTA
        // =====================================================

        private async Task<string>
            ConstruirContextoSegunPreguntaAsync(
                string tipoConsulta)
        {
            switch (tipoConsulta)
            {
                case "EQUIPO":

                    return
                        await ObtenerEquiposAsync();

                case "MANTENIMIENTO":

                    return
                        await ObtenerMantenimientosAsync();

                case "TECNICO":

                    return
                        await ObtenerTecnicosAsync();

                case "REPUESTO":

                    return
                        await ObtenerRepuestosAsync();

                default:

                    return
                        "La consulta no requiere datos " +
                        "específicos de la base SIGREC.";
            }
        }

        // =====================================================
        // EQUIPOS
        // =====================================================

        private async Task<string>
            ObtenerEquiposAsync()
        {
            StringBuilder texto =
                new StringBuilder();

            using var db =
                new SigrecDbContext();

            var equipos =
                await db.Equipos
                    .AsNoTracking()
                    .OrderBy(e => e.Id)
                    .Take(50)
                    .ToListAsync();

            texto.AppendLine(
                "EQUIPOS REGISTRADOS:");

            if (equipos.Count == 0)
            {
                texto.AppendLine(
                    "No existen equipos registrados.");

                return texto.ToString();
            }

            foreach (Equipo equipo in equipos)
            {
                texto.AppendLine(
                    $"ID: {equipo.Id}");

                texto.AppendLine(
                    $"Código: {equipo.Codigo}");

                texto.AppendLine(
                    $"Marca: {equipo.Marca}");

                texto.AppendLine(
                    $"Modelo: {equipo.Modelo}");

                texto.AppendLine(
                    $"Capacidad BTU: " +
                    $"{equipo.CapacidadBTU}");

                texto.AppendLine(
                    $"Estado: {equipo.Estado}");

                texto.AppendLine(
                    $"Tipo: {equipo.GetType().Name}");

                if (equipo is
                    AireAcondicionado aire)
                {
                    texto.AppendLine(
                        $"Tipo de filtro: " +
                        $"{aire.TipoFiltro}");
                }

                if (equipo is
                    CamaraFrigorifica camara)
                {
                    texto.AppendLine(
                        $"Temperatura mínima: " +
                        $"{camara.TemperaturaMinima}");
                }

                if (equipo is
                    Refrigerador refrigerador)
                {
                    texto.AppendLine(
                        $"Número de puertas: " +
                        $"{refrigerador.NumeroPuertas}");
                }

                texto.AppendLine(
                    "------------------------------");
            }

            return texto.ToString();
        }

        // =====================================================
        // MANTENIMIENTOS
        // =====================================================

        private async Task<string>
            ObtenerMantenimientosAsync()
        {
            StringBuilder texto =
                new StringBuilder();

            using var db =
                new SigrecDbContext();

            var mantenimientos =
                await db.Mantenimientos
                    .AsNoTracking()
                    .Include(m => m.Equipo)
                    .Include(m => m.Tecnico)
                    .OrderByDescending(m => m.Id)
                    .Take(50)
                    .ToListAsync();

            texto.AppendLine(
                "MANTENIMIENTOS REGISTRADOS:");

            if (mantenimientos.Count == 0)
            {
                texto.AppendLine(
                    "No existen mantenimientos registrados.");

                return texto.ToString();
            }

            foreach (Mantenimiento mantenimiento
                     in mantenimientos)
            {
                texto.AppendLine(
                    $"ID: {mantenimiento.Id}");

                texto.AppendLine(
                    $"Tipo: " +
                    $"{mantenimiento.TipoMantenimiento}");

                texto.AppendLine(
                    $"Descripción: " +
                    $"{mantenimiento.Descripcion}");

                texto.AppendLine(
                    $"Estado: " +
                    $"{mantenimiento.Estado}");

                texto.AppendLine(
                    $"Costo: $" +
                    $"{mantenimiento.Costo}");

                texto.AppendLine(
                    $"Duración: " +
                    $"{mantenimiento.DuracionHoras} horas");

                if (mantenimiento.Equipo != null)
                {
                    texto.AppendLine(
                        $"Equipo: " +
                        $"{mantenimiento.Equipo.Codigo}");

                    texto.AppendLine(
                        $"Marca: " +
                        $"{mantenimiento.Equipo.Marca}");

                    texto.AppendLine(
                        $"Modelo: " +
                        $"{mantenimiento.Equipo.Modelo}");
                }

                if (mantenimiento.Tecnico != null)
                {
                    texto.AppendLine(
                        $"Técnico: " +
                        $"{mantenimiento.Tecnico.Nombre}");

                    texto.AppendLine(
                        $"Especialidad: " +
                        $"{mantenimiento.Tecnico.Especialidad}");
                }

                texto.AppendLine(
                    "------------------------------");
            }

            return texto.ToString();
        }

        // =====================================================
        // TÉCNICOS
        // =====================================================

        private async Task<string>
            ObtenerTecnicosAsync()
        {
            StringBuilder texto =
                new StringBuilder();

            using var db =
                new SigrecDbContext();

            var tecnicos =
                await db.Tecnicos
                    .AsNoTracking()
                    .OrderBy(t => t.Nombre)
                    .Take(50)
                    .ToListAsync();

            texto.AppendLine(
                "TÉCNICOS REGISTRADOS:");

            if (tecnicos.Count == 0)
            {
                texto.AppendLine(
                    "No existen técnicos registrados.");

                return texto.ToString();
            }

            foreach (Tecnico tecnico in tecnicos)
            {
                texto.AppendLine(
                    $"ID: {tecnico.Id}");

                texto.AppendLine(
                    $"Nombre: {tecnico.Nombre}");

                texto.AppendLine(
                    $"Especialidad: " +
                    $"{tecnico.Especialidad}");

                texto.AppendLine(
                    $"Experiencia: " +
                    $"{tecnico.Experiencia} años");

                texto.AppendLine(
                    "------------------------------");
            }

            return texto.ToString();
        }

        // =====================================================
        // REPUESTOS
        // =====================================================

        private async Task<string>
            ObtenerRepuestosAsync()
        {
            StringBuilder texto =
                new StringBuilder();

            using var db =
                new SigrecDbContext();

            var repuestos =
                await db.Repuestos
                    .AsNoTracking()
                    .OrderBy(r => r.Nombre)
                    .Take(50)
                    .ToListAsync();

            texto.AppendLine(
                "REPUESTOS REGISTRADOS:");

            if (repuestos.Count == 0)
            {
                texto.AppendLine(
                    "No existen repuestos registrados.");

                return texto.ToString();
            }

            foreach (Repuesto repuesto
                     in repuestos)
            {
                texto.AppendLine(
                    $"ID: {repuesto.Id}");

                texto.AppendLine(
                    $"Nombre: {repuesto.Nombre}");

                texto.AppendLine(
                    $"Marca: {repuesto.Marca}");

                texto.AppendLine(
                    $"Tipo: {repuesto.TipoRepuesto}");

                texto.AppendLine(
                    $"Cantidad disponible: " +
                    $"{repuesto.Cantidad}");

                texto.AppendLine(
                    $"Precio: $" +
                    $"{repuesto.Precio}");

                texto.AppendLine(
                    "------------------------------");
            }

            return texto.ToString();
        }

        // =====================================================
        // NORMALIZAR PREGUNTA
        // =====================================================

        private string NormalizarPregunta(
            string pregunta)
        {
            return pregunta
                .Trim()
                .ToLowerInvariant();
        }

        // =====================================================
        // OBTENER ERROR REAL
        // =====================================================

        private string ObtenerMensajeError(
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
    }
}