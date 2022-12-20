using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }

        private void Frm_Closing(object sender, FormClosingEventArgs e)
        {
            this.Tag = "";
            this.Show();
        }

        private void btngenerarmanualmente_Click(object sender, EventArgs e)
        {
            Form1 FormularioVista = new Form1();
            this.Hide();
            FormularioVista.Show();
            FormularioVista.FormClosing += Frm_Closing;
        }

        private void btngenerarmasivamente_Click(object sender, EventArgs e)
        {
            frmMasivo FormularioVista = new frmMasivo();
            this.Hide();
            FormularioVista.Show();
            FormularioVista.FormClosing += Frm_Closing;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }
    }
}
