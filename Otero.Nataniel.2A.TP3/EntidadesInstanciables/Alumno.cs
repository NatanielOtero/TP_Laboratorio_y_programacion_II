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
    public sealed class Alumno : PersonaGimnasio
    {
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta
        {
            MesPrueba,
            Deudor,
            AlDia
        }

        #region Constructores
        /// <summary>
        /// Constructor por defecto de alumno
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// constructor de alumno
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="nombre">nombre</param>
        /// <param name="apellido">apellido</param>
        /// <param name="dni">dni</param>
        /// <param name="nacionalidad">nacionalidad</param>
        /// <param name="claseQueToma">clase tomada por el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        /// <summary>
        /// constructor de alumno
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="nombre">nombre</param>
        /// <param name="estadoCuenta">estado de la cuota del alumno</param>
        /// <param name="apellido">apellido</param>
        /// <param name="dni">dni</param>
        /// <param name="nacionalidad">nacionalidad</param>
        /// <param name="claseQueToma">clase tomada por el alumno</param>

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// muestra los datos del alumno
        /// </summary>
        /// <returns>un string con la informacion del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sbAlumno;
            sbAlumno = new StringBuilder();

            sbAlumno.AppendLine(base.MostrarDatos());
            sbAlumno.AppendLine(this.ParticiparEnClase());
            sbAlumno.AppendLine("Estado de cuenta: " + this._estadoCuenta);

            return sbAlumno.ToString();
        }
        /// <summary>
        /// sobrecarga de participa en clase
        /// </summary>
        /// <returns>un string con la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return ("Toma clase de: " + this._claseQueToma);
        }
        /// <summary>
        /// sobrecarga de toString
        /// </summary>
        /// <returns>permita acceder a los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas

        public static bool operator ==(Alumno alumno, Gimnasio.EClases clase)
        {
            if (alumno._claseQueToma == clase && alumno._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Alumno alumno, Gimnasio.EClases clase)
        {
            if (alumno._claseQueToma != clase)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
