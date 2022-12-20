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
    public class BD_Productos:BD_Conexion
    {
        public static bool seguardo = false;
        public static bool seedito = false;

        public void BD_Registrar_Productos(EN_Productos pro)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", pro.Idpro);
                cmd.Parameters.AddWithValue("@idprove", pro.Idprove);
                cmd.Parameters.AddWithValue("@codigo", pro.Codigo);
                cmd.Parameters.AddWithValue("@modelo", pro.Modelo);
                cmd.Parameters.AddWithValue("@descripcion", pro.Descripcion);
                cmd.Parameters.AddWithValue("@frank", pro.Frank);
                cmd.Parameters.AddWithValue("@Pre_compraSol", pro.PreCompra_Sol);
                cmd.Parameters.AddWithValue("@pre_CompraDolar", pro.PreCompra_Dlr);
                cmd.Parameters.AddWithValue("@StockActual", pro.Stock);
                cmd.Parameters.AddWithValue("@idCat", pro.Idcat);
                cmd.Parameters.AddWithValue("@idMar", pro.Idmark);
                cmd.Parameters.AddWithValue("@Foto", pro.Foto);
                cmd.Parameters.AddWithValue("@Pre_Venta_Menor", pro.PreVenta_Mnr);
                cmd.Parameters.AddWithValue("@Pre_Venta_Mayor", pro.PreVenta_Myr);
                cmd.Parameters.AddWithValue("@Pre_Venta_Dolar", pro.PreVenta_Dolr);
                cmd.Parameters.AddWithValue("@UndMdida", pro.UndMedida);
                cmd.Parameters.AddWithValue("@PesoUnit", pro.PesoUnit);
                cmd.Parameters.AddWithValue("@Utilidad", pro.UtilidadUnit);
                cmd.Parameters.AddWithValue("@TipoProd", pro.TipoProduct);
                cmd.Parameters.AddWithValue("@ValorporProd", pro.ValorGeneral);

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
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Editar_Productos(EN_Productos pro)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", pro.Idpro);
                cmd.Parameters.AddWithValue("@idprove", pro.Idprove);
                cmd.Parameters.AddWithValue("@codigo", pro.Codigo);
                cmd.Parameters.AddWithValue("@modelo", pro.Modelo);
                cmd.Parameters.AddWithValue("@descripcion", pro.Descripcion);
                cmd.Parameters.AddWithValue("@frank", pro.Frank);
                cmd.Parameters.AddWithValue("@Pre_compraSol", pro.PreCompra_Sol);
                cmd.Parameters.AddWithValue("@pre_CompraDolar", pro.PreCompra_Dlr);                
                cmd.Parameters.AddWithValue("@idCat", pro.Idcat);
                cmd.Parameters.AddWithValue("@idMar", pro.Idmark);
                cmd.Parameters.AddWithValue("@Foto", pro.Foto);
                cmd.Parameters.AddWithValue("@Pre_Venta_Menor", pro.PreVenta_Mnr);
                cmd.Parameters.AddWithValue("@Pre_Venta_Mayor", pro.PreVenta_Myr);
                cmd.Parameters.AddWithValue("@Pre_Venta_Dolar", pro.PreVenta_Dolr);
                cmd.Parameters.AddWithValue("@UndMdida", pro.UndMedida);
                cmd.Parameters.AddWithValue("@PesoUnit", pro.PesoUnit);
                cmd.Parameters.AddWithValue("@Utilidad", pro.UtilidadUnit);
                cmd.Parameters.AddWithValue("@TipoProd", pro.TipoProduct);
                

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;

            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public DataTable BD_Cargar_Todas_Productos()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_cargar_Todos_Productos", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable data = new DataTable();

                da.Fill(data);
                da = null;
                return data;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Consultar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public DataTable BD_Buscar_Productos(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_buscador_Productos", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valor", valor);

                DataTable data = new DataTable();

                da.Fill(data);
                da = null;
                return data;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Consultar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        public void BD_DarBaja_Productos(string idpro)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Darbaja_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);
               


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;

            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Eliminar_Productos(string idpro)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Eliminar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;

            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Sumar_Stock_Productos(string idpro,double stock)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_SumarStock", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);
                cmd.Parameters.AddWithValue("@stock", stock);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;

            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Restar_Stock_Productos(string idpro, double stock)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Restar_Stock", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);
                cmd.Parameters.AddWithValue("@stock", stock);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;

            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Actualizar_Precios_Compra_Productos(string idpro, double precompraSol, double preVentaMnr, double utilidad,double valorAlmacen)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actulizar_Precios_CompraVenta_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Pro", idpro);
                cmd.Parameters.AddWithValue("@Pre_CompraS", precompraSol);
                cmd.Parameters.AddWithValue("@Pre_vntaxMenor", preVentaMnr);
                cmd.Parameters.AddWithValue("@Utilidad", utilidad);
                cmd.Parameters.AddWithValue("@ValorAlmacen", valorAlmacen);
                



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;

            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        public String GenerarCodigo(string tabla)
        {
            SqlConnection cn=new SqlConnection();
            SqlCommand cmd;
            SqlDataReader dr;
            string codigo = string.Empty;
            int Total = 0;

            cn.ConnectionString = Conectar();
            cmd = new SqlCommand("select COUNT(*) as Id_Pro from "+tabla, cn);
            cmd.CommandType = CommandType.Text;
            cn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Total = Convert.ToInt32(dr["Id_Pro"]) + 1;
            }
            dr.Close();

            if (Total < 10)
            {
                codigo = "0000000" + Total;
            }
            else if (Total < 100)
            {
                codigo = "000000" + Total;
            }
            else if (Total < 1000)
            {
                codigo = "00000" + Total;
            }
            else if (Total < 10000)
            {
                codigo = "0000" + Total;
            }
            else if (Total < 100000)
            {
                codigo = "000" + Total;
            }
            else if (Total < 1000000)
            {
                codigo = "00" + Total;
            }
            else if (Total < 10000000)
            {
                codigo = "0" + Total;
            }

            cn.Close();
            return codigo;
        }
    }
}
