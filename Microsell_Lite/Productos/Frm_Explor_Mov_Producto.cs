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
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace Microsell_Lite.Productos
{
    public partial class Frm_Explor_Mov_Producto : Form
    {
        public Frm_Explor_Mov_Producto()
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
            Buscar_Kardex_delDia(dtp_dia.Value);
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
            lis.Columns.Add("ID Kardex", 140, HorizontalAlignment.Center);//0
            //lis.Columns.Add("Codigo", 80, HorizontalAlignment.Left);//1
            lis.Columns.Add("Item", 80, HorizontalAlignment.Center);//2
            lis.Columns.Add("Fecha Emis.", 110, HorizontalAlignment.Center);//5
            lis.Columns.Add("Doc Soporte", 130, HorizontalAlignment.Center);//3
            lis.Columns.Add("Detalle Movimiento", 280, HorizontalAlignment.Center);//4
            lis.Columns.Add("Entrada", 80, HorizontalAlignment.Center);//5
            lis.Columns.Add("Salida", 80, HorizontalAlignment.Center);//2
            //lis.Columns.Add("PRE VENTA2", 90, HorizontalAlignment.Center);//3
            lis.Columns.Add("Saldos", 80, HorizontalAlignment.Center);//4
            lis.Columns.Add("ID PRODUCTO", 0, HorizontalAlignment.Center);//4
            lis.Columns.Add("Producto", 300, HorizontalAlignment.Center);//4
            //lis.Columns.Add("TOTAL", 100, HorizontalAlignment.Center);//5
            ////lis.Columns.Add("ESTADO", 100, HorizontalAlignment.Center);//5


        }

       
        private void Llenar_Listview(DataTable data)
        {
            lsv_provee.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_krdx"].ToString().Trim());               
                list.SubItems.Add(dr["Item"].ToString());
                list.SubItems.Add(dr["Fecha_Krdx"].ToString());
                list.SubItems.Add(dr["Doc_Soporte"].ToString().Trim());
                list.SubItems.Add(dr["Det_Operacion"].ToString());
                list.SubItems.Add(dr["Cantidad_In"].ToString());
                list.SubItems.Add(dr["Cantidad_Out"].ToString());
                list.SubItems.Add(dr["Cantidad_Saldo"].ToString());

                list.SubItems.Add(dr["Id_Pro"].ToString());
                list.SubItems.Add(dr["Modelo"].ToString());
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



        private void Buscar_Kardex_delDia(DateTime dia)
        {
            RN_Kardex obj = new RN_Kardex();
            DataTable dato = new DataTable();

            dato = obj.RN_Cargar_DetalleKardex_delDia(dia);
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

        private void Buscar_Kardex_delMes(DateTime mes)
        {
            RN_Kardex obj = new RN_Kardex();
            DataTable dato = new DataTable();

            dato = obj.BD_Cargar_DetalleKardex_delMes(mes);
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

        private void Buscar_Kardex_porProd(string pro)
        {
            RN_Kardex obj = new RN_Kardex();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_KardexDetalle_porProducto(pro);
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
                Buscar_Kardex_porProd(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    Buscar_Kardex_porProd(txt_buscar.Text);
                }
                else
                {
                    Buscar_Kardex_delDia(dtp_dia.Value);
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
                string idprovee=lis.SubItems[8].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());
            }
        }

       


        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar_Kardex_delDia(dtp_dia.Value);
        }
       

        private void dtp_dia_ValueChanged(object sender, EventArgs e)
        {
            Buscar_Kardex_delDia(dtp_dia.Value);
        }

        private void Frm_Explor_Mov_Producto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void verMovimientoDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;
                Buscar_Kardex_delDia(xfecha);
            }
        }

        private void verMovimientoDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_SoloFecha solo = new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;
                Buscar_Kardex_delMes(xfecha);
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel workook|*.xlsx", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1,1] = "ID KARDEX";
                    ws.Cells[1,2] = "Documento";
                    ws.Cells[1,3]= "Fecha";
                    ws.Cells[1,4]= "Producto";
                    ws.Cells[1,5]= "Ingreso";
                    ws.Cells[1,6] = "Salidas";
                    ws.Cells[1,7]= "Stock Real";
                    int i = 2;
                    foreach (ListViewItem item in lsv_provee.Items)
                    {
                        ws.Cells[i, 1] = item.SubItems[0].Text;
                        ws.Cells[i, 2] = item.SubItems[3].Text;
                        ws.Cells[i, 3] = item.SubItems[2].Text;
                        ws.Cells[i, 4] = item.SubItems[9].Text;
                        ws.Cells[i, 5] = item.SubItems[5].Text;
                        ws.Cells[i, 6] = item.SubItems[6].Text;
                        ws.Cells[i, 7] = item.SubItems[7].Text;
                        i++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution
                        .xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();
                    MessageBox.Show("Los Datos Se Exportaron Correctamente.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            }
        }
    }
}
