using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Numero
    {
        private double _numero;
        /// <summary>
        /// Constructor por defecto de la clase Numero, inicializa los atributos en 0
        /// </summary>
        public Numero()
        {
            this._numero = 0;
        }       
        /// <summary>
        /// Sobrecarga de Numero,
        /// por medio de SetNumero carga el atributo _numero con el string pasado por parametro
        /// </summary>
        /// <param name="numero">String a cargar en _numero</param>
        public Numero(string numero)
        {
            setNumero(numero);
        }
        /// <summary>
        /// Carga un double en el atributo _numero.
        /// </summary>
        /// <param name="numero">Double a cargar en _numero</param>
        public Numero(double numero)
        {

            this._numero = numero;
        }
        /// <summary>
        /// Devuelve _numero.
        /// </summary>
        /// <returns>valor de _numero</returns>
        public double getNumero()
        {
            return this._numero;
        }
        /// <summary>
        /// Carga el string numero ya validado en el atributo _numero.
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {
            this._numero = validarNumero(numero);
        }
        /// <summary>
        /// Valida el string pasado por parametro
        /// </summary>
        /// <param name="numeroString">numero a validar y convertir a double</param>
        /// <returns>el string convertido en double o 0 si falla la conversion</returns>
        private double validarNumero(string numeroString)
        {
            double numeroConvertido;
            bool result = double.TryParse(numeroString, out numeroConvertido);
            if (result)
            {
                return this._numero = numeroConvertido;
                
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// sobrecarga de Numero
        /// </summary>
        /// <param name="numero">double con el que operar</param>
        /// <returns>un nuevo objeto de la clase numero</returns>
        public static implicit operator Numero(double numero)
        {
            return new Numero(numero);
        }
        /// <summary>
        /// sobrecarga de double
        /// </summary>
        /// <param name="numero">Numero con el que operar</param>
        /// <returns>el atributo double de la clase Numero</returns>
        public static implicit operator double(Numero numero)
        {
            return numero._numero;
        }
        /// <summary>
        /// sobrecarga del operador +
        /// </summary>
        /// <param name="numero1">numero 1</param>
        /// <param name="numero2">numero 2</param>
        /// <returns>el resultado</returns>
        public static double operator +(Numero numero1,Numero numero2)
        {

            return numero1._numero + numero2._numero;
        }
        /// <summary>
        /// sobrecarga del operador -
        /// </summary>
        /// <param name="numero1">numero 1</param>
        /// <param name="numero2">numero 2</param>
        /// <returns>el resultado</returns>
        public static double operator -(Numero numero1,Numero numero2)
        {
            return numero1._numero - numero2._numero;
        }
        /// <summary>
        /// sobrecarga del operador *
        /// </summary>
        /// <param name="numero1">numero 1</param>
        /// <param name="numero2">numero 2</param>
        /// <returns>el resultado</returns>
        public static double operator *(Numero numero1,Numero numero2)
        {
            return numero1._numero * numero2._numero;
        }
        /// <summary>
        /// sobrecarga del operador /
        /// </summary>
        /// <param name="numero1">numero 1</param>
        /// <param name="numero2">numero 2</param>
        /// <returns>el resultado</returns>
        public static double operator /(Numero numero1, Numero numero2)
        {
            return numero1._numero / numero2._numero;
        }       
    }
}
