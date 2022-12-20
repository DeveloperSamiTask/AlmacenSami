using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsell_Lite.Productos;
using Microsell_Lite.Ventas;
using Microsell_Lite.Cliente;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Proveedores;
using Microsell_Lite.Compras;
using Microsell_Lite.Cotizacion;
using Microsell_Lite.Caja;
using Microsell_Lite.Credito;
using Prj_Capa_Negocio;
using Prj_Capa_Entidad;
using System.IO;
using Microsell_Lite.BaseDatos;
using Microsell_Lite.CodigoBarra;
using System.Data.SqlClient;
using System.Collections;
using Microsell_Lite.Usuario;

namespace Microsell_Lite
{
    public partial class Frm_Principal : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source =192.168.100.13;Initial Catalog =ALMACEN; User ID=sa;Password=$axelis123");
        SqlCommand cmd;
        SqlDataReader dr;
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            GrafCategorias();
            Prod_Preferidos();
            DashboardDatos();

            lbl_usuario2.Text = Cls_Libreria.Nombres + "  " + Cls_Libreria.Apellidos;
            lbl_role.Text = Cls_Libreria.Rol;
            lblcorreo32.Text = Cls_Libreria.Usuario;
            //PicUser_2.Load(Cls_Libreria.Foto);
        }
        ArrayList Categoria = new ArrayList();
        ArrayList Cantidad = new ArrayList();
        ArrayList Producto = new ArrayList();
        ArrayList Cant = new ArrayList();
        private void GrafCategorias()
        {
            cmd = new SqlCommand("PRODxCategoria",conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Categoria.Add(dr.GetString(0));
                Cantidad.Add(dr.GetInt32(1));
            }
            chartProdCate.Series[0].Points.DataBindXY(Categoria,Cantidad);
            dr.Close();
            conexion.Close();
        }

        private void Prod_Preferidos()
        {
            cmd = new SqlCommand("ProdPreferidos", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Producto.Add(dr.GetString(0));
                Cant.Add(dr.GetInt32(1));
            }
            chartProdPref.Series[0].Points.DataBindXY(Producto, Cant);
            dr.Close();
            conexion.Close();
        }

        private void DashboardDatos()
        {
            cmd = new SqlCommand("DashBoard", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter total = new SqlParameter("@totventas", 0); total.Direction = ParameterDirection.Output;
            SqlParameter totalcomp = new SqlParameter("@totCompr", 0); totalcomp.Direction = ParameterDirection.Output;
            SqlParameter nprod = new SqlParameter("@nprod", 0); nprod.Direction = ParameterDirection.Output;
            SqlParameter nmarca = new SqlParameter("@nmarc", 0); nmarca.Direction = ParameterDirection.Output;
            SqlParameter ncategora = new SqlParameter("@ncateg", 0); ncategora.Direction = ParameterDirection.Output;
            SqlParameter ncliente = new SqlParameter("@nclient", 0); ncliente.Direction = ParameterDirection.Output;
            SqlParameter nproveedores = new SqlParameter("@nprove", 0); nproveedores.Direction = ParameterDirection.Output;
            SqlParameter nempleados = new SqlParameter("@nemple", 0); nempleados.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(total);
            cmd.Parameters.Add(totalcomp);
            cmd.Parameters.Add(nprod);
            cmd.Parameters.Add(nmarca);
            cmd.Parameters.Add(ncategora);
            cmd.Parameters.Add(ncliente);
            cmd.Parameters.Add(nproveedores);
            cmd.Parameters.Add(nempleados);
            conexion.Open();
            cmd.ExecuteNonQuery();
            lblTotalVentas.Text = cmd.Parameters["@totVentas"].Value.ToString();
            lblTotalCompras.Text = cmd.Parameters["@totCompr"].Value.ToString();
            lblCantCateg.Text = cmd.Parameters["@ncateg"].Value.ToString();
            lblCAntMarcas.Text = cmd.Parameters["@nmarc"].Value.ToString();
            lblCantProd.Text = cmd.Parameters["@nprod"].Value.ToString();
            lblCantClient.Text = cmd.Parameters["@nclient"].Value.ToString();
            lblCantEmple.Text = cmd.Parameters["@nemple"].Value.ToString();
            lblCantProve.Text = cmd.Parameters["@nprove"].Value.ToString();
            conexion.Close();
        }
        private void bt_almacen_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Explor_Producto"] != null)
            {
                Frm_Advertencia ver = new Frm_Advertencia();
                Frm_Filtro filtro = new Frm_Filtro();

                filtro.Show();
                ver.lbl_msm1.Text = "El Formulario ya esta Abierto!";
                ver.ShowDialog();
                filtro.Hide();
            }
            else
            {
                Frm_Explor_Producto pro = new Frm_Explor_Producto();

                pro.MdiParent = this;
                pro.Show();
                CerrarMenu();
                pnl_dashboard.Visible = false;
            }
            

            //Explor_Producto explo = new Explor_Producto();
            //if (pnl_fondo.Contains(explo)==false )
            //{
            //    pnl_fondo.Controls.Add(explo);
            //    explo.Dock = DockStyle.Fill;
            //    explo.BringToFront();
            //}
            //else
            //{
            //    explo.BringToFront();
            //}
            //Frm_Explor_Cliente pro = new Frm_Explor_Producto();

            //pro.MdiParent = this;
            //pro.Show();
        }

        public void Cargar_datos_Usuario()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Bienvenido conf = new Frm_Bienvenido();
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            Frm_InicioCaja ca = new Frm_InicioCaja();

            fil.Show();
            conf.Lbl_msm1.Text = "Bienvenido (a) Sr: " + Cls_Libreria.Nombres + " " + Cls_Libreria.Apellidos+" "+"al Sistema de Ventas ¡Que Tenga un Buen Dia!";
            conf.ShowDialog();
            //MessageBox.Show("Bienvenido (a) Sr: " + Cls_Libreria.Nombres + " " + Cls_Libreria.Apellidos, "Inicio de Session", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fil.Hide();

           /* if (obj.RN_validar_InicioDoble_caja()==false)
            {
                //le falta hacer inicio de caja
                fil.Show();
                ca.ShowDialog();
                fil.Hide();

            }*/



            //lbl_user.Text = Cls_Libreria.Nombres + "  " + Cls_Libreria.Apellidos;
            //lblrole.Text = Cls_Libreria.Rol;


            //if (Cls_Libreria.Foto.Trim().Length == 0 | Cls_Libreria.Foto == null) return;

            //if (File.Exists(Cls_Libreria.Foto) == true)
            //{
            //    PicUser_2.Load(Cls_Libreria.Foto);
            //    PicUser_2.Load(Cls_Libreria.Foto);
            //}
            //else
            //{
            //    PicUser_2.Image = Properties.Resources.user;
            //    PicUser_2.Image = Properties.Resources.user;
            //}
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_sino ver=new Frm_sino();

            fil.Show();
            ver.lbl_msm1.Text = "¿Estás Seguro de que Quieres Cerrar la Sesión?";
            ver.ShowDialog();
            fil.Hide();
            

            if (ver.Tag.ToString().Trim() == "Si")
            {
                Application.Exit();
            }           
        }

        private void Pnl_Menu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();
           if (e.Button ==MouseButtons.Left )
            {
                obj.Mover_formulario(this);
            }
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_hide_Click(object sender, EventArgs e)
        {

          if( PanelLateral.Width == 247)
            {
                PanelLateral.Width = 40;
                separator2.Width = 40;
                PicLogo.Visible = false;
                PicUser_2.Visible = true;
            }
          else
            {
                PanelLateral.Width = 247;
                separator2.Width = 247;
                PicLogo.Visible = true;
                PicUser_2.Visible = false;
            }
        }

        private void CerrarMenu()
        {
            if (PanelLateral.Width == 247)
            {
                PanelLateral.Width = 40;
                separator2.Width = 40;
                PicLogo.Visible = false;
                PicUser_2.Visible = true;
            }
        }


        private void Bt_ventas_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Crear_Ventas"] !=null)
            {
                Frm_Advertencia ver = new Frm_Advertencia();
                Frm_Filtro filtro = new Frm_Filtro();

                filtro.Show();
                ver.lbl_msm1.Text = "El Formulario ya esta Abierto!";
                ver.ShowDialog();
                filtro.Hide();
            }
            else
            {
                Frm_Crear_Ventas ven = new Frm_Crear_Ventas();

                ven.MdiParent = this;
                ven.Show();
                CerrarMenu();
                pnl_dashboard.Visible = false;
            }       


        }

        private void bt_cliente_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Explor_Cliente"] != null)
            {
                Frm_Advertencia ver = new Frm_Advertencia();
                Frm_Filtro filtro = new Frm_Filtro();

                filtro.Show();
                ver.lbl_msm1.Text = "El Formulario ya esta Abierto!";
                ver.ShowDialog();
                filtro.Hide();
            }
            else
            {
                Frm_Explor_Cliente ven = new Frm_Explor_Cliente();

                ven.MdiParent = this;
                ven.Show();
                CerrarMenu();
                pnl_dashboard.Visible = false;
            }
            
            
        }

        private void Bt_MantenimientoCategoria_Click(object sender, EventArgs e)
        {
            Frm_Categoria ven = new Frm_Categoria();

            ven.MdiParent = this;
            ven.Show();
            pnl_dashboard.Visible = false;

        }

        private void Bt_MantenimientoMarca_Click(object sender, EventArgs e)
        {
            Frm_Marcas ven = new Frm_Marcas();

            ven.MdiParent = this;
            ven.Show();
            pnl_dashboard.Visible = false;

        }

        private void mantenimientoDistritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Distritos ven = new Frm_Distritos();

            ven.MdiParent = this;
            ven.Show();
            pnl_dashboard.Visible = false;
        }       
        
        private void listadoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ListadoCliente ven = new Frm_ListadoCliente();
            ven.MdiParent = this;
            ven.Show();
            CerrarMenu();
        }

        private void bt_compras_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Compras"] != null)
            {
                Frm_Advertencia ver = new Frm_Advertencia();
                Frm_Filtro filtro = new Frm_Filtro();

                filtro.Show();
                ver.lbl_msm1.Text = "El Formulario ya esta Abierto!";
                ver.ShowDialog();
                filtro.Hide();
            }
            else
            {
                Frm_Compras ven = new Frm_Compras();
                ven.MdiParent = this;
                ven.Show();
                CerrarMenu();
                pnl_dashboard.Visible = false;
            }
            
        }

        private void Bt_AbrirExploradorDeCompras_Click(object sender, EventArgs e)
        {
            Frm_Explor_Compras explor = new Frm_Explor_Compras();
            explor.MdiParent = this;
            explor.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void Bt_AbrirExploradorDeProveedores_Click(object sender, EventArgs e)
        {
            Frm_Proveedor ven = new Frm_Proveedor();

            ven.MdiParent = this;
            ven.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void Bt_cotizar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Cotizacion"] != null)
            {
                Frm_Advertencia ver = new Frm_Advertencia();
                Frm_Filtro filtro = new Frm_Filtro();

                filtro.Show();
                ver.lbl_msm1.Text = "El Formulario ya esta Abierto!";
                ver.ShowDialog();
                filtro.Hide();
            }
            else
            {
                Frm_Cotizacion coti = new Frm_Cotizacion();
                coti.MdiParent = this;
                coti.Show();
                CerrarMenu();
                pnl_dashboard.Visible = false;
            }
           
        }

        private void bt_DocEmitidos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Frm_Explor_Documentos"] != null)
            {
                Frm_Advertencia ver = new Frm_Advertencia();
                Frm_Filtro filtro = new Frm_Filtro();

                filtro.Show();
                ver.lbl_msm1.Text = "El Formulario ya esta Abierto!";
                ver.ShowDialog();
                filtro.Hide();
            }
            else
            {
                Frm_Explor_Documentos doc = new Frm_Explor_Documentos();
                doc.MdiParent = this;
                doc.Show();
                CerrarMenu();
                pnl_dashboard.Visible = false;
            }
           
        }

        private void Bt_VerCotizacionesEmitidas_Click(object sender, EventArgs e)
        {
            Frm_Explor_Cotizacion excoti = new Frm_Explor_Cotizacion();
            excoti.MdiParent = this;
            excoti.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void Bt_crearUnaCotización_Click(object sender, EventArgs e)
        {
            Frm_Cotizacion coti = new Frm_Cotizacion();
            coti.MdiParent = this;
            coti.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void Bt_VentanaDeFacturación_Click(object sender, EventArgs e)
        {
            Frm_Explor_Cotizacion_Estado cotiE = new Frm_Explor_Cotizacion_Estado();
            cotiE.MdiParent = this;
            cotiE.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void bt_VerListadoDeClientes_Click(object sender, EventArgs e)
        {
            Frm_ListadoCliente list = new Frm_ListadoCliente();
            list.MdiParent = this;
            list.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void Bt_VerDocumentosEmitidos_Click(object sender, EventArgs e)
        {
            Frm_Explor_Documentos doc = new Frm_Explor_Documentos();
            doc.MdiParent = this;
            doc.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void Bt_RegistrarUnaCompra_Click(object sender, EventArgs e)
        {
            Frm_Compras comp = new Frm_Compras();
            comp.MdiParent = this;
            comp.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void Bt_HacerCierreDeCaja_Click(object sender, EventArgs e)
        {
            Frm_CerrarCaja cja = new Frm_CerrarCaja();
            cja.MdiParent = this;
            cja.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void Bt_RegistrarGastos_Click(object sender, EventArgs e)
        {
            Frm_Registrar_Gastos gas = new Frm_Registrar_Gastos();
            gas.MdiParent = this;
            gas.Show();
            pnl_dashboard.Visible = false;

        }

        private void Bt_RegistrarOtrosIngresos_Click(object sender, EventArgs e)
        {
            Frm_Reg_otroIngresos ot = new Frm_Reg_otroIngresos();
            ot.MdiParent = this;
            ot.Show();
            pnl_dashboard.Visible = false;

        }

        private void Bt_AperturarCajaDelDia_Click(object sender, EventArgs e)
        {
            Frm_InicioCaja apt = new Frm_InicioCaja();
            apt.MdiParent = this;
            apt.Show();
            pnl_dashboard.Visible = false;

        }

        private void Bt_VerMovimientoDeCaja_Click(object sender, EventArgs e)
        {
            Frm_Explor_Caja cja = new Frm_Explor_Caja();
            cja.MdiParent = this;
            cja.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }
                

        private void Bt_VerCierreDeCaja_Click(object sender, EventArgs e)
        {
            Frm_Explor_DetCaja detcja = new Frm_Explor_DetCaja();
            detcja.MdiParent = this;
            detcja.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void Bt_VerCreditoDeClientes_Click(object sender, EventArgs e)
        {
            Frm_Explor_Credito cred = new Frm_Explor_Credito();
            cred.MdiParent = this;
            cred.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void bt_VerExploradorDeProductos_Click(object sender, EventArgs e)
        {
            Frm_Explor_Producto pro = new Frm_Explor_Producto();
            pro.MdiParent = this;
            pro.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void Bt_EditarTipoDeCambio_Click(object sender, EventArgs e)
        {
            Frm_TipoCambio cam = new Frm_TipoCambio();
            cam.MdiParent = this;
            cam.Show();
            pnl_dashboard.Visible = false;

        }

        private void Bt_EditarCorrelativos_Click(object sender, EventArgs e)
        {
            Frm_Correlativo co = new Frm_Correlativo();

            co.MdiParent = this;
            co.Show();
            pnl_dashboard.Visible = false;

        }

        private void bt_VerMovimientoDeProductos_Click(object sender, EventArgs e)
        {
            Frm_Explor_Mov_Producto emp = new Frm_Explor_Mov_Producto();

            emp.MdiParent = this;
            emp.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void Bt_ReporteDeProductos_Click(object sender, EventArgs e)
        {
            Frm_Print_Productos pro = new Frm_Print_Productos();
            pro.MdiParent = this;
            pro.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }

        private void manejoBdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreBD pro = new RestoreBD();
            pro.MdiParent = this;
            pro.Show();
            pnl_dashboard.Visible = false;
        }

        private void generarCodigoDeBarrasToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            
        }

        private void miEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Empresa pro = new Frm_Empresa();
            pro.MdiParent = this;
            pro.Show();
            pnl_dashboard.Visible = false;
        }

        private void bt_salidadinero_Click(object sender, EventArgs e)
        {
            Frm_Registrar_Gastos gas = new Frm_Registrar_Gastos();
            gas.MdiParent = this;
            gas.Show();

        }

        private void bt_EntradaDinero_Click(object sender, EventArgs e)
        {
            Frm_Reg_otroIngresos ing = new Frm_Reg_otroIngresos();
            ing.MdiParent = this;
            ing.Show();
            
        }

        private void codigoDeBarrasManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 man = new Form1();
            man.MdiParent = this;
            man.Show();
            pnl_dashboard.Visible = false;
        }

        private void codigoDeBarrasMasivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasivo mas = new frmMasivo();
            mas.MdiParent = this;
            mas.Show();
            pnl_dashboard.Visible = false;
        }

        private void bt_Dash_Click(object sender, EventArgs e)
        {
            pnl_dashboard.Visible = true;
        }

        private void Bt_CajearUnaNotaVenta_Click(object sender, EventArgs e)
        {

        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToLongTimeString();
            fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void registrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Reg_Usuario mas = new Frm_Reg_Usuario();
            mas.MdiParent = this;
            mas.Show();
            pnl_dashboard.Visible = false;
        }

        private void listadoUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Explor_Usuario mas = new Frm_Explor_Usuario();
            mas.MdiParent = this;
            mas.Show();
            CerrarMenu();
            pnl_dashboard.Visible = false;
        }
    }
}
