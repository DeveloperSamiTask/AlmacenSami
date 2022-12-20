using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
    public class BD_Tipo_Doc:BD_Conexion
    {
        public static bool saved = false;
        public static string BD_NroId(int idtipo)
        {

            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conectar2(); 
                SqlCommand cmd = new SqlCommand("Sp_Listado_Tipo",cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo",idtipo);

                string NroDoc;
                cn.Open();
                NroDoc = Convert.ToString(cmd.ExecuteScalar());
                cn.Close();
                return NroDoc;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose();
                cn = null;
                return null;
                
            }
        }

        public static void BD_Actualizar_Tipo_Doc(int Id_Tipo)
        {
            SqlConnection cn = new SqlConnection();
            

            try
            {
                cn.ConnectionString=Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Actualiza_Tipo_Doc", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType =CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", Id_Tipo);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();

            }   
            catch(Exception ex)
            {

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                 MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

       //editar tipo de cambio
        
        public static void BD_Actualizar_Tipo_Cambio(int Id_Tipo, double TipoCambio)
        {
            SqlConnection cn = new SqlConnection();


            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Tipo_Cambio", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idtipo", Id_Tipo);
                cmd.Parameters.AddWithValue("@numero", TipoCambio);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        public static double BD_Leer_TipoCambio(int idtipo)
        {

            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Listar_TipoCambio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", idtipo);

                double TipoCambio;
                cn.Open();
                TipoCambio = Convert.ToDouble(cmd.ExecuteScalar());
                cn.Close();
                return TipoCambio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose();
                cn = null;
                return 0;

            }
        }

        public DataTable BD_Listar_Doc_Especial()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Tipod_Doc_Spcial", cn);
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

        public void BD_Editar_Nro_Correlativo(int Id_Tipo,string docu,string sre,string numero)
        {
            SqlConnection cn = new SqlConnection();


            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Tipo_Doc", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idtipo", Id_Tipo);
                cmd.Parameters.AddWithValue("@documento", docu);
                cmd.Parameters.AddWithValue("@serie", sre);
                cmd.Parameters.AddWithValue("@numero", numero);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();
                saved = true;

            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        public DataTable BD_Listar_Todos_TipoDoc_porId(int idtipo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("SP_Listar_tipo_doc_porID", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idtipo", idtipo);

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

        public DataTable BD_Listar_Todos_TipoDoc()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("SP_Listar_Tipo_Doc", cn);
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

    }
}
