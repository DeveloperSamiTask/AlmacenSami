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

namespace Microsell_Lite.Proveedores
{
    public partial class Frm_ListadoProveedor : Form
    {
        public Frm_ListadoProveedor()
        {
            InitializeComponent();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void Frm_ListadoProveedor_Load(object sender, EventArgs e)
        {
            Configurar_listview();
            Cargar_Todos_Proveedores();
        }

        private void Configurar_listview()
        {
            var lis = lsv_provee;

            lsv_provee.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = false;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 142, HorizontalAlignment.Center);//0            
            lis.Columns.Add("Nombre del Proveedor", 250, HorizontalAlignment.Center);//1
        }

        private void Llenar_Listview(DataTable data)
        {
            lsv_provee.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["IDPROVEE"].ToString());                
                list.SubItems.Add(dr["NOMBRE"].ToString());
                lsv_provee.Items.Add(list);//si no ponemos esto., el listview nunca se llenara

            }
            Pintar_Filas();
        }

        private void Pintar_Filas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_provee.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_provee.Items[i].BackColor = Color.LightBlue;
                }
                cont += 1;
            }
        }

        private void Cargar_Todos_Proveedores()
        {
            RN_Proveedor obj = new RN_Proveedor();
            DataTable dato = new DataTable();

            dato = obj.RN_Cargar_Todas_Proveedores();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_provee.Items.Clear();
            }
        }

        private void lsv_provee_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsv_provee.SelectedIndices.Count == 0 )
            {
                MessageBox.Show("Selecciona un Proveedor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                lbl_idp.Text = lsv_provee.SelectedItems[0].SubItems[0].Text;
                lbl_nompr.Text = lsv_provee.SelectedItems[0].SubItems[1].Text;

                this.Tag = "A";
                this.Close();
            }
        }

        private void lsv_provee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lsv_provee.SelectedIndices.Count ==0)
                {
                    MessageBox.Show("Selecciona un Proveedor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    lbl_idp.Text = lsv_provee.SelectedItems[0].SubItems[0].Text;
                    lbl_nompr.Text = lsv_provee.SelectedItems[0].SubItems[1].Text;

                    this.Tag = "A";
                    this.Close();
                }
            }
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void Frm_ListadoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
