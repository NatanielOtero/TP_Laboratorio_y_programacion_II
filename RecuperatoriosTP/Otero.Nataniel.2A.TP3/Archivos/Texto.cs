using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excepciones;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos en un txt
        /// </summary>
        /// <param name="archivo">destino a guardar</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns></returns>
        public bool guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo, true);

                sw.Write(datos);
                sw.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Lee un archivo
        /// </summary>
        /// <param name="archivo">archivo a leer</param>
        /// <param name="datos">dato obtenido</param>
        /// <returns></returns>

        public bool leer(string archivo, out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo);

                datos = sr.ReadToEnd();
                sr.Close();

                return true;
            }
            catch (Exception e)
            {
                datos = default(string);
                throw new ArchivosException(e);
            }
        }
    }
}
