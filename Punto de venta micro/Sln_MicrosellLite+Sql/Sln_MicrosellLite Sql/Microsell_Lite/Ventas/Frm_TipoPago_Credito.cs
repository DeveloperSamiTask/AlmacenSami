using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_TipoPago_Credito : Form
    {
        public Frm_TipoPago_Credito()
        {
            InitializeComponent();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void elButton1_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_procesar_Click(object sender, EventArgs e)
        {
            if (txt_SaldoACuenta.Text == "") { MessageBox.Show("Ingrese un Monto de Adelanto", "Falta Monto a Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);txt_SaldoACuenta.Focus();return; }
            //if (Convert.ToDouble(txt_SaldoACuenta.Text) == 0) { MessageBox.Show("El Importe a Cuenta no debe de ser Cero", "Falta Monto a Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_SaldoACuenta.Focus(); return; }

            if (Convert.ToDouble(txt_SaldoACuenta.Text) == Convert.ToDouble(lbl_TotalVenta.Text)) { MessageBox.Show("El Importe a Cuenta no debe, Ni debe ser Igual a Total a Pagar,Caso contrario,Realice su venta en Efectivo", "Falta Monto a Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_SaldoACuenta.Focus(); return; }
            if (Convert.ToDouble(txt_SaldoACuenta.Text) > Convert.ToDouble(lbl_TotalVenta.Text)) { MessageBox.Show("El Importe a Cuenta no debe, Ni debe ser MAYOR a Total a Pagar", "Falta Monto a Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_SaldoACuenta.Focus(); return; }

            this.Tag = "A";
            this.Close();

        }

        private void Frm_TipoPago_Credito_Load(object sender, EventArgs e)
        {
            txt_SaldoACuenta.Focus();
        }

        public void LimpiarForm()
        {
            txt_SaldoACuenta.Text = "0";
            lbl_saldoPagarCred.Text = "0";
            lbl_TotalVenta.Text = "0";
        }

        private void txt_SaldoACuenta_TextChanged(object sender, EventArgs e)
        {
            txt_SaldoACuenta.Text = txt_SaldoACuenta.Text.Replace(",", ".");
            txt_SaldoACuenta.SelectionStart = txt_SaldoACuenta.Text.Length;
            try
            {
                double saldoPdnte = 0;
                saldoPdnte = Convert.ToDouble(lbl_TotalVenta.Text) - Convert.ToDouble(txt_SaldoACuenta.Text);
                lbl_saldoPagarCred.Text = saldoPdnte.ToString("###0.00");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txt_SaldoACuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}
