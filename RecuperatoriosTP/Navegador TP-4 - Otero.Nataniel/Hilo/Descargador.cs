using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;


        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }
        public delegate void _progresoEvento(int progreso);        
        public delegate void _finDescargaEvento(string html);
        public event _progresoEvento ProgresoDescarga;
        public event _finDescargaEvento FinDescarga;


        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// actualiza la barra de progreso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.ProgresoDescarga(e.ProgressPercentage);
        }
        /// <summary>
        /// carga el html con el resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;

            }
            catch (Exception)
            {

                this.html = "Error en la descarga";
            }
            finally 
            {
                this.FinDescarga(html);
            }
            
            
        }
    }
}
