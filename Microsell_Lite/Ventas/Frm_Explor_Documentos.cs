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
using Microsell_Lite.Ventas;
using Microsell_Lite.Compras;

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Explor_Documentos : Form
    {
        public Frm_Explor_Documentos()
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
            Buscar_Documento_Dia(dtp_Hoy.Value);

        }

       
        private void Configurar_listview()
        {
            var lis = lsv_COM;

            lsv_COM.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:            
            lis.Columns.Add("ID Documento", 120, HorizontalAlignment.Center);//0           
            lis.Columns.Add("Fecha Emi.", 110, HorizontalAlignment.Center);//2
            lis.Columns.Add("Nombre del Cliente", 350, HorizontalAlignment.Center);//5
            lis.Columns.Add("Tipo Doc.", 90, HorizontalAlignment.Center);//3
            lis.Columns.Add("Nro Pedido", 120, HorizontalAlignment.Center);//4
            lis.Columns.Add("Tipo Pago", 0, HorizontalAlignment.Center);//5                    
            lis.Columns.Add("Total S/", 0, HorizontalAlignment.Center);//4
            lis.Columns.Add("Estado Doc.", 100, HorizontalAlignment.Center);//5
            lis.Columns.Add("Vendedor", 100, HorizontalAlignment.Center);//5  



        }


        private void Llenar_Listview(DataTable data)
        {
            lsv_COM.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["id_Doc"].ToString());
                //list.SubItems.Add(dr["Codigo"].ToString());
                list.SubItems.Add(dr["Fecha_Emi"].ToString());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                list.SubItems.Add(dr["Documento"].ToString());
                list.SubItems.Add(dr["id_Ped"].ToString());
                list.SubItems.Add(dr["TipoPago"].ToString());
                list.SubItems.Add(dr["ImporteDoc"].ToString());
                //list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());
                list.SubItems.Add(dr["Estado_Doc"].ToString());
                list.SubItems.Add(dr["Nombres"].ToString());
                //list.SubItems.Add(dr["Estado_Pro"].ToString());


                lsv_COM.Items.Add(list);//si no ponemos esto., el listview nunca se llenara

            }
            Pintar_Filas();
            pnl_sms.Visible = false;
            lbl_TotalItems.Text = Convert.ToString(lsv_COM.Items.Count);
        }

        private void Pintar_Filas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_COM.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_COM.Items[i].BackColor = Color.LightBlue;
                }
                cont += 1;
            }
        }

        private void Cargar_Todas_Ventas()
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todos_Documentos();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_COM.Items.Clear();
                pnl_sms.Visible = true;
            }
        }

        private void Buscar_Documentos_Ventas(string valor)
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Documento_porValor(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);

                
            }
            else
            {
                lsv_COM.Items.Clear();
                pnl_sms.Visible = true;
            }
        }

        private void Buscar_Documento_Dia(DateTime fechax)
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Documento_porDia(fechax);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);


            }
            else
            {
                lsv_COM.Items.Clear();
                pnl_sms.Visible = true;
            }
        }

        private void Buscar_Ventas_mes( DateTime fechax)
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Documento_porMes(fechax);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);


            }
            else
            {
                lsv_COM.Items.Clear();
                pnl_sms.Visible = true;
            }
        }
        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                Buscar_Documentos_Ventas(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    Buscar_Documentos_Ventas(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todas_Ventas();
                }
            }
        }

        private void txt_buscar_Enter(object sender, EventArgs e)
        {
            if (txt_buscar.Text == "Buscar Ventas")
            {
                txt_buscar.Text = "";
            }
        }    

        
        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todas_Ventas();
        }
              

        private void lsv_COM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_DetallePedido edi = new Frm_DetallePedido();

            if (lsv_COM.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Ver el Detalle";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_COM.SelectedItems[0];
                string idcompra = lis.SubItems[0].Text;

                fil.Show();
                edi.Tag = idcompra;
                edi.ShowDialog();
                fil.Hide();              

            }
        }

        private void copiarNroDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_COM.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas copiar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_COM.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());
            }
        }

        private void ventasDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;
                Buscar_Documento_Dia(xfecha);
            }
        }

        private void buscarVentasDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;
                Buscar_Ventas_mes(xfecha);
            }
        }

        private void reImprimirDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Crear_Ventas ven = new Frm_Crear_Ventas();

            if (lsv_COM.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Re-Imprimir";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_COM.SelectedItems[0];
                string iddoc = lis.SubItems[0].Text;

                fil.Show();                
                ven.txtBuscar.Text = iddoc;
                ven.ShowDialog();
                fil.Hide();

            }
        }
    }
}
