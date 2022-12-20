using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Proveedores;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Prj_Capa_Datos;


namespace Microsell_Lite.Productos
{
    public partial class Frm_Reg_Prod : Form
    {
        public Frm_Reg_Prod()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            //GenerarCodigo();
            txtidproductos.Text = RN_TipoDoc.RN_NroId(4);
            double tipocambio = 0;            
            tipocambio = RN_TipoDoc.RN_Leer_TipoCambio(7);
            lbl_PrecioCambio.Text = tipocambio.ToString("###0.00");
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

        string xFotoruta="";
        private void lbl_abrircon_Click(object sender, EventArgs e)
        {
            var FilePath = String.Empty;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xFotoruta = openFileDialog1.FileName;
                    pic_producto.Load(xFotoruta);
                }
            }
            catch (Exception ex)
            {
                pic_producto.Load(Application.StartupPath + @"\user.png");
                xFotoruta = Application.StartupPath + @"\user.png";
                MessageBox.Show("Error al Guardar el Producto" + ex.Message);
            }
        }

        private bool Validar_Textbox()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (txt_codpro.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa o Genera el Codigo del Producto"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_nomprodu.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Nombre del Producto"; ver.ShowDialog(); fil.Hide(); txt_nomprodu.Focus(); return false; }
            if (txt_descripcion.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la Descripcion del Producto"; ver.ShowDialog(); fil.Hide(); txt_descripcion.Focus(); return false; }
            if (txt_Provee.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Nombre del Proveedor"; ver.ShowDialog(); fil.Hide(); txt_Provee.Focus(); return false; }
            if (txt_marca.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la Marca del Producto"; ver.ShowDialog(); fil.Hide(); txt_marca.Focus(); return false; }
            if (txt_categ.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la Categoria del Producto"; ver.ShowDialog(); fil.Hide(); txt_categ.Focus(); return false; }
            if (cbo_TipoProduc.SelectedIndex == -1) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Tipo del Producto"; ver.ShowDialog(); fil.Hide(); cbo_TipoProduc.Focus(); return false; }
            if (cbo_UndMedida.SelectedIndex == -1) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la Unidad de Medida del Producto"; ver.ShowDialog(); fil.Hide(); cbo_UndMedida.Focus(); return false; }

            //validar los numeros

            if (txt_precioComp.Text.Trim() == "") { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Precio de Compra en Soles"; ver.ShowDialog(); fil.Hide(); txt_precioComp.Focus(); return false; }
            if (Convert.ToDouble(txt_precioComp.Text) == 0) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Precio de Compra en Soles"; ver.ShowDialog(); fil.Hide(); txt_precioComp.Focus(); return false; }

            if (txt_frankuni.Text.Trim() == "") { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Frank del Producto"; ver.ShowDialog(); fil.Hide(); txt_frankuni.Focus(); return false; }
            if (Convert.ToDouble(txt_frankuni.Text) == 0) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Frank del Producto"; ver.ShowDialog(); fil.Hide(); txt_frankuni.Focus(); return false; }

            if (txt_pvm.Text.Trim() == "") { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Precio de Venta por Menor"; ver.ShowDialog(); fil.Hide(); txt_pvm.Focus(); return false; }
            if (Convert.ToDouble(txt_pvm.Text) == 0) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Precio de Venta por Menor"; ver.ShowDialog(); fil.Hide(); txt_pvm.Focus(); return false; }

            if (txt_pvma.Text.Trim() == "") { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Precio de Venta por Mayor"; ver.ShowDialog(); fil.Hide(); txt_pvma.Focus(); return false; }
            if (Convert.ToDouble(txt_pvma.Text) == 0) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Precio de Venta por Mayor"; ver.ShowDialog(); fil.Hide(); txt_pvma.Focus(); return false; }

            if (txt_pvd.Text.Trim() == "") { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Precio de Venta en Dolares"; ver.ShowDialog(); fil.Hide(); txt_pvd.Focus(); return false; }
            //if (Convert.ToDouble(txt_precioComp.Text) == 0) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Precio de Compra en Soles"; ver.ShowDialog(); fil.Hide(); txt_precioComp.Focus(); return false; }

            if (txt_dolar.Text.Trim() == "") { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Precio de Compra en Dolares"; ver.ShowDialog(); fil.Hide(); txt_dolar.Focus(); return false; }
            //if (Convert.ToDouble(txt_dolar.Text) == 0) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Precio de Compra en Dolares"; ver.ShowDialog(); fil.Hide(); txt_dolar.Focus(); return false; }

            return true;
        }

        private void limpiarForm()
        {
            txt_codpro.Text = "";
            txt_nomprodu.Text = "";
            txt_descripcion.Text = "";
            txt_Provee.Text = "";
            txt_marca.Text = "";
            txt_categ.Text = "";
            cbo_UndMedida.Text = "Seleccionar:";
            cbo_UndMedida.Text = "Seleccionar:";
            txt_precioComp.Text = "";
            txt_frankuni.Text = "";
            txt_pvm.Text = "";
            txt_pvma.Text = "";
            txt_pvd.Text = "";
            txt_dolar.Text = "";
            xFotoruta = "";
        }

        private void txt_precioComp_TextChanged(object sender, EventArgs e)
        {
            
            
        }

      

        private void label14_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Categoria lis = new Frm_Categoria();

            fil.Show();
            lis.ShowDialog();

            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                txt_categ.Text = lis.txt_nom.Text;
                lbl_cat.Text = lis.txt_id.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        
        private void lbl_BuscarMarca_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Marcas lis = new Frm_Marcas();

            fil.Show();
            lis.ShowDialog();

            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                txt_marca.Text = lis.txt_nom.Text;
                lbl_mar.Text = lis.txt_id.Text;
            }
        }

        private void lbl_BuscarCategoria_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Categoria lis = new Frm_Categoria();

            fil.Show();
            lis.ShowDialog();

            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                txt_categ.Text = lis.txt_nom.Text;
                lbl_cat.Text = lis.txt_id.Text;
            }
        }

        private void lbl_buscarProve_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_ListadoProveedor lis = new Frm_ListadoProveedor();

            fil.Show();
            lis.ShowDialog();

            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                txt_Provee.Text = lis.lbl_nompr.Text;
                lbl_idprove.Text = lis.lbl_idp.Text;
            }
        }

        private void txt_precioComp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_precioComp_TextChanged_1(object sender, EventArgs e)
        {
            txt_precioComp.Text = txt_precioComp.Text.Replace(",",".") ;
            txt_precioComp.SelectionStart= txt_precioComp.Text.Length  ;
        }

        private void txt_frankuni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_frankuni_TextChanged(object sender, EventArgs e)
        {
            
            txt_frankuni.Text = txt_frankuni.Text.Replace(",", ".");
            txt_frankuni.SelectionStart = txt_frankuni.Text.Length;
            
            try
            {
                if (txt_frankuni.Text.Trim() == "") return;
                if (txt_precioComp.Text.Trim() == "") return;

                double precio_compra = 0;
                double utilidad_unitaria = 0;

                precio_compra = Convert.ToDouble(txt_precioComp.Text) * Convert.ToDouble(txt_frankuni.Text);
                txt_pvm.Text = precio_compra.ToString("###0.00");

                //calcular la utilidad:
                utilidad_unitaria = Convert.ToDouble(txt_pvm.Text) - Convert.ToDouble(txt_precioComp.Text);
                txt_utilidd.Text = utilidad_unitaria.ToString("###0.00");
            }
            catch (Exception ex)
            {
                string sms = ex.Message;
            }
        }

        private void txt_pvm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_pvm_TextChanged(object sender, EventArgs e)
        {
            txt_pvm.Text = txt_pvm.Text.Replace(",", ".");
            txt_pvm.SelectionStart = txt_pvm.Text.Length;
        }

        private void txt_pvma_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_pvma_TextChanged(object sender, EventArgs e)
        {
            txt_pvma.Text = txt_pvma.Text.Replace(",", ".");
            txt_pvma.SelectionStart = txt_pvma.Text.Length;
        }

        private void txt_pvd_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_pvd_TextChanged(object sender, EventArgs e)
        {
            txt_pvd.Text = txt_pvd.Text.Replace(",", ".");
            txt_pvd.SelectionStart = txt_pvd.Text.Length;
        }

        private void txt_dolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_dolar_TextChanged(object sender, EventArgs e)
        {
            txt_dolar.Text = txt_dolar.Text.Replace(",", ".");
            txt_dolar.SelectionStart = txt_dolar.Text.Length;

            //calcular el precio de venta en soles
            try
            {
                if (txt_frankuni.Text.Trim() == "") return;
                if (txt_dolar.Text.Trim() == "") return;

                double precio_compraSol = 0;
                double precio_ventaDlr = 0;
                double utilidad_unitaria = 0;

                //hallar el precio de compra en dolares
                precio_compraSol = Convert.ToDouble(txt_dolar.Text) * Convert.ToDouble(lbl_PrecioCambio.Text);
                txt_precioComp.Text = precio_compraSol.ToString("###0.00");

                //hallar el precio de venta soles
                precio_compraSol = Convert.ToDouble(txt_precioComp.Text) * Convert.ToDouble(txt_frankuni.Text);
                txt_pvm.Text = precio_compraSol.ToString("###0.00");

                //hallar el precio venta en dolares
                precio_ventaDlr = Convert.ToDouble(txt_dolar.Text) * Convert.ToDouble(txt_frankuni.Text);
                txt_pvd.Text = precio_ventaDlr.ToString("###0.00");


                //calcular la utilidad:
                utilidad_unitaria = Convert.ToDouble(txt_pvm.Text) - Convert.ToDouble(txt_precioComp.Text);
                txt_utilidd.Text = utilidad_unitaria.ToString("###0.00");
            }
            catch (Exception ex)
            {
                string sms = ex.Message;
            }
        }

        private void cbo_dolar2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbo_dolar2.Checked == true)
            {
                txt_dolar.Enabled = true;
                txt_dolar.Text = "";
                txt_dolar.Focus();
            }
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (Validar_Textbox()==true)
            {
                registrar_Producto(); 
            }
        }

        private void registrar_Producto()
        {
            RN_Productos obj=new RN_Productos();
            EN_Productos pro=new EN_Productos();

            try
            {
                txtidproductos.Text = RN_TipoDoc.RN_NroId(4);

                pro.Idpro= txtidproductos.Text.Trim();
                pro.Idprove = lbl_idprove.Text.Trim();
                pro.Codigo = txt_codpro.Text.Trim();
                pro.Modelo=txt_nomprodu.Text;
                pro.Descripcion=txt_descripcion.Text;
                pro.Frank=Convert.ToDouble(txt_frankuni.Text);
                pro.PreCompra_Sol = Convert.ToDouble(txt_precioComp.Text);
                pro.PreCompra_Dlr = Convert.ToDouble(txt_dolar.Text);
                pro.Stock = 0;
                pro.Idcat = Convert.ToInt32(lbl_cat.Text);
                pro.Idmark = Convert.ToInt32(lbl_mar.Text);
                if (xFotoruta.Trim().Length < 5)
                {
                    pro.Foto = "-";

                }
                else
                {
                    pro.Foto = xFotoruta;
                }
                
                pro.PreVenta_Mnr = Convert.ToDouble(txt_pvm.Text);
                pro.PreVenta_Myr= Convert.ToDouble(txt_pvma.Text);
                pro.PreVenta_Dolr = Convert.ToDouble(txt_pvd.Text);
                pro.UndMedida = cbo_UndMedida.Text;
                pro.PesoUnit = Convert.ToDouble(txt_peso.Text);
                pro.UtilidadUnit = Convert.ToDouble(txt_utilidd.Text);
                pro.TipoProduct = cbo_TipoProduc.Text;
                pro.ValorGeneral = 0;

                obj.RN_Registrar_Productos(pro);

                
                if (BD_Productos.seguardo==true)
                {
                    
                    if (cbo_TipoProduc.SelectedIndex == 0)
                    {
                        //PARA REGISTRAR EL KARDEX
                        Registrar_Kardex(txtidproductos.Text);
                    }
                    RN_TipoDoc.RN_Actualizar_Tipo_Doc(4);
                    //GenerarCodigo();

                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ver = new Frm_Msm_Bueno();
                    fil.Show();
                    ver.Lbl_msm1.Text = "Producto se ha Creado y Guardado Correctamente";
                    ver.ShowDialog();
                    fil.Hide();

                    this.Tag = "A";
                    this.Close();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Guardar el Producto", ex.Message);
            }
        }

        private void Registrar_Kardex(string idprod)
        {
            RN_Kardex obj=new RN_Kardex();
            EN_Kardex kr = new EN_Kardex();
            try
            {
                if (obj.RN_Verificar_Producto_siTieneKardex(idprod) == true)
                {
                    return;//ya tiene kardex no hace falta de crear otro
                }
                else
                {
                    string idkardex = RN_TipoDoc.RN_NroId(6);
                    obj.RN_Registrar_Kardex(idkardex, idprod, lbl_idprove.Text);

                    if (BD_Kardex.seguardo==true)
                    {
                        //actualizar el siguiente numero correlativo

                        RN_TipoDoc.RN_Actualizar_Tipo_Doc(6);

                        //ahora trabajamos con el detalle de kardex;
                        kr.Idkardex = idkardex;
                        kr.Item = 1;
                        kr.Doc_soporte = "000";
                        kr.Det_operacion = "Inicio de Kardex";

                        //entradas

                        kr.Cantidad_in = 0;
                        kr.Precio_in = 0;
                        kr.Total_in = 0;

                        //salidas

                        kr.Cantidad_out = 0;
                        kr.Precio_out = 0;
                        kr.Total_out = 0;

                        //saldos
                        kr.Cantidad_saldo = 0;
                        kr.Promedio = 0;
                        kr.Total_saldo = 0;

                        obj.RN_Registrar_Detalle_Kardex(kr);

                        if (BD_Kardex.detsave ==true)
                        {
                            //actualizar el kardez
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar el Producto"+ ex.Message,"Advertencia de Seguridad",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        //private void GenerarCodigo()
        //{
        //    RN_Productos obj = new RN_Productos();
        //    txtidproductos.Text = "PROD-" + obj.GenerarCodigo("Productos");
        //}

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void txtcodbarras_CheckedChanged(object sender, EventArgs e)
        {
            if (txtcodbarras.Checked==true)
            {
                txt_codpro.Text = "";
                txt_codpro.Focus();
            }
            else
            {
                txt_codpro.Text = "";
            }

        }

        private void cbo_TipoProduc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_TipoProduc.SelectedIndex ==0)
            {
                cbo_UndMedida.SelectedIndex = 0;
                txt_peso.Enabled = true;
            }
            else
            {
                txt_peso.Enabled = false;
                cbo_UndMedida.SelectedIndex = 0;
            }
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            txtidproductos.Text = RN_TipoDoc.RN_NroId(4);
            double tipocambio = 0;
            tipocambio = RN_TipoDoc.RN_Leer_TipoCambio(7);
            lbl_PrecioCambio.Text = tipocambio.ToString("###0.00");
        }

        private void gru_det_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Reg_Prod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
