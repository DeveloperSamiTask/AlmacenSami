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
    public class BD_Credito:BD_Conexion
    {
        public static bool Credsaved = false;
        public static bool CredDetsaved = false;
        public static bool borrado = false;
        public void BD_Registrar_Credito(EN_Credito cre)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Credito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idnotacredito", cre.IdCredito);
                cmd.Parameters.AddWithValue("@idDoc", cre.IdDoc);
                cmd.Parameters.AddWithValue("@Fecha_Credito", cre.FechaCredito);
                cmd.Parameters.AddWithValue("@nomcliente", cre.NomCliente);
                cmd.Parameters.AddWithValue("@total_ped", cre.TotalCredito);
                cmd.Parameters.AddWithValue("@Saldo_Pdnte", cre.Saldo_Pndte);
                cmd.Parameters.AddWithValue("@Fecha_vncmnto", cre.Fecha_Vencimiento);
               


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                Credsaved = true;

            }
            catch (Exception ex)
            {
                Credsaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Registrar_Detalle_Credito(EN_DetCredito cre)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_ingresar_det_Credito", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idnotacredito", cre.IdNotaCredito);
                cmd.Parameters.AddWithValue("@Acuenta", cre.Acuenta);
                cmd.Parameters.AddWithValue("@saldoactual", cre.SaldoActual);
                cmd.Parameters.AddWithValue("@Fecha_Pago", cre.FechaPago);
                cmd.Parameters.AddWithValue("@TipoPago", cre.TipoPago);
                cmd.Parameters.AddWithValue("@nroOpera", cre.NroOpera);
                cmd.Parameters.AddWithValue("@idUsu", cre.IdUsu);



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                CredDetsaved = true;

            }
            catch (Exception ex)
            {
                CredDetsaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public static double BD_Sumar_Total_Credito_poCliente(string idcliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand da = new SqlCommand("Sp_Ver_SumaTotal_credito_xcliente", cn);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@nomcliente", idcliente);
                double TotalCredito = 0;
                cn.Open();
                TotalCredito = Convert.ToDouble(da.ExecuteScalar());
                cn.Close();

                return TotalCredito;
            }
            catch (Exception ex)
            {
                CredDetsaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar:" + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

        }

        public DataTable BD_Listar_Todos_Creditos()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Ver_Todo_Credito", cn);
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

        public DataTable BD_Listar_Creditos_porValor(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_creditos", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@nomcliente", valor);

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

        public DataTable BD_VerDetalle_deCredito(string idCred)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Ver_Det_credito", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id_Cred", idCred);

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

        public void BD_Eliminar_Creditp(string idcate)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_eliminar_Credito_Permanente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idcredito", idcate);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                borrado = true;
            }
            catch (Exception ex)
            {
                borrado = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Eliminar:" + ex.Message, "Capa Datos Marca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void BD_Abonar_Credito(string idnota,double saldopnd,string stado)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actualizar_Saldo_Pdnte", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idnotacredito", idnota);
                cmd.Parameters.AddWithValue("@Saldo_Pndte", saldopnd);
                cmd.Parameters.AddWithValue("@Stado", stado);

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
                MessageBox.Show("Error al Editar:" + ex.Message, "Capa Datos Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    }
}
