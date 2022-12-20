using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Entidad;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
    public class BD_Kardex:BD_Conexion
    {

        public static bool seguardo=false;
        public static bool detsave = false;
        public void BD_Registrar_Kardex(string idkardx,string idproducto, string idprovee)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_crear_kardex", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idkardex", idkardx);
                cmd.Parameters.AddWithValue("@idprod", idproducto);
                cmd.Parameters.AddWithValue("@idprovee", idprovee);
                

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seguardo = true;

            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Kardex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //detalle de kardex
        public void BD_Registrar_Detalle_Kardex(EN_Kardex kr)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_detalle_kardex", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Krdx", kr.Idkardex);
                cmd.Parameters.AddWithValue("@Item", kr.Item);
                cmd.Parameters.AddWithValue("@Doc_Soport", kr.Doc_soporte);
                cmd.Parameters.AddWithValue("@Det_Operacion", kr.Det_operacion);

                cmd.Parameters.AddWithValue("@Cantidad_In", kr.Cantidad_in);
                cmd.Parameters.AddWithValue("@Precio_Unt_In", kr.Precio_in);
                cmd.Parameters.AddWithValue("@Costo_Total_In", kr.Total_in);

                cmd.Parameters.AddWithValue("@Cantidad_Out", kr.Cantidad_out);
                cmd.Parameters.AddWithValue("@Precio_Unt_Out", kr.Precio_out);
                cmd.Parameters.AddWithValue("@Importe_Total_Out", kr.Total_out);

                cmd.Parameters.AddWithValue("@Cantidad_Saldo", kr.Cantidad_saldo);
                cmd.Parameters.AddWithValue("@Promedio", kr.Promedio);
                cmd.Parameters.AddWithValue("@Costo_Total_Saldo", kr.Total_saldo);
               
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                detsave = true;

            }
            catch (Exception ex)
            {
                detsave = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //VALIDAR:

        public bool BD_Verificar_Producto_siTieneKardex(string idprod)
        {
            bool respuesta=false;
            Int32 getvalue = 0;

            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {               

                cn.ConnectionString = Conectar();
                cmd.CommandText = "Sp_Ver_sihay_Kardex";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros
                cmd.Parameters.AddWithValue("@Id_Prod", idprod);

                cn.Open();
                getvalue = Convert.ToInt32(cmd.ExecuteScalar());
                if (getvalue > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
                cn.Close();
            }
            catch (Exception ex)
            {
                detsave = false;
                
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;            
            }
            return respuesta;
        }

        public DataTable BD_Buscar_KardexDetalle_porProducto(string idprod)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_DeKardex_Principal_yDetalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", idprod);
                DataTable dato = new DataTable();

                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return null;
        }

        public DataTable BD_Cargar_DetalleKardex_delDia(DateTime dia)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Ver_Kardex_delDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha", dia);
                DataTable dato = new DataTable();

                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return null;
        }

        public DataTable BD_Cargar_DetalleKardex_delMes(DateTime mes)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Ver_Kardex_del_Mes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha", mes);
                DataTable dato = new DataTable();

                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return null;
        }
    }
}

