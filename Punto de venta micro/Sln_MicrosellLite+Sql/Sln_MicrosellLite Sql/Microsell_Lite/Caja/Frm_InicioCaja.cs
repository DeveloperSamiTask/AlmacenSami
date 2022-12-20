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
    public partial class Frm_InicioCaja : Form
    {
        public Frm_InicioCaja()
        {
            InitializeComponent();
        }

        private void Frm_InicioCaja_Load(object sender, EventArgs e)
        {
            txt_importe.Focus();
        }

        private void Frm_InicioCaja_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button ==MouseButtons.Left )
            {
                ui.Mover_formulario(this);
            }
        }

        private void Frm_InicioCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Escape )
            {
                this.Tag = "";
                this.Close();
            }
        }



       
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

       
        private void txt_importe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                btn_procesar_Click(sender, e);
            }
        }

        private void Registrar_Inicio_caja()
        {
            EN_CierreCaja ca = new EN_CierreCaja();
            RN_Cierre_Caja obj = new RN_Cierre_Caja();

            try
            {
                string idcierre = RN_TipoDoc.RN_NroId(12);

                ca.Idcierre = idcierre;
                ca.AperturCaja = Convert.ToDouble(txt_importe.Text);
                ca.TotalIngreso = 0;
                ca.TotalEgreso = 0;
                ca.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                ca.TotalDeposito = 0;
                ca.TotalGanancia = 0;
                ca.TotalEntregado = 0;
                ca.SaldoSiguiente = 0;
                ca.TotalFactura = 0;
                ca.TotalBoleta = 0;
                ca.TotalNota = 0;
                ca.TotalCreditoCobrado = 0;
                ca.TotalCreditoEmitido = 0;

                obj.RN_registrar_Inicio_Caja(ca);

                if (BD_Cierre_Caja.saved==true)
                {
                    RN_TipoDoc.RN_Actualizar_Tipo_Doc(12);
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "El inicio de Caja se ah Aperturado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    txt_importe.Text = "";

                    this.Tag = "A";
                    this.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_procesar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            RN_Cierre_Caja obj = new RN_Cierre_Caja();

            if (txt_importe.Text.Trim().Length==0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Por Favor, Ingresa el Importe para Aperturar la caja del Dia";
                ver.ShowDialog();
                fil.Hide();

                txt_importe.Focus();
                return;
            }
            if (obj.RN_validar_InicioDoble_caja()==true)
            {
                fil.Show();
                ver.lbl_msm1.Text = "El sistema Verifica que ya Existe una apertura de caja en este mismo dia ";
                ver.ShowDialog();
                fil.Hide();

                txt_importe.Focus();
                return;
            }
            else
            {
                Registrar_Inicio_caja();
            }
            
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button == MouseButtons.Left)
            {
                ui.Mover_formulario(this);
            }
        }
    }
}
