using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS
{
    public class Registro
    {
        public string Nombre { get; set; }
        public string Carrera { get; set; }

        public Registro()
        {
            Nombre = string.Empty;
            Carrera = string.Empty;
        }

        public Registro(string nombre, string carrera)
        {
            Nombre = nombre;
            Carrera = carrera;
        }

        /// <summary>
        /// Convierte el registro a formato de texto para guardar en archivo
        /// Formato: Nombre|Carrera
        /// </summary>
        public string ToFileString()
        {
            return $"{Nombre}|{Carrera}";
        }

        /// <summary>
        /// Crea un objeto Registro desde una línea de texto del archivo
        /// </summary>
        public static Registro? FromFileString(string linea)
        {
            if (string.IsNullOrWhiteSpace(linea))
                return null;

            string[] partes = linea.Split('|');

            if (partes.Length != 2)
                return null;

            try
            {
                return new Registro
                {
                    Nombre = partes[0],
                    Carrera = partes[1]
                };
            }
            catch
            {
                return null;
            }
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Carrera: {Carrera}";
        }
    }
}
