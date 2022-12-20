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
    public class BD_Temporal:BD_Conexion
    {
        public static bool saved = false;
        public void BD_Registrar_Temporal(EN_Temporal temp)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insertar_Temporal", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codTem", temp.IdTemporal);
                cmd.Parameters.AddWithValue("@FechaEmi", temp.FechaEmi);
                cmd.Parameters.AddWithValue("@cliente", temp.NomCliente);
                cmd.Parameters.AddWithValue("@Ruc", temp.Ruc);
                cmd.Parameters.AddWithValue("@Direccion", temp.Direccion);
                cmd.Parameters.AddWithValue("@SubTtal", temp.SubTotal);
                cmd.Parameters.AddWithValue("@IgvT", temp.Igv);
                cmd.Parameters.AddWithValue("@TotalT", temp.Total);
                cmd.Parameters.AddWithValue("@SonT", temp.Sonletra);
                cmd.Parameters.AddWithValue("@vendedor", temp.Vendedor);
                cmd.Parameters.AddWithValue("@CodigoQr", temp.CodigoQR);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                saved = true;

            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Registrar_DetTemporal(EN_Det_Temporal temp)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_Det_Temporal", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codtem", temp.IdTempo);
                cmd.Parameters.AddWithValue("@CodProd", temp.CodProd);
                cmd.Parameters.AddWithValue("@Cantidad", temp.Canti);
                cmd.Parameters.AddWithValue("@Producto", temp.Producto);
                cmd.Parameters.AddWithValue("@PreUnt", temp.Precio);
                cmd.Parameters.AddWithValue("@Importe", temp.Importe);
                

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                saved = true;

            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Detalle Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public DataTable BD_Leer_Temporal_porID(string idTemp)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Temporales", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", idTemp);                

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

        public void BD_Eliminar_Temporal(string idTemp)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Delete_Det_Temporal", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", idTemp);
                



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                saved = true;

            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
