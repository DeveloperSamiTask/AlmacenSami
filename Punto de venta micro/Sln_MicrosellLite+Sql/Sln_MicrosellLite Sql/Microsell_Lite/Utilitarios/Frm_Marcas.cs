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


namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Marcas : Form
    {
        public Frm_Marcas()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listview();
            Cargar_Todos_Marca();
            
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        

        private void Configurar_listview()
        {
            var lis = lsv_mar;

            lsv_mar.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = false;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 50, HorizontalAlignment.Center);//0
            lis.Columns.Add("Nombre de Marca", 280, HorizontalAlignment.Center);//1
            

        }

       

        private void Llenar_Listview(DataTable data)
        {
            lsv_mar.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list=new ListViewItem(dr["Id_Marca"].ToString());
                list.SubItems.Add(dr["Marca"].ToString());
                lsv_mar.Items.Add(list);//si no ponemos esto., el listview nunca se llenara

            }
            Pintar_Filas();
        }

        private void Pintar_Filas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_mar.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_mar.Items[i].BackColor = Color.LightBlue;
                }
                cont += 1;
            }
        }

        private void Cargar_Todos_Marca()
        {
            RN_Marca obj= new RN_Marca();
            DataTable dato= new DataTable();

            dato=obj.RN_Cargar_Todas_Marcas();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_mar.Items.Clear();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = true;
            txt_nom.Focus();
            editar = false;
        }

       
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            pnl_add.Visible = false;
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            RN_Marca obj= new RN_Marca();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ver = new Frm_Msm_Bueno();
            if (txt_nom.Text.Trim().Length < 0)
            {
                MessageBox.Show("Ingresa el Nombre de la Marca","Registrar Marca",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            if(editar == false)
            {
                //Nuevo
                obj.RN_Registrar_Marca(txt_nom.Text);
                pnl_add.Visible = false;
                Cargar_Todos_Marca();
                txt_nom.Text = "";

                fil.Show();
                ver.Lbl_msm1.Text = "La Marca se ha Guardado Exitosamente";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                //Editar
                obj.RN_Editar_Marca(Convert.ToInt32(txt_id.Text),txt_nom.Text);
                pnl_add.Visible = false;
                Cargar_Todos_Marca();
                txt_nom.Text = "";
                editar = false;
                fil.Show();
                ver.Lbl_msm1.Text = "La Marca se ha Editado Exitosamente";
                ver.ShowDialog();
                fil.Hide();
            }
            
        }

        public bool editar=false;

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            if (lsv_mar.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Editar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lsv = lsv_mar.SelectedItems[0];
                txt_id.Text=lsv.SubItems[0].Text;
                txt_nom.Text=lsv.SubItems[1].Text;

                pnl_add.Visible = true;
                txt_nom.Focus();
                editar = true;
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ver2 = new Frm_Msm_Bueno();
            if (lsv_mar.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Eliminar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lsv = lsv_mar.SelectedItems[0];
                txt_id.Text = lsv.SubItems[0].Text;
                
                Frm_sino sino=new Frm_sino();

                sino.lbl_msm1.Text = "¿Estas Seguro de Eliminar la Marca?";
                sino.ShowDialog();

                if (sino.Tag.ToString() =="Si")
                {
                    RN_Marca obj = new RN_Marca();
                    obj.RN_Eliminar_Marca(Convert.ToInt32(txt_id.Text));
                    Cargar_Todos_Marca();

                    fil.Show();
                    ver2.Lbl_msm1.Text = "La Marca se ha Eliminado Exitosamente";
                    ver2.ShowDialog();
                    fil.Hide();
                }

               
            }

        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Marca();
        }

        private void eliminarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ver2 = new Frm_Msm_Bueno();
            if (lsv_mar.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Eliminar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lsv = lsv_mar.SelectedItems[0];
                txt_id.Text = lsv.SubItems[0].Text;

                Frm_sino sino = new Frm_sino();

                sino.lbl_msm1.Text = "¿Estas Seguro de Eliminar la Marca?";
                sino.ShowDialog();

                if (sino.Tag.ToString() == "Si")
                {
                    RN_Marca obj = new RN_Marca();
                    obj.RN_Eliminar_Marca(Convert.ToInt32(txt_id.Text));
                    Cargar_Todos_Marca();

                    fil.Show();
                    ver2.Lbl_msm1.Text = "La Marca se ha Eliminado Exitosamente";
                    ver2.ShowDialog();
                    fil.Hide();
                }
            }
        }

        private void btn_Seleccionar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            if (lsv_mar.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Selecciona una Categoria";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lsv = lsv_mar.SelectedItems[0];
                txt_id.Text = lsv.SubItems[0].Text;
                txt_nom.Text = lsv.SubItems[1].Text;

                this.Tag = "A";
                this.Close();
            }
        }

        private void lsv_mar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Seleccionar_Click(sender, e);
            }
        }

        private void lsv_mar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            if (lsv_mar.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Selecciona una Categoria";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                txt_id.Text = lsv_mar.SelectedItems[0].SubItems[0].Text;
                txt_nom.Text = lsv_mar.SelectedItems[0].SubItems[1].Text;

                this.Tag = "A";
                this.Close();
            }
        }

        private void seleccionaMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            if (lsv_mar.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Selecciona una Categoria";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                txt_id.Text = lsv_mar.SelectedItems[0].SubItems[0].Text;
                txt_nom.Text = lsv_mar.SelectedItems[0].SubItems[1].Text;

                this.Tag = "A";
                this.Close();
            }
        }

        private void Frm_Marcas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
