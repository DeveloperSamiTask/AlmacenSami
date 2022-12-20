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
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;
using Microsell_Lite.Creditos;
using Prj_Capa_Datos;

namespace Microsell_Lite.Credito
{
    public partial class Frm_Explor_Credito : Form
    {
        public Frm_Explor_Credito()
        {
            InitializeComponent();
        }

        private void Frm_Explor_Proveedor_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Configurar_listView_det ();
            Cargar_Todos_Creditos  ();
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

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //configurar nuestro listview:

        private void Configurar_listView()
        {
            var lis = lsv_prodcto;

            lsv_prodcto.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("Id Credito", 100, HorizontalAlignment.Left); //0 
            lis.Columns.Add("Nro Doc.", 100, HorizontalAlignment.Left); //0 
            lis.Columns.Add("Nombre del Cliente", 330, HorizontalAlignment.Left);  //2
            lis.Columns.Add("Fecha credito", 180, HorizontalAlignment.Left);  //3
            lis.Columns.Add("Total S/", 100, HorizontalAlignment.Right);  //4
            lis.Columns.Add("Saldo S/", 100, HorizontalAlignment.Right);  //1
            lis.Columns.Add("Fecha Vence", 90, HorizontalAlignment.Left);  //1
            lis.Columns.Add("Estado", 110, HorizontalAlignment.Left);  //1          
           

        }



        private void Configurar_listView_det()
        {
            var lis = lsv_cre;

            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("Fecha Pago", 100, HorizontalAlignment.Left); //0 
            lis.Columns.Add("Acuenta", 80, HorizontalAlignment.Left); //0           
            lis.Columns.Add("Saldo", 80, HorizontalAlignment.Left);  //1          


        }


        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
        }


       


        private void Llenar_Listview_DetCred(DataTable data)
        {
            //lsv_cre.Items.Clear();           
            //double TotalCoti = 0;
            //double saldocred = 0;
            //for (int i = 0; i < data.Rows.Count; i++)
            //{
            //    DataRow dr = data.Rows[i];
                
            //    ListViewItem list = new ListViewItem(dr["Fecha_Pago"].ToString().Trim());
            //    TotalCoti = Convert.ToDouble(dr["A_cuenta"]);
            //    list.SubItems.Add(TotalCoti.ToString("###0.00"));  //acuenta
            //    saldocred = Convert.ToDouble(dr["Saldo_Actual"]);
            //    list.SubItems.Add(saldocred.ToString("###0.00"));                             

            //    lsv_cre.Items.Add(list); //si no podemos esto., el listview nunca se llenara
            //}
           
        }




        private void Cargar_Todos_Creditos()
        {
            //RN_Credito  obj = new RN_Credito ();
            //DataTable dato = new DataTable();

            //dato = obj.RN_Listar_Todas_Creditos ();
            //if (dato.Rows.Count >0)
            //{
            //    Llenar_Listview(dato);
            //}
            //else
            //{
            //    lsv_prodcto.Items.Clear();
            //    pnl_msm.Visible = true;
            //}

        }



        private void buscar_creditos_porvalor(string valor)
        {
            //RN_Credito obj = new RN_Credito ();
            //DataTable dato = new DataTable();

            //dato = obj.RN_Listar_creditos_porValor  (valor);
            //if (dato.Rows.Count > 0)
            //{
            //    Llenar_Listview(dato);
            //}
            //else
            //{
            //    lsv_prodcto.Items.Clear();
            //    pnl_msm.Visible = true;
            //}

        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {

           

        }

        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_prodcto.SelectedIndices .Count ==0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona le Item que deseas copiar";
                ver.ShowDialog();
                fil.Hide();
             }
            else
            {
                var lis = lsv_prodcto.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());


            }


        }

       

       

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Creditos ();
        }

      
        private void copiarNroDocumentoTool_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_prodcto.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_Msm1.Text = "Selecciona le Item que deseas copiar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_prodcto.SelectedItems[0];
                string idprovee = lis.SubItems[1].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());


            }
        }

        private void abonarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Advertencia ver = new Frm_Advertencia();

            //if (lsv_prodcto.SelectedIndices.Count == 0)
            //{
            //    fil.Show();
            //    ver.Lbl_Msm1.Text = "Selecciona le Item que deseas copiar";
            //    ver.ShowDialog();
            //    fil.Hide();
            //}
            //else
            //{
            //    var lis = lsv_prodcto.SelectedItems[0];
            //    string idcredito = lis.SubItems[0].Text;

            //    Frm_abonarCred abo = new Frm_abonarCred();

            //    fil.Show();
            //    abo.Tag = idcredito;
            //    abo.ShowDialog();
            //    fil.Hide();
                

            //}

        }

        private void lsv_prodcto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Advertencia ver = new Frm_Advertencia();

            //RN_Credito obj = new RN_Credito();
            //DataTable datos = new DataTable();
            //if (lsv_prodcto.SelectedIndices.Count == 0)
            //{
            //    fil.Show();
            //    ver.Lbl_Msm1.Text = "Selecciona le Item para ver su Detalle";
            //    ver.ShowDialog();
            //    fil.Hide();
            //}
            //else
            //{
            //    var lis = lsv_prodcto.SelectedItems[0];
            //    string idcredito = lis.SubItems[0].Text;

            //    datos = obj.RN_VerDetalle_deCredito(idcredito);
            //    if (datos.Rows.Count > 0)
            //    {
            //        Llenar_Listview_DetCred(datos);
            //        pnl_Det.Visible = true;
            //    }
            //    else
            //    {
            //        pnl_Det.Visible = false;
            //    }
               
            //}
        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Advertencia ver = new Frm_Advertencia();
            //Frm_Sinodelete sino = new Frm_Sinodelete();
            //Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            //RN_Credito obj = new RN_Credito();
            //DataTable datos = new DataTable();
            //if (lsv_prodcto.SelectedIndices.Count == 0)
            //{
            //    fil.Show();
            //    ver.Lbl_Msm1.Text = "Selecciona le Item que deseas Eliminar";
            //    ver.ShowDialog();
            //    fil.Hide();
            //}
            //else
            //{
            //    var lis = lsv_prodcto.SelectedItems[0];
            //    string idcredito = lis.SubItems[0].Text;

            //    fil.Show();
            //    sino.Lbl_msm1.Text = "Estas Seguro de Eliminar de forma Permanente este Crédito??";
            //    sino.ShowDialog();
            //    fil.Hide();

            //    if (sino.Tag.ToString().Trim()=="Si")
            //    {
            //        obj.RN_Eliminar_Credito_Permanente(idcredito);
            //        if (BD_Credito.borrado == true )
            //        {
            //            buscar_creditos_porvalor (idcredito);
            //        }
            //    }

               
                

            //}


        }

        private void lsv_prodcto_MouseClick(object sender, MouseEventArgs e)
        {
            //if (lsv_prodcto.SelectedIndices.Count == 0)
            //{
              
            //}
            //else
            //{
            //    var lis = lsv_prodcto.SelectedItems[0];
            //    string idcredito = lis.SubItems[0].Text;
            //    pnl_Det.Visible = false;
            //    lsv_cre.Items.Clear();
            //}
        }
    }
}
