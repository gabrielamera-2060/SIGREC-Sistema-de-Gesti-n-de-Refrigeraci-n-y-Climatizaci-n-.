#pragma warning disable OPENAI001

using System;
using System.Linq;
using System.Threading.Tasks;
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


        public async Task<string> PreguntarAsync(
            string pregunta)
        {
            if (string.IsNullOrWhiteSpace(pregunta))
            {
                return "La pregunta no puede estar vacía.";
            }

            string preguntaNormalizada =
                NormalizarPregunta(pregunta);


            // =================================================
            // 1. BUSCAR PRIMERO EN SQL SERVER
            // =================================================

            using (var context =
                   new SigrecDbContext())
            {
                ConsultaIA consultaExistente =
                    context.ConsultasIA
                        .AsEnumerable()
                        .FirstOrDefault(
                            c =>
                            NormalizarPregunta(
                                c.Pregunta)
                            == preguntaNormalizada);

                if (consultaExistente != null)
                {
                    return
                        "[Respuesta recuperada de SIGREC]\n\n" +
                        consultaExistente.Respuesta;
                }
            }


            // =================================================
            // 2. OBTENER API KEY
            // =================================================

            string? apiKey =
                Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return
                    "No se encontró la variable OPENAI_API_KEY.";
            }


            // =================================================
            // 3. CONSULTAR OPENAI
            // =================================================

            try
            {
                ResponsesClient client =
                    new ResponsesClient(apiKey);

                string instrucciones =
                    """
                    Eres el asistente técnico del sistema SIGREC,
                    Sistema de Gestión de Refrigeración y
                    Climatización.

                    Responde en español de forma clara,
                    profesional y sencilla.

                    Tu función es ayudar con conceptos de
                    refrigeración, climatización, mantenimiento,
                    equipos, repuestos y funcionamiento general
                    del sistema SIGREC.

                    Si no conoces una respuesta, indícalo
                    claramente. No inventes información.
                    """;

                string prompt =
                    instrucciones +
                    "\n\nPregunta del usuario:\n" +
                    pregunta;

                ResponseResult response =
                    await client.CreateResponseAsync(
                        modelo,
                        prompt);

                string respuesta =
                    response.GetOutputText();


                // =================================================
                // 4. GUARDAR PREGUNTA Y RESPUESTA
                // =================================================

                using (var context =
                       new SigrecDbContext())
                {
                    ConsultaIA consulta =
                        new ConsultaIA(
                            pregunta,
                            respuesta,
                            modelo);

                    context.ConsultasIA.Add(
                        consulta);

                    await context.SaveChangesAsync();
                }

                return respuesta;
            }
            catch (Exception ex)
            {
                return
                    "No fue posible consultar OpenAI.\n" +
                    ex.Message;
            }
        }


        private string NormalizarPregunta(
            string pregunta)
        {
            return pregunta
                .Trim()
                .ToLowerInvariant();
        }
    }
}