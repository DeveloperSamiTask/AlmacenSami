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

namespace Microsell_Lite.Cotizacion
{
    public partial class Frm_Explor_Cotizacion_Estado : Form
    {
        public Frm_Explor_Cotizacion_Estado()
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
            Buscar_Compras_Dia(dtp_Hoy.Value);

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
            lis.Columns.Add("ID Req.", 120, HorizontalAlignment.Center);//0           
            lis.Columns.Add("Fecha Req.", 110, HorizontalAlignment.Center);//2
            lis.Columns.Add("Nombre Cliente", 300, HorizontalAlignment.Center);//5           
            lis.Columns.Add("Importe S/", 0, HorizontalAlignment.Center);//4     
            lis.Columns.Add("Estado Req.", 100, HorizontalAlignment.Center);//5
            lis.Columns.Add("Condiciones",255, HorizontalAlignment.Center);//5
            lis.Columns.Add("Vendedor", 90, HorizontalAlignment.Center);//5



        }

       
        private void Llenar_Listview(DataTable data)
        {
            lsv_COM.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Cotiza"].ToString().Trim());
                //list.SubItems.Add(dr["Codigo"].ToString());
                list.SubItems.Add(dr["FechaCoti"].ToString());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                list.SubItems.Add(dr["TotalCotiza"].ToString());
                list.SubItems.Add(dr["EstadoCoti"].ToString());
                list.SubItems.Add(dr["Condiciones"].ToString());
                list.SubItems.Add(dr["Nombres"].ToString());



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

        private void Cargar_Todas_Cotizaciones()
        {
            RN_Cotizacion obj = new RN_Cotizacion();
            DataTable dato = new DataTable();

            dato = obj.BD_Listar_Cotizacion_Estado("Pendiente");
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

        private void Buscar_Cotizacion(string valor)
        {
            RN_Cotizacion obj = new RN_Cotizacion();
            DataTable dato = new DataTable();

            dato = obj.BD_Buscar_Cotizacion(valor);
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
                Buscar_Cotizacion(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    Buscar_Cotizacion(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todas_Cotizaciones();
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

            if (lsv_COM.SelectedIndices.Count ==0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas copiar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis=lsv_COM.SelectedItems[0];
                string idprovee=lis.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());
            }
        }    

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todas_Cotizaciones();
        }

        private void Buscar_Compras_Dia(DateTime fechax)
        {
            RN_Cotizacion obj = new RN_Cotizacion();
            DataTable dato = new DataTable();

            dato = obj.BD_Buscar_Cotizacion_Explorador_Mes_Dia("dia", fechax);
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

        private void cargarComprasDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;
                Buscar_Compras_Dia(xfecha);
            }
        }

        private void Buscar_Compras_mes(DateTime fechax)
        {
            RN_Cotizacion obj = new RN_Cotizacion();
            DataTable dato = new DataTable();

            dato = obj.BD_Buscar_Cotizacion_Explorador_Mes_Dia("mes", fechax);
            if (dato.Rows.Count > 0)
            {
                Cargar_Todas_Cotizaciones();
                
            }
            else
            {
                lsv_COM.Items.Clear();
                pnl_sms.Visible = true;
            }
        }

        private void buscarComprasDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;
                Buscar_Compras_mes(xfecha);
            }
        }

        private void lsv_COM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_DetalleCotizacion edi = new Frm_DetalleCotizacion();

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

        private void procesarCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
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
                ven.chk_Coti.Checked = true;
                ven.ShowDialog();
                fil.Hide();

            }
        }

        private void Frm_Explor_Cotizacion_Estado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
