﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clase_12_Library
{
    public class Concecionaria
    {
    
        List<Vehiculo> vehiculos;
        int espacioDisponible;
        public enum ETipo
        {
            Moto, Camion, Automovil, Todos
        }

        
        private Concecionaria()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Concecionaria(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        

        
        /// <summary>
        /// Muestro la concecionaria y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string  ToString()
        {
            return Mostrar(this,ETipo.Todos);
        }
        

        

        /// <summary>
        /// Expone los datos de la concecionaria y sus vehículos (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="concecionaria">Concecionaria a exponer</param>
        /// <param name="ETipo">Tipos de Vehiculos a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Concecionaria concecionaria, ETipo tipoDeVehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concecionaria.vehiculos.Count, concecionaria.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in concecionaria.vehiculos)
            {
                switch (tipoDeVehiculo)
                {
                    case ETipo.Automovil:
                        if(v is Automovil)
                            sb.AppendLine(((Automovil)v).Mostrar());
                        break;
                    case ETipo.Moto:
                        if(v is Moto)
                            sb.AppendLine(((Moto)v).Mostrar());
                        break;
                    case ETipo.Camion:
                        if (v is Camion)
                            sb.AppendLine(((Camion)v).Mostrar());
                        break;
                    default:
                        if (v is Automovil)
                        sb.AppendLine(((Automovil)v).Mostrar());
                        if (v is Moto)
                        sb.AppendLine(((Moto)v).Mostrar());
                        if (v is Camion)
                        sb.AppendLine(((Camion)v).Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
       

      
        /// <summary>
        /// Agregará un vehículo a la concecionaria, siempre que haya espacio disponible
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns></returns>
        public static Concecionaria operator +(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            if (concecionaria.vehiculos.Count >= concecionaria.espacioDisponible)
                return concecionaria;
            foreach (Vehiculo v in concecionaria.vehiculos)
            {
                if (v == vehiculo)
                    return concecionaria;
            }

            concecionaria.vehiculos.Add(vehiculo);
            return concecionaria;
        }
        /// <summary>
        /// Quitará un vehículo de la concecionaria
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns></returns>
        public static Concecionaria operator -(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in concecionaria.vehiculos)
            {
                if (v == vehiculo)
                {
                    concecionaria.vehiculos.Remove(v);
                    break;
                }
            }

            return concecionaria;
        }
        
    }
}
