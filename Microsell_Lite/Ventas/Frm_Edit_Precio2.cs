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

namespace Microsell_Lite.Ventas
{
    public partial class Frm_Edit_Precio2 : Form
    {
        public Frm_Edit_Precio2()
        {
            InitializeComponent();
        }

        public string idProducto = "";

        private void Frm_Edit_Precio_Load(object sender, EventArgs e)
        {

            Buscar_Producto(idProducto.Trim());
            txt_precio.Focus();

        }

        private void Buscar_Producto(String xvalor)
        {
            RN_Productos obj = new RN_Productos();
            DataTable data = new DataTable();
            
            try
            {
                data = obj.RN_Buscar_Productos(xvalor.Trim()); ;

                if (data.Rows.Count > 0)
                {
                    lbl_idproducto.Text = Convert.ToString(data.Rows[0]["Id_Pro"]);
                    Lbl_stockActual.Text = Convert.ToString(data.Rows[0]["Stock_Actual"]);
                    Lbl_precompra.Text = Convert.ToString(data.Rows[0]["Pre_CompraS"]);
                    lbl_producto.Text = Convert.ToString(data.Rows[0]["Modelo"]);      
                    lbl_tipoProducto.Text= Convert.ToString(data.Rows[0]["TipoProdcto"]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Editar 2 Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {

            if(txt_precio.Text == "") { txt_precio.Focus();return; };
            if (Convert.ToDouble(txt_precio.Text) == 0) { txt_precio.Focus(); return; };

            if (txt_cant.Text == "") { txt_cant.Focus(); return; };
            if (Convert.ToDouble(txt_cant.Text) == 0) { txt_cant.Focus(); return; };


            try
            {
                double PreCompra = Convert.ToDouble(Lbl_precompra.Text);
                double PreVenta = Convert.ToDouble(txt_precio.Text);
                double xutili_Unit = 0;

                xutili_Unit = PreVenta - PreCompra;//para obtener la utilidad
                Lbl_UtilidadUnit.Text = xutili_Unit.ToString("###.00");

                //validar stock del producto
                if (lbl_tipoProducto.Text.Trim().ToString()=="Producto")
                {
                    if (Convert.ToDouble(txt_cant.Text)>Convert.ToDouble(Lbl_stockActual.Text))
                    {
                        Frm_Filtro fil = new Frm_Filtro();
                        Frm_Advertencia ver = new Frm_Advertencia();
                        txt_cant.Text = "1";

                        fil.Show();
                        ver.lbl_msm1.Text = "La Cantidad a Vender no Puede Superar al Stock Disponible";
                        ver.ShowDialog();
                        fil.Hide();
                        //MessageBox.Show("La Cantidad a Vender no Puede Superar al Stock Disponible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_cant.Focus();
                        return;
                    }
                    else
                    {
                        this.Tag = "A";
                        this.Close();
                    }
                }
                else
                {
                    this.Tag = "A";
                    this.Close();

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            this.Tag = "A";
            this.Close();
        }

        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilitario ui = new Utilitario();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_precio_TextChanged(object sender, EventArgs e)
        {
            txt_precio.Text = txt_precio.Text.Replace(",", ".");
            txt_precio.SelectionStart = txt_precio.Text.Length;

            try
            {
                double PreCompra = Convert.ToDouble(Lbl_precompra.Text);
                double PreVenta = Convert.ToDouble(txt_precio.Text);
                double xutili_Unit = 0;

                xutili_Unit = PreVenta - PreCompra;//para obtener la utilidad
                Lbl_UtilidadUnit.Text = xutili_Unit.ToString("###.00");
            }
            catch(Exception ex)
            {
                string sms = ex.Message;
            }
        }

        private void txt_cant_TextChanged(object sender, EventArgs e)
        {
            txt_cant.Text = txt_cant.Text.Replace(",", ".");
            txt_cant.SelectionStart = txt_cant.Text.Length;
        }

        private void Frm_Edit_Precio2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
