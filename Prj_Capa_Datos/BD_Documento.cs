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
    public class BD_Documento:BD_Conexion
    {
        public bool BD_Verificar_NroDocumento(string nroDoc)
        {
            bool respuesta = false;
            Int32 getvalue = 0;

            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {

                cn.ConnectionString = Conectar();
                cmd.CommandText = "Sp_Validar_Id_Doc";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros
                cmd.Parameters.AddWithValue("@Id_Doc", nroDoc);

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


        public static bool seguardo = false;
        public void BD_Registrar_Nuevo_Documento(EN_Documento doc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insert_Documento", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Doc", doc.IdDoc);
                cmd.Parameters.AddWithValue("@id_Ped", doc.IdPedido);
                cmd.Parameters.AddWithValue("@Id_Tipo", doc.IdTipo);
                cmd.Parameters.AddWithValue("@Fecha_Emi", doc.FechaDoc);
                cmd.Parameters.AddWithValue("@Importe", doc.Importe);
                cmd.Parameters.AddWithValue("@TipoPago", doc.TipoPago);
                cmd.Parameters.AddWithValue("@NroOpera", doc.Nr_Operacion);
                cmd.Parameters.AddWithValue("@id_Usu", doc.IdUsu);
                cmd.Parameters.AddWithValue("@Igv", doc.Igv);
                cmd.Parameters.AddWithValue("@son", doc.SonLetra);
                cmd.Parameters.AddWithValue("@TotalGanancia", doc.TotalGanancia);
                
                

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

        public void BD_Actualizar_Nuevo_Documento(string iddoc,double importe,double igv,string son)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actualizar_documento", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Doc", iddoc);                
                cmd.Parameters.AddWithValue("@Importe", importe);                
                cmd.Parameters.AddWithValue("@Igv", igv);
                cmd.Parameters.AddWithValue("@son", son);             



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

        public DataTable BD_Buscar_Documento_porValor(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Documentos_xValor", cn);
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
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return null;
        }

        public DataTable BD_Listar_Documento_porDia(DateTime diax)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Doc_emitoshoy", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@FechaActual", diax);
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

        public DataTable BD_Listar_Documento_porMes(DateTime mesx)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Fcturas_Emtidas_EnunMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes", mesx);
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

        public DataTable BD_Leer_Documento_Emitidas_porMes(DateTime mesx,int idtipodoc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Comprobantes_Emtidas_EnunMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes", mesx);
                da.SelectCommand.Parameters.AddWithValue("@Docu", idtipodoc);
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

        public DataTable BD_Buscar_Documento_yDetalle(string NroDoc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Documento_yDetalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nro_Doc", NroDoc);
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

        public void BD_Anular_Documento(string idDoc,string estadoDoc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Anular_Documento", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Doc", idDoc);
                cmd.Parameters.AddWithValue("@estado", estadoDoc);             



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

        public void BD_Cambiar_TipoPago_Documento(string idDoc, string tipoPago)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Cambiar_TipoPago_Documento", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Doc", idDoc);
                cmd.Parameters.AddWithValue("@tipoPago", tipoPago);



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

        public DataTable BD_Listar_Todos_Documentos()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_todos_docs", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@Nro_Doc", NroDoc);
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
