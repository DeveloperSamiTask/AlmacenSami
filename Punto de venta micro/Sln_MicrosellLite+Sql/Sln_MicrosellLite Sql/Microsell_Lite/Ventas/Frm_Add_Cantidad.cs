using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Add_Cantidad : Form
    {
        public Frm_Add_Cantidad()
        {
            InitializeComponent();
        }

        private void Frm_Edit_Precio_Load(object sender, EventArgs e)
        {
            txt_cant.Focus();
        }

        private void txt_cant_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (lbl_TipoProducto.Text.Trim().ToString() == "Producto")
                {
                    if (Convert.ToDouble(txt_cant.Text) > Convert.ToDouble(Lbl_stockActual.Text))
                    {
                        Frm_Filtro fil = new Frm_Filtro();
                        Frm_Advertencia ver = new Frm_Advertencia();

                        txt_cant.Text = "1";
                        fil.Show();
                        ver.lbl_msm1.Text = "La Cantidad a Vender no puede ser Mayor al Stock Disnopible";
                        ver.ShowDialog();
                        fil.Hide();
                        //MessageBox.Show("La Cantidad a Vender no puede ser Mayor al Stock Disnopible", "Validad Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                        return;
                    }
                    else
                    {
                        this.Tag = "A";
                        this.Close();
                    }
                }
                else
                {
                    this.Tag = "A";
                    this.Close();
                }
            }           
        }

        private void Frm_Add_Cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
