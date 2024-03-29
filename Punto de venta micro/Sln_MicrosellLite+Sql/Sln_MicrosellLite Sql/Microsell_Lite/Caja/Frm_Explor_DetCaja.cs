﻿using System;
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
    public partial class Frm_Explor_DetCaja : Form
    {
        public Frm_Explor_DetCaja()
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
            Buscar_Caja_Dia(dtp_Hoy.Value);

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
            lis.Columns.Add("ID Cierre.", 110, HorizontalAlignment.Center);//0           
            lis.Columns.Add("Fecha Cierre.", 110, HorizontalAlignment.Center);//2
            lis.Columns.Add("Apertura Caja", 110, HorizontalAlignment.Center);//5           
            lis.Columns.Add("Total Ingreso", 120, HorizontalAlignment.Center);//4     
            lis.Columns.Add("Total Egreso", 100, HorizontalAlignment.Center);//5
            lis.Columns.Add("Usuario",110, HorizontalAlignment.Center);//5
            lis.Columns.Add("Depositos", 90, HorizontalAlignment.Center);//5            
            lis.Columns.Add("Ganancia Dia", 110, HorizontalAlignment.Center);//5
            lis.Columns.Add("Total Entregado", 120, HorizontalAlignment.Center);//5
            lis.Columns.Add("Saldo Sig.", 90, HorizontalAlignment.Center);//5
            lis.Columns.Add("Total Fact.", 90, HorizontalAlignment.Center);//5
            lis.Columns.Add("Total Bol.", 90, HorizontalAlignment.Center);//5
            lis.Columns.Add("Total Nota V.", 100, HorizontalAlignment.Center);//5
            lis.Columns.Add("Total Cred. Cobrado", 150, HorizontalAlignment.Center);//5
            lis.Columns.Add("Total Cred. Emitido", 150, HorizontalAlignment.Center);//5
            lis.Columns.Add("Estado Cierre", 110, HorizontalAlignment.Center);//5


        }

       
        private void Llenar_Listview(DataTable data)
        {
            lsv_COM.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_cierre"].ToString().Trim());
                //list.SubItems.Add(dr["Codigo"].ToString());
                list.SubItems.Add(dr["Fecha_Cierre"].ToString());
                list.SubItems.Add(dr["Apertura_Caja"].ToString());
                list.SubItems.Add(dr["Total_Ingreso"].ToString());
                list.SubItems.Add(dr["TotalEgreso"].ToString());
                list.SubItems.Add(dr["Nombres"].ToString());
                list.SubItems.Add(dr["TodoDeposito"].ToString());
                list.SubItems.Add(dr["Gananciadeldia"].ToString());
                list.SubItems.Add(dr["TotalEntregado"].ToString());
                list.SubItems.Add(dr["SaldoSiguiente"].ToString());
                list.SubItems.Add(dr["TotalFactura"].ToString());
                list.SubItems.Add(dr["TotalBoleta"].ToString());
                list.SubItems.Add(dr["TotalNotaVenta"].ToString());
                list.SubItems.Add(dr["TotalCreditoCobrado"].ToString());
                list.SubItems.Add(dr["TotalCreditoEmitido"].ToString());
                list.SubItems.Add(dr["Estado_cierre"].ToString());




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
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todas_CierreCajas();
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
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_General_Cierrecajas(valor);
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
            if (e.KeyCode == Keys.Enter)
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


        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todas_lasCajas();
        }

        private void Buscar_Caja_Dia(DateTime diax)
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_cargar_Cierre_Caja_DelDia(diax);
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
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Cierre_Caja_DelMes(fechax);
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

        private void Frm_Explor_DetCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
