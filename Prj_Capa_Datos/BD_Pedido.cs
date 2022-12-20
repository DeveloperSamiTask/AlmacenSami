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
    public class BD_Pedido:BD_Conexion
    {

        public static bool seguardo = false;

        public static bool detseguardo = false;

        public void BD_Registrar_Pedido(EN_Pedido ped)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", ped.IdPedido);
                cmd.Parameters.AddWithValue("@Id_Cliente", ped.IdCliente);
                cmd.Parameters.AddWithValue("@SubTotal", ped.SubTotal);
                cmd.Parameters.AddWithValue("@IgvPed", ped.Igv);
                cmd.Parameters.AddWithValue("@TotalPed", ped.TotalPed);
                cmd.Parameters.AddWithValue("@id_Usu", ped.IdUsu);
                cmd.Parameters.AddWithValue("@TotalGancia", ped.TotalGanancia);
               

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

        //editar pedido

        public void BD_Editar_Pedido(EN_Pedido ped)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", ped.IdPedido);
                cmd.Parameters.AddWithValue("@Id_Cliente", ped.IdCliente);                
                cmd.Parameters.AddWithValue("@SubTotal", ped.SubTotal);
                cmd.Parameters.AddWithValue("@IgvPed", ped.Igv);
                cmd.Parameters.AddWithValue("@TotalPed", ped.TotalPed);
                cmd.Parameters.AddWithValue("@id_Usu", ped.IdUsu);
                cmd.Parameters.AddWithValue("@TotalGancia", ped.TotalGanancia);


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

        //verificar id Pedido

        public bool BD_Verificar_NroPedido(string NroPedido)
        {
            bool respuesta = false;
            Int32 getvalue = 0;

            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {

                cn.ConnectionString = Conectar();
                cmd.CommandText = "Sp_Verificar_Id_Pedido";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros
                cmd.Parameters.AddWithValue("@Id_Ped", NroPedido);

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
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }
            return respuesta;
        }

        public void BD_Registrar_Detalle_Pedido(EN_Detalle_Pedido det)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Registrar_detalle_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", det.IdPed);
                cmd.Parameters.AddWithValue("@Id_Pro", det.IdProd);
                cmd.Parameters.AddWithValue("@Precio", det.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", det.Cantidad);
                cmd.Parameters.AddWithValue("@Importe", det.Importe);
                cmd.Parameters.AddWithValue("@Tipo_Prod", det.TipoProd);
                cmd.Parameters.AddWithValue("@Und_Medida", det.Und);
                cmd.Parameters.AddWithValue("@Utilidad_Unit", det.Utilidad_Unit);
                cmd.Parameters.AddWithValue("@TotalUtilidad", det.TotalUtilidad);


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

        //borrar detalle pedido:

        public void BD_Eliminar_Detalle_Pedido(string idpedido)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_detalle_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", idpedido);
              


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

        //Poner pedido como Atendido

        public void BD_Poner_Pedido_Atendido(string idpedido)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Pedido_Atendido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", idpedido);



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

        //cambiar el nombre del cliente en el pedido

        public void BD_Cambiar_Cliente_Pedido(string idpedido,string idcliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actu_clien_Ped", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", idpedido);
                cmd.Parameters.AddWithValue("@Id_Ped", idcliente);



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

        //eliminar pedido por completo
        public void BD_Eliminar_Pedido_Permanente(string idpedido)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Pedido_Completo", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", idpedido);



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

        //buscar pedido completo con detalle
        public DataTable BD_Buscar_Pedido_Editar(string idped)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Pedido_Para_Editar", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Ped", idped);

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

        //buscar pedido por valor
        public DataTable BD_Buscar_Pedido_porValor(string idped)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_buscar_Pedidos_porValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valor", idped);

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

        //buscar pedido por fecha
        public DataTable BD_Buscar_Pedido_Fecha(string tipo,DateTime xfecha)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Pedidos_porFecha", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.Parameters.AddWithValue("@fecha", xfecha);

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

        //buscar pedido por atender

        public DataTable BD_Buscar_Pedido_porAtender()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Pedidos_PorAtender", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                //da.SelectCommand.Parameters.AddWithValue("@fecha", xfecha);

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

        public DataTable BD_Buscar_Pedido_ConDetalle(string idped)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_FacturasPedido_Detalle ", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", idped);
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
