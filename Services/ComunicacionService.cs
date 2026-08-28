using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Services
{
    public class ComunicacionService
    {
        // =====================================================
        // ABRIR CORREO ELECTRÓNICO
        // =====================================================

        public void AbrirCorreo(
            string correo,
            string asunto,
            string mensaje)
        {
            try
            {
                string url =
                    "mailto:" +
                    correo +
                    "?subject=" +
                    Uri.EscapeDataString(asunto) +
                    "&body=" +
                    Uri.EscapeDataString(mensaje);

                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No fue posible abrir el correo.");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        // =====================================================
        // ABRIR WHATSAPP
        // =====================================================

        public void AbrirWhatsApp(
            string telefono,
            string mensaje)
        {
            try
            {
                string numero =
                    telefono
                        .Replace("+", "")
                        .Replace(" ", "")
                        .Replace("-", "")
                        .Replace("(", "")
                        .Replace(")", "");

                string url =
                    "https://wa.me/" +
                    numero +
                    "?text=" +
                    Uri.EscapeDataString(mensaje);

                Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No fue posible abrir WhatsApp.");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}
