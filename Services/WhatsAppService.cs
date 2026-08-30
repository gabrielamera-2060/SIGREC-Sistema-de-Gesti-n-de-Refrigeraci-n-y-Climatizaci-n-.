using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Services
{
    public class WhatsAppResultado
    {
        public bool Exitoso { get; set; }
        public string? MensajeId { get; set; }
        public string Detalle { get; set; } = string.Empty;
    }

    public class WhatsAppService
    {
        private static readonly HttpClient ClienteHttp = new HttpClient();

        private static string ObtenerVariableObligatoria(string nombre)
        {
            string? valor =
                Environment.GetEnvironmentVariable(nombre) ??
                Environment.GetEnvironmentVariable(
                    nombre,
                    EnvironmentVariableTarget.User);

            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new Exception(
                    $"No se encontró la variable de entorno {nombre}.");
            }

            return valor.Trim();
        }

        private static string ObtenerUrlMensajes()
        {
            string version =
                ObtenerVariableObligatoria(
                    "SIGREC_WHATSAPP_GRAPH_VERSION");

            string phoneNumberId =
                ObtenerVariableObligatoria(
                    "SIGREC_WHATSAPP_PHONE_NUMBER_ID");

            return
                $"https://graph.facebook.com/{version}/{phoneNumberId}/messages";
        }

        public async Task<WhatsAppResultado> EnviarTextoAsync(
            string telefono,
            string mensaje)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException(
                    "El teléfono del destinatario es obligatorio.");

            if (string.IsNullOrWhiteSpace(mensaje))
                throw new ArgumentException(
                    "El mensaje es obligatorio.");

            object payload = new
            {
                messaging_product = "whatsapp",
                recipient_type = "individual",
                to = telefono,
                type = "text",
                text = new
                {
                    preview_url = false,
                    body = mensaje
                }
            };

            return await EnviarAsync(payload);
        }

        public async Task<WhatsAppResultado> EnviarPlantillaPruebaAsync(
            string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException(
                    "El teléfono del destinatario es obligatorio.");

            object payload = new
            {
                messaging_product = "whatsapp",
                to = telefono,
                type = "template",
                template = new
                {
                    name = "hello_world",
                    language = new
                    {
                        code = "en_US"
                    }
                }
            };

            return await EnviarAsync(payload);
        }

        private async Task<WhatsAppResultado> EnviarAsync(
            object payload)
        {
            string token =
                ObtenerVariableObligatoria(
                    "SIGREC_WHATSAPP_TOKEN");

            string url =
                ObtenerUrlMensajes();

            string json =
                JsonSerializer.Serialize(payload);

            using HttpRequestMessage request =
                new HttpRequestMessage(
                    HttpMethod.Post,
                    url);

            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);

            request.Content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

            using HttpResponseMessage response =
                await ClienteHttp.SendAsync(request);

            string contenido =
                await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new WhatsAppResultado
                {
                    Exitoso = false,
                    Detalle =
                        $"HTTP {(int)response.StatusCode}: {contenido}"
                };
            }

            string? mensajeId = null;

            try
            {
                using JsonDocument documento =
                    JsonDocument.Parse(contenido);

                JsonElement raiz =
                    documento.RootElement;

                if (raiz.TryGetProperty(
                        "messages",
                        out JsonElement messages) &&
                    messages.ValueKind ==
                        JsonValueKind.Array &&
                    messages.GetArrayLength() > 0)
                {
                    JsonElement primerMensaje =
                        messages[0];

                    if (primerMensaje.TryGetProperty(
                            "id",
                            out JsonElement id))
                    {
                        mensajeId =
                            id.GetString();
                    }
                }
            }
            catch
            {
                // El envío fue aceptado por la API.
                // Si cambia el formato de respuesta,
                // se conserva igualmente el detalle recibido.
            }

            return new WhatsAppResultado
            {
                Exitoso = true,
                MensajeId = mensajeId,
                Detalle = contenido
            };
        }
    }
}
