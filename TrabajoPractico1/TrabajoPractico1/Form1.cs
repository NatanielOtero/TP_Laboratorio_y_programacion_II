using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPractico1
{
    public partial class Form1 : Form
    {
        public Numero numero1;
        public Numero numero2;
        public double resultado;
        public string operando;

        public Form1()
        {
            
            InitializeComponent();
        }
       

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.operando = cmbOperacion.Text;
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            this.numero2 = new Numero(txtNumero2.Text);
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            
            this.numero1 = new Numero(txtNumero1.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }        

        private void btnOperar_Click(object sender, EventArgs e)
        {
            operar();
            lblResultado.Text = resultado.ToString();
            
            

        }
        /// <summary>
        /// metodo que limpia los parametros de la calculadora.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            lblResultado.Text = "0";
            cmbOperacion.Text = "+";
            

        }
        /// <summary>
        /// metodo que realiza la operacion.
        /// </summary>
        private void operar()
        {
            Calculadora aux;
            aux = new Calculadora();
            resultado = aux.operar(this.numero1, this.numero2, this.operando);
            
        }    

       
        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

       

        
    }
}
