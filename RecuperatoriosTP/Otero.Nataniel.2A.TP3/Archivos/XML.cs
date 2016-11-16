using System;
using System.Collections.Generic;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {

        /// <summary>
        /// guarda los datos en un xml
        /// </summary>
        /// <param name="archivo">lugar a guardar</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            XmlSerializer serializador;
            XmlTextWriter escritor;

            try
            {
                serializador = new XmlSerializer(typeof(T));
                escritor = new XmlTextWriter(archivo, Encoding.UTF8);

                serializador.Serialize(escritor, datos);
                escritor.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

        }
        /// <summary>
        /// lee un xml
        /// </summary>
        /// <param name="archivo">xml a leer</param>
        /// <param name="datos">dato devuelto</param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos)
        {
            XmlSerializer serializador;
            XmlTextReader lector;

            try
            {
                serializador = new XmlSerializer(typeof(T));
                lector = new XmlTextReader(archivo);

                datos = (T)serializador.Deserialize(lector);
                lector.Close();

                return true;
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
        }
    }
}

