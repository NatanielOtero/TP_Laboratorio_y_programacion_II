using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public abstract class Vehiculo
    {
        
        EMarca _marca;
        string _patente;
        ConsoleColor _color;

        public Vehiculo(EMarca marca,string patente,ConsoleColor color)
        {
            this._marca = marca;
            this._patente = patente;
            this._color = color;
        }

        /// <summary>
        /// Retornará la cantidad de ruedas del vehículo
        /// </summary>
        public abstract short CantidadRuedas { get; set; }
        /// <summary>
        /// Mostrar
        /// </summary>
        /// <returns>Retorna un string con la informacion del objeto</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehículos son iguales si comparten la misma patente
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (v1._patente == v2._patente)
                return true;
            return false;
        }
        /// <summary>
        /// Dos vehículos son distintos si su patente es distinta
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        /// <summary>
        /// Sobrecarga de equals
        /// </summary>
        /// <param name="obj">Obketo a comprar</param>
        /// <returns>booleano de acuerdo a la igualdad</returns>
        public override bool Equals(object obj)
        {
            if (obj is Vehiculo)
                return this == (Vehiculo)obj;
            else
                return false;
        }
        /// <summary>
        /// Sobrecaga de GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
       
        
    }

    
}
