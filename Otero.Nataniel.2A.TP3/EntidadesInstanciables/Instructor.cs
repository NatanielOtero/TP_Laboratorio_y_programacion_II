using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Instructor : PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        #region Constructores
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Instructor()
        {
 
        }
        /// <summary>
        /// constructor de clase que genera un random
        /// </summary>
        static Instructor()
        {
            _random = new Random();
        }
        /// <summary>
        /// constructor de instructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClase();
            
            
        }

        #endregion
        #region Propiedades
        public Gimnasio.EClases[] clases
        {
            get 
            {
                return this._clasesDelDia.ToArray();
            }
            
        }
        #endregion

        #region Metodos
        /// <summary>
        /// genera dos clases aleatorias basadas en un random y las asigna al instructor, de esto depende las jornadas
        /// </summary>
        private void _randomClase()
        {
            int randomUno;
            int randomDos;

            randomUno = _random.Next(0, 3);
            randomDos = _random.Next(0, 3);

            this._clasesDelDia.Enqueue((Gimnasio.EClases)randomUno);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)randomDos);
        }
        /// <summary>
        /// muestra los datos
        /// </summary>
        /// <returns>cadena de informacion</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sbInstructor;
            sbInstructor = new StringBuilder();            
            sbInstructor.AppendLine(base.MostrarDatos());
            sbInstructor.AppendLine(this.ParticiparEnClase());

            return sbInstructor.ToString();
        }
        /// <summary>
        /// sobrecarga de participa en clase
        /// </summary>
        /// <returns>clases que participa</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sbInstructor;
            sbInstructor = new StringBuilder();

            sbInstructor.AppendLine("--Clases del dia--");

            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sbInstructor.AppendLine(item.ToString());
            }

            return sbInstructor.ToString();
        }
        /// <summary>
        /// sobrecarga de toString
        /// </summary>
        /// <returns>los datos del instructor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// sobrecarga del operador ==
        /// </summary>
        /// <param name="instructor">instructor a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>si la clase pasada por parametro esta en las clases del dia del instructor true, de lo contrario false</returns>
        public static bool operator ==(Instructor instructor, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases item in instructor._clasesDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// sobrecarga del operador ==
        /// </summary>
        /// <param name="instructor">instructor a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>si la clase pasada por parametro esta en las clases del dia del instructor false, de lo contrario true</returns>
        public static bool operator !=(Instructor instructor, Gimnasio.EClases clase)
        {
            return !(instructor == clase);
        }

        #endregion
    }
}
