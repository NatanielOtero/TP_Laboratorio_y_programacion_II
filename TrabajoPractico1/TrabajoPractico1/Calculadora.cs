using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Calculadora
    { 
        /// <summary>
        /// en base al operador pasado por parametro, realiza la operacion correspondiente.
        /// </summary>
        /// <param name="Numero1">numero 1</param>
        /// <param name="Numero2">numero 2</param>
        /// <param name="operador">operador</param>
        /// <returns>resultado de la operacion</returns>
        public double operar(Numero Numero1, Numero Numero2, string operador)
        {
            operador = validarOperador(operador);

            switch (operador)
            { 
                case "+":
                    return Numero1 + Numero2;
                    
                case "-":
                    return Numero1 - Numero2;
                    
                case "*":
                    return Numero1 * Numero2;
                    
                case "/":
                    if (Numero2 != 0)
                        return Numero1 / Numero2;
                    else
                        return 0;
               default:
                    return Numero1 + Numero2;
                    
                
            } 

        }
        /// <summary>
        /// valida que el operador pasado por parametro sea valido
        /// </summary>
        /// <param name="operador">operador a validar</param>
        /// <returns>el operador validado, o bien + si el operador no es valido</returns>
        public string validarOperador(string operador)
        {
            if (operador.Equals("+") || operador.Equals("-") || operador.Equals("*") || operador.Equals("/"))
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }
    }
}
