using System;
using Excepciones;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Persona
    {

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
 
        }
        /// <summary>
        /// Constructor persona
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Sobrecarga de Persona
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni en entero de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Sobrecarga de Persona
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni en cadena de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #region Propiedades
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = value;
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDNI(this._nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }
        public string StringToDNI
        {
            set
            {
                this._dni = this.ValidarDNI(this._nacionalidad, value);
            }
        }
#endregion
        /// <summary>
        /// valida dni
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">dato a validar</param>
        /// <returns>dato validado</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato > 0 && dato < 90000000)                
                    return dato;                
                else                
                    throw new DniInvalidoException("Nacionalidad no se condice con el numero de DNI");                
            }
            else 
             if (dato >= 90000000)
                return dato;
             else                    
                throw new NacionalidadInvalidaException("Nacionalidad Invalida");
            
        }
        /// <summary>
        /// Valida DNI
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">dni de la persona a validar</param>
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDNI(nacionalidad, int.Parse(dato));
        }
        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (char.IsDigit(dato[i]))                
                    throw new Exception("Nombre/Apellido Invalido");
                
            }
            return dato;
        }
        /// <summary>
        /// Sobrecarga de toString
        /// </summary>
        /// <returns>info de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Persona: ");
            sb.AppendLine(this.Apellido + ", " + this.Nombre);
            sb.AppendLine("Dni: " + this.DNI+ ", " + this.Nacionalidad);
            return sb.ToString();
            
        }
    }
}
