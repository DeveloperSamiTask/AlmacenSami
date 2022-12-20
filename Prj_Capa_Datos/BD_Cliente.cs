using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Prj_Capa_Entidad;


namespace Prj_Capa_Datos
{
    public class BD_Cliente:BD_Conexion
    {
        public bool BD_Verificar_NroDni(string NroDni)
        {
            bool respuesta = false;
            Int32 getvalue = 0;

            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {

                cn.ConnectionString = Conectar();
                cmd.CommandText = "sp_Validar_NroDNI";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros
                cmd.Parameters.AddWithValue("@dni", NroDni);

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


        public static bool saved = false;
        public static bool edited = false;
        public static bool baja = false;
        public static bool eliminar = false;

        public void BD_Insertar_Cliente(EN_Cliente cli)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", cli.Idcliente);
                cmd.Parameters.AddWithValue("@razonsocial", cli.Razonsocial);
                cmd.Parameters.AddWithValue("@dni", cli.Dni);
                cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@email", cli.Email);
                cmd.Parameters.AddWithValue("@idDis", cli.Iddis);
                cmd.Parameters.AddWithValue("@fechaAniver", cli.Fechaaniver);
                cmd.Parameters.AddWithValue("@contacto", cli.Contacto);
                cmd.Parameters.AddWithValue("@limiteCred", cli.LimiteCredito);

               
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

        public void BD_Editar_Cliente(EN_Cliente cli)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Modificar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", cli.Idcliente);
                cmd.Parameters.AddWithValue("@razonsocial", cli.Razonsocial);
                cmd.Parameters.AddWithValue("@dni", cli.Dni);
                cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@email", cli.Email);
                cmd.Parameters.AddWithValue("@idDis", cli.Iddis);
                cmd.Parameters.AddWithValue("@fechaAniver", cli.Fechaaniver);
                cmd.Parameters.AddWithValue("@contacto", cli.Contacto);
                cmd.Parameters.AddWithValue("@limiteCred", cli.LimiteCredito);



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
    
        public DataTable BD_Cargar_Todos_Cliente(string estado)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Clientes",cn);
                da.SelectCommand.CommandType=CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@estado",estado);

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

        public DataTable BD_Buscar_Cliente(string valor, string estado)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Cliente_porValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Valor", valor);
                da.SelectCommand.Parameters.AddWithValue("@estado", estado);

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

        public void BD_DarBaja_Cliente(string idcliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_DarBajar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", idcliente);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                baja = true;

            }
            catch (Exception ex)
            {
                baja = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Dar de Baja:" + ex.Message, "Capa Datos Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Eliminar_Cliente(string idcliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", idcliente);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                eliminar = true;

            }
            catch (Exception ex)
            {
                eliminar= false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            cmd = new SqlCommand("select COUNT(*) as Id_Cliente from " + tabla, cn);
            cmd.CommandType = CommandType.Text;
            cn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Total = Convert.ToInt32(dr["Id_Cliente"]) + 1;
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
