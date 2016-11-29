using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;

        public Texto(string archivo)
        {
            this._archivo = archivo;
        }
        /// <summary>
        /// guarda los datos en el archivo
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                StreamWriter escritor  = new StreamWriter(this._archivo, true);
                escritor.WriteLine(datos);
                escritor.Close();
                return true;
            }
            catch (Exception)
            {
                
                
                return false;
            } 
            
        }
        /// <summary>
        /// Lee los datos del archivo y los asigna a datos
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            bool flag = false;
            try
            {
                StreamReader lector = new StreamReader(this._archivo);

                datos = new List<string>();

                while(!lector.EndOfStream)
                {
                    datos.Add(lector.ReadLine());
                }

                lector.Close();

                flag = true;
            }
            catch (Exception)
            {
                datos = null;
                flag = false;
            }            
             return flag;
            
        }
    }
}
