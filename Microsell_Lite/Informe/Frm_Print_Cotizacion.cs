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

namespace Microsell_Lite.Informe
{
    public partial class Frm_Print_Cotizacion : Form
    {
        public Frm_Print_Cotizacion()
        {
            InitializeComponent();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Crear_Impresion_Cotizacion()
        {
            RN_Cotizacion obj = new RN_Cotizacion();
            DataTable datos = new DataTable();

            datos = obj.BD_Buscar_Cotizacion_Editar(Convert.ToString(this.Tag));
            RPTE_Cotizacion report = new RPTE_Cotizacion();
            CRV_Cotizacion.ReportSource = report;
            report.SetDataSource(datos);
            report.Refresh();
            CRV_Cotizacion.ReportSource = report;
        }

        private void Frm_Print_Cotizacion_Load(object sender, EventArgs e)
        {
            Crear_Impresion_Cotizacion();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void Frm_Print_Cotizacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
