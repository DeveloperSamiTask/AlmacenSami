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
    public partial class Frm_Categoria : Form
    {
        public Frm_Categoria()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Configurar_listview();
            Cargar_Todos_Carteg();
            
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
            var lis = lsv_cat;

            lsv_cat.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = false;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 50, HorizontalAlignment.Center);//0
            lis.Columns.Add("Nombre de Categoria", 285, HorizontalAlignment.Center);//1
            

        }

       

        private void Llenar_Listview(DataTable data)
        {
            lsv_cat.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list=new ListViewItem(dr["Id_Cat"].ToString());
                list.SubItems.Add(dr["Categoria"].ToString());
                lsv_cat.Items.Add(list);//si no ponemos esto., el listview nunca se llenara

            }
            Pintar_Filas();
        }
        private void Pintar_Filas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_cat.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_cat.Items[i].BackColor = Color.LightBlue;
                }
                cont += 1;
            }
        }
        private void Cargar_Todos_Carteg()
        {
            RN_Categoria obj= new RN_Categoria();
            DataTable dato= new DataTable();

            dato=obj.RN_Cargar_Todas_Categorias();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_cat.Items.Clear();
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
            RN_Categoria obj= new RN_Categoria();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ver = new Frm_Msm_Bueno();
            if (txt_nom.Text.Trim().Length < 0)
            {
                MessageBox.Show("Ingresa el Nombre de la Categoria","Registrar Categoria",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            if(editar == false)
            {
                //Nuevo
                obj.RN_Registrar_Categoria(txt_nom.Text);
                pnl_add.Visible = false;
                Cargar_Todos_Carteg();
                txt_nom.Text = "";
                
                fil.Show();
                ver.Lbl_msm1.Text = "La Categoria se ha Guardado Exitosamente";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                //Editar
                obj.RN_Editar_Categoria(Convert.ToInt32(txt_id.Text),txt_nom.Text);
                pnl_add.Visible = false;
                Cargar_Todos_Carteg();
                txt_nom.Text = "";
                editar = false;
                fil.Show();
                ver.Lbl_msm1.Text = "La Categoria se ha Editado Exitosamente";
                ver.ShowDialog();
                fil.Hide();
            }
            
        }

        public bool editar=false;

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            if (lsv_cat.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Editar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lsv = lsv_cat.SelectedItems[0];
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
            if (lsv_cat.SelectedIndices.Count == 0)
            {

                if (lsv_cat.SelectedItems.Count == 0)
                {
                    fil.Show();
                    ver.lbl_msm1.Text = "Seleccion el Item que deseas Eliminar";
                    ver.ShowDialog();
                    fil.Hide();

                    //MessageBox.Show("Selecciona el Item para Eliminar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return;
                }
            }
            else
            {
                var lsv = lsv_cat.SelectedItems[0];
                txt_id.Text = lsv.SubItems[0].Text;

                Frm_sino sino = new Frm_sino();


                sino.lbl_msm1.Text = "¿Estas Seguro de Eliminar la Categoria?";
                sino.ShowDialog();

                if (sino.Tag.ToString() == "Si")
                {
                    RN_Categoria obj = new RN_Categoria();
                    obj.RN_Eliminar_Marca(Convert.ToInt32(txt_id.Text));
                    Cargar_Todos_Carteg();

                    fil.Show();
                    ver2.Lbl_msm1.Text = "La Categoria se ha Eliminado Exitosamente";
                    ver2.ShowDialog();
                    fil.Hide();
                }


            }
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Carteg();
        }

        
        private void eliminarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ver2 = new Frm_Msm_Bueno();
            if (lsv_cat.SelectedIndices.Count == 0)
            {
               
                if (lsv_cat.SelectedItems.Count == 0)
                {
                    fil.Show();
                    ver.lbl_msm1.Text = "Seleccion el Item que deseas Eliminar";
                    ver.ShowDialog();
                    fil.Hide();

                    //MessageBox.Show("Selecciona el Item para Eliminar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return;
                }
            }
            else
            {
                var lsv = lsv_cat.SelectedItems[0];
                txt_id.Text = lsv.SubItems[0].Text;

                Frm_sino sino = new Frm_sino();

                sino.lbl_msm1.Text = "¿Estas Seguro de Eliminar la Categoria?";
                sino.ShowDialog();

                if (sino.Tag.ToString() == "Si")
                {
                    RN_Categoria obj = new RN_Categoria();
                    obj.RN_Eliminar_Marca(Convert.ToInt32(txt_id.Text));
                    Cargar_Todos_Carteg();

                    fil.Show();
                    ver2.Lbl_msm1.Text = "La Categoria se ha Eliminado Exitosamente";
                    ver2.ShowDialog();
                    fil.Hide();
                }


            }
        }

       
        private void lsv_cat_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_Seleccionar_Click(sender, e);
            }

        }

        private void btn_Seleccionar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            if (lsv_cat.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Selecciona una Categoria";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lsv = lsv_cat.SelectedItems[0];
                txt_id.Text = lsv.SubItems[0].Text;
                txt_nom.Text = lsv.SubItems[1].Text;

                this.Tag = "A";
                this.Close();
            }
        }

        private void lsv_cat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            if (lsv_cat.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Selecciona una Categoria";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                txt_id.Text = lsv_cat.SelectedItems[0].SubItems[0].Text;
                txt_nom.Text = lsv_cat.SelectedItems[0].SubItems[1].Text;

                this.Tag = "A";
                this.Close();
            }
        }

        private void seleccionarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            if (lsv_cat.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Selecciona una Categoria";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                txt_id.Text = lsv_cat.SelectedItems[0].SubItems[0].Text;
                txt_nom.Text = lsv_cat.SelectedItems[0].SubItems[1].Text;

                this.Tag = "A";
                this.Close();
            }
        }

        private void Frm_Categoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
