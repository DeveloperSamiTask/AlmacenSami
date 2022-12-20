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

namespace Microsell_Lite.Proveedores
{
    public partial class Frm_EditProvee : Form
    {
        public Frm_EditProvee()
        {
            InitializeComponent();
        }

        private void Frm_Reg_Prod_Load(object sender, EventArgs e)
        {
            Buscar_Proveedor_Editar(this.Tag.ToString());
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

        string xFotoruta;

        private void lbl_Abrir_Click(object sender, EventArgs e)
        {
            var FilePath = String.Empty;

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xFotoruta = openFileDialog1.FileName;
                    pic_persona.Load(xFotoruta);
                }
            }
            catch (Exception ex)
            {
                pic_persona.Load(Application.StartupPath + @"\user.png");
                xFotoruta = Application.StartupPath + @"\user.png";
                MessageBox.Show("Error al Guardar el Persoanal" + ex.Message);
            }

        }

        private bool Validar_Textbox()
        {
            Frm_Filtro fil=new Frm_Filtro();
            Frm_Advertencia ver=new Frm_Advertencia();

            if (txtidd.Text.Trim().Length <2){fil.Show();ver.lbl_msm1.Text = "Ingresa o Genera el Id del Proveedor";ver.ShowDialog();fil.Hide();return false;}
            if (txt_nomprove.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Nombre del Proveedor"; ver.ShowDialog(); fil.Hide(); txt_nomprove.Focus(); return false; }
            if (txt_direc.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la Direccion del Proveedor"; ver.ShowDialog(); fil.Hide(); txt_direc.Focus(); return false; }
            if (txt_tel.Text.Trim().Length < 9) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Numero del Proveedor"; ver.ShowDialog(); fil.Hide(); txt_tel.Focus(); return false; }
            if (txt_rub.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Rubro del Proveedor"; ver.ShowDialog(); fil.Hide(); txt_rub.Focus(); return false; }
            if (txt_ruc.Text.Trim().Length < 8) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Nro de DNI o RUC del Proveedor"; ver.ShowDialog(); fil.Hide(); txt_ruc.Focus(); return false; }
            if (txt_correo.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la Direccion de Correo del Proveedor"; ver.ShowDialog(); fil.Hide(); txt_correo.Focus(); return false; }

            return true;
        }

        private void Editar_Proveedor()
        {
            RN_Proveedor obj = new RN_Proveedor();
            EN_Proveedor pro=new EN_Proveedor();

            try
            {
                pro.Idprovedor = txtidd.Text;
                pro.Nombreproveedor = txt_nomprove.Text;
                pro.Direccion = txt_direc.Text;
                pro.Telefono = txt_tel.Text;
                pro.Rubro = txt_rub.Text;
                pro.Ruc=txt_ruc.Text;
                pro.Correo = txt_correo.Text;
                pro.Contacto=txt_contacto.Text;
                pro.Fotologo = xFotoruta;

                obj.RN_Editar_Proveedor(pro);

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
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
         }

        private void limpiarForm()
        {
            txtidd.Text = "";
            txt_nomprove.Text = "";
            txt_direc.Text = "";
            txt_rub.Text = "";
            txt_ruc.Text = "";
            txt_correo.Text = "";
            txt_contacto.Text = "";
            xFotoruta = "";
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (Validar_Textbox()==true)
            {
                Editar_Proveedor();
            }
        }

        private void Buscar_Proveedor_Editar(String idprovee)
        {
            RN_Proveedor obj = new RN_Proveedor();
            DataTable data=new DataTable();

            try
            {
                data = obj.RN_Buscar_Proveedores(idprovee);

                if (data.Rows.Count >0)
                {
                    txtidd.Text = Convert.ToString(data.Rows[0]["IDPROVEE"]);                   
                    txt_nomprove.Text = Convert.ToString(data.Rows[0]["NOMBRE"]);
                    txt_direc.Text = Convert.ToString(data.Rows[0]["DIRECCION"]);
                    txt_correo.Text = Convert.ToString(data.Rows[0]["CORREO"]);
                    txt_tel.Text = Convert.ToString(data.Rows[0]["TELEFONO"]);
                    txt_contacto.Text = Convert.ToString(data.Rows[0]["CONTACTO"]);
                    txt_rub.Text = Convert.ToString(data.Rows[0]["RUBRO"]);
                    txt_ruc.Text = Convert.ToString(data.Rows[0]["RUC"]);
                    xFotoruta = Convert.ToString(data.Rows[0]["FOTO_LOGO"]);

                    pic_persona.Load(xFotoruta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Editar 2 Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void Frm_EditProvee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
