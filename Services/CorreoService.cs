using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Services
{
    public static class CorreoService
    {
        public static async Task EnviarAsync(
            string correoDestino,
            string asunto,
            string mensaje)
        {
            string? correoRemitente =
                Environment.GetEnvironmentVariable("SIGREC_SMTP_EMAIL");

            if (string.IsNullOrWhiteSpace(correoRemitente))
            {
                correoRemitente =
                    Environment.GetEnvironmentVariable(
                        "SIGREC_SMTP_EMAIL",
                        EnvironmentVariableTarget.User);
            }

            string? clave =
                Environment.GetEnvironmentVariable("SIGREC_SMTP_PASSWORD");

            if (string.IsNullOrWhiteSpace(clave))
            {
                clave =
                    Environment.GetEnvironmentVariable(
                        "SIGREC_SMTP_PASSWORD",
                        EnvironmentVariableTarget.User);
            }

            string? host =
                Environment.GetEnvironmentVariable("SIGREC_SMTP_HOST");

            if (string.IsNullOrWhiteSpace(host))
            {
                host =
                    Environment.GetEnvironmentVariable(
                        "SIGREC_SMTP_HOST",
                        EnvironmentVariableTarget.User);
            }

            string? puertoTexto =
                Environment.GetEnvironmentVariable("SIGREC_SMTP_PORT");

            if (string.IsNullOrWhiteSpace(puertoTexto))
            {
                puertoTexto =
                    Environment.GetEnvironmentVariable(
                        "SIGREC_SMTP_PORT",
                        EnvironmentVariableTarget.User);
            }

            if (string.IsNullOrWhiteSpace(correoRemitente))
                throw new Exception(
                    "No se encontró la variable SIGREC_SMTP_EMAIL.");

            if (string.IsNullOrWhiteSpace(clave))
                throw new Exception(
                    "No se encontró la variable SIGREC_SMTP_PASSWORD.");

            host = string.IsNullOrWhiteSpace(host)
                ? "smtp.gmail.com"
                : host;

            int puerto = 587;

            if (!string.IsNullOrWhiteSpace(puertoTexto) &&
                int.TryParse(puertoTexto, out int puertoConfigurado))
            {
                puerto = puertoConfigurado;
            }

            using MailMessage correo = new MailMessage();

            correo.From = new MailAddress(
                correoRemitente,
                "SIGREC");

            correo.To.Add(correoDestino);
            correo.Subject = asunto;
            correo.Body = mensaje;
            correo.IsBodyHtml = false;

            // Se especifica el namespace completo para evitar
            // conflicto con MailKit.Net.Smtp.SmtpClient.
            using System.Net.Mail.SmtpClient smtp =
                new System.Net.Mail.SmtpClient(
                    host,
                    puerto);

            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials =
                new NetworkCredential(
                    correoRemitente,
                    clave);

            await smtp.SendMailAsync(correo);
        }
    }
}

