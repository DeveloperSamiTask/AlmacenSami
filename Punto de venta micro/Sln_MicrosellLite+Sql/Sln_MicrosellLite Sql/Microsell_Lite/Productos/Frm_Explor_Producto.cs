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
using Prj_Capa_Entidad;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;

namespace Microsell_Lite.Productos
{
    public partial class Frm_Explor_Producto : Form
    {
        public Frm_Explor_Producto()
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

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }
        private void Frm_Proveedor_Load(object sender, EventArgs e)
        {
            Configurar_listview();
            Cargar_Todos_Productos();

        }

       
        private void Configurar_listview()
        {
            var lis = lsv_provee;

            lsv_provee.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            //lis.Columns.Add("Id Proveedor", 80, HorizontalAlignment.Center);//0
            lis.Columns.Add("ID Producto", 140, HorizontalAlignment.Center);//0
            //lis.Columns.Add("Codigo", 80, HorizontalAlignment.Left);//1
            lis.Columns.Add("Modelo", 740, HorizontalAlignment.Center);//2
            lis.Columns.Add("MARCA", 100, HorizontalAlignment.Center);//5
            lis.Columns.Add("STOCK A", 100, HorizontalAlignment.Center);//3
            lis.Columns.Add("PRE COMPRA", 0, HorizontalAlignment.Center);//4
            lis.Columns.Add("FRANK", 0, HorizontalAlignment.Center);//5
            lis.Columns.Add("PRE VENTA1", 0, HorizontalAlignment.Center);//2
            //lis.Columns.Add("PRE VENTA2", 90, HorizontalAlignment.Center);//3a
            lis.Columns.Add("UTILIDAD", 0, HorizontalAlignment.Center);//4
            lis.Columns.Add("TOTAL", 0, HorizontalAlignment.Center);//5
            //lis.Columns.Add("ESTADO", 100, HorizontalAlignment.Center);//5


        }

       
        private void Llenar_Listview(DataTable data)
        {
            lsv_provee.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString().Trim());
                //list.SubItems.Add(dr["Codigo"].ToString());
                list.SubItems.Add(dr["Modelo"].ToString());
                list.SubItems.Add(dr["Marca"].ToString());
                list.SubItems.Add(dr["Stock_Actual"].ToString());
                list.SubItems.Add(dr["Pre_CompraS"].ToString());
                list.SubItems.Add(dr["Frank"].ToString());
                list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());
                //list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());
                list.SubItems.Add(dr["UtilidadUnit"].ToString());
                list.SubItems.Add(dr["Valor_porCant"].ToString());
                //list.SubItems.Add(dr["Estado_Pro"].ToString());


                lsv_provee.Items.Add(list);//si no ponemos esto., el listview nunca se llenara

            }
            Pintar_Filas();
            pnl_sms.Visible = false;
            lbl_TotalItems.Text = Convert.ToString(lsv_provee.Items.Count);
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

        private void Cargar_Todos_Productos()
        {
            RN_Productos obj = new RN_Productos();
            DataTable dato = new DataTable();

            dato = obj.RN_Cargar_Todas_Productos();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_provee.Items.Clear();
                pnl_sms.Visible = true;
            }
        }

        private void Buscar_Productos(string valor)
        {
            RN_Productos obj = new RN_Productos();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Productos(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);

                
            }
            else
            {
                lsv_provee.Items.Clear();
                pnl_sms.Visible = true;
            }
        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                Buscar_Productos(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    Buscar_Productos(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todos_Productos();
                }
            }
        }

        private void txt_buscar_Enter(object sender, EventArgs e)
        {
            if (txt_buscar.Text == "Buscar Productos")
            {
                txt_buscar.Text = "";
            }
        }

        private void copiarIDProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil=new Frm_Filtro();
            Frm_Advertencia ver= new Frm_Advertencia();

            if (lsv_provee.SelectedIndices.Count ==0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas copiar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis=lsv_provee.SelectedItems[0];
                string idprovee=lis.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Reg_Prod ad=new Frm_Reg_Prod();

            fil.Show();
            ad.ShowDialog();
            fil.Hide();

            if (ad.Tag.ToString() == "A")
            {
                Cargar_Todos_Productos();
            }

        }

        private void agregarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_add_Click(sender, e);
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Edit_Prod edi = new Frm_Edit_Prod();

            if (lsv_provee.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Editar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_provee.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text;

                fil.Show();
                edi.Tag = idprovee;
                edi.ShowDialog();
                fil.Hide();

                if (edi.Tag.ToString() == "A")
                {
                    Cargar_Todos_Productos();
                }

            }
        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Editar_Click(sender, e);
        }

        //falta boton eliminar
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ver2 = new Frm_Msm_Bueno();
            if (lsv_provee.SelectedItems.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Dar de Baja";
                ver.ShowDialog();
                fil.Hide();

                //MessageBox.Show("Selecciona el Item para Eliminar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return;
            }
            else
            {

                var lsv = lsv_provee.SelectedItems[0];

                txt_id.Text = lsv.SubItems[0].Text;

                Frm_sino sino = new Frm_sino();

                sino.lbl_msm1.Text = "¿Estas Seguro que deseas dar de baja el Producto?";
                sino.ShowDialog();

                if (sino.Tag.ToString() == "Si")
                {
                    RN_Productos obj = new RN_Productos();
                    obj.RN_DarBaja_Productos(txt_id.Text.ToString());
                    Cargar_Todos_Productos();

                    fil.Show();
                    ver2.Lbl_msm1.Text = "El Producto se ha Dado de Baja Exitosamente";
                    ver2.ShowDialog();
                    fil.Hide();
                }


            }
        }

        private void eliminarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Eliminar_Click(sender, e);
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Productos();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ver2 = new Frm_Msm_Bueno();
            if (lsv_provee.SelectedItems.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Eliminar";
                ver.ShowDialog();
                fil.Hide();

                //MessageBox.Show("Selecciona el Item para Eliminar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return;
            }
            else
            {

                var lsv = lsv_provee.SelectedItems[0];

                txt_id.Text = lsv.SubItems[0].Text;

                Frm_sino sino = new Frm_sino();

                sino.lbl_msm1.Text = "¿Estas Seguro que deseas Elimnar el Producto?";
                sino.ShowDialog();

                if (sino.Tag.ToString() == "Si")
                {
                    RN_Productos obj = new RN_Productos();
                    obj.RN_Eliminar_Productos(txt_id.Text.ToString());
                    Cargar_Todos_Productos();

                    fil.Show();
                    ver2.Lbl_msm1.Text = "El Cliente se ha Eliminado Exitosamente";
                    ver2.ShowDialog();
                    fil.Hide();
                }


            }
        }

        private void elimnarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_delete_Click(sender, e);
        }

        private void importarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Importar_Producto impo = new Frm_Importar_Producto();
            Frm_Filtro fil = new Frm_Filtro();

            fil.Show();
            impo.Show();
            fil.Hide();

        }

        private void Frm_Explor_Producto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
