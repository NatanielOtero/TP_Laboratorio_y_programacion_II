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
            StringBuilder sb;
            sb = new StringBuilder();
            sb.AppendLine("Datos de la Jornada: ");
            sb.AppendLine("Instructor: " + this._instructor.ToString());
            sb.AppendLine("Da la clase de: " + this._clase.ToString());
            sb.AppendLine("Alumnos");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// sobrecargar del ==
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true o false dependiendo si el alumno este en el jornada</returns>
        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            foreach (Alumno item in jornada._alumnos)
            {
                if (item == alumno)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// sobrecarga del distinto
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true o false dependiendo si el alumno este en el jornada</return
        public static bool operator !=(Jornada jor, Alumno alu)
        {
            return !(jor == alu);
        }
        /// <summary>
        /// sobrecarga de +
        /// </summary>
        /// <param name="jor">jornada a incrementar</param>
        /// <param name="alu">alumno a incluir en la jornada</param>
        /// <returns>una jordana con el alumno a agregado</returns>
        public static Jornada operator +(Jornada jor, Alumno alu)
        {
            int i;
            for (i = 0; i < jor._alumnos.Count; i++)
            {
                //Si el alumno se encuentra en la jornada, devuelve la lista sin cambios.
                if (jor._alumnos[i] == alu)
                    return jor;

            }
            if (i == jor._alumnos.Count)
                //Si el alumo no esta, lo agrega y devuleve la lista de alumnos.
                jor._alumnos.Add(alu);
            return jor;
        }

        //Sobrecarga de Equals y GetHashCode para evitar el warning
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
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






        
    }
}
