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
            Configurar_listView_det();
            Cargar_Todos_Creditos();
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
            lis.Columns.Add("Id Credito", 110, HorizontalAlignment.Center); //0 
            lis.Columns.Add("Nro Doc.", 110, HorizontalAlignment.Center); //0 
            lis.Columns.Add("Nombre del Cliente", 300, HorizontalAlignment.Center);  //2
            lis.Columns.Add("Fecha credito", 110, HorizontalAlignment.Center);  //3
            lis.Columns.Add("Total S/", 100, HorizontalAlignment.Center);  //4
            lis.Columns.Add("Saldo S/", 100, HorizontalAlignment.Center);  //1
            lis.Columns.Add("Fecha Vence", 110, HorizontalAlignment.Center);  //1
            lis.Columns.Add("Estado", 110, HorizontalAlignment.Center);  //1          
           

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
            lis.Columns.Add("Fecha Pago", 181, HorizontalAlignment.Left); //0 
            lis.Columns.Add("Acuenta", 80, HorizontalAlignment.Left); //0           
            lis.Columns.Add("Saldo", 80, HorizontalAlignment.Left);  //1          


        }


        //llenar el listview:

        private void Llenar_Listview(DataTable data)
        {
            lsv_prodcto.Items.Clear();
            DateTime FechaCoti;
            double TotalCoti = 0;
            double SaldoCred = 0;

            for (int i=0; i<data.Rows.Count;i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["IdNotaCred"].ToString().Trim());
                list.SubItems.Add(dr["Id_Doc"].ToString().Trim());
                list.SubItems.Add(dr["Nom_Cliente"].ToString().Trim());
                list.SubItems.Add(dr["Fecha_Credito"].ToString());
                TotalCoti = Convert.ToDouble(dr["Total_Cre"]);
                list.SubItems.Add(TotalCoti.ToString("###0.00"));
                //saldo
                SaldoCred = Convert.ToDouble(dr["Saldo_Pdnte"]);
                list.SubItems.Add(SaldoCred.ToString("###0.00"));

                FechaCoti = Convert.ToDateTime(dr["Fecha_Vncimnto"]);
                list.SubItems.Add(FechaCoti.ToString("dd/MM/yyyy"));
                list.SubItems.Add(dr["Estado_Cred"].ToString());

                lsv_prodcto.Items.Add(list);
            }
            Pintar_Filas();
            pnl_msm.Visible = false;
            lbl_totallItem.Text = lsv_prodcto.Items.Count.ToString();
        }


        private void Pintar_Filas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_prodcto.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_prodcto.Items[i].BackColor = Color.LightBlue;
                }
                cont += 1;
            }
        }

        private void Pintar_Filas2()
        {
            int cont = 1;
            for (int i = 0; i < lsv_cre.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_cre.Items[i].BackColor = Color.LightBlue;
                }
                cont += 1;
            }
        }

        private void Llenar_Listview_DetCred(DataTable data)
        {
            lsv_cre.Items.Clear();
            double TotalCoti = 0;
            double saldocred = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];

                ListViewItem list = new ListViewItem(dr["Fecha_Pago"].ToString().Trim());
                TotalCoti = Convert.ToDouble(dr["A_cuenta"]);
                list.SubItems.Add(TotalCoti.ToString("###0.00"));  //acuenta
                saldocred = Convert.ToDouble(dr["Saldo_Actual"]);
                list.SubItems.Add(saldocred.ToString("###0.00"));

                lsv_cre.Items.Add(list); //si no podemos esto., el listview nunca se llenara
            }
            Pintar_Filas2();
        }




        private void Cargar_Todos_Creditos()
        {
            RN_Credito obj = new RN_Credito();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todos_Creditos();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_prodcto.Items.Clear();
                pnl_msm.Visible = true;
            }

        }



        private void buscar_creditos_porvalor(string valor)
        {
            RN_Credito obj = new RN_Credito();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Creditos_porValor(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_prodcto.Items.Clear();
                pnl_msm.Visible = true;
            }

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
                ver.lbl_msm1.Text = "Selecciona le Item que deseas copiar";
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
                ver.lbl_msm1.Text = "Selecciona le Item que deseas copiar";
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

        private void abonar_Credito()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_prodcto.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Selecciona le Item que deseas Abonar Credito";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_prodcto.SelectedItems[0];
                string idcredito = lis.SubItems[0].Text;

                Frm_abonarCred abo = new Frm_abonarCred();

                fil.Show();
                abo.Tag = idcredito;
                abo.ShowDialog();
                fil.Hide();


            }
        }

        private void abonarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            btn_Abonar_Click(sender,e) ;
        }
       
        private void Elimnar_Credito()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_sino sino = new Frm_sino();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            RN_Credito obj = new RN_Credito();
            DataTable datos = new DataTable();
            if (lsv_prodcto.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Selecciona le Item que deseas Eliminar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_prodcto.SelectedItems[0];
                string idcredito = lis.SubItems[0].Text;

                fil.Show();
                sino.lbl_msm1.Text = "Estas Seguro de Eliminar de forma Permanente este Crédito??";
                sino.ShowDialog();
                fil.Hide();

                if (sino.Tag.ToString().Trim() == "Si")
                {
                    obj.RN_Eliminar_Creditp(idcredito);
                    if (BD_Credito.borrado == true)
                    {
                        buscar_creditos_porvalor(idcredito);
                    }
                }




            }
        }


        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            btn_delete_Click(sender,e);


        }       

        private void lsv_prodcto_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            RN_Credito obj = new RN_Credito();
            DataTable datos = new DataTable();
            if (lsv_prodcto.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Selecciona le Item para ver su Detalle";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                var lis = lsv_prodcto.SelectedItems[0];
                string idcredito = lis.SubItems[0].Text;

                datos = obj.RN_VerDetalle_deCredito(idcredito);
                if (datos.Rows.Count > 0)
                {
                    Llenar_Listview_DetCred(datos);
                    pnl_Det.Visible = true;
                }
                else
                {
                    pnl_Det.Visible = false;
                }

            }
        }

        private void lsv_prodcto_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (lsv_prodcto.SelectedIndices.Count == 0)
            {

            }
            else
            {
                var lis = lsv_prodcto.SelectedItems[0];
                string idcredito = lis.SubItems[0].Text;
                pnl_Det.Visible = false;
                lsv_cre.Items.Clear();
            }
        }

        private void btn_cerrar_Click_1(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnl_titu_MouseMove_1(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void btn_Abonar_Click(object sender, EventArgs e)
        {
            abonar_Credito();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Elimnar_Credito();
        }

        private void Frm_Explor_Credito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
