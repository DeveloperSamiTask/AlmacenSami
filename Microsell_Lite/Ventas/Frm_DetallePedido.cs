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

namespace Microsell_Lite.Ventas
{
    public partial class Frm_DetallePedido : Form
    {
        public Frm_DetallePedido()
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
            lis.Columns.Add("ID Documento ", 110, HorizontalAlignment.Right);//0           
            lis.Columns.Add("ID Producto", 110, HorizontalAlignment.Center);//2
            lis.Columns.Add("Descripcion del Producto", 350, HorizontalAlignment.Center);//5
            lis.Columns.Add("Precio Unit.", 0, HorizontalAlignment.Center);//3
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
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Documento_yDetalle(idcompra.Trim());

            if (dato.Rows.Count >0)
            {
                lsv_DetCompra.Items.Clear();

                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];
                    ListViewItem list = new ListViewItem(dr["Id_Doc"].ToString());
                    //list.SubItems.Add(dr["Codigo"].ToString());
                    list.SubItems.Add(dr["Id_Pro"].ToString());
                    list.SubItems.Add(dr["Modelo"].ToString());
                    list.SubItems.Add(dr["Precio"].ToString());
                    list.SubItems.Add(dr["Cantidad"].ToString());
                    list.SubItems.Add(dr["Importe"].ToString());                   


                    lsv_DetCompra.Items.Add(list);//si no ponemos esto., el listview nunca se llenara

                }
                Pintar_Filas();
            }            
        }
    }
}
