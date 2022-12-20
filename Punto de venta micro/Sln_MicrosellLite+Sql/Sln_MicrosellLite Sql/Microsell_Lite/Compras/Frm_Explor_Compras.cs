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

namespace Microsell_Lite.Compras
{
    public partial class Frm_Explor_Compras : Form
    {
        public Frm_Explor_Compras()
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
            Cargar_Todas_Compras();

        }

       
        private void Configurar_listview()
        {
            var lis = lsv_COM;

            lsv_COM.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = false;
            lis.HideSelection = false;
            //configurar las columnas:            
            lis.Columns.Add("ID Interno", 140, HorizontalAlignment.Center);//0           
            lis.Columns.Add("Nro Factura", 100, HorizontalAlignment.Center);//2
            lis.Columns.Add("Proveedor", 446, HorizontalAlignment.Center);//5
            lis.Columns.Add("Fecha", 100, HorizontalAlignment.Center);//3
            lis.Columns.Add("Importe S/", 0, HorizontalAlignment.Center);//4
            lis.Columns.Add("Forma Pago", 0, HorizontalAlignment.Center);//5
           // lis.Columns.Add("Tipo Ingreso", 100, HorizontalAlignment.Center);//2            
            lis.Columns.Add("Tipo Doc.", 100, HorizontalAlignment.Center);//4
            lis.Columns.Add("Estado Fact.", 100, HorizontalAlignment.Center);//5
            lis.Columns.Add("Observacion", 0, HorizontalAlignment.Center);//5



        }

       
        private void Llenar_Listview(DataTable data)
        {
            lsv_COM.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_DocComp"].ToString().Trim());
                //list.SubItems.Add(dr["Codigo"].ToString());
                list.SubItems.Add(dr["NroFac_Fisico"].ToString().Trim());
                list.SubItems.Add(dr["NOMBRE"].ToString());
                list.SubItems.Add(dr["Fecha_Ingre"].ToString());
                list.SubItems.Add(dr["Total_Ingre"].ToString());
                list.SubItems.Add(dr["ModalidadPago"].ToString());
                list.SubItems.Add(dr["TipoDoc_Compra"].ToString());
                //list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());
                list.SubItems.Add(dr["Estado_Ingre"].ToString());
                list.SubItems.Add(dr["Datos_Adicional"].ToString());
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

        private void Cargar_Todas_Compras()
        {
            RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_Cargar_Todas_Compras();
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

        private void Buscar_Compras(string valor)
        {
            RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Compras_Explorador(valor);
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

        private void Buscar_Compras_Dia(DateTime fechax)
        {
            RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Compras_Explorador_Mes_Dia("dia",fechax);
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

        private void Buscar_Compras_mes( DateTime fechax)
        {
            RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Compras_Explorador_Mes_Dia("mes", fechax);
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
                Buscar_Compras(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    Buscar_Compras(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todas_Compras();
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Reg_Prod ad=new Frm_Reg_Prod();

            fil.Show();
            ad.ShowDialog();
            fil.Hide();

            if (ad.Tag.ToString() == "A")
            {
                Cargar_Todas_Compras();
            }

        }

        private void agregarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_add_Click(sender, e);
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Edit_Prod edi = new Frm_Edit_Prod();

            if (lsv_COM.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Editar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_COM.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text;

                fil.Show();
                edi.Tag = idprovee;
                edi.ShowDialog();
                fil.Hide();

                if (edi.Tag.ToString() == "A")
                {
                    Cargar_Todas_Compras();
                }

            }
        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Editar_Click(sender, e);
        }

        //falta boton eliminar
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ver2 = new Frm_Msm_Bueno();
            if (lsv_COM.SelectedItems.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Dar de Baja";
                ver.ShowDialog();
                fil.Hide();

                //MessageBox.Show("Selecciona el Item para Eliminar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return;
            }
            else
            {

                var lsv = lsv_COM.SelectedItems[0];

                txt_id.Text = lsv.SubItems[0].Text;

                Frm_sino sino = new Frm_sino();

                sino.lbl_msm1.Text = "¿Estas Seguro que deseas dar de baja el Producto?";
                sino.ShowDialog();

                if (sino.Tag.ToString() == "Si")
                {
                    RN_Productos obj = new RN_Productos();
                    obj.RN_DarBaja_Productos(txt_id.Text.ToString());
                    Cargar_Todas_Compras();

                    fil.Show();
                    ver2.Lbl_msm1.Text = "El Producto se ha Dado de Baja Exitosamente";
                    ver2.ShowDialog();
                    fil.Hide();
                }


            }
        }

        private void eliminarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Eliminar_Click(sender, e);
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todas_Compras();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ver2 = new Frm_Msm_Bueno();
            if (lsv_COM.SelectedItems.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Item que deseas Eliminar";
                ver.ShowDialog();
                fil.Hide();

                //MessageBox.Show("Selecciona el Item para Eliminar", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return;
            }
            else
            {

                var lsv = lsv_COM.SelectedItems[0];

                txt_id.Text = lsv.SubItems[0].Text;

                Frm_sino sino = new Frm_sino();

                sino.lbl_msm1.Text = "¿Estas Seguro que deseas Elimnar el Producto?";
                sino.ShowDialog();

                if (sino.Tag.ToString() == "Si")
                {
                    RN_Productos obj = new RN_Productos();
                    obj.RN_Eliminar_Productos(txt_id.Text.ToString());
                    Cargar_Todas_Compras();

                    fil.Show();
                    ver2.Lbl_msm1.Text = "El Cliente se ha Eliminado Exitosamente";
                    ver2.ShowDialog();
                    fil.Hide();
                }


            }
        }

        private void elimnarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_delete_Click(sender, e);
        }

        private void cargarComprasDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil=new Frm_Filtro();
            Frm_SoloFecha solo=new Frm_SoloFecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString()=="A")
            {
                DateTime xfecha = solo.dtp_fecha.Value;
                Buscar_Compras_Dia(xfecha);
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
            Frm_DetalleCompra edi = new Frm_DetalleCompra();

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

        private void Frm_Explor_Compras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
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
                    ws.Cells[1, 1] = "Nro Documento";
                    ws.Cells[1, 2] = "Tipo Doc";                    
                    ws.Cells[1, 3] = "Fecha";
                    ws.Cells[1, 4] = "Proveedor";
                    
                    int i = 2;
                    foreach (ListViewItem item in lsv_COM.Items)
                    {
                        ws.Cells[i, 1] = item.SubItems[1].Text;
                        ws.Cells[i, 2] = item.SubItems[6].Text;
                        ws.Cells[i, 3] = item.SubItems[3].Text;
                        ws.Cells[i, 4] = item.SubItems[2].Text;                        
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
