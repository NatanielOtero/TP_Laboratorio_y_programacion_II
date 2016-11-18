using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }
        /// <summary>
        /// carga el historial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);            
            List<string> aux;
            try
            {
                if (archivos.leer(out aux))
                {
                    lstHistorial.DataSource = aux;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar el historial");
            }

            
        }

        private void lstHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
