using System;
using System.Collections.Generic;
using System.Text;

namespace SIGREC__Sistema_de_Gestión_de_Refrigeración_y_Climatización__.Generales
{
    public static class ArchivoJson
    {
        private static readonly JsonSerializerOptions opciones = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public static List<T> Cargar<T>(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                return new List<T>();
            }

            string json = File.ReadAllText(rutaArchivo);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(json, opciones) ?? new List<T>();
        }

        public static void Guardar<T>(string rutaArchivo, List<T> datos)
        {
            string json = JsonSerializer.Serialize(datos, opciones);
            File.WriteAllText(rutaArchivo, json);
        }
    }
}
