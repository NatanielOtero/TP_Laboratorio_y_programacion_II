using System;
using System.Collections.Generic;
using Archivos;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Text;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        #region Constructores
        /// <summary>
        /// Constructor de Jornada
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        /// <summary>
        /// sobrecarga de jornada
        /// </summary>
        /// <param name="clase">clase de la jordana</param>
        /// <param name="instructor">instructor de la jornada</param>
        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion
        #region Propiedades
        public List<Alumno> alumnos
        {
            get
            {
                return this._alumnos;
            }
        }
        public Instructor instructor
        {
            get
            {
                return this._instructor;
            }
        }
        public Gimnasio.EClases clases
        {
            get        
            {
                return this._clase;
            }
        }
       
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos en un archivo txt
        /// </summary>
        /// <param name="jornada">datos a guardar</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            

            Texto texto = new Texto();
            return texto.guardar("jornada.txt", jornada.ToString());          
                                 
           
        }
        /// <summary>
        /// lee los datos del txt y los devuelve en un string
        /// </summary>
        /// <returns></returns>
        public static string leer()
        {
            string pathTexto = "jornada.txt";
            string aux;

            Texto text = new Texto();
            text.leer(pathTexto, out aux);

            return aux;
        }
        /// <summary>
        /// sobrecarga de toString
        /// </summary>
        /// <returns>cadena con la info de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sbJornada;
            sbJornada = new StringBuilder();

            sbJornada.AppendLine("--JORNADA--");
            sbJornada.AppendLine("Instructor: " + this._instructor.ToString());
            sbJornada.AppendLine("Da la clase de: " + this._clase.ToString());
            sbJornada.AppendLine("Alumnos");
            foreach (Alumno item in this._alumnos)
            {
                sbJornada.AppendLine(item.ToString());
            }
            

            return sbJornada.ToString();
        }

        #endregion       

        #region Sobrecargas
        /// <summary>
        /// sobrecargar del ==
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true o false dependiendo si el alumno este en el jornada</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (j._alumnos.Contains(a))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// sobrecarga del distinto
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true o false dependiendo si el alumno este en el jornada</return
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// sobrecarga de +
        /// </summary>
        /// <param name="j">jornada a incrementar</param>
        /// <param name="a">alumno a incluir en la jornada</param>
        /// <returns>una jordana con el alumno a agregado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            int i;
            for ( i = 0; i < j._alumnos.Count; i++)
            {
                if (j._alumnos[i] == a)
                    return j;

            }
                if(i == j._alumnos.Count)
                    j._alumnos.Add(a);
                return j;
        }

        #endregion
    }
}
