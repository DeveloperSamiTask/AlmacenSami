using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Negocio;
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_TipoCambio : Form
    {
        public Frm_TipoCambio()
        {
            InitializeComponent();
        }

       

        private void Frm_Edit_Precio_Load(object sender, EventArgs e)
        {         
            double tipocambio = 0;
            tipocambio = RN_TipoDoc.RN_Leer_TipoCambio(7);
            txt_precio.Text = tipocambio.ToString("###0.00");
            txt_preAc.Focus();
        }

       

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            RN_TipoDoc obj = new RN_TipoDoc();

            if (txt_preAc.Text.Trim().Length ==0) { txt_preAc.Focus();return; }
            if (Convert.ToDouble(txt_preAc.Text)==0) { txt_preAc.Focus();return; }

            obj.RN_Actualizar_Tipo_Cambio(7, Convert.ToDouble(txt_preAc.Text));

            this.Tag = "A";
            this.Close();
        }

        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_precio_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_cant_TextChanged(object sender, EventArgs e)
        {
            txt_preAc.Text = txt_preAc.Text.Replace(",", ".");
            txt_preAc.SelectionStart = txt_preAc.Text.Length;
        }

        private void Frm_Edit_Precio2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
