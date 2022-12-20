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


namespace Microsell_Lite
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

       

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            
        }

        private bool Validar_Texto()
        {
            Frm_Filtro fil=new Frm_Filtro();

            if (txtUser.Text.Trim().Length<2){fil.Show();MessageBox.Show("Ingresa el Nombre de Usuario","Login",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);txtUser.Focus();return false;}
            if (txtClave.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("Ingrese la Contraseña", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txtClave.Focus(); return false; }
            return true;
        }

        private void Hacer_Login()
        {
            RN_Usuario obj = new RN_Usuario();
            DataTable dato = new DataTable();

            string usu = txtUser.Text;
            string pass= txtClave.Text;

            int veces = 0;

            if (Validar_Texto() == false) return;

            if (obj.RN_Login(usu,pass)==true)
            {
                dato=obj.RN_Buscar_Usuario(usu);

                if (dato.Rows.Count >0)
                {
                    DataRow dr=dato.Rows[0];
                    Cls_Libreria.IdRol = dr["Id_Rol"].ToString();
                    Cls_Libreria.Nombres = dr["Nombres"].ToString();
                    Cls_Libreria.Apellidos = dr["Apellidos"].ToString();
                    Cls_Libreria.Foto = dr["Ubicacion_Foto"].ToString();
                    Cls_Libreria.Rol = dr["Rol"].ToString();
                    Cls_Libreria.IdUsu= dr["id_Usu"].ToString();
                    Cls_Libreria.Usuario = dr["Usuario"].ToString();
                    
                }

                this.Hide();
                Frm_Principal pri = new Frm_Principal();
                pri.Show();
                pri.Cargar_datos_Usuario();


            }
            else
            {
                Frm_Filtro fil = new Frm_Filtro();
                Frm_Advertencia ver = new Frm_Advertencia();

                veces += 1;
                txtClave.Text = "";
                txtUser.Text = "";
                txtUser.Focus();

                fil.Show();
                ver.lbl_msm1.Text = "El Usuario y/o Clave son Incorrectos, Intentalo Nuevamente";
                ver.ShowDialog();
                fil.Hide();
                //MessageBox.Show("El Usuario y/o Clave son Incorrectos, Intentalo Nuevamente", "Advertencia de Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (veces == 3)
                {
                    MessageBox.Show("Ud ha sobrepasado los Limites Permitidos","Advertencia de Login", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
            }

            
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            Hacer_Login();
           
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }
        
        private void btnOcultarPass_Click_1(object sender, EventArgs e)
        {
            if (txtClave.PasswordChar == '\0')
            {
                btnMostrarPass.BringToFront();
                txtClave.PasswordChar = '*';
            }
        }

        private void btnMostrarPass_Click(object sender, EventArgs e)
        {
            if (txtClave.PasswordChar == '*')
            {
                btnOcultarPass.BringToFront();
                txtClave.PasswordChar = '\0';
            }
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "Password")
            {
                txtClave.Text = "";
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btn_listo_Click(sender, e);
            }
        }
    }
}
