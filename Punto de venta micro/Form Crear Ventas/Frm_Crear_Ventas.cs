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
    public partial class Frm_Crear_Ventas : Form
    {
        public Frm_Crear_Ventas()
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
            lis.Columns.Add("ID producto", 80, HorizontalAlignment.Left); //0
            lis.Columns.Add("Descripcion producto", 400, HorizontalAlignment.Left);  //1
            lis.Columns.Add("cantidad", 80, HorizontalAlignment.Left);  //2
            lis.Columns.Add("precio Unit", 90, HorizontalAlignment.Right);  //3
            lis.Columns.Add("Importe", 90, HorizontalAlignment.Right );  //4
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

      
        private void btn_Nuevo_buscarProd_Click(object sender, EventArgs e)
        {

            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProd_Compra xpro = new Frm_ListadoProd_Compra();

            fil.Show();
            Frm_ListadoProd_Compra.TipoVenta = "coti";
            xpro.Chk_cotiza.Checked = true;
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
                   _idprod = xpro.lbl_IdProd.Text;
                    _nomprod = xpro.lbl_NomProd.Text;
                   _cant = Convert.ToDouble(xpro.lbl_Cant.Text);
                   _precio = Convert.ToDouble(xpro.Lbl_PrecioUnit.Text);
                     _importe = Convert.ToDouble(xpro.Lbl_PrecioUnit.Text);
                     _und = xpro.lbl_Und_Mda.Text;
                    _tipoProd = xpro.Lbl_TipoProd.Text;
                     _Utili_Unit = Convert.ToDouble(xpro.Lbl_Utilidad_Unit.Text);

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
            Frm_ListadoProd_Compra xpro = new Frm_ListadoProd_Compra();

            fil.Show();
            Frm_ListadoProd_Compra.TipoVenta = "coti";
            xpro.Chk_cotiza.Checked = true;
            xpro.ShowDialog();

            fil.Hide();

            if (xpro.Tag.ToString() == "A")
            {
                string _idprod = xpro.lbl_IdProd.Text;
                string _nomprod = xpro.lbl_NomProd.Text;
                double _cant = Convert.ToDouble(xpro.lbl_Cant.Text);
                double _precio = Convert.ToDouble(xpro.Lbl_PrecioUnit.Text);
                double _importe = Convert.ToDouble(xpro.Lbl_PrecioUnit.Text);
                string _und = xpro.lbl_Und_Mda.Text;
                string _tipoProd = xpro.Lbl_TipoProd.Text;
                Double _Utili_Unit = Convert.ToDouble(xpro.Lbl_Utilidad_Unit.Text);

                Agregar_Productos_alCarrito(_idprod, _nomprod, _cant, _precio, _importe, _und, _tipoProd, _Utili_Unit);


            }
        }

        private void bt_editPre_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solo_Precio solo = new Frm_Solo_Precio();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Editar su Precio", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double precio_Ingresado = 0;
                double Precio_Editado = 0;
                precio_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[3].Text);

                fil.Show();
                solo.txt_precio.Text = precio_Ingresado.ToString();
                solo.ShowDialog();
                fil.Hide();


                if (solo.Tag.ToString() == "A")
                {
                    Precio_Editado = Convert.ToDouble(solo.txt_precio.Text);
                    lsv_Det.SelectedItems[0].SubItems[3].Text = Precio_Editado.ToString("###0.00");
                    Calcular();
                }

            }


        }

        private void bt_editCant_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solo_Canti solo = new Frm_Solo_Canti();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Editar su Cantidad", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double cant_Ingresado = 0;
                double cant_Editado = 0;
                cant_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

                fil.Show();
                solo.txt_cant.Text = cant_Ingresado.ToString();
                solo.ShowDialog();
                fil.Hide();


                if (solo.Tag.ToString() == "A")
                {
                    cant_Editado = Convert.ToDouble(solo.txt_cant.Text);
                    lsv_Det.SelectedItems[0].SubItems[2].Text = cant_Editado.ToString("###0.00");
                    Calcular();
                }

            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Sino sino = new Frm_Sino();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Quitar", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                fil.Show();
                sino.Lbl_msm1.Text = "Estas Seguro de Quitar este producto del Carrito?";
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
                          

        private void Guardar_Pedido()
        {
            RN_Pedido obj = new RN_Pedido();
            EN_Pedido ped = new EN_Pedido();
            EN_Det_Pedido det = new EN_Det_Pedido();

            try
            {
                txt_nroPed.Text = RN_TipoDoc.RN_NroID(10);

                ped.IdPedido = txt_nroPed.Text;
                ped.IdCliente = lbl_idcliente.Text;
                ped.SubTotal = Convert.ToDouble(lbl_subtotal.Text);
                ped.Igv = Convert.ToDouble(lbl_igv.Text);
                ped.TotalPed = Convert.ToDouble(lbl_TotalPagar.Text);
                ped.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);
                ped.TotalGancia = Convert.ToDouble(lbl_totalGanancia.Text);

                obj.RN_Registrar_Pedido(ped);              

                if (BD_Pedido.seguardo ==true )
                {
                    RN_TipoDoc.RN_Actualizar_SiguienteNro_Correlativo(10);
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
            Frm_Listadocliente lis = new Frm_Listadocliente();
            Frm_Filtro fil = new Frm_Filtro();

            fil.Show();
            Frm_Listadocliente.tipo = txt_cliente.Text;
            lis.ShowDialog();
            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                lbl_idcliente.Text = lis.lbl_id.Text;
                txt_cliente.Text = lis.lbl_nom.Text;
            }
        }



        private void Leer_Datos_DelCliente(string idprove)
        {
            RN_Proveedor obj = new RN_Proveedor();
            DataTable data = new DataTable();

            try
            {
                data = obj.RN_Buscar_Proveedores(idprove);
                if (data.Rows.Count > 0)
                {
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





    }
}
