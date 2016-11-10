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

        #region Constructores
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Persona()
        {
 
        }
        /// <summary>
        /// constructor
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
        /// sobrecarga del constructor
        /// </summary>       
        /// <param name="dni">dni de la persona en entero</param>        

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// sobrecarga del constructor
        /// </summary>       
        /// <param name="dni">dni de la persona en cadena de caracteres</param> 

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// sobrecarda de el toString
        /// </summary>
        /// <returns>datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sbPersona;
            sbPersona = new StringBuilder();

            
            sbPersona.AppendLine("Nombre: " + this.Nombre);
            sbPersona.AppendLine("Apellido: " + this.Apellido);
            sbPersona.AppendLine("DNI: " + this.DNI);
            sbPersona.AppendLine("Nacionalidad: " + this.Nacionalidad);

            return sbPersona.ToString();
        }
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
                {
                    return dato;
                }
                else
                {
                    throw new DniInvalidoException("Nacionalidad no se condice con el numero de DNI");
                }
            }
            else
            {
                if (dato >= 90000000)
                    return dato;
                throw new NacionalidadInvalidaException("Nacionalidad Invalida");
            }
        }
        /// <summary>
        /// valida dni 
        /// </summary>
        /// <param name="nacionalidad">nacionalidad</param>
        /// <param name="dato">dni</param>
        /// <returns>dni en entero</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDNI(nacionalidad, int.Parse(dato));
        }
        /// <summary>
        /// valida nombre y apellido
        /// </summary>
        /// <param name="dato">nombre validado</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (char.IsDigit(dato[i]))
                {
                    throw new Exception("Nombre Invalido");
                }
            }

            return dato;
        }

        #endregion

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


        
    }
}
