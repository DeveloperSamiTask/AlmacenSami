using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using System.IO;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;

namespace Microsell_Lite.Compras
{
    public partial class Frm_Compras : Form
    {
        public Frm_Compras()
        {
            InitializeComponent();
        }

        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {
            //GenerarCodigo();
            Configurar_listview();
            LLlenar_Combo_Proveedores();
            
        }

        private void Configurar_listview()
        {
            var lis = lsv_Det;

            lsv_Det.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:            
            lis.Columns.Add("ID Producto", 140, HorizontalAlignment.Center);//0
            //lis.Columns.Add("Codigo", 0, HorizontalAlignment.Center);//0  
            lis.Columns.Add("Descripcion", 542, HorizontalAlignment.Center);//2
            lis.Columns.Add("Cantidad", 80, HorizontalAlignment.Center);//5
            lis.Columns.Add("Precio Unit", 0, HorizontalAlignment.Right);//3
            lis.Columns.Add("Importe", 0, HorizontalAlignment.Right);//4           


        }

        private void LLlenar_Combo_Proveedores()
        {
            RN_Proveedor obj = new RN_Proveedor();
            DataTable dato = new DataTable();

            dato = obj.RN_Cargar_Todas_Proveedores();

            if (dato.Rows.Count > 0)
            {
                var cbo = cbo_provee;

                cbo.DataSource = dato;
                cbo.DisplayMember = "NOMBRE";
                cbo.ValueMember = "IDPROVEE";
                cbo.SelectedIndex = -1;
            }
        }


        //private void Pintar_Filas()
        //{
        //    int cont = 1;
        //    for (int i = 0; i < lsv_Det.Items.Count; i++)
        //    {
        //        if (cont % 2 == 0)
        //        {

        //        }
        //        else
        //        {
        //            lsv_Det.Items[i].BackColor = Color.LightBlue;
        //        }
        //        cont += 1;
        //    }
        //}      

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {

            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }

        }

        private void pnl_sinProd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //public static string xxidproducto;
        //public static string xxnombreprod;
        //public static double xxcant;
        //public static double xxprecio;
        //public static double xximporte;


        private void calcular()
        {
            double xtotal = 0;
            double ximporte = 0;
            double xcant = 0;
            double xprecio = 0;
            double xigv = 0;
            double xsubtotal = 0;
            double xuti_unit = 0;
            double ximport_Uti = 0;

            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

                //suma del importe
                ximporte = xcant * xprecio;
                lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

                ////utilidad:
                //xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                //ximport_Uti = xuti_unit * xcant;
                //lsv_Det.Items[i].SubItems[8].Text = ximport_Uti.ToString("###0.00");

                //suma del total de la venta
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);
            }
            //calcular igv
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;

            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");
        }



        private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximporte)
        {
            try
            {

                if (lsv_Det.Items.Count == 0)
                {
                    ListViewItem item = new ListViewItem();
                    item = lsv_Det.Items.Add(xidprod);
                    item.SubItems.Add(xnomprod.Trim());
                    item.SubItems.Add(xcant.ToString());
                    item.SubItems.Add(xprecio.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));

                    calcular();
                    lsv_Det.Focus();
                    txt_IdComp.Text = RN_TipoDoc.RN_NroId(8);
                    lsv_Det.Items[0].Selected = true;
                    pnl_sinProd.Visible = false;
                }
                else
                {
                    //valir del que el producto no ingrese dos veces
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Advertencia ver = new Frm_Advertencia();
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        if (lsv_Det.Items[i].Text.Trim() == xidprod.Trim())
                        {
                            fil.Show();
                            ver.lbl_msm1.Text = "El Producto ya fue Agregado al Carrito de Compras";
                            ver.ShowDialog();
                            fil.Hide();

                            return;
                        }
                    }

                    ListViewItem item = new ListViewItem();
                    item = lsv_Det.Items.Add(xidprod);
                    item.SubItems.Add(xnomprod.Trim());
                    item.SubItems.Add(xcant.ToString());
                    item.SubItems.Add(xprecio.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));

                    calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede agregar al carrito en compras" + ex, "Advertencia en agregar al carrito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProductos_Compras pro = new Frm_ListadoProductos_Compras();

            fil.Show();
            pro.cbo_Coti.Checked = true;
            Frm_ListadoProductos_Compras.TipoVenta = "compra";
            pro.txt_buscar.Focus();
            pro.ShowDialog();
            fil.Hide();

            string _idprod;
            string _nomprod;
            double _cant = 0;
            double _precio = 0;
            double _importe = 0;
            string _und;
            string _tipoProd;
            Double _Utili_Unit;

            if (pro.Tag.ToString()=="A")
            {
               

                if (pro.lsv_Ped.Items.Count > 0)
                {
                    //para agregar del carrito
                    for (int i = 0; i < pro.lsv_Ped.Items.Count; i++)
                    {
                        var item = pro.lsv_Ped.Items[i];
                        _idprod = item.SubItems[0].Text;
                        _nomprod = item.SubItems[1].Text;
                        _cant = Convert.ToDouble(item.SubItems[3].Text);
                        _precio = Convert.ToDouble(item.SubItems[4].Text);
                        _importe = Convert.ToDouble(item.SubItems[5].Text);

                        Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe);

                    }
                }
                else
                {
                    //agregar productos de 1 en 1
                    _idprod = pro.lbl_IdProdu.Text;
                     _nomprod = pro.lbl_Nom_Prod.Text;
                    _cant = Convert.ToDouble(pro.lbl_cant.Text);
                  _precio = Convert.ToDouble(pro.lbl_pre_unit.Text);
                    _importe = Convert.ToDouble(pro.lbl_pre_unit.Text);

                    Agregar_Productos_alCarrito(_idprod.Trim(), _nomprod, _cant, _precio, _importe);
                    txt_IdComp.Text = RN_TipoDoc.RN_NroId(8);
                }
                



            }

        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProductos_Compras xpro = new Frm_ListadoProductos_Compras();

            fil.Show();
            xpro.txt_buscar.Focus();
            xpro.cbo_Coti.Checked = true;            
            Frm_ListadoProductos_Compras.TipoVenta = "compra";
            xpro.ShowDialog();
            fil.Hide();
           

            if (xpro.Tag.ToString() == "A")
            {
                string _idprod;
                string _nomprod;
                double _cant = 0;
                double _precio = 0;
                double _importe = 0;
                string _und;
                string _tipoProd;
                Double _Utili_Unit;

                if (xpro.lsv_Ped.Items.Count > 0)
                {
                    for (int i = 0; i < xpro.lsv_Ped.Items.Count; i++)
                    {
                        var item = xpro.lsv_Ped.Items[i];
                        _idprod = item.SubItems[0].Text;
                        _nomprod = item.SubItems[1].Text;
                        _cant = Convert.ToDouble(item.SubItems[3].Text);
                        _precio = Convert.ToDouble(item.SubItems[4].Text);
                        _importe = Convert.ToDouble(item.SubItems[5].Text);
                       

                        Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe);
                    }
                }
                else
                {
                    //para agregar de uno en Uno:
                    _idprod = xpro.lbl_IdProdu.Text;
                    _nomprod = xpro.lbl_Nom_Prod.Text;
                    _cant = Convert.ToDouble(xpro.lbl_cant.Text);
                    _precio = Convert.ToDouble(xpro.lbl_pre_unit.Text);
                    _importe = Convert.ToDouble(xpro.lbl_importe.Text);
                    

                    Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe);
                }

            }            
        }

        private void bt_editPre_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solo_Precio solo = new Frm_Solo_Precio();
            Frm_Advertencia ver = new Frm_Advertencia();
            if (lsv_Det.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Producto que deseas Editar el Precio";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                double precio_Ingresado = 0;
                double precio_editado = 0;
                precio_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[3].Text);

                fil.Show();
                solo.txt_precio.Text = precio_Ingresado.ToString();
                solo.ShowDialog();
                fil.Hide();

                if (solo.Tag.ToString() == "A")
                {
                    precio_editado = Convert.ToDouble(solo.txt_precio.Text);
                    lsv_Det.SelectedItems[0].SubItems[3].Text = precio_editado.ToString("###0.00");
                    calcular();
                }

            }
        }

        private void bt_editCant_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solo_Cantidad solo = new Frm_Solo_Cantidad();
            Frm_Advertencia ver = new Frm_Advertencia();
            if (lsv_Det.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Producto que deseas Editar la Cantidad";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                double cantidad_Ingresado = 0;
                double cantidad_editado = 0;
                cantidad_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

                fil.Show();
                solo.txt_cant.Text = cantidad_Ingresado.ToString();
                solo.ShowDialog();
                fil.Hide();

                if (solo.Tag.ToString() == "A")
                {
                    cantidad_editado = Convert.ToDouble(solo.txt_cant.Text);
                    lsv_Det.SelectedItems[0].SubItems[2].Text = cantidad_editado.ToString("");
                    calcular();
                }

            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_sino sino = new Frm_sino();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_Det.SelectedIndices.Count == 0)
            {

                fil.Show();
                ver.lbl_msm1.Text = "Seleccion el Producto que deseas Quitar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                fil.Show();
                sino.lbl_msm1.Text = "Estas Seguro de Quitar este Producto del Carrito";
                sino.ShowDialog();
                fil.Hide();

                if (sino.Tag.ToString()=="Si")
                {
                    int i;
                    var lis = lsv_Det.SelectedItems[0];

                    for (i = lsv_Det.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        lsv_Det.Items.Remove(lsv_Det.SelectedItems[i]);

                    }
                    calcular();
                }
                             

            }
        }

        private void Frm_Compras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                if (pnl_sinProd.Visible == true)
                {
                    btn_Nuevo_buscarProd_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.F4)
            {
                if (pnl_sinProd.Visible == false)
                {
                    bt_add_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                if (pnl_sinProd.Visible == false)
                {
                    btn_procesar_Click(sender, e);
                }
            }

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.A))
            {
                if (pnl_sinProd.Visible == false)
                {
                    cbo_provee.Focus();
                }                
            }

        }

        private bool validar_Compras()
        {
            Frm_Filtro fil=new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_Det.Items.Count ==0){fil.Show();ver.lbl_msm1.Text = "Ingresa al menos un Producto";ver.ShowDialog();fil.Hide();lsv_Det.Focus();return false;}
            if (cbo_provee.SelectedIndex ==-1) { fil.Show(); ver.lbl_msm1.Text = "Selecciona un Proveedor"; ver.ShowDialog(); fil.Hide(); cbo_provee.Focus(); return false; }
            if (txt_NroFisico.Text.Trim().Length <2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Numero de Factura Fisica"; ver.ShowDialog(); fil.Hide(); txt_NroFisico.Focus(); return false; }
            if (cbo_tipoPago.SelectedIndex == -1) { fil.Show(); ver.lbl_msm1.Text = "Selecciona el Tipo de Pago"; ver.ShowDialog(); fil.Hide(); cbo_tipoPago.Focus(); return false; }
            if (cbo_tipoDoc.SelectedIndex == -1) { fil.Show(); ver.lbl_msm1.Text = "Selecciona el Tipo de Documento"; ver.ShowDialog(); fil.Hide(); cbo_tipoDoc.Focus(); return false; }

            return true;

        }

        private double Buscar_Frank_Producto(string idprod)
        {
            RN_Productos obj=new RN_Productos();
            DataTable dato = new DataTable();

            double frank = 0;

            dato = obj.RN_Buscar_Productos(idprod);
            if (dato.Rows.Count >0)
            {
                //margen de utilidad:
               frank =Convert.ToDouble( dato.Rows[0]["Frank"]);
                return frank;

            }
            else
            {
                return 0;
            }
        }



        private void Registrar_Compra()
        {
            EN_IngresoCompras com = new EN_IngresoCompras();
            EN_Det_IngresoCompra det = new EN_Det_IngresoCompra();
            RN_Ingreso_Compra obj=new RN_Ingreso_Compra();
            RN_Productos pro = new RN_Productos();

            try
            {
                txt_IdComp.Text = RN_TipoDoc.RN_NroId(8);

                com.Idcompra = txt_IdComp.Text;
                com.NroDoc_fisico = txt_NroFisico.Text;
                com.Idproveedor = cbo_provee.SelectedValue.ToString();
                com.Subtotal = Convert.ToDouble(lbl_subtotal.Text);
                com.FechaIngreso = dtp_FechaCom.Value;
                com.Totalcompra= Convert.ToDouble(lbl_TotalPagar.Text);
                com.Idusu =Convert.ToInt32( Cls_Libreria.IdUsu);
                com.Modali_Pago = cbo_tipoPago.Text;
                com.TiempoEspera = 0;
                com.FechaVence = dtp_FechaVenc.Value;
                com.EstadoIngreso = "Activo";
                com.RecibiConforme = recibiConforme;
                com.Datos_Adicional = txt_obser.Text;
                com.TipoDoc_Compra = cbo_tipoDoc.Text;

                
                
                obj.RN_Ingresar_RegistroCompra(com);

                if (BD_Ingreso_Compra.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_Tipo_Doc(8);

                    //guardar el detalle
                    for (int i=0;i < lsv_Det.Items.Count; i++)
                    {
                        var item=lsv_Det.Items[i];
                        
                        det.Id_Ingreso = txt_IdComp.Text;
                        det.Idproducto = item.SubItems[0].Text;
                        det.Precio = Convert.ToDouble(item.SubItems[3].Text);
                        det.Cantidad =Convert.ToDouble( item.SubItems[2].Text);                        
                        det.Importe=Convert.ToDouble( item.SubItems[4].Text);

                        obj.RN_Detalle_RegistroCompra(det);
                        Registrar_MovimientoKardex(det.Idproducto.Trim(),det.Cantidad,det.Precio);

                        //ahora actualizamos el precio del producot:
                        double utilidad = 0;
                        double valorAlmacen = 0;
                        double PreCompra = det.Precio;
                        double PreVenta = 0;
                        double xfrank = 0;

                       xfrank= Buscar_Frank_Producto(det.Idproducto.Trim());

                        PreVenta = xfrank * PreCompra; //calculamos el valor de venta
                        utilidad = PreVenta - PreCompra;
                        valorAlmacen = det.Cantidad * PreCompra;

                        pro.RN_Actualizar_Precios_Compra_Productos(det.Idproducto.Trim(),PreCompra,PreVenta,utilidad,valorAlmacen);
                    }

                    //terminamos
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok=new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "Los Datos de la Compra se han Registrado Exitosamente";
                    ok.ShowDialog();
                    fil.Hide();

                    lsv_Det.Items.Clear();
                    cbo_provee.SelectedIndex = -1;
                    txt_NroFisico.Text = "";
                    cbo_tipoDoc.SelectedIndex = -1;
                    cbo_tipoPago.SelectedIndex = -1;



                    this.Tag = "A";
                    this.Close();
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Registrar_MovimientoKardex(string xidprod,double xcantidad, double xpreCompra)
        {
            RN_Kardex obj = new RN_Kardex();
            EN_Kardex kar = new EN_Kardex();
            RN_Productos objpro = new RN_Productos();
            DataTable dato = new DataTable();
            DataTable datoprod = new DataTable();

            string xidkarde = "";
            int xitem = 0;
            double stockProd = 0;
            double precioCompraprod = 0;

            try
            {
                if(obj.RN_Verificar_Producto_siTieneKardex(xidprod) == true)
                {
                    //si tiene kardex es valido:
                    dato =obj.RN_Buscar_KardexDetalle_porProducto(xidprod.Trim());
                    if (dato.Rows.Count>0)
                    {
                        xidkarde =Convert.ToString(dato.Rows[0]["Id_krdx"]);
                        xitem = dato.Rows.Count;

                        //leemos los datos del rpoducto

                        datoprod = objpro.RN_Buscar_Productos(xidprod.Trim());
                        stockProd =Convert.ToDouble(datoprod.Rows[0]["Stock_Actual"]);
                        precioCompraprod= Convert.ToDouble(datoprod.Rows[0]["Pre_CompraS"]);

                        //registrar el detalle del kardex:
                        kar.Idkardex = xidkarde;
                        kar.Item = xitem + 1;
                        kar.Doc_soporte = txt_NroFisico.Text;
                        kar.Det_operacion = "Compra de Mercaderia";
                        //entradas:
                        kar.Cantidad_in = xcantidad;
                        kar.Precio_in = xpreCompra;
                        kar.Total_in = xcantidad * xpreCompra;
                        //salidas
                        kar.Cantidad_out =   0;
                        kar.Precio_out = 0;
                        kar.Total_out = 0;
                        //saldos:
                        kar.Cantidad_saldo = stockProd + xcantidad;
                        kar.Promedio = xpreCompra;
                        kar.Total_saldo = xpreCompra * kar.Cantidad_saldo;

                        obj.RN_Registrar_Detalle_Kardex(kar);

                        //ahora actualizamos nuestro stock de la tabla productos:
                        objpro.RN_Sumar_Stock_Productos(xidprod.Trim(), xcantidad);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //private void GenerarCodigo()
        //{
        //    RN_Ingreso_Compra obj = new RN_Ingreso_Compra();
        //    txt_IdComp.Text = "CMP" + obj.GenerarCodigo("DocumentoCompras");
        //}
        private void btn_procesar_Click(object sender, EventArgs e)
        {
            if (validar_Compras() ==true)
            {
                Registrar_Compra();
            }
        }

        bool recibiConforme = false;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                recibiConforme = true;
            }
            else
            {
                recibiConforme = false;
            }
        }
    }
}
