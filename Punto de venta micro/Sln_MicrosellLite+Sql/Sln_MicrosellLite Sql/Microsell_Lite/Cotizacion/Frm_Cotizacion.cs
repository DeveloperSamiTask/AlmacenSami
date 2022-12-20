using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Compras;

//importar:
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using System.IO;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;
using Microsell_Lite.Cliente;
using Microsell_Lite.Informe;


namespace Microsell_Lite.Cotizacion
{
    public partial class Frm_Cotizacion : Form
    {
        public Frm_Cotizacion()
        {
            InitializeComponent();
        }

        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            

        }

        private void Configurar_listView()
        {
            var lis = lsv_Det;

            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID producto", 140, HorizontalAlignment.Center); //0
            lis.Columns.Add("Descripcion producto", 555, HorizontalAlignment.Center);  //1
            lis.Columns.Add("cantidad", 80, HorizontalAlignment.Center);  //2
            lis.Columns.Add("precio Unit", 0, HorizontalAlignment.Center);  //3
            lis.Columns.Add("Importe", 0, HorizontalAlignment.Center);  //4
            lis.Columns.Add("Tipo Producto", 0, HorizontalAlignment.Right);  //5
            lis.Columns.Add("Und", 0, HorizontalAlignment.Right);  //6
            lis.Columns.Add("Utilidad Unit", 0, HorizontalAlignment.Right);  //7
            lis.Columns.Add("Total Utilidad", 0, HorizontalAlignment.Right);  //8

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
            WindowState = FormWindowState.Minimized;
        }


       


        private bool Validar_Cotizacion()
        {
            Frm_Filtro fil = new Frm_Filtro();

            if (lsv_Det.Items.Count == 0) { fil.Show(); MessageBox.Show("INgresa Almenos un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); lsv_Det.Focus(); return false; }
            //if (cbo_provee.SelectedIndex ==-1) { fil.Show(); MessageBox.Show("INgresa Almenos un Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_provee.Focus(); return false; }
            //if (txt_NroFisico.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("INgresa el Nro de FActura Fisica", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_NroFisico.Focus(); return false; }
            //if (cbo_tipoPago.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoPago.Focus(); return false; }
            //if (cbo_tipoDoc .SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoDoc.Focus(); return false; }

            return true;
        }

        private void Frm_Cotizacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Escape )
            {
                this.Close();
            }

            if (e.KeyCode == Keys.F1)
            {
                if (pnl_sinProd.Visible == true)
                {
                    btn_Nuevo_buscarProd_Click(sender, e);
                }
            }
        }

        private void pnl_subtitu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil=new Frm_Filtro();
            Frm_ListadoProductos_Compras pro=new Frm_ListadoProductos_Compras();

            fil.Show();
            Frm_ListadoProductos_Compras.TipoVenta = "coti";
            pro.cbo_Coti.Checked = true;
            pro.ShowDialog();
            fil.Hide();

            if (pro.Tag.ToString()=="A")
            {
                string _idprod;
                string _nomprod;
                double _cant =0;
                double _precio=0;
                double _importe=0;
                string _und;
                string _tipoProd;
                double _utilidad=0;

                if (pro.lsv_Ped.Items.Count >0)
                {
                    for (int i = 0; i < pro.lsv_Ped.Items.Count; i++)
                    {
                        var item = pro.lsv_Ped.Items[i];
                        _idprod = item.SubItems[0].Text;
                        _nomprod = item.SubItems[1].Text;
                        _cant = Convert.ToDouble(item.SubItems[3].Text);
                        _precio = Convert.ToDouble(item.SubItems[4].Text);
                        _importe= Convert.ToDouble(item.SubItems[5].Text);
                        _und = item.SubItems[2].Text;
                        _tipoProd = item.SubItems[8].Text;
                        _utilidad= Convert.ToDouble(item.SubItems[6].Text);

                        Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _utilidad);

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
                     _und = pro.lbl_und.Text;
                     _tipoProd = pro.lbl_TipoProd.Text;
                     _utilidad = Convert.ToDouble(pro.lbl_Uti_Unit.Text);
                    Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _utilidad);
                }

                
            }
        }

        private void calcular()
        {
            double xtotal = 0;
            double ximporte = 0;
            double xcant = 0;
            double xprecio = 0;
            double xigv = 0;
            double xsubtotal = 0;
            double xuti_unit = 0;
            double ximport_uti = 0;
            double xtotalganancia = 0;

            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

                //suma del importe
                ximporte = xcant * xprecio;
                lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");


                //utilidad:
                xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                ximport_uti = xuti_unit * xcant;

                //suma del total de la venta
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);
                xtotalganancia = xtotalganancia + Convert.ToDouble(lsv_Det.Items[i].SubItems[8].Text);
            }
            //calcular igv
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;

            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");
            lbl_totalGanancia.Text=xtotalganancia.ToString("###0.00");

            lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);
            let.LetraCapital = chkCapital.Checked;
            if (!actualizado) ActualizarCong();
            

        }

        Numalet let = new Numalet();
        bool actualizado = false;

        private void ActualizarCong()
        {
            actualizado = true;
            chkCapital.Checked = let.LetraCapital;
            if (lbl_son.Text.Length > 0)
            {
                lbl_son.Text = let.ToCustomString(lbl_TotalPagar.Text);
                actualizado = false;
            }
        }



        //agregar varios productos al mismo tiempo

        private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximporte,string xund,string xtipoProd,double xutili_unit)
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
                    item.SubItems.Add(xtipoProd.ToString());
                    item.SubItems.Add(xund.ToString());
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));

                    calcular();
                    lsv_Det.Focus();
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
                    item.SubItems.Add(xtipoProd.ToString());
                    item.SubItems.Add(xund.ToString());
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));

                    calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProductos_Compras pro = new Frm_ListadoProductos_Compras();

            fil.Show();
            Frm_ListadoProductos_Compras.TipoVenta = "coti";
            pro.cbo_Coti.Checked = true;
            pro.ShowDialog();
            fil.Hide();

            if (pro.Tag.ToString() == "A")
            {
                string _idprod = pro.lbl_IdProdu.Text;
                string _nomprod = pro.lbl_Nom_Prod.Text;
                double _cant = Convert.ToDouble(pro.lbl_cant.Text);
                double _precio = Convert.ToDouble(pro.lbl_pre_unit.Text);
                double _importe = Convert.ToDouble(pro.lbl_pre_unit.Text);
                string _und = pro.lbl_und.Text;
                string _tipoProd = pro.lbl_TipoProd.Text;
                double _utilidad = Convert.ToDouble(pro.lbl_Uti_Unit.Text);

                Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _utilidad);
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

                if (sino.Tag.ToString() == "Si")
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





        private void btn_procesar_Click(object sender, EventArgs e)
        {
            if (lsv_Det.Items.Count == 0) { MessageBox.Show("Debes Agregar un Producto a tu Carrito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            if (lbl_idCliente.Text.Trim().Length < 4) { MessageBox.Show("Debes Agregar un Cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            Guardar_Cotizacion();
        }

        private void Guardar_Pedido()
        {
            RN_Pedido obj = new RN_Pedido();
            EN_Pedido ped=new EN_Pedido();
            EN_Detalle_Pedido det=new EN_Detalle_Pedido();

            try
            {
                txt_NroPedido.Text = RN_TipoDoc.RN_NroId(9);
                ped.IdPedido = txt_NroPedido.Text;
                ped.IdCliente = lbl_idCliente.Text;
                ped.SubTotal = Convert.ToDouble(lbl_subtotal.Text);
                ped.Igv=Convert.ToDouble(lbl_igv.Text);
                ped.TotalPed = Convert.ToDouble(lbl_TotalPagar.Text);
                ped.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                ped.TotalGanancia = Convert.ToDouble(lbl_totalGanancia.Text);

                obj.RN_Registrar_Pedido(ped);
                if (BD_Pedido.seguardo ==true)
                {
                    RN_TipoDoc.RN_Actualizar_Tipo_Doc(9);

                    //guardar el detalle del pedido
                    det.IdPed = txt_NroPedido.Text;
                    for (int i =0; i<lsv_Det.Items.Count; i++)
                    {
                        var lis = lsv_Det.Items[i];
                        det.IdProd= lis.SubItems[0].Text;
                        det.Precio = Convert.ToDouble(lis.SubItems[3].Text);
                        det.Cantidad= Convert.ToDouble(lis.SubItems[2].Text);
                        det.Importe= Convert.ToDouble(lis.SubItems[4].Text);
                        det.TipoProd=lis.SubItems[5].Text;
                        det.Und=lis.SubItems[6].Text;
                        det.Utilidad_Unit= Convert.ToDouble(lis.SubItems[7].Text);
                        det.TotalUtilidad= Convert.ToDouble(lis.SubItems[8].Text);

                        obj.RN_Registrar_Detalle_Pedido(det);
                    }


                }

            }catch (Exception ex)
            {
                string msm = ex.Message;
                MessageBox.Show("Error al Guardar:" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void Guardar_Cotizacion()
        {
            RN_Cotizacion obj = new RN_Cotizacion();
            EN_Cotizacion coti=new EN_Cotizacion();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Print_Cotizacion Print = new Frm_Print_Cotizacion();

            try
            {

                //primero guardo el pedido:
                Guardar_Pedido();
                if (BD_Pedido.seguardo ==true && BD_Pedido.detseguardo==true)
                {
                    txt_NroCotizacion.Text = RN_TipoDoc.RN_NroId(10);
                    coti.IdCotiza = txt_NroCotizacion.Text;
                    coti.IdPedido = txt_NroPedido.Text;
                    coti.FechaCoti = dtp_FechaEmi.Value;
                    coti.Vigencia = Convert.ToInt32(nud_vigencia.Value);
                    coti.TotalCoti = Convert.ToDouble(lbl_TotalPagar.Text);
                    coti.Condiciones = txt_condicion.Text;
                    if (chk_sinIgv.Checked == true)
                    {
                        coti.PrecioCon_igv = "No";
                    }
                    else
                    {
                        coti.PrecioCon_igv = "Si";
                    }
                    coti.EstadoCoti = "Pendiente";

                    obj.BD_Registrar_Cotizacion(coti);

                    if (BD_Cotizacion.seguardo == true)
                    {
                        RN_TipoDoc.RN_Actualizar_Tipo_Doc(10);

                        fil.Show();
                        ok.Lbl_msm1.Text = "La Cotizacion Nro:" + txt_NroCotizacion.Text + "Se Guardo con Exito";
                        ok.ShowDialog();
                        fil.Hide();

                        //mandar a imprmir:
                        fil.Show();
                        Print.Tag = txt_NroCotizacion.Text;
                        Print.ShowDialog();
                        fil.Hide();

                        pnl_sinProd.Visible = true;
                        lsv_Det.Items.Clear();
                        txt_cliente.Text = "";
                        txt_NroCotizacion.Text = "";
                        txt_NroPedido.Text = "";
                        lbl_idCliente.Text = "-";
                        txt_condicion.Text = "";
                        chk_sinIgv.Checked = false;
                        nud_vigencia.Value = 1;

                    }
                }

                

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Guardar:" + ex.Message,"Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void txt_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                lbl_BusCli_Click(sender, e);
            }
        }

        private void lbl_BusCli_Click(object sender, EventArgs e)
        {
            Frm_ListadoCliente lis = new Frm_ListadoCliente();
            Frm_Filtro fil = new Frm_Filtro();

            fil.Show();
            Frm_ListadoCliente.tipo = txt_cliente.Text;
            lis.ShowDialog();
            fil.Hide();

            if (lis.Tag.ToString()=="A")
            {
                lbl_idCliente.Text = lis.lbl_id.Text;
                txt_cliente.Text = lis.lbl_nom.Text;
            }
        }
    }
}
