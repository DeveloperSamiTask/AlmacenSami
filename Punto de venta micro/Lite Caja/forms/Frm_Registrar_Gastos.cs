using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.Caja
{
    public partial class Frm_Registrar_Gastos : Form
    {
        public Frm_Registrar_Gastos()
        {
            InitializeComponent();
        }

        private void Frm_Registrar_Gastos_Load(object sender, EventArgs e)
        {

        }

        private void Pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button == MouseButtons.Left)
            {
                ui.Mover_formulario(this);
            }
        }



        private void Guardar_SalidaCaja()
        {

            RN_CAja obj = new RN_CAja();
            EN_Caja cja = new EN_Caja();

            try
            {

                cja.FechaCaja = dtp_fecha.Value;
                cja.TipoCaja = "Salida";
                cja.Concepto = txt_concepto.Text;
                cja.DePara_Cliente = txt_cliente.Text;
                cja.Nr_Documento = txt_nroDoc.Text;
                cja.ImporteCaja = Convert.ToDouble(txt_importe.Text);
                cja.Idusu = Convert.ToInt32(Cls_Libreria.IdUsu);
                cja.TotalUtilidad = 0;
                cja.TipoPago = cbo_tipoPago.Text;
                cja.GeneradoPor = "Otros";

                obj.RN_Registrar_Mov_Caja(cja);

                if (BD_Caja.cajaSaved == true)
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "La Salida de Caja se guardo correctamente";
                    ok.ShowDialog();
                    fil.Hide();


                    this.Tag = "A";
                    this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Guardar_SalidaCaja();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();

        }
    }
}
