using Microsell_Lite.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Compras
{
    public partial class Frm_Solo_Cantidad : Form
    {
        public Frm_Solo_Cantidad()
        {
            InitializeComponent();
        }

        private void Frm_Solo_Cantidad_Load(object sender, EventArgs e)
        {
            txt_cant.Focus();
        }

        private void Frm_Solo_Cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void txt_cant_KeyDown(object sender, KeyEventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (e.KeyCode== Keys.Enter)
            {
                if (txt_cant.Text.Trim() == "") return;
                if (Convert.ToDouble(txt_cant.Text)==0)
                {
                    fil.Show();
                    ver.lbl_msm1.Text = "La cantidad debe ser mayor a Cero";
                    ver.ShowDialog();
                    fil.Hide();
                    txt_cant.Focus();
                    return;
                }

                this.Tag = "A";
                this.Close();
                
            }
        }

        private void txt_cant_TextChanged(object sender, EventArgs e)
        {
            txt_cant.Text = txt_cant.Text.Replace(",", ".");
            txt_cant.SelectionStart = txt_cant.Text.Length;
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }
    }
}
