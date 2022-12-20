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
    public class BD_Ingreso_Compra:BD_Conexion
    {

        public static bool seguardo = false;
        public static bool detseguardo = false;
        public void BD_Ingresar_RegistroCompra(EN_IngresoCompras com)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Compra", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCom", com.Idcompra);
                cmd.Parameters.AddWithValue("@Nro_Fac_Fisico", com.NroDoc_fisico);
                cmd.Parameters.AddWithValue("@IdProvee", com.Idproveedor);
                cmd.Parameters.AddWithValue("@SubTotal_Com", com.Subtotal);
                cmd.Parameters.AddWithValue("@FechaIngre", com.FechaIngreso);
                cmd.Parameters.AddWithValue("@TotalCompra", com.Totalcompra);
                cmd.Parameters.AddWithValue("@IdUsu", com.Idusu);
                cmd.Parameters.AddWithValue("@ModalidadPago", com.Modali_Pago);
                cmd.Parameters.AddWithValue("@TiempoEspera", com.TiempoEspera);
                cmd.Parameters.AddWithValue("@FechaVence", com.FechaVence);
                cmd.Parameters.AddWithValue("@EstadoIngre", com.EstadoIngreso);
                cmd.Parameters.AddWithValue("@RecibiConforme", com.RecibiConforme);
                cmd.Parameters.AddWithValue("@Datos_Adicional", com.Datos_Adicional);
                cmd.Parameters.AddWithValue("@Tipo_Doc_Compra", com.TipoDoc_Compra);


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
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //guardar el detalle

        public void BD_Detalle_RegistroCompra(EN_Det_IngresoCompra det)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insert_Detalle_ingreso", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_ingreso", det.Id_Ingreso);
                cmd.Parameters.AddWithValue("@Id_Pro", det.Idproducto);
                cmd.Parameters.AddWithValue("@Precio", det.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", det.Cantidad);
                cmd.Parameters.AddWithValue("@Importe", det.Importe);              


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                detseguardo = true;

            }
            catch (Exception ex)
            {
                detseguardo = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public bool BD_Verificar_NroDoc_Fisico(string idfisico)
        {
            bool respuesta = false;
            Int32 getvalue = 0;

            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {

                cn.ConnectionString = Conectar();
                cmd.CommandText = "sp_validar_NroFisico_Compra";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros
                cmd.Parameters.AddWithValue("@Nro_Doc_fisico", idfisico);

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


                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Ingreso Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }
            return respuesta;
        }

        public String GenerarCodigo(string tabla)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd;
            SqlDataReader dr;
            string codigo = string.Empty;
            int Total = 0;

            cn.ConnectionString = Conectar();
            cmd = new SqlCommand("select COUNT(*) as Id_DocComp from " + tabla, cn);
            cmd.CommandType = CommandType.Text;
            cn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Total = Convert.ToInt32(dr["Id_DocComp"]) + 1;
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

        //consultas

        public DataTable BD_Buscar_Compras_Explorador(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Gnral_deCompras", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", valor);
                

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
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Ingreso Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return null;
        }

        public DataTable BD_Cargar_Todas_Compras()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Todas_Facturas_Compras", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@Valor", valor);
                //da.SelectCommand.Parameters.AddWithValue("@estado", estado);

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
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return null;
        }

        public DataTable BD_Buscar_Compras_Explorador_Mes_Dia(string tipo,DateTime fechames)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Facturas_Ingresadas_alDia ", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.Parameters.AddWithValue("@fecha", fechames);


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
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Ingreso Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return null;
        }

        //borrar
        public void BD_Borrar_Compra(string idfac)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("SP_Borrar_Factura_Ingresada", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Fac", idfac);



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
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public DataTable BD_Buscar_Compras_ConDetalle(string idcompra)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_FacturasCompras_Detalle ", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", idcompra);
                //da.SelectCommand.Parameters.AddWithValue("@fecha", fechames);


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
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Ingreso Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return null;
        }
    }
}
