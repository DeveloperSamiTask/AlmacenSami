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
//codigo qr
using Gma.QrCodeNet.Encoding;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using QRCoder;



//importar:
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using System.IO;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Productos;
using Microsell_Lite.Cliente;
using Microsell_Lite.Informe;
using Microsell_Lite.Ventas;


namespace Microsell_Lite.Ventas
{
    public partial class Frm_Crear_Ventas : Form
    {
        public Frm_Crear_Ventas()
        {
            InitializeComponent();
        }

        private void Frm_Ventana_Ventas_Load(object sender, EventArgs e)
        {
           
            Configurar_listView();
            LLlenar_Combo_Doc();
            CBO_TipoPago.SelectedIndex = 0;

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
            lis.Columns.Add("Nombre producto", 560, HorizontalAlignment.Center);  //1
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
            this.Tag = "";
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }                 

      
        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProductos_Compras xpro = new Frm_ListadoProductos_Compras();

            fil.Show();
            Frm_ListadoProductos_Compras.TipoVenta = "venta";
            xpro.cbo_Coti.Checked = false;
            xpro.ShowDialog();

            fil.Hide();

            if (xpro.Tag.ToString()=="A")
            {
                string _idprod ;
                string _nomprod ;
                double _cant =0;
                double _precio=0 ;
                double _importe=0 ;
                string _und ;
                string _tipoProd ;
                Double _Utili_Unit ;

                if (xpro.lsv_Ped.Items.Count >0)
                {
                    for (int i = 0; i < xpro.lsv_Ped.Items.Count; i++)
                    {
                        var item =xpro.lsv_Ped.Items[i];
                        _idprod = item.SubItems[0].Text;
                        _nomprod = item.SubItems[1].Text;
                        _cant =Convert.ToDouble(item.SubItems[3].Text);
                        _precio = Convert.ToDouble(item.SubItems[4].Text);
                        _importe= Convert.ToDouble(item.SubItems[5].Text);
                        _und = item.SubItems[2].Text;
                        _tipoProd = item.SubItems[8].Text;
                        _Utili_Unit = Convert.ToDouble(item.SubItems[6].Text );

                        Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit);
                    }
                }
                else
                {
                    //para agregar de uno en Uno:
                   _idprod = xpro.lbl_IdProdu.Text;
                    _nomprod = xpro.lbl_Nom_Prod.Text;
                   _cant = Convert.ToDouble(xpro.lbl_cant.Text);
                   _precio = Convert.ToDouble(xpro.lbl_pre_unit.Text);
                     _importe = Convert.ToDouble(xpro.lbl_pre_unit.Text);
                     _und = xpro.lbl_und.Text;
                    _tipoProd = xpro.lbl_TipoProd.Text;
                     _Utili_Unit = Convert.ToDouble(xpro.lbl_Uti_Unit.Text);

                    Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit);
                }              
                
            }

        }      




        private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximporte, string xund, string xtipoProd, double xutili_unit)
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
                    item.SubItems.Add(xutili_unit .ToString("###0.00"));
                    item.SubItems.Add(xutili_unit.ToString("###0.00"));

                    Calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                    pnl_sinProd.Visible = false;
                }
                else
                {
                    //validar de que el producvto no se ingrese dos veces
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        if (lsv_Det.Items[i].Text.Trim() == xidprod.Trim())
                        {
                            MessageBox.Show("El Producvto ya fue Agregado al Carrito de Compras", "ADveretencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    //lo añadimos:
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

                    Calcular();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

                      

        private void Calcular()
        {

            double xtotal = 0;
            double xcant = 0;
            double xprecio = 0;
            double ximporte = 0;
            double xsubtotal = 0;
            double xigv = 0;
            double xuti_unit = 0;
            double ximport_Uti = 0;
            double xTotalGanancia = 0;

          
            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xprecio = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

                //calculo:
                ximporte = xprecio * xcant;
                lsv_Det.Items[i].SubItems[4].Text = ximporte.ToString("###0.00");

                //utilidad:
                xuti_unit = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);
                ximport_Uti = xuti_unit * xcant;
                lsv_Det.Items[i].SubItems[8].Text = ximport_Uti.ToString("###0.00");

                //caluclo del total:
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);

               xTotalGanancia  = xTotalGanancia  + Convert.ToDouble(lsv_Det.Items[i].SubItems[8].Text);

            }
            //calcular el IGV: IVA
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;

            lbl_subtotal.Text = xsubtotal.ToString("###0.00");
            lbl_igv.Text = xigv.ToString("###0.00");
            lbl_TotalPagar.Text = xtotal.ToString("###0.00");
            lbl_totalGanancia.Text = xTotalGanancia.ToString("###0.00");

            lbl_son.Text = Numalet.ToString(lbl_TotalPagar.Text);
            let.LetraCapital = chkCapital.Checked;
            if (!actualizado) ActualizarCong();

                   


        }


        Numalet let = new Numalet();
        Boolean actualizado = false;

        private void ActualizarCong()
        {
            actualizado = true;
            chkCapital.Checked = let.LetraCapital;
            if (lbl_son.Text.Length >0)
            {
                lbl_son.Text = let.ToCustomString(lbl_TotalPagar.Text);
                actualizado = false;
            }
        }



        private void bt_add_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProductos_Compras xpro = new Frm_ListadoProductos_Compras();

            fil.Show();
            Frm_ListadoProductos_Compras.TipoVenta = "venta";
            xpro.cbo_Coti.Checked = false;
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
                        _und = item.SubItems[2].Text;
                        _tipoProd = item.SubItems[8].Text;
                        _Utili_Unit = Convert.ToDouble(item.SubItems[6].Text);

                        Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit);
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
                    _und = xpro.lbl_und.Text;
                    _tipoProd = xpro.lbl_TipoProd.Text;
                    _Utili_Unit = Convert.ToDouble(xpro.lbl_Uti_Unit.Text);

                    Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit);
                }

            }           
        }

        private void bt_editPre_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Edit_Precio2 solo = new Frm_Edit_Precio2();
            

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Editar su Precio", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double precio_Ingresado = 0;
                double cant_Ingresado = 0;
                double Precio_Editado = 0;
                double cant_Editado = 0;
                string xidprod = "";
                double xUti_Unit = 0;

                xidprod= lsv_Det.SelectedItems[0].SubItems[0].Text;
                precio_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[3].Text);
                cant_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

                fil.Show();
                solo.txt_precio.Text = precio_Ingresado.ToString("###0.00");
                solo.txt_cant.Text = cant_Ingresado.ToString();
                solo.idProducto = xidprod.Trim();
                solo.ShowDialog();
                fil.Hide();


                if (solo.Tag.ToString() == "A")
                {
                    Precio_Editado = Convert.ToDouble(solo.txt_precio.Text);
                    cant_Editado = Convert.ToDouble(solo.txt_cant.Text);
                    xUti_Unit = Convert.ToDouble(solo.Lbl_UtilidadUnit.Text);
                    lsv_Det.SelectedItems[0].SubItems[3].Text = Precio_Editado.ToString("###0.00");                    
                    lsv_Det.SelectedItems[0].SubItems[2].Text = cant_Editado.ToString();
                    lsv_Det.SelectedItems[0].SubItems[7].Text = xUti_Unit.ToString("###0.00");

                    Calcular();
                }

            }


        }

        
        private void bt_Delete_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_sino sino = new Frm_sino();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Quitar", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                fil.Show();
                sino.lbl_msm1.Text = "Estas Seguro de Quitar este producto del Carrito?";
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
                    Calcular();
                }

            }
        }

        private void Guardar_Pedido_Editado()
        {
            RN_Pedido obj = new RN_Pedido();
            EN_Pedido ped = new EN_Pedido();
            EN_Detalle_Pedido det = new EN_Detalle_Pedido();

            try
            {
                
                ped.IdPedido = txt_nroPed.Text;
                ped.IdCliente = lbl_idcliente.Text;
                ped.SubTotal = Convert.ToDouble(lbl_subtotal.Text);
                ped.Igv = Convert.ToDouble(lbl_igv.Text);
                ped.TotalPed = Convert.ToDouble(lbl_TotalPagar.Text);
                ped.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                ped.TotalGanancia = Convert.ToDouble(lbl_totalGanancia.Text);

                obj.RN_Editar_Pedido(ped);

                if (BD_Pedido.seguardo == true)
                {
                    obj.RN_Eliminar_Detalle_Pedido(txt_nroPed.Text);
                    //giuardar el detalle del pedido:

                    det.IdPed = txt_nroPed.Text;

                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        var lis = lsv_Det.Items[i];

                        det.IdProd = lis.SubItems[0].Text;
                        det.Precio = Convert.ToDouble(lis.SubItems[3].Text);
                        det.Cantidad = Convert.ToDouble(lis.SubItems[2].Text);
                        det.Importe = Convert.ToDouble(lis.SubItems[4].Text);
                        det.TipoProd = lis.SubItems[5].Text;
                        det.Und = lis.SubItems[6].Text;
                        det.Utilidad_Unit = Convert.ToDouble(lis.SubItems[7].Text);
                        det.TotalUtilidad = Convert.ToDouble(lis.SubItems[8].Text);

                        obj.RN_Registrar_Detalle_Pedido(det);
                    }
                }

            }
            catch (Exception ex)
            {
                string msm = ex.Message;
                MessageBox.Show("Error al Guardar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }


        private void Guardar_Pedido()
        {
            RN_Pedido obj = new RN_Pedido();
            EN_Pedido ped = new EN_Pedido();
            EN_Detalle_Pedido det = new EN_Detalle_Pedido();

            try
            {
                txt_nroPed.Text = RN_TipoDoc.RN_NroId(9);

                ped.IdPedido = txt_nroPed.Text;
                ped.IdCliente = lbl_idcliente.Text;
                ped.SubTotal = Convert.ToDouble(lbl_subtotal.Text);
                ped.Igv = Convert.ToDouble(lbl_igv.Text);
                ped.TotalPed = Convert.ToDouble(lbl_TotalPagar.Text);
                ped.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                ped.TotalGanancia = Convert.ToDouble(lbl_totalGanancia.Text);

                obj.RN_Registrar_Pedido(ped);              

                if (BD_Pedido.seguardo ==true )
                {
                    RN_TipoDoc.RN_Actualizar_Tipo_Doc(9);
                    //giuardar el detalle del pedido:

                    det.IdPed = txt_nroPed.Text;

                    for (int i =0; i < lsv_Det.Items.Count; i++)
                    {
                        var lis = lsv_Det.Items[i];

                        det.IdProd = lis.SubItems[0].Text;
                        det.Precio = Convert.ToDouble(lis.SubItems[3].Text);
                        det.Cantidad = Convert.ToDouble(lis.SubItems[2].Text);
                        det.Importe = Convert.ToDouble(lis.SubItems[4].Text);
                        det.TipoProd = lis.SubItems[5].Text;
                        det.Und = lis.SubItems[6].Text;
                       det.Utilidad_Unit = Convert.ToDouble(lis.SubItems[7].Text);
                        det.TotalUtilidad = Convert.ToDouble(lis.SubItems[8].Text);

                        obj.RN_Registrar_Detalle_Pedido(det);                        
                    }
                }

            }
            catch (Exception ex)
            {
                string msm = ex.Message;
                MessageBox.Show("Error al Guardar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

              

        private void txt_cliente_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode ==Keys.Enter)
            {
                lbl_BusClien_Click(sender, e);
            }


        }

       

        private void lbl_BusClien_Click(object sender, EventArgs e)
        {
            Frm_ListadoCliente lis = new Frm_ListadoCliente();
            Frm_Filtro fil = new Frm_Filtro();

            fil.Show();
            Frm_ListadoCliente.tipo = txt_cliente.Text;
            lis.ShowDialog();
            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                lbl_idcliente.Text = lis.lbl_id.Text;
                txt_cliente.Text = lis.lbl_nom.Text;
                Leer_Datos_DelCliente(lbl_idcliente.Text);
                
            }
        }



        private void Leer_Datos_DelCliente(string idprove)
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable data = new DataTable();
            double xlimit_Cred = 0;

            try
            {
                data = obj.RN_Buscar_Cliente(idprove,"Activo");
                if (data.Rows.Count > 0)
                {
                    lbl_Dni.Text= Convert.ToString(data.Rows[0]["DNI"]);
                    lbl_Direccion.Text= Convert.ToString(data.Rows[0]["Direccion"]);
                    xlimit_Cred= Convert.ToDouble(data.Rows[0]["Limit_Credit"]);
                    lbl_LimitCredit.Text = xlimit_Cred.ToString("###0.00");
                    //txt_idprove.Text = Convert.ToString(data.Rows[0]["IDPROVEE"]);
                    //txt_nom.Text = Convert.ToString(data.Rows[0]["NOMBRE"]);
                    //txt_direccion.Text = Convert.ToString(data.Rows[0]["DIRECCION"]);
                    //txt_correo.Text = Convert.ToString(data.Rows[0]["CORREO"]);
                    //txt_celular.Text = Convert.ToString(data.Rows[0]["TELEFONO"]);
                    //txt_contacto.Text = Convert.ToString(data.Rows[0]["CONTACTO"]);
                    //txt_rubro.Text = Convert.ToString(data.Rows[0]["RUBRO"]);
                    //txt_ruc.Text = Convert.ToString(data.Rows[0]["RUC"]);
                    //xFotoruta = Convert.ToString(data.Rows[0]["FOTO_LOGO"]);

                    //piclogo.Load(xFotoruta);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void LLlenar_Combo_Doc()
        {
            RN_TipoDoc obj = new RN_TipoDoc();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Doc_Especial ();

            if (dato.Rows.Count > 0)
            {
                var cbo = cbo_tipoDocumento;

                cbo.DataSource = dato;
                cbo.DisplayMember = "Documento";
                cbo.ValueMember = "Id_Tipo";
                cbo.SelectedIndex = 0;
            }
        }

        private bool Validar_Antes_Vender()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (lsv_Det.Items.Count==0){fil.Show();ver.lbl_msm1.Text = "Debes Agregar como Minimo un Producto al Carrito";ver.ShowDialog();fil.Hide();return false;}
            if (Convert.ToInt32(lbl_idcliente.Text.Length)<2) { fil.Show(); ver.lbl_msm1.Text = "Te Falta Agregar un Cliente"; ver.ShowDialog(); fil.Hide(); return false; }
            if (CBO_TipoPago.SelectedIndex == -1) { fil.Show(); ver.lbl_msm1.Text = "Por Favor Elige el Tipo de Pago "; ver.ShowDialog(); fil.Hide(); CBO_TipoPago.Focus(); return false; }
            if (cbo_tipoDocumento.SelectedIndex == -1) { fil.Show(); ver.lbl_msm1.Text = "Por Favor Elige el Tipo de Comprobante "; ver.ShowDialog(); fil.Hide(); cbo_tipoDocumento.Focus(); return false; }

            return true;
        }


        private void Guardar_Documento()
        {
            RN_Documento obj = new RN_Documento();
            EN_Documento doc = new EN_Documento();

            try
            {
                txt_NroDoc.Text = RN_TipoDoc.RN_NroId(Convert.ToInt32(cbo_tipoDocumento.SelectedValue));
                //los parametros:
                doc.IdDoc = txt_NroDoc.Text;
                doc.IdPedido = txt_nroPed.Text;
                doc.IdTipo = Convert.ToInt32(cbo_tipoDocumento.SelectedValue);
                doc.FechaDoc = dtp_FechaEmi.Value;
                doc.Importe = Convert.ToDouble(lbl_TotalPagar.Text);
                doc.TipoPago = CBO_TipoPago.Text;
                doc.Nr_Operacion = txt_NroOperacio.Text;
                doc.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                doc.Igv = Convert.ToDouble(lbl_igv.Text);
                doc.SonLetra = lbl_son.Text;
                doc.TotalGanancia = Convert.ToDouble(lbl_totalGanancia.Text);

                obj.RN_Registrar_Nuevo_Documento(doc);

                if (BD_Documento.seguardo==true)
                {
                    RN_TipoDoc.RN_Actualizar_Tipo_Doc(Convert.ToInt32(cbo_tipoDocumento.SelectedValue));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Guardar_Ingreso_CAJA()
        {
            RN_Caja obj = new RN_Caja();
            EN_Caja cja = new EN_Caja();

            try
            {
                cja.Fecha_Caja = dtp_FechaEmi.Value;
                cja.Tipo_Caja = "Entrada";
                cja.Concepto = "Por Venta al Publico";
                cja.DePara_Cliente = txt_cliente.Text;
                cja.Nr_Documento = txt_NroDoc.Text;
                cja.ImporteCaja = Convert.ToDouble(lbl_TotalPagar.Text);
                cja.Idusu = Convert.ToInt32(Cls_Libreria.IdUsu);
                cja.TotalUtilidad = Convert.ToDouble(lbl_totalGanancia.Text);
                cja.TipoPago = CBO_TipoPago.Text;
                cja.GeneradoPor = cbo_tipoDocumento.Text;

                obj.RN_Registrar_Mov_Caja(cja);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        private void Registrar_MovimientoKardex()
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

            string xidProd = "";
            double xcant = 0;
            string xTipoProdu = "";

            
            try
            {
                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    var lis = lsv_Det.Items[i];

                    xidProd = lis.SubItems[0].Text;
                    xcant = Convert.ToDouble(lis.SubItems[2].Text);
                    xTipoProdu = lis.SubItems[5].Text;

                    if (obj.RN_Verificar_Producto_siTieneKardex(xidProd) == true)
                    {
                        dato = obj.RN_Buscar_KardexDetalle_porProducto(xidProd.Trim());
                        if (dato.Rows.Count > 0)
                        {
                            xidkarde = Convert.ToString(dato.Rows[0]["Id_krdx"]);
                            xitem = dato.Rows.Count;

                            //leemos los datos del rpoducto

                            datoprod = objpro.RN_Buscar_Productos(xidProd.Trim());
                            stockProd = Convert.ToDouble(datoprod.Rows[0]["Stock_Actual"]);
                            precioCompraprod = Convert.ToDouble(datoprod.Rows[0]["Pre_CompraS"]);

                            //registrar el detalle del kardex:
                            kar.Idkardex = xidkarde;
                            kar.Item = xitem + 1;
                            kar.Doc_soporte = txt_NroDoc.Text;
                            kar.Det_operacion = "Ventas al Publico";
                            //entradas:
                            kar.Cantidad_in = 0;
                            kar.Precio_in = 0;
                            kar.Total_in = 0;
                            //salidas
                            kar.Cantidad_out = xcant;
                            kar.Precio_out = precioCompraprod;
                            kar.Total_out = xcant * precioCompraprod;
                            //saldos:
                            kar.Cantidad_saldo = stockProd - xcant;
                            kar.Promedio = precioCompraprod;
                            kar.Total_saldo = precioCompraprod * kar.Cantidad_saldo;

                            obj.RN_Registrar_Detalle_Kardex(kar);


                            //ahora actualizamos nuestro stock de la tabla productos:
                            objpro.RN_Restar_Stock_Productos(xidProd.Trim(), xcant);

                            
                        }
                        Prod_krd += 1;
                    }
                }              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registra Kardex Caja Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         }
        int Prod_krd = 0;
        private void btn_procesar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_TipoPago_Credito cred = new Frm_TipoPago_Credito();
            Frm_Print_NotaVenta nota = new Frm_Print_NotaVenta();
            RN_Cotizacion objcoti = new RN_Cotizacion();
            try
            {
                if (Validar_Antes_Vender() == true)
                {
                    if (CBO_TipoPago.SelectedIndex ==2)
                    {
                        fil.Show();
                        cred.LimpiarForm();
                        cred.lbl_TotalVenta.Text = lbl_TotalPagar.Text;
                        cred.ShowDialog();
                        fil.Hide();

                        if (cred.Tag.ToString() =="A")
                        {
                            lbl_Acuenta.Text = cred.txt_SaldoACuenta.Text;
                            lbl_SaldoCredito.Text = cred.lbl_saldoPagarCred.Text;
                            dtp_Vencimiento_Credito.Value = cred.dtp_FechaVen.Value;
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (chk_Coti.Checked==true)
                    {
                        Guardar_Pedido_Editado();
                    }
                    else
                    {
                        //llamar a guardar pedido
                        Guardar_Pedido();
                    }
                    
                    if (BD_Pedido.seguardo==true && BD_Pedido.detseguardo==true)
                    {
                        //ahora toca guardar el documento:
                        Guardar_Documento();
                        if (BD_Documento.seguardo == true)
                        {
                            if (CBO_TipoPago.SelectedIndex == 0 || CBO_TipoPago.SelectedIndex == 1)//si es efectivo o deposito
                            {
                                Guardar_Ingreso_CAJA();
                            }
                            else if (CBO_TipoPago.SelectedIndex == 2)//si es a credito
                            {
                                //crear un movimiento de caja a credito:
                                //crear un registro de credito del cliente:
                                Crear_Registro_deCredito();

                            }
                            else if (CBO_TipoPago.SelectedIndex == 3)//si es con vale
                            {
                                //para poder actualizar, verificar el vale:                           

                            }

                            if (BD_Caja.cajasaved == true)
                            {
                                //registramos el mov del kardex.
                                Registrar_MovimientoKardex();

                                if (BD_Kardex.detsave == true)
                                {
                                    //terminar la venta:
                                    fil.Show();
                                    ok.Lbl_msm1.Text = "La Venta se ha desarrollado Exitosamente y Se ha Creado el Mov de:"+" "+Prod_krd.ToString()+" "+"Productos en Kardex";
                                    ok.ShowDialog();
                                    fil.Hide();

                                    //cambiar el estado de la cotizacion
                                    if (txt_NroCotiza.Text.Trim().Length >5)
                                    {
                                        objcoti.BD_Cambiar_Estado_Cotizacion(txt_NroCotiza.Text,"Atendido");
                                    }

                                    //mara para imprimir;
                                    Registrar_Archivos_Temporales();

                                    fil.Show();
                                    nota.lbl_nroDoc.Text = "Nota de Venta: "+ txt_NroDoc.Text;
                                    nota.Tag = txt_NroDoc.Text;
                                    nota.ShowDialog();                                    
                                    fil.Hide();


                                    //limpiar todo;
                                    Limpiar_Todo();
                                    pnl_sinProd.Visible = true;
                                }                               
                            }
                        }
                    }                        
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        
        public void GenerarQr(string tipodoc,string totaldoc,string cliente,string nrdoc,string rutaQr)
        {
            QRCodeEncoder generarCodigo = new QRCodeEncoder();
            generarCodigo.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            generarCodigo.QRCodeScale = Int32.Parse("4");

            try
            {
                generarCodigo.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //la version 0 calcula automaticamente el tamaño
                generarCodigo.QRCodeVersion = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Generar QR1" + ex.Message, "Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

            //'----------------------------------------------------------
            string contenido;
            contenido = "Nro: " + nrdoc + "\r\n" + "Documento: " + tipodoc + "\r\n" + "Total: " + totaldoc + "\r\n" + "Cliente: " + cliente;
            System.Drawing.Bitmap imgQR;

            try
            {
                imgQR = new System.Drawing.Bitmap(generarCodigo.Encode(contenido, System.Text.Encoding.UTF8));
                pic_qr.Image = imgQR;
                imgQR.Save(rutaQr); /*para guardarlo en carpeta especifica*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Generar QR2" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        public static byte[] convertir_imagen_bytes(Image img)
        {
            string stemp = Path.GetTempFileName();
            FileStream fs = new FileStream(stemp,FileMode.OpenOrCreate,FileAccess.ReadWrite);
            img.Save(fs,System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;

            int imglenght = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imglenght];
            fs.Read(bytes,0,imglenght);
            fs.Close();
            return bytes;
        }

        private void crear_Carpeta()
        {
            string ruta = @"C:\CodigoQR-Ventas\";
            try
            {
                if (!Directory.Exists(ruta))
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ad = new Frm_Msm_Bueno();

                    fil.Show();
                    ad.Lbl_msm1.Text = "Creando Carpeta..."+ruta;
                    ad.ShowDialog();
                    fil.Hide();

                    Directory.CreateDirectory(ruta);
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Registrar_Archivos_Temporales() 
        {
            RN_Temporal obj = new RN_Temporal();
            EN_Temporal tem = new EN_Temporal();
            EN_Det_Temporal det = new EN_Det_Temporal();

            string dias= dtp_FechaEmi.Value.Day.ToString();
            string mes = dtp_FechaEmi.Value.Month.ToString();
            string año = dtp_FechaEmi.Value.Year.ToString();
            
            int totalEspacio = 0;
            int totalFila = lsv_Det.Items.Count;

            crear_Carpeta();
            string RutaQR = @"C:\\CodigoQR-Ventas\\" + txt_NroDoc.Text + ".BMP";
            GenerarQr(cbo_tipoDocumento.Text,lbl_TotalPagar.Text,txt_cliente.Text,txt_NroDoc.Text,RutaQR);

            try
            {
                tem.IdTemporal = txt_NroDoc.Text;
                tem.FechaEmi = dtp_FechaEmi.Value.ToString();
                tem.NomCliente = txt_cliente.Text;
                tem.Ruc = lbl_Dni.Text;
                tem.Direccion = lbl_Direccion.Text;
                tem.SubTotal = lbl_subtotal.Text;
                tem.Igv = lbl_igv.Text;
                tem.Total = lbl_TotalPagar.Text;
                tem.Sonletra = lbl_son.Text;
                tem.Vendedor = Cls_Libreria.Nombres;
                tem.CodigoQR = convertir_imagen_bytes(pic_qr.Image);

                obj.RN_Registrar_Temporal(tem);

                if (BD_Temporal.saved ==true)
                {                    
                    //guardar el detalle
                    for (int i=0; i < lsv_Det.Items.Count ; i++)
                    {
                        var lis = lsv_Det.Items[i];            
                        

                        det.IdTempo = txt_NroDoc.Text;
                        det.CodProd = lis.SubItems[0].Text;           
                        det.Canti = lis.SubItems[2].Text;
                        det.Producto = lis.SubItems[1].Text;
                        det.Precio = lis.SubItems[3].Text;
                        det.Importe = lis.SubItems[4].Text;
                        obj.RN_Registrar_DetTemporal(det);
                    }


                    int veces = 0;       
                    totalEspacio = 11 - totalFila;//8
                    if (totalEspacio < 11)
                    {
                        for (int x =1; x <= totalEspacio; x++)
                        {
                            det.IdTempo = txt_NroDoc.Text;
                            det.CodProd = "";
                            det.Canti = "";
                            det.Producto = "";
                            det.Precio = "";
                            det.Importe = "";

                            obj.RN_Registrar_DetTemporal(det);
                        }
                        veces += 1;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Crear_Registro_deCredito()
        {
            RN_Credito obj = new RN_Credito();
            EN_Credito cre = new EN_Credito();
            

            EN_Caja cja = new EN_Caja();
            RN_Caja objCaja = new RN_Caja();

            string idCredito = "";

            try
            {
                idCredito = RN_TipoDoc.RN_NroId(11);

                cre.IdCredito = idCredito;
                cre.IdDoc = txt_NroDoc.Text;
                cre.FechaCredito = dtp_FechaEmi.Value;
                cre.NomCliente = txt_cliente.Text;
                cre.TotalCredito = Convert.ToDouble(lbl_TotalPagar.Text);
                if (Convert.ToDouble(lbl_Acuenta.Text)==0)
                {
                    cre.Saldo_Pndte = Convert.ToDouble(lbl_TotalPagar.Text);
                }
                else if (Convert.ToDouble(lbl_Acuenta.Text) > 0)
                {
                    cre.Saldo_Pndte = Convert.ToDouble(lbl_SaldoCredito.Text);
                }
                cre.Fecha_Vencimiento = dtp_Vencimiento_Credito.Value;

                obj.RN_Registrar_Credito(cre);

                if (BD_Credito.Credsaved==true)
                {
                    RN_TipoDoc.RN_Actualizar_Tipo_Doc(11);

                    if (Convert.ToDouble(lbl_Acuenta.Text) > 0)
                    {
                        Reg_Detalle_Credito(idCredito);
                        //creamos un registro de movimiento de caja por el importe que dejo a cuenta:
                       
                            cja.Fecha_Caja = dtp_FechaEmi.Value;
                            cja.Tipo_Caja = "Entrada";
                            cja.Concepto = "Abono de Credito";
                            cja.DePara_Cliente = txt_cliente.Text;
                            cja.Nr_Documento = txt_NroDoc.Text;
                            cja.ImporteCaja = Convert.ToDouble(lbl_Acuenta.Text);
                            cja.Idusu = Convert.ToInt32(Cls_Libreria.IdUsu);
                            cja.TotalUtilidad = Convert.ToDouble(lbl_totalGanancia.Text);
                            cja.TipoPago = "Efectivo";
                            cja.GeneradoPor = "Abono";

                            objCaja.RN_Registrar_Mov_Caja(cja);

                        //otro moviemiento de caja
                        cja.Fecha_Caja = dtp_FechaEmi.Value;
                        cja.Tipo_Caja = "Entrada";
                        cja.Concepto = "Por Venta al Publico a Credito";
                        cja.DePara_Cliente = txt_cliente.Text;
                        cja.Nr_Documento = txt_NroDoc.Text;
                        cja.ImporteCaja = Convert.ToDouble(lbl_TotalPagar.Text);
                        cja.Idusu = Convert.ToInt32(Cls_Libreria.IdUsu);
                        cja.TotalUtilidad = 0;
                        cja.TipoPago = "Credito";
                        cja.GeneradoPor = cbo_tipoDocumento.Text;

                        objCaja.RN_Registrar_Mov_Caja(cja);

                    }
                    else
                    {
                        //otro moviemiento de caja
                        cja.Fecha_Caja = dtp_FechaEmi.Value;
                        cja.Tipo_Caja = "Entrada";
                        cja.Concepto = "Por Venta al Publico a Credito";
                        cja.DePara_Cliente = txt_cliente.Text;
                        cja.Nr_Documento = txt_NroDoc.Text;
                        cja.ImporteCaja = Convert.ToDouble(lbl_TotalPagar.Text);
                        cja.Idusu = Convert.ToInt32(Cls_Libreria.IdUsu);
                        cja.TotalUtilidad = 0;
                        cja.TipoPago = "Credito";
                        cja.GeneradoPor = cbo_tipoDocumento.Text;

                        objCaja.RN_Registrar_Mov_Caja(cja);
                    }


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Reg_Detalle_Credito(string idCredito)
        {
            EN_DetCredito det = new EN_DetCredito();
            RN_Credito obj = new RN_Credito();

            try
            {
                det.IdNotaCredito = idCredito;
                det.Acuenta = Convert.ToDouble(lbl_Acuenta.Text);
                det.SaldoActual = Convert.ToDouble(lbl_SaldoCredito.Text);
                det.FechaPago = dtp_FechaEmi.Value;
                det.TipoPago = "Efectivo";
                det.NroOpera = txt_NroOperacio.Text;
                det.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);

                obj.RN_Registrar_Detalle_Credito(det);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void Limpiar_Todo()
        {
            lsv_Det.Items.Clear();
            txt_cliente.Text = "";
            lbl_idcliente.Text = "-";
            lbl_totalGanancia.Text = "0";
            lbl_subtotal.Text = "0";
            lbl_igv.Text = "0";
            lbl_TotalPagar.Text = "0";
            lbl_LimitCredit.Text = "0";
            lbl_Dni.Text = "";
            CBO_TipoPago.SelectedIndex = -1;
            cbo_tipoDocumento.SelectedIndex = -1;
            lbl_SaldoVale.Text = "0";
            lbl_SaldoPend.Text = "0";
            lbl_Direccion.Text = "";
            txt_NroOperacio.Text = "";
            txt_NroCotiza.Text = "";
            txt_NroDoc.Text = "";
            txt_nroPed.Text = "";
        }

        private void Guardar_Cotizacion()
        {
            RN_Cotizacion obj = new RN_Cotizacion();
            EN_Cotizacion coti = new EN_Cotizacion();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Print_Cotizacion Print = new Frm_Print_Cotizacion();

            try
            {

                //primero guardo el pedido:
                Guardar_Pedido();
                if (BD_Pedido.seguardo == true && BD_Pedido.detseguardo == true)
                {
                    txt_NroCotiza.Text = RN_TipoDoc.RN_NroId(10);
                    coti.IdCotiza = txt_NroCotiza.Text;
                    coti.IdPedido = txt_nroPed.Text;
                    coti.FechaCoti = dtp_FechaEmi.Value;
                    coti.Vigencia = 15;
                    coti.TotalCoti = Convert.ToDouble(lbl_TotalPagar.Text);
                    coti.Condiciones = "Cotizacion Creada a partir de una Venta Pausada";
                    coti.PrecioCon_igv = "Si";
                    coti.EstadoCoti = "Pendiente";

                    obj.BD_Registrar_Cotizacion(coti);

                    if (BD_Cotizacion.seguardo == true)
                    {
                        RN_TipoDoc.RN_Actualizar_Tipo_Doc(10);

                        fil.Show();
                        ok.Lbl_msm1.Text = "se ha Creado una Cotizacion Nro:" + txt_NroCotiza.Text + "para el cliente,Mientras este Piensa";
                        ok.ShowDialog();
                        fil.Hide();

                        txtBuscar.Text = txt_NroCotiza.Text;

                        pnl_sinProd.Visible = true;
                        lsv_Det.Items.Clear();
                        txt_cliente.Text = "";
                        txt_NroCotiza.Text = "";
                        txt_nroPed.Text = "";
                        lbl_idcliente.Text = "-";
                        

                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar:" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_AtenderOtro_Click(object sender, EventArgs e)
        {
            Guardar_Cotizacion();
        }

        private void Frm_Crear_Ventas_KeyDown(object sender, KeyEventArgs e)
        {
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
        }

        private void lbl_lupa_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim().Length > 6)
            {
                if (chk_Coti.Checked == true)
                {
                    //va a cargar una cotizacion
                    buscar_Cotizacion_para_Atender(txtBuscar.Text);
                }
                else
                {
                    //va a cargar un documento para re imprimir
                    buscar_documento_reImprimir(txtBuscar.Text);

                }
            }
        }
        private void buscar_Cotizacion_para_Atender(string nrodoc)
        {
            //RN_Documento obj = new RN_Documento();
            RN_Cotizacion objcoti = new RN_Cotizacion();
            DataTable dato = new DataTable();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            string idprod;
            double xcant;

            try
            {
                dato = objcoti.BD_Buscar_Cotizacion_Editar(nrodoc.Trim());
                if (dato.Rows.Count > 0)
                {
                    var dt = dato.Rows[0];
                    
                    txt_nroPed.Text = Convert.ToString(dt["id_Ped"]);
                    txt_NroCotiza.Text= Convert.ToString(dt["Id_Cotiza"]);
                    //cbo_tipoDocumento.SelectedValue = Convert.ToInt32(dt["Id_Tipo"]);
                    dtp_FechaEmi.Value = Convert.ToDateTime(dt["FechaCoti"]);
                    //txt_NroOperacio.Text = Convert.ToString(dt["Nro_Operacion"]);
                    //CBO_TipoPago.Text = Convert.ToString(dt["TipoPago"]);
                    lbl_idcliente.Text = Convert.ToString(dt["Id_Cliente"]);
                    txt_cliente.Text = Convert.ToString(dt["Razon_Social_Nombres"]);
                    lbl_Direccion.Text = Convert.ToString(dt["Direccion"]);
                    lbl_Dni.Text = Convert.ToString(dt["DNI"]);
                    txt_estado_coti.Text = Convert.ToString(dt["EstadoCoti"]);

                    if (txt_estado_coti.Text.Trim() == "Atendido")
                    {
                        fil.Show();
                        ver.lbl_msm1.Text = "Esta Cotizacion ya fue Atendida,por favor , Cargue otra que este Pendiente";
                        ver.ShowDialog();
                        fil.Hide();
                        Limpiar_Todo();
                        pnl_sinProd.Visible = true;
                        txtBuscar.Text = "";
                        chk_Coti.Checked = false;
                        return;
                    }

                    //detalle del documento
                    lsv_Det.Items.Clear();
                    foreach (DataRow xitem in dato.Rows)
                    {
                        ListViewItem xlist;
                        idprod = xitem["Id_Pro"].ToString();
                        xcant =Convert.ToDouble( xitem["Cantidad"].ToString());
                        Buscar_Producto_Cotizacion(idprod.Trim());
                        if (xcant > Convert.ToDouble(lbl_stockprodx.Text)&& lbl_tipoprodx.Text.Trim().ToString()=="Producto")
                        {
                            if (Convert.ToDouble(lbl_stockprodx.Text) > 0 && Convert.ToDouble(lbl_stockprodx.Text) < xcant)
                            {
                                xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                                xlist.SubItems.Add(xitem["Modelo"].ToString());
                                xlist.SubItems.Add(xitem["Cantidad"].ToString());
                                xlist.SubItems.Add(xitem["Precio"].ToString());
                                xlist.SubItems.Add(xitem["Importe"].ToString());
                                xlist.SubItems.Add(xitem["Tipo_Prod"].ToString());
                                xlist.SubItems.Add(xitem["Und_Medida"].ToString());
                                xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                                xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());
                            }
                        }
                        else
                        {
                            xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                            xlist.SubItems.Add(xitem["Modelo"].ToString());
                            xlist.SubItems.Add(xitem["Cantidad"].ToString());
                            xlist.SubItems.Add(xitem["Precio"].ToString());
                            xlist.SubItems.Add(xitem["Importe"].ToString());
                            xlist.SubItems.Add(xitem["Tipo_Prod"].ToString());
                            xlist.SubItems.Add(xitem["Und_Medida"].ToString());
                            xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                            xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());
                        }

                        
                    }
                    Calcular();
                    pnl_sinProd.Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Leer: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void buscar_documento_reImprimir(string nrodoc)
        {
            RN_Documento obj = new RN_Documento();
            DataTable dato = new DataTable();

            try
            {
                dato = obj.RN_Buscar_Documento_yDetalle(nrodoc.Trim());
                if (dato.Rows.Count > 0)
                {
                    var dt = dato.Rows[0];

                    txt_NroDoc.Text = Convert.ToString(dt["id_Doc"]);
                    txt_nroPed.Text = Convert.ToString(dt["id_Ped"]);
                    cbo_tipoDocumento.SelectedValue = Convert.ToInt32(dt["Id_Tipo"]);
                    dtp_FechaEmi.Value = Convert.ToDateTime(dt["Fecha_Emi"]);
                    txt_NroOperacio.Text = Convert.ToString(dt["Nro_Operacion"]);
                    CBO_TipoPago.Text = Convert.ToString(dt["TipoPago"]);
                    lbl_idcliente.Text = Convert.ToString(dt["Id_Cliente"]);
                    txt_cliente.Text = Convert.ToString(dt["Razon_Social_Nombres"]);
                    lbl_Direccion.Text = Convert.ToString(dt["Direccion"]);
                    lbl_Dni.Text = Convert.ToString(dt["DNI"]);

                    //detalle del documento

                    foreach (DataRow xitem in dato.Rows)
                    {
                        ListViewItem xlist;
                        xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                        xlist.SubItems.Add(xitem["Modelo"].ToString());
                        xlist.SubItems.Add(xitem["Cantidad"].ToString());
                        xlist.SubItems.Add(xitem["Precio"].ToString());
                        xlist.SubItems.Add(xitem["Importe"].ToString());
                        xlist.SubItems.Add(xitem["Tipo_Prod"].ToString());
                        xlist.SubItems.Add(xitem["Und_Medida"].ToString());
                        xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                        xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());
                    }
                    Calcular();
                    pnl_sinProd.Visible = false;
                }

                else
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Advertencia ver = new Frm_Advertencia();

                    fil.Show();
                    ver.lbl_msm1.Text = "El documento que buscas no Existe, o Talvez sea una Cotizacion, Marque el Check";
                    ver.ShowDialog();
                    fil.Hide();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Leer: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Buscar_Producto_Cotizacion(String idprodu)
        {
            RN_Productos obj = new RN_Productos();
            DataTable data = new DataTable();

            try
            {
                data = obj.RN_Buscar_Productos(idprodu);

                if (data.Rows.Count > 0)
                {
                    lbl_stockprodx.Text= Convert.ToString(data.Rows[0]["Stock_Actual"]);
                    lbl_tipoprodx.Text= Convert.ToString(data.Rows[0]["TipoProdcto"]);               

                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Editar 2 Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Print_NotaVenta nota = new Frm_Print_NotaVenta();

            Registrar_Archivos_Temporales();
            fil.Show();
            nota.lbl_nroDoc.Text = "Nota Venta: " + txt_NroDoc.Text;
            nota.Tag = txt_NroDoc.Text;
            nota.ShowDialog();
            fil.Hide();

            Limpiar_Todo();
            pnl_sinProd.Visible = true;
            
        }

        private void CBO_TipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_TipoPago.Text=="Deposito")
            {
                txt_NroOperacio.ReadOnly = false;
                txt_NroOperacio.Text = "";
                txt_NroOperacio.Focus();
            }
            else
            {
                txt_NroOperacio.Text = "-";
                txt_NroOperacio.ReadOnly = true;
            }
        }
    }
}
