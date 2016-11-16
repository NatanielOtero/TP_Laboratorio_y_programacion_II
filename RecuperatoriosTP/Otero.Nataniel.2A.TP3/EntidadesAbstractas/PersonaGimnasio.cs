using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio:Persona
    {
        private int _identificador;

        /// <summary>
        /// constructor por defecto de personagimnasio
        /// </summary>
        public PersonaGimnasio()
        {

        }
        /// <summary>
        /// Constructor de persona gimnasio
        /// </summary>
        /// <param name="id">id de la persona</param>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad</param>
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Muestra la info de la persona gim
        /// </summary>
        /// <returns>strin con la info</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("ID #" + this._identificador);
            return sb.ToString();
        }
        /// <summary>
        /// sobrecarga de equals
        /// </summary>
        /// <param name="obj">objeto a compara su tipo con personagimnasio</param>
        /// <returns>tru o false respectivamente</returns>
        public override bool Equals(object obj)
        {
            return (obj is PersonaGimnasio);
        }
        public static bool operator ==(PersonaGimnasio uno, PersonaGimnasio dos)
        {
            if (uno.Equals(dos) && (uno.DNI == dos.DNI || uno._identificador == dos._identificador))            
                return true;          
             return false;            
        }
        public static bool operator !=(PersonaGimnasio uno, PersonaGimnasio dos)
        {
            return !(uno == dos);
        }
        //Sobrecarga de equals y gethascode para evitar el warning
        public override string ToString()
        {
            return base.ToString();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
