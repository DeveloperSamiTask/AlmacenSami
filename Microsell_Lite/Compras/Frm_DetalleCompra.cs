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

namespace Microsell_Lite.Compras
{
    public partial class Frm_DetalleCompra : Form
    {
        public Frm_DetalleCompra()
        {
            InitializeComponent();
        }
                

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void Frm_DetalleCompra_Load(object sender, EventArgs e)
        {
            Configurar_listview();
            Buscar_Det_Compras(this.Tag.ToString());
        }

        private void Configurar_listview()
        {
            var lis = lsv_DetCompra;

            lsv_DetCompra.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:            
            lis.Columns.Add("ID Interno", 120, HorizontalAlignment.Right);//0           
            lis.Columns.Add("ID Producto", 130, HorizontalAlignment.Center);//2
            lis.Columns.Add("Descripcion del Producto", 350, HorizontalAlignment.Center);//5
            lis.Columns.Add("Precio Unitario", 0, HorizontalAlignment.Center);//3
            lis.Columns.Add("Cant", 70, HorizontalAlignment.Center);//5
            lis.Columns.Add("Importe S/", 0, HorizontalAlignment.Center);//4            
            
        }
        private void Pintar_Filas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_DetCompra.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_DetCompra.Items[i].BackColor = Color.LightBlue;
                }
                cont += 1;
            }
        }
        private void Buscar_Det_Compras(string idcompra)
        {
            RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Compras_ConDetalle(idcompra.Trim());

            if (dato.Rows.Count >0)
            {
                lsv_DetCompra.Items.Clear();

                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];
                    ListViewItem list = new ListViewItem(dr["Id_DocComp"].ToString().Trim());
                    //list.SubItems.Add(dr["Codigo"].ToString());
                    list.SubItems.Add(dr["Id_Pro"].ToString().Trim());
                    list.SubItems.Add(dr["Modelo"].ToString());
                    list.SubItems.Add(dr["PrecioUnit"].ToString());
                    list.SubItems.Add(dr["Cantidad"].ToString());
                    list.SubItems.Add(dr["Importe"].ToString());                   


                    lsv_DetCompra.Items.Add(list);//si no ponemos esto., el listview nunca se llenara

                }
                Pintar_Filas();
            }            
        }

        private void Frm_DetalleCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
