using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Windows.Forms;
using Prj_Capa_Entidad;

//para los de SQL:
using System.Data.SqlClient;

namespace Prj_Capa_Datos
{
   public  class BD_Caja :BDConexion 
    {
        public static bool cajaSaved = false;

        public void BD_Registrar_Mov_Caja(EN_Caja cja)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha_Caja", cja.FechaCaja );
                cmd.Parameters.AddWithValue("@Tipo_Caja", cja.TipoCaja);
                cmd.Parameters.AddWithValue("@Concepto", cja.Concepto );
                cmd.Parameters.AddWithValue("@De_Para", cja.DePara_Cliente );
                cmd.Parameters.AddWithValue("@Nro_Doc", cja.Nr_Documento );
                cmd.Parameters.AddWithValue("@ImporteCaja", cja.ImporteCaja );
                cmd.Parameters.AddWithValue("@Id_Usu", cja.Idusu );
                cmd.Parameters.AddWithValue("@TotalUti", cja.TotalUtilidad );
                cmd.Parameters.AddWithValue("@TipoPago", cja.TipoPago );
                cmd.Parameters.AddWithValue("@GeneradoPor", cja.GeneradoPor );
               

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                cajaSaved  = true;

            }
            catch (Exception ex)
            {
                cajaSaved  = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }



        public void BD_Actualizar_Total_Caja(string nroDoc, double total, double totalUtili, string tipoPago)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nro_doc", nroDoc );
                cmd.Parameters.AddWithValue("@total", total );
                cmd.Parameters.AddWithValue("@TotalUtilidad", totalUtili );
                cmd.Parameters.AddWithValue("@TipoPago", tipoPago);
               


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                cajaSaved = true;

            }
            catch (Exception ex)
            {
                cajaSaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }



        public DataTable BD_Listar_Todas_Cajas()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Todas_Cajas", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes", mesx);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;

        }

        public DataTable BD_lisgar_Cajas_DelDia(DateTime diax)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cajas_delDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@dia", diax);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;

        }



        public DataTable BD_lisgar_Cajas_Del_Mes(DateTime mesx)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cajas_del_Mes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechas", mesx);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;

        }


        public DataTable BD_buscador_General_Cajas(String valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_MoviCaja_xValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor",valor );
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;

        }





        public void BD_editar_Mov_Caja(EN_Caja cja)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Editar_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcaja", cja.Idcaja);
                cmd.Parameters.AddWithValue("@Fecha_Caja", cja.FechaCaja);
                cmd.Parameters.AddWithValue("@Tipo_Caja", cja.TipoCaja);
                cmd.Parameters.AddWithValue("@Concepto", cja.Concepto);
                cmd.Parameters.AddWithValue("@De_Para", cja.DePara_Cliente);
                cmd.Parameters.AddWithValue("@Nro_Doc", cja.Nr_Documento);
                cmd.Parameters.AddWithValue("@ImporteCaja", cja.ImporteCaja);               
                cmd.Parameters.AddWithValue("@TotalUti", cja.TotalUtilidad);
                cmd.Parameters.AddWithValue("@TipoPago", cja.TipoPago);
                cmd.Parameters.AddWithValue("@estado", cja.Estado);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                cajaSaved = true;

            }
            catch (Exception ex)
            {
                cajaSaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        //anular caja:
        public void BD_Anular_Mov_Caja(string nroDoc, string estadoCaja)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_anular_moviCaja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroDoc", nroDoc);
                cmd.Parameters.AddWithValue("@estadocaja", estadoCaja);               


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                cajaSaved = true;

            }
            catch (Exception ex)
            {
                cajaSaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        //1:
        public static double BD_Leer_Suma_TotalGanancias_delMes(DateTime fecha1)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Sumar_Ganancias_porMes", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechas", fecha1);
                double TipoCambio;

                cn.Open();
                if (Convert.IsDBNull(cmd.ExecuteScalar()) == true)
                {
                    TipoCambio = 0;
                }
                else
                {
                    TipoCambio = Convert.ToDouble(cmd.ExecuteScalar());
                }

                cn.Close();
                return TipoCambio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (cn.State == ConnectionState.Open) cn.Close();
                cn.Dispose();
                cn = null;
                return 0;
            }
        }


        public static double BD_Leer_Suma_TotalGanancias_poraño(DateTime fecha1)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Sumar_Ganancias_poraño", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechas", fecha1);
                double TipoCambio;

                cn.Open();
                if (Convert.IsDBNull(cmd.ExecuteScalar()) == true)
                {
                    TipoCambio = 0;
                }
                else
                {
                    TipoCambio = Convert.ToDouble(cmd.ExecuteScalar());
                }

                cn.Close();
                return TipoCambio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (cn.State == ConnectionState.Open) cn.Close();
                cn.Dispose();
                cn = null;
                return 0;
            }
        }

    }
}
