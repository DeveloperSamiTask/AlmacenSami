using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Prj_Capa_Datos
{
    public class BD_Categoria : BD_Conexion 
    {
        

        public void BD_Registrar_Categoria(string nomCateg)
        {
            
            SqlConnection cn=new SqlConnection();            
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_categoria", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nomCateg);

                cn.Open(); 
                cmd.ExecuteNonQuery();
                cn.Close();
                
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message,"Capa Datos Categoria",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        //editar:

        public void BD_Editar_Categoria(int idcate,string nomCateg)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_modificar_categoria", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcat", idcate);
                cmd.Parameters.AddWithValue("@nombre", nomCateg);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Editar:" + ex.Message, "Capa Datos Categoria", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        //eliminar
        public void BD_Eliminar_Categoria(int idcate)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_categoria", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcat", idcate);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Eliminar:" + ex.Message, "Capa Datos Marca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //consultar:

        public DataTable BD_Cargar_Todas_Categorias()
        {
            SqlConnection cn=new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_listar_todas_Categorias", cn);
                da.SelectCommand.CommandType=CommandType.StoredProcedure;

                DataTable data=new DataTable();

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
                MessageBox.Show("Error al Consultar:" + ex.Message, "Capa Datos Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
    }
}
