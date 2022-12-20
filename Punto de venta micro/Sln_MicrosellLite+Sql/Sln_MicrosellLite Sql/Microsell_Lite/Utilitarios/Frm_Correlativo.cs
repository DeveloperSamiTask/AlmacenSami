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
using Prj_Capa_Datos;

namespace Microsell_Lite.Utilitarios
{
    public partial class Frm_Correlativo : Form
    {
        public Frm_Correlativo()
        {
            InitializeComponent();
        }


        bool yacargo = false;
        private void Frm_Edit_Precio_Load(object sender, EventArgs e)
        {
            Cargar_TipoDoc();
            yacargo = true;
        }

        private void Cargar_TipoDoc()
        {
            RN_TipoDoc obj = new RN_TipoDoc();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todos_TipoDoc();
            if (dato.Rows.Count >0)
            {
                cbo_Documento.DataSource = dato;
                cbo_Documento.DisplayMember = "Documento";
                cbo_Documento.ValueMember = "Id_Tipo";
                cbo_Documento.SelectedIndex = -1;
            }
        }
       

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            RN_TipoDoc obj = new RN_TipoDoc();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

            if(txt_Id.Text.Trim().Length == 0) { fil.Show(); ver.lbl_msm1.Text = "Falta el ID del Documento";ver.ShowDialog();fil.Hide();cbo_Documento.Focus();return; }
            if (txt_Serie.Text.Trim().Length == 0) { fil.Show(); ver.lbl_msm1.Text = "Falta la Serie del Documento"; ver.ShowDialog(); fil.Hide(); txt_Serie.Focus(); return; }
            if (txt_Numero.Text.Trim().Length < 5) { fil.Show(); ver.lbl_msm1.Text = "Falta el Numero del Documento"; ver.ShowDialog(); fil.Hide(); txt_Numero.Focus(); return; }

            obj.RN_Editar_Nro_Correlativo(Convert.ToInt32(txt_Id.Text),lbl_doc.Text,txt_Serie.Text,txt_Numero.Text);

            if (BD_Tipo_Doc.saved==true)
            {
                fil.Show();
                ok.Lbl_msm1.Text = "Los Cambios se han Guardado Correctamente";
                ok.ShowDialog();
                fil.Hide();

                txt_Serie.Text = "";
                txt_Numero.Text = "";
                txt_Id.Text = "";
                lbl_doc.Text = "Editar Correlativo";
                cbo_Documento.Text = "Seleccionar:";

                pnl_edit.Enabled = false;
                btn_aceptar.Enabled = false;
            }
        }      


        private void Frm_Edit_Precio2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void cbo_Documento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yacargo==true)
            {
                if (cbo_Documento.SelectedIndex > -1)
                {
                    int idtipo = Convert.ToInt32(cbo_Documento.SelectedValue);
                    Buscar_tipoDoc(idtipo);
                }
            }
        }

        private void Buscar_tipoDoc(int idtipo)
        {
            RN_TipoDoc obj = new RN_TipoDoc();
            DataTable dato = new DataTable();

            dato = obj.RN_Listar_Todos_TipoDoc_porId(idtipo);
            if (dato.Rows.Count >0)
            {
                txt_Id.Text = Convert.ToString(dato.Rows[0]["Id_Tipo"]);
                lbl_doc.Text = Convert.ToString(dato.Rows[0]["Documento"]);
                txt_Serie.Text = Convert.ToString(dato.Rows[0]["Serie"]);
                txt_Numero.Text = Convert.ToString(dato.Rows[0]["Numero"]);

                pnl_edit.Enabled = true;
                btn_aceptar.Enabled = true;
                txt_Serie.Focus();
            }
        }
    }
}
