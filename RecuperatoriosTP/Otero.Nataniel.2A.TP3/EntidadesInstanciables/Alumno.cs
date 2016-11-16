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
    public class Alumno:PersonaGimnasio
    {
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta
        {
            MesPrueba,
            Deudor,
            AlDia
        }
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

        protected override string ParticiparEnClase()
        {
            return ("Toma clases de : " + this.Clases);
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            sb.AppendLine("Estado de la cuenta : " + this.Cuenta);
            return sb.ToString();

        }
        #region Propiedades
        public EEstadoCuenta Cuenta
        {
            get
            {
                return this._estadoCuenta;
            }
        }
        public Gimnasio.EClases Clases
        {
            get
            {
                return this._claseQueToma;
            }
        }
        #endregion
        public static bool operator ==(Alumno alumno, Gimnasio.EClases clase)
        {
            if (alumno.Clases == clase && alumno.Cuenta != EEstadoCuenta.Deudor)
                return true;
             return false;
            
        }

        public static bool operator !=(Alumno alumno, Gimnasio.EClases clase)
        {
            if (alumno.Clases != clase)
               return true;
           return false;
            
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
