using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Services
{
    public class CorreoService
    {
        public async Task EnviarAsync(
            string destinatario,
            string asunto,
            string mensaje)
        {
            if (string.IsNullOrWhiteSpace(destinatario))
                throw new ArgumentException("El correo del destinatario es obligatorio.");

            string? correoRemitente =
                Environment.GetEnvironmentVariable("SIGREC_EMAIL") ??
                Environment.GetEnvironmentVariable(
                    "SIGREC_EMAIL",
                    EnvironmentVariableTarget.User);

            string? claveCorreo =
                Environment.GetEnvironmentVariable("SIGREC_EMAIL_PASSWORD") ??
                Environment.GetEnvironmentVariable(
                    "SIGREC_EMAIL_PASSWORD",
                    EnvironmentVariableTarget.User);

            string smtpHost =
                Environment.GetEnvironmentVariable("SIGREC_SMTP_HOST") ??
                Environment.GetEnvironmentVariable(
                    "SIGREC_SMTP_HOST",
                    EnvironmentVariableTarget.User) ??
                "smtp.gmail.com";

            string puertoTexto =
                Environment.GetEnvironmentVariable("SIGREC_SMTP_PORT") ??
                Environment.GetEnvironmentVariable(
                    "SIGREC_SMTP_PORT",
                    EnvironmentVariableTarget.User) ??
                "465";

            string nombreRemitente =
                Environment.GetEnvironmentVariable("SIGREC_EMAIL_NOMBRE") ??
                Environment.GetEnvironmentVariable(
                    "SIGREC_EMAIL_NOMBRE",
                    EnvironmentVariableTarget.User) ??
                "SIGREC";

            if (string.IsNullOrWhiteSpace(correoRemitente))
            {
                throw new Exception(
                    "No se encontró la variable de entorno SIGREC_EMAIL.");
            }

            if (string.IsNullOrWhiteSpace(claveCorreo))
            {
                throw new Exception(
                    "No se encontró la variable de entorno SIGREC_EMAIL_PASSWORD.");
            }

            if (!int.TryParse(puertoTexto, out int puerto))
            {
                throw new Exception(
                    "SIGREC_SMTP_PORT no contiene un puerto válido.");
            }

            MimeMessage correo = new MimeMessage();

            correo.From.Add(
                new MailboxAddress(
                    nombreRemitente,
                    correoRemitente));

            correo.To.Add(
                MailboxAddress.Parse(destinatario));

            correo.Subject = asunto;

            correo.Body =
                new TextPart("plain")
                {
                    Text = mensaje
                };

            using SmtpClient clienteSmtp = new SmtpClient();

            SecureSocketOptions seguridad =
                puerto == 465
                    ? SecureSocketOptions.SslOnConnect
                    : SecureSocketOptions.StartTls;

            await clienteSmtp.ConnectAsync(
                smtpHost,
                puerto,
                seguridad);

            await clienteSmtp.AuthenticateAsync(
                correoRemitente,
                claveCorreo);

            await clienteSmtp.SendAsync(correo);

            await clienteSmtp.DisconnectAsync(true);
        }
    }
}
