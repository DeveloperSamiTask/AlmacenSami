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
using Microsell_Lite.Compras;
using Microsell_Lite.Ventas;

namespace Microsell_Lite.Productos
{
    public partial class Frm_ListadoProductos_Compras : Form
    {
        public Frm_ListadoProductos_Compras()
        {
            InitializeComponent();
        }

        public static string TipoVenta = "";

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
            this.Tag = "";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Frm_Proveedor_Load(object sender, EventArgs e)
        {
            Configurar_listview();
            Configurar_listview_Pedido();

            if (TipoVenta.Trim() == "compra" || TipoVenta == "coti")
            {
                cbo_VerTodo.Checked = true;
            }
            else
            {
                cbo_VerTodo.Checked = false;
            }
            Cargar_Todos_Productos();
            txt_buscar.Focus();


        }


        private void Configurar_listview()
        {
            var lis = lsv_produ;

            lsv_produ.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:            
            lis.Columns.Add("ID Producto", 140, HorizontalAlignment.Center);//0            
            lis.Columns.Add("Modelo", 600, HorizontalAlignment.Center);//2
            lis.Columns.Add("MARCA", 140, HorizontalAlignment.Center);//5
            lis.Columns.Add("STOCK A", 100, HorizontalAlignment.Center);//3
            lis.Columns.Add("PRE COMPRA", 0, HorizontalAlignment.Center);//4            
            lis.Columns.Add("Venta Menor", 0, HorizontalAlignment.Center);//4                                                              
            lis.Columns.Add("Venta Mayor", 0, HorizontalAlignment.Center);//4
            lis.Columns.Add("Foto", 0, HorizontalAlignment.Center);//5
            lis.Columns.Add("und", 0, HorizontalAlignment.Center);//5
            lis.Columns.Add("utilidad unit", 0, HorizontalAlignment.Center);//5           
            lis.Columns.Add("ESTADO", 95, HorizontalAlignment.Center);//5
            lis.Columns.Add("TipoProd", 0, HorizontalAlignment.Center);//5
        }

        private void Configurar_listview_Pedido()
        {
            var lis = lsv_Ped;

            lsv_Ped.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:            
            lis.Columns.Add("ID Producto", 0, HorizontalAlignment.Center);//0            
            lis.Columns.Add("Nombre del Producto", 335, HorizontalAlignment.Center);//2
            lis.Columns.Add("Und", 0, HorizontalAlignment.Center);//5
            lis.Columns.Add("Cant", 50, HorizontalAlignment.Center);//3
            lis.Columns.Add("Precio", 0, HorizontalAlignment.Center);//4
            lis.Columns.Add("Importe", 100, HorizontalAlignment.Center);//4

            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Center);//4
            lis.Columns.Add("Ganancia Total", 0, HorizontalAlignment.Center);//5
            lis.Columns.Add("Tipo Porducto", 0, HorizontalAlignment.Center);//5


        }

        private void Agregar_Producto_alPedido(string xxidpro, string xxnombre, string xxund, double xxcant, double xxprecio, double xximporte, double xxutilidad_Unit, double xxgananciaTotal, string xxtipoProducto)
        {
            if (lsv_Ped.Items.Count == 0)
            {
                //nuestro listview esta vacio, añadiremos por primera vez
                ListViewItem item = new ListViewItem();
                item = lsv_Ped.Items.Add(xxidpro.Trim());
                item.SubItems.Add(xxnombre.Trim());
                item.SubItems.Add(xxund.Trim()) ;
                item.SubItems.Add(xxcant.ToString());
                item.SubItems.Add(xxprecio.ToString("###0.00"));
                item.SubItems.Add(xximporte.ToString("###0.00"));
                item.SubItems.Add(xxutilidad_Unit.ToString("###0.00"));
                item.SubItems.Add(xxgananciaTotal.ToString("###0.00"));
                item.SubItems.Add(xxtipoProducto.ToString());

                calcular();
            }
            else
            {
                Frm_Filtro fil = new Frm_Filtro();
                Frm_Advertencia ver = new Frm_Advertencia();
                for (int i = 0; i < lsv_Ped.Items.Count; i++)
                {
                    if (lsv_Ped.Items[i].Text.Trim() == xxidpro.Trim())
                    {
                        fil.Show();
                        ver.lbl_msm1.Text = "El Producto ya fue Agregado al Carrito de Compras";
                        ver.ShowDialog();
                        fil.Hide();

                        return;
                    }
                }
                //nuestro listview esta vacio, añadiremos por primera vez
                ListViewItem item = new ListViewItem();
                item = lsv_Ped.Items.Add(xxidpro);
                item.SubItems.Add(xxnombre.Trim());
                item.SubItems.Add(xxund.ToString());
                item.SubItems.Add(xxcant.ToString());
                item.SubItems.Add(xxprecio.ToString("###0.00"));
                item.SubItems.Add(xximporte.ToString("###0.00"));
                item.SubItems.Add(xxutilidad_Unit.ToString("###0.00"));
                item.SubItems.Add(xxgananciaTotal.ToString("###0.00"));
                item.SubItems.Add(xxtipoProducto.ToString());

                calcular();

            }
            Pintar_Filas2();
        }

        private void calcular()
        {
            double xtotal = 0;
            double ximporte = 0;
            double xycant = 0;
            double xprecio = 0;
            double xigv = 0;
            double xsubtotal = 0;

            for (int i = 0; i < lsv_Ped.Items.Count; i++)
            {
                xycant = Convert.ToDouble(lsv_Ped.Items[i].SubItems[3].Text);
                xprecio = Convert.ToDouble(lsv_Ped.Items[i].SubItems[4].Text);

                //suma del importe
                ximporte = xycant * xprecio;
                lsv_Ped.Items[i].SubItems[5].Text = ximporte.ToString("###0.00");

                //suma del total de la venta
                xtotal = xtotal + Convert.ToDouble(lsv_Ped.Items[i].SubItems[5].Text);
            }


            lbl_total.Text = xtotal.ToString("###0.00");
            lbl_TotalItem.Text = Convert.ToString(lsv_Ped.Items.Count);
            btn_Pedido.Text = Convert.ToString(lsv_Ped.Items.Count);
        }

        private void Llenar_Listview(DataTable data)
        {

            try
            {
                string idprod = "";
                double stockReal = 0;

                lsv_produ.Items.Clear();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    idprod = dr["Id_Pro"].ToString();
                    stockReal = Convert.ToDouble(dr["Stock_Actual"]);
                    if (cbo_VerTodo.Checked == true)
                    {
                        ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString().Trim());
                        //list.SubItems.Add(dr["Codigo"].ToString());
                        list.SubItems.Add(dr["Modelo"].ToString());
                        list.SubItems.Add(dr["Marca"].ToString());
                        list.SubItems.Add(dr["Stock_Actual"].ToString());
                        list.SubItems.Add(dr["Pre_CompraS"].ToString());
                        list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());
                        list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());
                        list.SubItems.Add(dr["Foto"].ToString());
                        list.SubItems.Add(dr["UndMedida"].ToString());
                        list.SubItems.Add(dr["UtilidadUnit"].ToString());
                        list.SubItems.Add(dr["Estado_Pro"].ToString());
                        list.SubItems.Add(dr["TipoProdcto"].ToString());


                        lsv_produ.Items.Add(list);//si no ponemos esto., el listview nunca se llenara

                        Pintar_Filas();
                        pnl_sms.Visible = false;
                        lbl_TotalItems.Text = Convert.ToString(lsv_produ.Items.Count);
                    }
                    else
                    {
                        //en caso de que no este marcado ...quiere decir que debo agregar producto solo los que esten con stock mayot a cero:
                        if (stockReal > 0)
                        {
                            ListViewItem list = new ListViewItem(dr["Id_Pro"].ToString().Trim());
                            //list.SubItems.Add(dr["Codigo"].ToString());
                            list.SubItems.Add(dr["Modelo"].ToString());
                            list.SubItems.Add(dr["Marca"].ToString());
                            list.SubItems.Add(dr["Stock_Actual"].ToString());
                            list.SubItems.Add(dr["Pre_CompraS"].ToString());
                            list.SubItems.Add(dr["Pre_vntaxMenor"].ToString());
                            list.SubItems.Add(dr["Pre_vntaxMayor"].ToString());
                            list.SubItems.Add(dr["Foto"].ToString());
                            list.SubItems.Add(dr["UndMedida"].ToString());
                            list.SubItems.Add(dr["UtilidadUnit"].ToString());
                            list.SubItems.Add(dr["Estado_Pro"].ToString());
                            list.SubItems.Add(dr["TipoProdcto"].ToString());


                            lsv_produ.Items.Add(list);//si no ponemos esto., el listview nunca se llenara

                            Pintar_Filas();
                            pnl_sms.Visible = false;
                            lbl_TotalItems.Text = Convert.ToString(lsv_produ.Items.Count);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string sms = ex.Message;
            }



        }

        private void Pintar_Filas()
        {
            //int cont = 1;
            //for (int i = 0; i < lsv_provee.Items.Count; i++)
            //{
            //    if (cont % 2 == 0)
            //    {

            //    }
            //    else
            //    {
            //        lsv_provee.Items[i].BackColor = Color.LightBlue;
            //    }
            //    cont += 1;
            //}

            //pintar columnas:

            for (int i = 0; i < lsv_produ.Items.Count; i++)
            {
                lsv_produ.Items[i].SubItems[3].BackColor = Color.Linen;
                lsv_produ.Items[i].SubItems[4].BackColor = Color.Beige;

                lsv_produ.Items[i].SubItems[5].BackColor = Color.MintCream;
                lsv_produ.Items[i].SubItems[6].BackColor = Color.AliceBlue;

                lsv_produ.Items[i].SubItems[3].Font = new System.Drawing.Font("Oxygen", 10, FontStyle.Bold);
                lsv_produ.Items[i].SubItems[5].Font = new System.Drawing.Font("Oxygen", 10, FontStyle.Bold);
                lsv_produ.Items[i].UseItemStyleForSubItems = false;
            }
        }

        private void Pintar_Filas2()
        {
            int cont = 1;
            for (int i = 0; i < lsv_Ped.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_Ped.Items[i].BackColor = Color.LightBlue;
                }
                cont += 1;
            }
        }


        private void Cargar_Todos_Productos()
        {
            RN_Productos obj = new RN_Productos();
            DataTable dato = new DataTable();

            dato = obj.RN_Cargar_Todas_Productos();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_produ.Items.Clear();
                pnl_sms.Visible = true;
            }
        }

        private void Buscar_Productos(string valor)
        {
            RN_Productos obj = new RN_Productos();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Productos(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);


            }
            else
            {
                lsv_produ.Items.Clear();
                pnl_sms.Visible = true;
            }
        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                Buscar_Productos(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    Buscar_Productos(txt_buscar.Text);

                    if (lsv_produ.Items.Count > 0)
                    {
                        lsv_produ.Focus();
                        lsv_produ.Items[0].Selected = true;
                    }
                }
                else
                {
                    Cargar_Todos_Productos();
                    if (lsv_produ.Items.Count > 0)
                    {
                        lsv_produ.Focus();
                        lsv_produ.Items[0].Selected = true;
                    }
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


        private void Seleccionar_Producto_ModoCotizacion()
        {

            //tambien servira para modo compra
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Add_Cantidad solo = new Frm_Add_Cantidad();

            if (lsv_produ.SelectedIndices.Count == 0)
            {
                fil.Show();
                MessageBox.Show("Por Favor, Selecciona una producto de la lista", "Seleccion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fil.Hide();
                return;
            }


            double stock = 0;
            string EstadoProd = "";
            double xxprecom = 0;
            double xxUtilidad_Unit = 0;

           

            var lis = lsv_produ.SelectedItems[0];

            //continuar:
            lbl_IdProdu.Text = lis.SubItems[0].Text;
            lbl_Nom_Prod.Text = lis.SubItems[1].Text;
            stock = Convert.ToDouble(lis.SubItems[3].Text);
            xxprecom = Convert.ToDouble(lis.SubItems[4].Text);
            lbl_pre_unit.Text = lis.SubItems[5].Text;//precio de venta por menor
            lbl_und.Text = lis.SubItems[8].Text;
            lbl_Uti_Unit.Text = lis.SubItems[9].Text;
            EstadoProd = lis.SubItems[10].Text;
            lbl_TipoProd.Text = lis.SubItems[11].Text;

            if (TipoVenta.Trim() == "compra")
            {
                lbl_pre_unit.Text = xxprecom.ToString("###0.00");
            }
            else
            {
                lbl_pre_unit.Text = lis.SubItems[5].Text;//precio de venta por menor
            }


            if (EstadoProd.Trim() == "Eliminado")
            {
                fil.Show();
                MessageBox.Show("El Producto esta Eliminado, y no Aptop para esta Transaccion, Elige otro por Favor", "Seleccion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fil.Hide();
                return;
            }           

            if (cbo_LlenarSinSalir.Checked == true)
            {
                fil.Show();
                solo.Lbl_stockActual.Text = stock.ToString();
                solo.lbl_NomProduct.Text = lbl_Nom_Prod.Text;
                solo.txt_cant.Text = "1";
                solo.ShowDialog();
                fil.Hide();


                if (solo.Tag.ToString() == "A")
                {
                    lbl_cant.Text = solo.txt_cant.Text;
                    solo.txt_cant.Text = "";

                    xxUtilidad_Unit = Convert.ToDouble(lbl_cant.Text) * Convert.ToDouble(xxprecom);
                    lbl_Uti_Unit.Text = xxUtilidad_Unit.ToString("###0.00");

                    double importxx = Convert.ToDouble(lbl_cant.Text) * Convert.ToDouble(lbl_pre_unit.Text);
                    lbl_importe.Text = importxx.ToString("###0.00");

                    Agregar_Producto_alPedido(lbl_IdProdu.Text, lbl_Nom_Prod.Text, lbl_und.Text, Convert.ToDouble(lbl_cant.Text), Convert.ToDouble(lbl_pre_unit.Text), Convert.ToDouble(lbl_importe.Text), Convert.ToDouble(lbl_Uti_Unit.Text), Convert.ToDouble(lbl_Uti_Unit.Text), lbl_TipoProd.Text);
                    LimpiarLabels();
                }
            }
            else
            {
                fil.Show();
                solo.Lbl_stockActual.Text = stock.ToString();
                solo.lbl_NomProduct.Text = lbl_Nom_Prod.Text;
                solo.txt_cant.Text = "1";
                solo.ShowDialog();
                fil.Hide();

                if (solo.Tag.ToString() == "A")
                {
                    lbl_cant.Text = solo.txt_cant.Text;
                    solo.txt_cant.Text = "";

                    xxUtilidad_Unit = Convert.ToDouble(lbl_cant.Text) * Convert.ToDouble(xxprecom);
                    lbl_Uti_Unit.Text = xxUtilidad_Unit.ToString("###0.00");

                    this.Tag = "A";
                    this.Close();
                }
            }
        }

        private void LimpiarLabels()
        {
            lbl_IdProdu.Text = "";
            lbl_cant.Text = "";
            lbl_importe.Text = "";
            lbl_Nom_Prod.Text = "";
            lbl_und.Text = "";
            lbl_Uti_Unit.Text = "";
            lbl_TipoProd.Text = "";
            lbl_pre_unit.Text = "";
        }


        //voy a reiniciar mi laptop. para desactivar la Telca FN .. no puedo usarlo asi
        //ahora regreso

        private void Seleccionar_Producto_paraVender()
        {
        
        //tu codigo no esta como del curso:

            Frm_Filtro fil = new Frm_Filtro();
            //Frm_Solo_Cantidad solo = new Frm_Solo_Cantidad();
            Frm_Add_Cantidad cant = new Frm_Add_Cantidad();

            if (lsv_produ.SelectedIndices.Count == 0)
            {
                fil.Show();
                MessageBox.Show("Por Favor, Selecciona una producto de la lista", "Seleccion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fil.Hide();
                return;
            }

            if (cbo_Coti.Checked == true)
            {
                Seleccionar_Producto_ModoCotizacion();
            }
            else
            {

                //para modo venta
                double stock = 0;
                string EstadoProd = "";
                double xxprecom = 0;
                double xxUtilidad_Unit = 0;



                var lis = lsv_produ.SelectedItems[0];

                

                //continuar:
                lbl_IdProdu.Text = lis.SubItems[0].Text;
                lbl_Nom_Prod.Text = lis.SubItems[1].Text;
                stock = Convert.ToDouble(lis.SubItems[3].Text);
                xxprecom = Convert.ToDouble(lis.SubItems[4].Text);
                lbl_pre_unit.Text = lis.SubItems[5].Text;//precio de venta por menor
                lbl_und.Text = lis.SubItems[8].Text;
                lbl_Uti_Unit.Text = lis.SubItems[9].Text;
                EstadoProd = lis.SubItems[10].Text;
                lbl_TipoProd.Text = lis.SubItems[11].Text;

                if (EstadoProd.Trim() == "Eliminado")
                {
                    fil.Show();
                    MessageBox.Show("El Producto esta Eliminado, y no Aptop para esta Transaccion, Elige otro por Favor", "Seleccion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    fil.Hide();
                    return;
                }

                if (lbl_TipoProd.Text.Trim().ToString() == "Producto")
                {
                    if (stock == 0)
                    {
                        fil.Show();
                        MessageBox.Show("El Producto no tiene Suficiente stock para la venta", "Seleccion de Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        fil.Hide();
                        return;

                    }
                }

                if (cbo_LlenarSinSalir.Checked == true)
                {
                    fil.Show();
                    cant.lbl_TipoProducto.Text = lbl_TipoProd.Text;
                    cant.Lbl_stockActual.Text = stock.ToString();
                    cant.lbl_NomProduct.Text = lbl_Nom_Prod.Text;
                    cant.txt_cant.Text = "1";
                    cant.ShowDialog();
                    fil.Hide();




                    if (cant.Tag.ToString() == "A")
                    {
                        lbl_cant.Text = cant.txt_cant.Text;
                        cant.txt_cant.Text = "";

                        //xxUtilidad_Unit = Convert.ToDouble(lbl_cant.Text) * Convert.ToDouble(xxprecom);
                        //lbl_Uti_Unit.Text = xxUtilidad_Unit.ToString("###0.00");

                        double importxx = Convert.ToDouble(lbl_cant.Text) * Convert.ToDouble(lbl_pre_unit.Text);
                        lbl_importe.Text = importxx.ToString("###0.00");

                        Agregar_Producto_alPedido(lbl_IdProdu.Text, lbl_Nom_Prod.Text, lbl_und.Text, Convert.ToDouble(lbl_cant.Text), Convert.ToDouble(lbl_pre_unit.Text), Convert.ToDouble(lbl_importe.Text), Convert.ToDouble(lbl_Uti_Unit.Text), Convert.ToDouble(lbl_Uti_Unit.Text), lbl_TipoProd.Text);
                        LimpiarLabels();
                    }
                }
                else
                {
                    fil.Show();
                    cant.lbl_TipoProducto.Text = lbl_TipoProd.Text;
                    cant.Lbl_stockActual.Text = stock.ToString();
                    cant.lbl_NomProduct.Text = lbl_Nom_Prod.Text;
                    cant.txt_cant.Text = "1";
                    cant.ShowDialog();
                    fil.Hide();

                    if (cant.Tag.ToString() == "A")
                    {
                        lbl_cant.Text = cant.txt_cant.Text;
                        cant.txt_cant.Text = "";

                        //xxUtilidad_Unit = Convert.ToDouble(lbl_cant.Text) * Convert.ToDouble(xxprecom);
                        //lbl_Uti_Unit.Text = xxUtilidad_Unit.ToString("###0.00");
                        double importxx = Convert.ToDouble(lbl_cant.Text) * Convert.ToDouble(lbl_pre_unit.Text);
                        lbl_importe.Text = importxx.ToString("###0.00");
                        this.Tag = "A";
                        this.Close();
                    }
                }

            }   //fin de modo venta        


        }
        
        


        private void lsv_provee_MouseDoubleClick(object sender, MouseEventArgs e)
        {
                btn_Add_Click(sender, e);
        }

        private void lsv_provee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add_Click(sender, e);
            }
        }

        private void Frm_ListadoProductos_Compras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape) 
            {
                this.Tag = "";
                this.Close();
            }
            if (e.KeyCode == Keys.F5)
            {
                btn_continuar_Click(sender, e);
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control)+Convert.ToInt32(Keys.A))
            {
                txt_buscar.Focus();
            }
        }

        private void cbo_VerTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbo_VerTodo.Checked==true)
            {
                Cargar_Todos_Productos();
            }
            else
            {
                Cargar_Todos_Productos();
            }
        }

        private void lsv_Ped_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //para quitar un producto de la lista:
            Frm_Filtro fil = new Frm_Filtro();
            Frm_sino sino = new Frm_sino();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_Ped.SelectedIndices.Count == 0)
            {

                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Producto que deseas Quitar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                
                    int i;
                    var lis = lsv_Ped.SelectedItems[0];

                    for (i = lsv_Ped.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        lsv_Ped.Items.Remove(lsv_Ped.SelectedItems[i]);

                    }
                    calcular();
                

            }
        }

        private void btn_Pedido_Click(object sender, EventArgs e)
        {
            if (pnl_Carrito.Visible==true)
            {
                pnl_Carrito.Visible = false;
            }
            else
            {
                pnl_Carrito.Visible = true;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Seleccionar_Producto_paraVender();
        }

        
        private void btn_continuar_Click(object sender, EventArgs e)
        {
            if (lsv_Ped.Items.Count > 0)
            {
                cbo_LlenarSinSalir.Checked = true;
                this.Tag = "A";
                this.Close();
            }
        }
    }
}
