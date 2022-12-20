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
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;


namespace Microsell_Lite.Productos
{
    public partial class Frm_Importar_Producto : Form
    {
        public Frm_Importar_Producto()
        {
            InitializeComponent();           
        }

        private void dtg_Datos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            string nomcolum = dtg_Datos.Columns[columnIndex].Name;
            dtg_Datos.Columns.Remove(nomcolum);
        }

        private void btn_Quitar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dtg_Datos.SelectedRows)
                {
                    dtg_Datos.Rows.Remove(row);
                    lbl_nroFila.Text = Convert.ToString(dtg_Datos.Rows.Count);
                }
            }
            catch (Exception)
            {

                lbl_nooboocks.Focus();
            }
        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                txt_ruta.Text = filename.Trim();
                lbl_nooboocks.Text = "Hoja1";
                if (txt_ruta.Text.Length == 0) { MessageBox.Show("Cargar la ruta del libro del Excel Por Favor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                if (lbl_nooboocks.Text.Length == 0) { MessageBox.Show("Cargar el nombre del libro del Excel Por Favor", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

                Importar_Excel(txt_ruta.Text.Trim(),lbl_nooboocks.Text.Trim());
                dtg_Datos.ClearSelection();
            }
        }

        public void Importar_Excel(string Path,string LibroName)
        {
            try
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet dataSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;

                MyConnection = new System.Data.OleDb.OleDbConnection(@"Provider= Microsoft.JET.OLEDB.4.0; Data Source='"+ Path + "';Extended Properties= Excel 8.0;");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from ["+ LibroName + "$]",MyConnection);

                dataSet = new System.Data.DataSet();
                MyCommand.Fill(dataSet);
                dtg_Datos.DataSource = "";

                dtg_Datos.DataSource = dataSet.Tables[0];

                int xnro = dtg_Datos.RowCount;
                lbl_nroFila.Text = Convert.ToString(xnro);

                MyConnection.Close();
                btn_Quitar.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Obtener_Registro();
        }

        string Codigo = "";
        string Modelo = "";
        string Descripcion = "";
        double PrecioVenta = 0;
        double PreCompra = 0;
        double Canti = 0;

        private void Obtener_Registro()
        {
            int xitm = 0;
            int totalfila = 0;
            totalfila = Convert.ToInt32(lbl_nroFila.Text);
            int xtotal = totalfila;

            if (dtg_Datos.Rows.Count == 0) return;

            try
            {
                foreach (DataGridViewRow fila in dtg_Datos.Rows)
                {
                    if (Convert.IsDBNull(fila.Cells[0].Value) == true)//codigo producto
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        Codigo = Convert.ToString(fila.Cells[0].Value);
                    }

                    if (Convert.IsDBNull(fila.Cells[1].Value) == true)//Modelo producto
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        Modelo = Convert.ToString(fila.Cells[1].Value);
                    }

                    if (Convert.IsDBNull(fila.Cells[1].Value) == true)//Descripcion producto
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        Descripcion = Convert.ToString(fila.Cells[2].Value);
                    }

                    if (Convert.IsDBNull(fila.Cells[1].Value) == true)//precio compra producto
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        PreCompra = Convert.ToDouble(fila.Cells[3].Value);
                    }

                    if (Convert.IsDBNull(fila.Cells[1].Value) == true)//precio venta producto
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        PrecioVenta = Convert.ToDouble(fila.Cells[4].Value);
                    }

                    if (Convert.IsDBNull(fila.Cells[1].Value) == true)//precio compra producto
                    {
                        break;
                        this.Tag = "A";
                        this.Close();
                    }
                    else
                    {
                        Canti = Convert.ToDouble(fila.Cells[5].Value);
                    }

                    registrar_Producto(Codigo, Modelo,Descripcion,PrecioVenta,PreCompra,Canti);
                    xitm += 1;
                    lblregistrado.Text = xitm.ToString();
                    lblregistrado.Refresh();
                }
                if (Convert.ToInt32(lbl_nroFila.Text) == Convert.ToInt32(lblregistrado.Text))
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();

                    fil.Show();
                    ok.Lbl_msm1.Text = "La Importacion ha Finalizado, Revise tu explorador de Productos";
                    ok.ShowDialog();
                    fil.Hide();

                    this.Tag = "A";
                    this.Close();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void registrar_Producto(string codigo,string modelo,string descricion,double prevent,double precom,double stock)
        {
            RN_Productos obj = new RN_Productos();
            EN_Productos pro = new EN_Productos();
            string idProd = RN_TipoDoc.RN_NroId(4);
            try
            {               

                pro.Idpro = idProd;
                pro.Idprove = "PRV-0000001";
                pro.Codigo = codigo;
                pro.Modelo = modelo;
                pro.Descripcion = descricion;
                pro.Frank = 1.20;
                pro.PreCompra_Sol = precom;
                pro.PreCompra_Dlr = 0;
                pro.Stock = stock;
                pro.Idcat =1;
                pro.Idmark = 2;
                pro.Foto = Application.StartupPath + @"\pic.jpg";

                pro.PreVenta_Mnr = prevent;
                pro.PreVenta_Myr = prevent;
                pro.PreVenta_Dolr = 0;
                pro.UndMedida = "Und";
                pro.PesoUnit = 1;
                pro.UtilidadUnit = 1;
                pro.TipoProduct = "Producto";
                pro.ValorGeneral = 0;

                obj.RN_Registrar_Productos(pro);


                if (BD_Productos.seguardo == true)
                {
                    RN_TipoDoc.RN_Actualizar_Tipo_Doc(4);
                    
                    Registrar_Kardex(idProd, stock);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar el Producto", ex.Message);
            }
        }

        private void Registrar_Kardex(string idprod,double stock)
        {
            RN_Kardex obj = new RN_Kardex();
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
                    obj.RN_Registrar_Kardex(idkardex, idprod, "PRV-0000001");

                    if (BD_Kardex.seguardo == true)
                    {
                        //actualizar el siguiente numero correlativo

                        RN_TipoDoc.RN_Actualizar_Tipo_Doc(6);

                        //ahora trabajamos con el detalle de kardex;
                        kr.Idkardex = idkardex;
                        kr.Item = 1;
                        kr.Doc_soporte = "000";
                        kr.Det_operacion = "Inicio de Kardex";

                        //entradas

                        kr.Cantidad_in = stock;
                        kr.Precio_in = 0;
                        kr.Total_in = 0;

                        //salidas

                        kr.Cantidad_out = 0;
                        kr.Precio_out = 0;
                        kr.Total_out = 0;

                        //saldos
                        kr.Cantidad_saldo =stock;
                        kr.Promedio = 0;
                        kr.Total_saldo = 0;

                        obj.RN_Registrar_Detalle_Kardex(kr);

                        if (BD_Kardex.detsave == true)
                        {
                            //actualizar el kardez
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar el Producto" + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void Frm_Importar_Producto_Load(object sender, EventArgs e)
        {
            dtg_Datos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_Datos.MultiSelect = false;
            dtg_Datos.ReadOnly = true;
            dtg_Datos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_Datos.AllowUserToAddRows = false;
        }

        private void Frm_Importar_Producto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
