using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Archivos;
using EntidadesAbstractas;
using System.Xml.Serialization;
using Excepciones;
using System.Text;

namespace EntidadesInstanciables
{
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(PersonaGimnasio))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]
    [Serializable]
    public class Gimnasio
    {
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates,
            Yoga
        }
        /// <summary>
        /// constructor de gimnasio
        /// </summary>
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        /// <summary>
        /// genera un xml con los datos de gimnasio
        /// </summary>
        /// <param name="gim">gimnasio a guardar</param>
        /// <returns>devuelve true o false si se pudo generar el archivo</returns>
        public static bool Guardar(Gimnasio gim)
        {
            Xml<Gimnasio> serializar = new Xml<Gimnasio>();
            return serializar.guardar("gimnasio.xml", gim);
        }
        /// <summary>
        /// se lee un xml 
        /// </summary>
        /// <returns>el dato leido en el xml</returns>
        public static Gimnasio Leer()
        {
            Gimnasio aux = null;

            Xml<Gimnasio> deserializar = new Xml<Gimnasio>();

            deserializar.leer("gimnasio.xml", out aux);

            return aux;
        }
        /// <summary>
        /// muestra un gim
        /// </summary>
        /// <param name="gim">gim a mostrar</param>
        /// <returns>cadena de caracteres con la info del gim</returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada item in gim._jornada)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// sobrecarga de toString
        /// </summary>
        /// <returns>string con los datos del gimnasio</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #region Propiedades

        public Jornada this[int i]
        {
            get
            {
                return this._jornada[i];
            }
        }
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
        }
        public List<Instructor> Instructores
        {
            get { return this._instructores; }
        }
        public List<Jornada> Jornadas
        {
            get { return this._jornada; }
        }

        #endregion
        /// <summary>
        /// sobrecarga del ==
        /// </summary>
        /// <param name="gim">gimnasio a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si el alumno esta en el gimnasio</returns>
        public static bool operator ==(Gimnasio gim, Alumno a)
        {
            foreach (Alumno item in gim._alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// sobrecarga del ==
        /// </summary>
        /// <param name="gim">gimnasio a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si el alumno no esta en el gimnasio</returns>
        public static bool operator !=(Gimnasio gim, Alumno a)
        {
            return !(gim == a);
        }
        /// <summary>
        /// sobrecarga del ==
        /// </summary>
        /// <param name="gim">gimnasio a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>el primer instructor para la clase, de lo contrario lanza la excepcion</returns>
        public static Instructor operator ==(Gimnasio gim, EClases clase)
        {
            foreach (Instructor item in gim._instructores)
            {
                if (item == clase)
                    return item;
            }
            throw new SinInstructorException();
        }
        /// <summary>
        /// sobrecarga del ==
        /// </summary>
        /// <param name="gim">gimnasio a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>el primer instructor que no de la clase, si todos la dan lanza la excepcion</returns>
        public static Instructor operator !=(Gimnasio gim, EClases clase)
        {
            try
            {
                foreach (Instructor item in gim._instructores)
                {
                    if (item != clase)
                        return item;

                }
                throw new Exception("Todos los instructores estan en esa clase");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// sobrecarga del ==
        /// </summary>
        /// <param name="gim">gimnasio a comparar/param>
        /// <param name="ins">instructor a comparar</param>
        /// <returns>true si el instructor esta en el gimnasio, de lo contrario false</returns>
        public static bool operator ==(Gimnasio gim, Instructor ins)
        {
            int i;
            for (i = 0; i < gim._instructores.Count; i++)
            {
                if (gim._instructores[i] == ins)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// sobrecarga del ==
        /// </summary>
        /// <param name="gim">gimnasio a comparar/param>
        /// <param name="ins">instructor a comparar</param>
        /// <returns>false si el instructor esta en el gimnasio, de lo contrario true</returns>
        public static bool operator !=(Gimnasio gim, Instructor i)
        {
            return !(gim == i);
        }
        /// <summary>
        /// sobrecarga del +
        /// </summary>
        /// <param name="gim">gimnasio a incrementar</param>
        /// <param name="alu">alumno a agregar</param>
        /// <returns>un gimnasio con el alumno agregado, de lo contrario lanza la excepcion</returns>
        public static Gimnasio operator +(Gimnasio gim, Alumno alu)
        {
            int i;
            for (i = 0; i < gim._alumnos.Count; i++)
            {
                if (gim._alumnos[i] == alu)
                    throw new AlumnoRepetidoException();
            }
            if (i == gim._alumnos.Count)
                gim._alumnos.Add(alu);

            return gim;
        }
        /// <summary>
        /// sobrecarga del +
        /// </summary>
        /// <param name="gim">gimnasio a incrementar</param>
        /// <param name="clase">clase a agregar</param>
        /// <returns>un gimnasio con la clase agregada</returns>
        public static Gimnasio operator +(Gimnasio gim, EClases clase)
        {
            Jornada jor = new Jornada(clase, (gim == clase));
            foreach (Alumno item in gim._alumnos)
            {
                if (item == clase)
                    jor += item;
            }
            gim._jornada.Add(jor);
            return gim;
        }
        /// <summary>
        /// sobrecarga del +
        /// </summary>
        /// <param name="gim">gimnasio a incrementar</param>
        /// <param name="i">instructor a agregar</param>
        /// <returns>un gimnasio con el instructor agregado, de lo contrario lanza la excepcion</returns>
        public static Gimnasio operator +(Gimnasio gim, Instructor i)
        {
            try
            {
                if (gim != i)
                    gim._instructores.Add(i);
                throw new Exception("Instructor repetido");

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
            return gim;


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

    }
}

