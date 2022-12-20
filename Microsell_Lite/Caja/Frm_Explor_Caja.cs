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

namespace Microsell_Lite.Caja
{
    public partial class Frm_Explor_Caja : Form
    {
        public Frm_Explor_Caja()
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
            Cargar_Todas_lasCajas();
            //Buscar_Caja_Dia(dtp_Hoy.Value);

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
            lis.Columns.Add("ID Caja.", 70, HorizontalAlignment.Center);//0           
            lis.Columns.Add("Nro Doc.", 120, HorizontalAlignment.Center);//2
            lis.Columns.Add("Nombre Cliente", 330, HorizontalAlignment.Center);//5           
            lis.Columns.Add("Fecha", 110, HorizontalAlignment.Center);//4     
            lis.Columns.Add("Tipo Caja", 110, HorizontalAlignment.Center);//5
            lis.Columns.Add("Concepto",250, HorizontalAlignment.Center);//5
            lis.Columns.Add("Total S/.", 100, HorizontalAlignment.Center);//5            
            lis.Columns.Add("Utilidad S/", 100, HorizontalAlignment.Center);//5
            lis.Columns.Add("Tipo Pago", 90, HorizontalAlignment.Center);//5           
            lis.Columns.Add("Generado Por.", 110, HorizontalAlignment.Center);//5
            lis.Columns.Add("Estado Caja", 100, HorizontalAlignment.Center);//5



        }

       
        private void Llenar_Listview(DataTable data)
        {
            lsv_COM.Items.Clear();
           
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Idcaja"].ToString());
                //list.SubItems.Add(dr["Codigo"].ToString());
                list.SubItems.Add(dr["Nro_Doc"].ToString().Trim());
                list.SubItems.Add(dr["De_Para"].ToString());
                list.SubItems.Add(dr["Fecha_Caja"].ToString());
                list.SubItems.Add(dr["Tipo_Caja"].ToString());
                list.SubItems.Add(dr["Concepto"].ToString());
                list.SubItems.Add(dr["ImporteCaja"].ToString());
                list.SubItems.Add(dr["TotalUti"].ToString());               
                list.SubItems.Add(dr["TipoPago"].ToString());
                list.SubItems.Add(dr["GeneradoPor"].ToString());
                list.SubItems.Add(dr["EstadoCaja"].ToString());
                



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

        private void Cargar_Todas_lasCajas()
        {
            RN_Caja obj = new RN_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todas_Cajas();
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

        private void Buscar_Caja(string valor)
        {
            RN_Caja obj = new RN_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_General_cajas(valor);
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
                Buscar_Caja(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    Buscar_Caja(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todas_lasCajas();
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
                string idprovee=lis.SubItems[1].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());
            }
        }


        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todas_lasCajas();
        }

        private void Buscar_Caja_Dia(DateTime diax)
        {
            RN_Caja obj = new RN_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Caja_porDia(diax);
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
                Buscar_Caja_Dia(xfecha);
            }
        }

        private void Buscar_caja_mes(DateTime fechax)
        {
            RN_Caja obj = new RN_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Caja_pormes(fechax);
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
                Buscar_caja_mes(xfecha);
            }
        }

        private void lsv_COM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Advertencia ver = new Frm_Advertencia();
            //Frm_DetalleCotizacion edi = new Frm_DetalleCotizacion();

            //if (lsv_COM.SelectedIndices.Count == 0)
            //{
            //    fil.Show();
            //    ver.lbl_msm1.Text = "Seleccion el Item que deseas Ver el Detalle";
            //    ver.ShowDialog();
            //    fil.Hide();
            //}
            //else
            //{
            //    var lis = lsv_COM.SelectedItems[0];
            //    string idcompra = lis.SubItems[0].Text;

            //    fil.Show();
            //    edi.Tag = idcompra;
            //    edi.ShowDialog();
            //    fil.Hide();

            //}
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_Abonar_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Explor_Caja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
