using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Negocio;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Microsell_Lite.Utilidades;

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Empresa : Form
    {
        public Frm_Empresa()
        {
            InitializeComponent();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void txt_cod_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes,0,imageBytes.Length);
            Image image = new Bitmap(ms);

            return image;
        }

        private void Frm_Empresa_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimage = new RN_Negocio().ObtenerLogo(out obtenido);

            if (obtenido)
                picLogo.Image = ByteToImage(byteimage);

            EN_Negocio datos = new RN_Negocio().BD_Obtener_Datos();

            txt_Razon.Text = datos.Razon_Social;
            txt_RUC.Text = datos.RUC;
            txt_Direccion.Text = datos.Direccion;
            txt_Correo.Text = datos.Correo;
            txt_Telefon.Text = datos.Telefono;
        }    
             

        private void btn_Guardar_Click_1(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ver = new Frm_Msm_Bueno();
            EN_Negocio obj = new EN_Negocio()
            {
                Razon_Social = txt_Razon.Text,
                RUC = txt_RUC.Text,
                Direccion = txt_Direccion.Text,
                Telefono = txt_Telefon.Text,
                Correo = txt_Correo.Text
            };

            bool respuesta = new RN_Negocio().BD_Guardar_Datos(obj);

            if (respuesta)
            {

                fil.Show();
                ver.Lbl_msm1.Text = "Los Cambios fueron Guardados Correctamente";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                fil.Show();
                ver.Lbl_msm1.Text = "Los Cambios No fueron Guardados Correctamente";
                ver.ShowDialog();
                fil.Hide();
            }
        }

        private void btn_Salir_Click_1(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_listo_Click_1(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ver = new Frm_Msm_Bueno();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.FileName = "Files|*.jpg;*.jpeg;*.png;";
            openFileDialog.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"; 



            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] byteimage = File.ReadAllBytes(openFileDialog.FileName);
                bool respuesta = new RN_Negocio().ActualizarLogo(byteimage);

                if (respuesta)
                {
                    picLogo.Image = ByteToImage(byteimage);
                }
                else
                {
                    fil.Show();
                    ver.Lbl_msm1.Text = "Los Cambios No fueron Guardados";
                    ver.ShowDialog();
                    fil.Hide();
                }

            }
        }
    }
}
