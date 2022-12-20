using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Entidad;

namespace Prj_Capa_Datos
{
    public class BD_Usuario:BD_Conexion
    {
        public static bool saved = false;
        public static bool edited = false;
        public static bool eliminar = false;
        public void BD_Insertar_Usuario(EN_Roles rol)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_Usuarios", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usu", rol.IdUsu);
                cmd.Parameters.AddWithValue("@Nombres", rol.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", rol.Apellidos);
                cmd.Parameters.AddWithValue("@iddis", rol.IdDis);
                cmd.Parameters.AddWithValue("@usuario", rol.Usuario);
                cmd.Parameters.AddWithValue("@contraseña", rol.Contraseña);
                cmd.Parameters.AddWithValue("@Foto", rol.Foto);
                cmd.Parameters.AddWithValue("@fecha", rol.Fechaaniver);
                cmd.Parameters.AddWithValue("@idrol", rol.IdRol);
                cmd.Parameters.AddWithValue("@correo", rol.Correo);
                


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

        public void BD_Editar_Usuario(EN_Roles rol)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Usuario", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usu", rol.IdUsu);
                cmd.Parameters.AddWithValue("@Nombres", rol.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", rol.Apellidos);
                cmd.Parameters.AddWithValue("@iddis", rol.IdDis);
                cmd.Parameters.AddWithValue("@usuario", rol.Usuario);
                cmd.Parameters.AddWithValue("@contraseña", rol.Contraseña);
                cmd.Parameters.AddWithValue("@Foto", rol.Foto);
                cmd.Parameters.AddWithValue("@fecha", rol.Fechaaniver);
                cmd.Parameters.AddWithValue("@idrol", rol.IdRol);
                cmd.Parameters.AddWithValue("@correo", rol.Correo);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                edited = true;

            }
            catch (Exception ex)
            {
                edited = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Eliminar_Usuario(string idRol)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Eliminar_Usuario", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usu", idRol);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                eliminar = true;

            }
            catch (Exception ex)
            {
                eliminar = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public bool BD_Login(string usu,string clave)
        {
            bool respuesta = false;
            Int32 getvalue = 0;

            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {

                cn.ConnectionString = Conectar();
                cmd.CommandText = "Sp_Login";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros
                cmd.Parameters.AddWithValue("@Usuario", usu);
                cmd.Parameters.AddWithValue("@Contraseña", clave);

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

        public DataTable BD_Buscar_Usuario(string nomusu)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Usuario_Login", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Usuario", nomusu);

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

        public String GenerarCodigo(string tabla)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd;
            SqlDataReader dr;
            string codigo = string.Empty;
            int Total = 0;

            cn.ConnectionString = Conectar();
            cmd = new SqlCommand("select COUNT(*) as Id_Usu from " + tabla, cn);
            cmd.CommandType = CommandType.Text;
            cn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Total = Convert.ToInt32(dr["Id_Usu"]) + 1;
            }
            dr.Close();

            if (Total < 10)
            {
                codigo = "" + Total;
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

        public DataTable BD_Cargar_Todos_Usuarios()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Usuario", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                

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

        public DataTable BD_Buscar_Usuario_Valor(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Usuario_porValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Valor", valor);
                

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
