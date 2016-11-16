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
        /// <param name="id">ID del isntructor</param>
        /// <param name="nombre">nombre del instructor</param>
        /// <param name="apellido">apellido del instructor</param>
        /// <param name="dni">dni del mismo</param>
        /// <param name="nacionalidad">nacionalidad</param>
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClase();


        }
        /// <summary>
        /// Genera clases random y se las agrega al instructor
        /// </summary>
        private void _randomClase()
        {                                 
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0,3));            
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0,3));
        }
        /// <summary>
        /// muestra los datos
        /// </summary>
        /// <returns>cadena de informacion</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();             
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// sobrecarga de toString
        /// </summary>
        /// <returns>los datos del instructor </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// sobrecarga de participa en clase
        /// </summary>
        /// <returns>clases que participa</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clases del dia: ");
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
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
