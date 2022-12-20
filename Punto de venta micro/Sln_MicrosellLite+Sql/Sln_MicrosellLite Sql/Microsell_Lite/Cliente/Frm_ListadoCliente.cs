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
using Prj_Capa_Entidad;
using Microsell_Lite.Utilitarios;
using Prj_Capa_Datos;

namespace Microsell_Lite.Cliente
{
    public partial class Frm_ListadoCliente : Form
    {
        public Frm_ListadoCliente()
        {
            InitializeComponent();
            //GenerarCodigo();
            txt_cod.Text = RN_TipoDoc.RN_NroId(13);
            Configurar_listview();
            Cargar_Todos_Clientes();
        }

        //private void GenerarCodigo()
        //{
        //    RN_Cliente obj = new RN_Cliente();
        //    txt_cod.Text = "CLIE" + obj.GenerarCodigo("Cliente");
        //}
        private void Registrar_Cliente()
        {
            RN_Cliente obj = new RN_Cliente();
            EN_Cliente cli = new EN_Cliente();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ver = new Frm_Msm_Bueno();
            try
            {
                txt_cod.Text = RN_TipoDoc.RN_NroId(13);
                cli.Idcliente = txt_cod.Text;
                cli.Razonsocial = txt_nombre.Text;
                cli.Direccion = txt_Direccion.Text;
                cli.Dni = txt_dni.Text;
                cli.Telefono = "0";
                cli.Email = "-";
                cli.Iddis = 1;
                cli.Fechaaniver = dtp_fecha.Value;
                cli.Contacto = "-";
                cli.LimiteCredito = 50;

                obj.RN_Insertar_Cliente(cli);

                //GenerarCodigo();
                
                if (BD_Cliente.saved == true)
                {
                    RN_TipoDoc.RN_Actualizar_Tipo_Doc(13);
                    //GenerarCodigo();               

                    limpiarForm();

                    fil.Show();
                    ver.Lbl_msm1.Text = "El Cliente se ha Guardado Exitosamente";
                    ver.ShowDialog();
                    fil.Hide();

                    txt_buscar.Text = txt_cod.Text;
                    limpiarForm();
                    Cargar_Todos_Clientes();
                    pnl_Add.Visible = false;

                }        

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Registro Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void limpiarForm()
        {
            txt_cod.Text =RN_TipoDoc.RN_NroId(13);
            txt_Direccion.Text = "";
            txt_dni.Text = "";
            txt_nombre.Text = "";
            

        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Validar_Textbox() == true)
            {
                Registrar_Cliente();                
                Cargar_Todos_Clientes();
            }

        }

        private bool Validar_Textbox()
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            if (txt_cod.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa o Genera el Id del Cliente"; ver.ShowDialog(); fil.Hide(); return false; }
            if (txt_nombre.Text.Trim().Length < 2) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Nombre del Cliente"; ver.ShowDialog(); fil.Hide(); txt_nombre.Focus(); return false; }
            if (txt_dni.Text.Trim().Length < 8) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el DNI del Cliente"; ver.ShowDialog(); fil.Hide(); txt_dni.Focus(); return false; }
            if (txt_Direccion.Text.Trim().Length < 5) { fil.Show(); ver.lbl_msm1.Text = "Ingresa la direccion del Cliente"; ver.ShowDialog(); fil.Hide(); txt_Direccion.Focus(); return false; }
            

            return true;
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            pnl_Add.Visible = true;
            
            txt_dni.Focus();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            pnl_Add.Visible=false;
            limpiarForm();
        }

        private void Configurar_listview()
        {
            var lis = lsv_client;

            lsv_client.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID Cliente", 0, HorizontalAlignment.Center);//0
            lis.Columns.Add("Datos del Cliente", 247, HorizontalAlignment.Center);//2
            lis.Columns.Add("DNI", 100, HorizontalAlignment.Left);//5
            lis.Columns.Add("Estado", 97, HorizontalAlignment.Center);//4



        }
        private void Llenar_Listview(DataTable data)
        {
            
            lsv_client.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Cliente"].ToString());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                list.SubItems.Add(dr["DNI"].ToString().Trim());                
                list.SubItems.Add(dr["Estado_Cli"].ToString());



                lsv_client.Items.Add(list);//si no ponemos esto., el listview nunca se llenara

            }
            Pintar_Filas();
            
        }

        private void Pintar_Filas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_client.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_client.Items[i].BackColor = Color.LightBlue;
                }
                cont += 1;
            }
        }

        private void Cargar_Todos_Clientes()
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable dato = new DataTable();

            dato = obj.RN_Cargar_Todos_Cliente("Activo");
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_client.Items.Clear();
               
            }
        }

        public void Buscar_Clientes(string valor)
        {
            RN_Cliente obj = new RN_Cliente();
            DataTable dato = new DataTable();

            dato = obj.RN_Buscar_Cliente(valor, "Activo");
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_client.Items.Clear();
                
            }
        }

        private void txt_buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                Buscar_Clientes(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    Buscar_Clientes(txt_buscar.Text);
                }
                else
                {
                    Cargar_Todos_Clientes();
                }
            }
        }

        private void txt_buscar_Enter(object sender, EventArgs e)
        {
            if (txt_buscar.Text == "Buscar Productos")
            {
                txt_buscar.Text = "";
            }
        }

        private void Seleccionar_Cliente()
        {
            if (lsv_client.SelectedIndices.Count ==0)
            {

            }
            else
            {
                var lis = lsv_client.SelectedItems[0];
                lbl_id.Text = lis.SubItems[0].Text;
                lbl_nom.Text = lis.SubItems[1].Text;
                lbl_ruc.Text = lis.SubItems[2].Text;

                this.Tag = "A";
                this.Close();
            }
        }


        private void lsv_client_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Seleccionar_Cliente();
        }

        private void lsv_client_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                Seleccionar_Cliente();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        public static string tipo = "";

        private void Frm_ListadoCliente_Load(object sender, EventArgs e)
        {
            if (tipo.Trim().Length == 0)
            {
                Configurar_listview();
                Cargar_Todos_Clientes();
            }
            else
            {
                Configurar_listview();
                Buscar_Clientes(tipo);
            }
            
        }

        private void txt_cod_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Frm_ListadoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
