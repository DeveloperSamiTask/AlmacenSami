using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Entidad;
using System.Data;
using System.Windows.Forms;

namespace Prj_Capa_Datos 
{
    public class BD_Negocio : BD_Conexion
    {
        public EN_Negocio BD_Obtener_Datos()
        {
            SqlConnection cn = new SqlConnection();
            EN_Negocio obj = new EN_Negocio();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("obtener_datos_Negocio", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        obj = new EN_Negocio()
                        {
                            IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                            Razon_Social = dr["Razon_Social"].ToString(),
                            RUC = dr["RUC"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        };
                    }
                }


                
                
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Negocio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return obj;
        }

        public bool BD_Guardar_Datos(EN_Negocio obj)
        {
            SqlConnection cn = new SqlConnection();
            bool respuesta = true;
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Modificar_Negocio", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdNegocio", obj.IdNegocio);
                cmd.Parameters.AddWithValue("@Razon_Social", obj.Razon_Social);
                cmd.Parameters.AddWithValue("@RUC", obj.RUC);
                cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("@Correo", obj.Correo);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                respuesta = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Negocios Guardar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return respuesta;
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] LogoBytes = new byte[0];
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conectar();
                cn.Open();
                SqlCommand cmd = new SqlCommand("select Logo from Negocio where IdNegocio = 1", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.Text;                
                cmd.ExecuteNonQuery();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        LogoBytes = (byte[])dr["Logo"];
                    }
                }

                
                cn.Close();
            }
            catch (Exception ex)
            {
                obtenido = false;
                LogoBytes = new byte[0];
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Negocio Obtener Logo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return LogoBytes;
         
        }

        public bool ActualizarLogo(byte [] image)
        {
            SqlConnection cn = new SqlConnection();
            bool respuesta = true;
            try
            {
                cn.ConnectionString = Conectar();
                StringBuilder query = new StringBuilder();
                query.AppendLine("update Negocio set Logo=@imagen");
                query.AppendLine("where IdNegocio=1");

                SqlCommand cmd = new SqlCommand(query.ToString(), cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@imagen", image);
                

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                respuesta = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Negocio Actualizar Logo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return respuesta;
        }
    }
}
