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
    public partial class Frm_Reg_otroIngresos : Form
    {
        public Frm_Reg_otroIngresos()
        {
            InitializeComponent();
        }
              

        private void Frm_Reg_otroIngresos_Load(object sender, EventArgs e)
        {

        }



        //private void btn_aceptar_Click(object sender, EventArgs e)
        //{
        //    Guardar_IngresoCaja();
        //}



        private void Guardar_IngresoCaja()
        {

            RN_Caja obj = new RN_Caja();
            EN_Caja cja = new EN_Caja();

            try
            {

                cja.Fecha_Caja = dtp_fecha.Value;
                cja.Tipo_Caja = "Entrada";
                cja.Concepto = txt_concepto.Text;
                cja.DePara_Cliente = txt_cliente.Text;
                cja.Nr_Documento = txt_nroDoc.Text;
                cja.ImporteCaja = Convert.ToDouble(txt_importe.Text);
                cja.Idusu = Convert.ToInt32(Cls_Libreria.IdUsu);
                cja.TotalUtilidad = 0;
                cja.TipoPago = cbo_tipoPago.Text;
                cja.GeneradoPor = "Otros";

                obj.RN_Registrar_Mov_Caja(cja);

                if (BD_Caja.cajasaved == true)
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "El Ingreso se guardo correctamente";
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

        private void btn_Generar_Click(object sender, EventArgs e)
        {
            Guardar_IngresoCaja();
        }

        private void btn_cancelPago_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
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

        private void Frm_Reg_otroIngresos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
