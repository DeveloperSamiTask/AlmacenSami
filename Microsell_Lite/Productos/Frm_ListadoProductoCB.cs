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
using Prj_Capa_Datos;

namespace Microsell_Lite.Productos
{
    public partial class Frm_ListadoProductoCB : Form
    {
        public Frm_ListadoProductoCB()
        {
            InitializeComponent();
            
            Configurar_listview();
            Cargar_Todos_Clientes();
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
            var lis = lsv_client;

            lsv_client.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;            
            //configurar las columnas:           
            lis.Columns.Add("Codigo", 100, HorizontalAlignment.Center);//2
            lis.Columns.Add("Descripcion Producto", 347, HorizontalAlignment.Left);//5
            
        }
        private void Llenar_Listview(DataTable data)
        {
            
            lsv_client.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Codigo"].ToString());
                list.SubItems.Add(dr["Modelo"].ToString());
                



                lsv_client.Items.Add(list);//si no ponemos esto., el listview nunca se llenara

            }
            Pintar_Filas();
            
        }

        private void Pintar_Filas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_client.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_client.Items[i].BackColor = Color.LightBlue;
                }
                cont += 1;
            }
        }

        private void Cargar_Todos_Clientes()
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
                lsv_client.Items.Clear();
               
            }
        }

        public void Buscar_Clientes(string valor)
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
                lsv_client.Items.Clear();
                
            }
        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                Buscar_Clientes(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    Buscar_Clientes(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todos_Clientes();
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

        private void Seleccionar_Cliente()
        {
            if (lsv_client.SelectedIndices.Count ==0)
            {

            }
            else
            {
                var lis = lsv_client.SelectedItems[0];
                lbl_Codigo.Text = lis.SubItems[0].Text;
                lbl_Modelo.Text = lis.SubItems[1].Text;
                

                this.Tag = "A";
                this.Close();
            }
        }


        private void lsv_client_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Seleccionar_Cliente();
        }

        private void lsv_client_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                Seleccionar_Cliente();
            }
        }

       
        public static string tipo = "";

        private void Frm_ListadoCliente_Load(object sender, EventArgs e)
        {
            if (tipo.Trim().Length == 0)
            {
                Configurar_listview();
                Cargar_Todos_Clientes();
            }
            else
            {
                Configurar_listview();
                Buscar_Clientes(tipo);
            }
            
        }


        private void Frm_ListadoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
