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


namespace Microsell_Lite.Usuario
{
    public partial class Frm_Reg_Usuario : Form
    {
        public Frm_Reg_Usuario()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            GenerarCodigo();
        }

        private void GenerarCodigo()
        {
            RN_Usuario obj = new RN_Usuario();
            txtid.Text = "" + obj.GenerarCodigo("Usuarios");
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

            if (txt_apellido.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa o Genera el Codigo del Producto"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_usuario.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Nombre del Producto"; ver.ShowDialog(); fil.Hide(); txt_usuario.Focus(); return false; }
            if (txt_nombre.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la Descripcion del Producto"; ver.ShowDialog(); fil.Hide(); txt_nombre.Focus(); return false; }
            if (txt_Distrito.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Nombre del Proveedor"; ver.ShowDialog(); fil.Hide(); txt_Distrito.Focus(); return false; }
            if (txt_marca.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la Marca del Producto"; ver.ShowDialog(); fil.Hide(); txt_marca.Focus(); return false; }
            if (txt_correo.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la Categoria del Producto"; ver.ShowDialog(); fil.Hide(); txt_correo.Focus(); return false; }
            if (txt_contra.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la Categoria del Producto"; ver.ShowDialog(); fil.Hide(); txt_contra.Focus(); return false; }


           
            return true;
        }

        private void limpiarForm()
        {
            txt_apellido.Text = "";
            txt_usuario.Text = "";
            txt_Distrito.Text = "";
            txt_Distrito.Text = "";
            txt_marca.Text = "";
            txt_usuario.Text = "";
            txt_contra.Text = "";            
            txt_correo.Text = "";            
            xFotoruta = "";
        }

      

      

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        
        private void lbl_BuscarMarca_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Roles lis = new Frm_Roles();

            fil.Show();
            lis.ShowDialog();

            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                txt_marca.Text = lis.lblNomDis.Text;
                lbl_mar.Text = lis.lbl_idDis.Text;
            }
        }

        

        private void lbl_buscarProve_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Distritos lis = new Frm_Distritos();

            fil.Show();
            lis.ShowDialog();

            fil.Hide();

            if (lis.Tag.ToString() == "A")
            {
                txt_Distrito.Text = lis.lblNomDis.Text;
                lbl_IdDis.Text = lis.lbl_idDis.Text;
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
            RN_Usuario obj=new RN_Usuario();
            EN_Roles pro=new EN_Roles();

            try
            {                
                pro.IdUsu = Convert.ToInt32(txtid.Text.Trim());
                pro.Nombres= txt_nombre.Text.Trim();
                pro.Apellidos = txt_apellido.Text.Trim();
                pro.IdDis = Convert.ToInt32(lbl_IdDis.Text);
                pro.Usuario=txt_usuario.Text;
                pro.Contraseña=txt_contra.Text;
                if (xFotoruta.Trim().Length < 5)
                {
                    pro.Foto = "-";

                }
                else
                {
                    pro.Foto = xFotoruta;
                }
                pro.Fechaaniver = dtp_fecha.Value;
                pro.IdRol = Convert.ToInt32(lbl_mar.Text);
                pro.Correo = txt_correo.Text.Trim();        


                obj.RN_Insertar_Usuario(pro);

                
                if (BD_Usuario.saved==true)
                {
                    
                    GenerarCodigo();

                    limpiarForm();

                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ver = new Frm_Msm_Bueno();
                    fil.Show();
                    ver.Lbl_msm1.Text = "El Rol se ha Creado y Guardado Correctamente";
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

        

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
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
