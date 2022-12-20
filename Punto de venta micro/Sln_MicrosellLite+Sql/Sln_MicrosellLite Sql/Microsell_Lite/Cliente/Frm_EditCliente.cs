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
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Prj_Capa_Datos;

namespace Microsell_Lite.Cliente
{
    public partial class Frm_EditCliente : Form
    {
        public Frm_EditCliente()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            //GenerarCodigo();
            
            Buscar_Cliente_Editar(this.Tag.ToString());
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

       

        private bool Validar_Textbox()
        {
            Frm_Filtro fil=new Frm_Filtro();
            Frm_Advertencia ver=new Frm_Advertencia();

            if (txt_Idcliente.Text.Trim().Length <2){fil.Show();ver.lbl_msm1.Text = "Ingresa o Genera el Id del Cliente";ver.ShowDialog();fil.Hide();return false;}
            if (txt_nomcliente.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Nombre del Cliente"; ver.ShowDialog(); fil.Hide(); txt_nomcliente.Focus(); return false; }
            if (txt_dni.Text.Trim().Length < 8) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el DNI del Cliente"; ver.ShowDialog(); fil.Hide(); txt_dni.Focus(); return false; }
            if (txt_direccion.Text.Trim().Length < 5) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la direccion del Cliente"; ver.ShowDialog(); fil.Hide(); txt_direccion.Focus(); return false; }
            if (txt_tel.Text.Trim().Length < 8) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Telefono del Cliente"; ver.ShowDialog(); fil.Hide(); txt_tel.Focus(); return false; }
            if (txt_email.Text.Trim().Length < 8) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Email del Cliente"; ver.ShowDialog(); fil.Hide(); txt_email.Focus(); return false; }
            if (txt_contacto.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Contacto del Cliente"; ver.ShowDialog(); fil.Hide(); txt_contacto.Focus(); return false; }
            if (txt_saldo.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Saldo del Cliente"; ver.ShowDialog(); fil.Hide(); txt_saldo.Focus(); return false; }
            if (cbo_distritos.SelectedIndex == -1) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Distrito del Cliente"; ver.ShowDialog(); fil.Hide(); cbo_distritos.Focus(); return false; }


            return true;
        }

        private void Registrar_Cliente()
        {
            RN_Cliente obj = new RN_Cliente();
            EN_Cliente cli=new EN_Cliente();
            
            try
            {
                cli.Idcliente=txt_Idcliente.Text;
                cli.Razonsocial=txt_nomcliente.Text;
                cli.Direccion = txt_direccion.Text;
                cli.Dni = txt_dni.Text;
                cli.Telefono = txt_tel.Text;
                cli.Email= txt_email.Text;
                cli.Iddis = Convert.ToInt32(cbo_distritos.SelectedValue);
                cli.Fechaaniver = dtp_fecha.Value;
                cli.Contacto=txt_contacto.Text;
                cli.LimiteCredito = Convert.ToDouble(txt_saldo.Text);

                obj.RN_Editar_Cliente(cli);

                if (BD_Cliente.edited==true)
                {
                    limpiarForm();

                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ver = new Frm_Msm_Bueno();
                    fil.Show();
                    ver.Lbl_msm1.Text = "El Cliente se ha Editado Exitosamente";
                    ver.ShowDialog();
                    fil.Hide();

                    this.Tag = "A";
                    this.Close();
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Registro Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
         }

        private void Buscar_Cliente_Editar(String valor)
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable data = new DataTable();
            Cargar_Distritos();
            try
            {
                data = obj.RN_Buscar_Cliente(valor,"Activo");

                if (data.Rows.Count > 0)
                {
                    txt_Idcliente.Text = Convert.ToString(data.Rows[0]["Id_Cliente"]);
                    txt_nomcliente.Text = Convert.ToString(data.Rows[0]["Razon_Social_Nombres"]);
                    txt_direccion.Text = Convert.ToString(data.Rows[0]["Direccion"]);
                    txt_dni.Text = Convert.ToString(data.Rows[0]["DNI"]);
                    txt_tel.Text = Convert.ToString(data.Rows[0]["Telefono"]);
                    txt_email.Text = Convert.ToString(data.Rows[0]["E_Mail"]);
                    txt_contacto.Text = Convert.ToString(data.Rows[0]["Contacto"]);
                    txt_saldo.Text = Convert.ToString(data.Rows[0]["Limit_Credit"]);
                    cbo_distritos.Text = Convert.ToString(data.Rows[0]["Distrito"]);
                    dtp_fecha.Text = Convert.ToString(data.Rows[0]["Fcha_Ncmnto_Anivsrio"]);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Editar 2 Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void limpiarForm()
        {
            txt_Idcliente.Text = "";
            txt_nomcliente.Text = "";
            txt_dni.Text = "";
            txt_tel.Text = "";
            txt_email.Text = "";
            txt_contacto.Text = "";
            txt_saldo.Text = "0";
            cbo_distritos.SelectedIndex = -1;

        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (Validar_Textbox()==true)
            {
                Registrar_Cliente();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        //private void GenerarCodigo()
        //{
        //    RN_Cliente obj = new RN_Cliente();
        //    txt_Idcliente.Text = "CLIE" + obj.GenerarCodigo("Cliente");
        //}

        private void Cargar_Distritos()
        {
            RN_Distritos obj = new RN_Distritos();
            DataTable dato = new DataTable();

            try
            {
                dato = obj.RN_Cargar_Todas_Distritos();
                if (dato.Rows.Count > 0)
                {
                    cbo_distritos.DataSource = dato;
                    cbo_distritos.ValueMember = "Id_Dis";
                    cbo_distritos.DisplayMember = "Distrito";                    
                    cbo_distritos.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         

        }

        private void Frm_EditCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
