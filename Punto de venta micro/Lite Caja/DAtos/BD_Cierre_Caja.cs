using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Entidad;

using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
   public  class BD_Cierre_Caja : BDConexion 
    {
        public static bool saved = false ;

        public void BD_registrar_Inicio_Caja(EN_cierre_Caja cli)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Reg_Cierre_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCierre", cli.Idcierre);
                cmd.Parameters.AddWithValue("@Apertura_Caja", cli.AperturaCaja);
                cmd.Parameters.AddWithValue("@Total_Ingreso", cli.TotalIngreso);
                cmd.Parameters.AddWithValue("@TotalEgreso", cli.TotalEgreso);
                cmd.Parameters.AddWithValue("@Id_usu", cli.IdUsu);
                cmd.Parameters.AddWithValue("@TodoDeposito", cli.Totaldeposito);
                cmd.Parameters.AddWithValue("@TotalGanancia", cli.TotalGanancia);
                cmd.Parameters.AddWithValue("@TotalEntregado", cli.Totalentregado);
                cmd.Parameters.AddWithValue("@SaldoSiguiente", cli.SaldoSiguiente);
                cmd.Parameters.AddWithValue("@TotalFactura", cli.TotalFactura);
                cmd.Parameters.AddWithValue("@TotalBoleta", cli.Totalboleta);
                cmd.Parameters.AddWithValue("@Totalnota", cli.TotalNota);
                cmd.Parameters.AddWithValue("@TotalCreditoCobrado", cli.TotalCreditoCobrado);
                cmd.Parameters.AddWithValue("@TotalCreditoEmitido", cli.TotalCreditoEmitido);               


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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        public void BD_registrar_Cierrede_Caja(EN_cierre_Caja cli)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_Cierre_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCIERRE", cli.Idcierre);
                cmd.Parameters.AddWithValue("@Apertura_Caja", cli.AperturaCaja);
                cmd.Parameters.AddWithValue("@Total_Ingreso", cli.TotalIngreso);
                cmd.Parameters.AddWithValue("@TotalEgreso", cli.TotalEgreso);
                cmd.Parameters.AddWithValue("@Id_usu", cli.IdUsu);
                cmd.Parameters.AddWithValue("@TodoDeposito", cli.Totaldeposito);
                cmd.Parameters.AddWithValue("@TotalGanancia", cli.TotalGanancia);
                cmd.Parameters.AddWithValue("@TotalEntregado", cli.Totalentregado);
                cmd.Parameters.AddWithValue("@SaldoSiguiente", cli.SaldoSiguiente);
                cmd.Parameters.AddWithValue("@TotalFactura", cli.TotalFactura);
                cmd.Parameters.AddWithValue("@TotalBoleta", cli.Totalboleta);
                cmd.Parameters.AddWithValue("@Totalnota", cli.TotalNota);
                cmd.Parameters.AddWithValue("@TotalCreditoCobrado", cli.TotalCreditoCobrado);
                cmd.Parameters.AddWithValue("@TotalCreditoEmitido", cli.TotalCreditoEmitido);
                

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }




        public DataTable BD_Listar_Cierre_Caja_DelDia(DateTime mes)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_delDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", mes);
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


        public DataTable BD_Listar_Cierre_Caja_DelMes(DateTime mes)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_delMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", mes);
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




        //validar:
        public bool BD_validar_InicioDoble_caja()
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {

                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();

                cmd.CommandText = "SP_VALIDAR_REGISTRO_CAJA";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros:
                //cmd.Parameters.AddWithValue("@Usuario", usu);
                //cmd.Parameters.AddWithValue("@Contraseña", clave);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }

            return respuesta;

        }


        //======================0 metodos para calcular las ventas del dia:
        public DataTable BD_Calcular_Ventas_PorTipo_Doc(string nomTipoDoc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_PorTipoDoc", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipodoc", nomTipoDoc);
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



        public DataTable BD_Calcular_Gastos_porTipoPago(string tipopago)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Gastos_porTipoPago", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipopago", tipopago);
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

        } //aqui



        public DataTable BD_Calcular_ventas_Acredito()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_aCredito", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@tipopago", tipopago);
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

        } //aqui



        public DataTable BD_Calcular_ventas_ADeposito()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_aDeposito", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@tipopago", tipopago);
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

        } //aqui



        public DataTable BD_Calcular_Ganancias_deldia()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_GananciadelDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@tipopago", tipopago);
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

        } //aqui

    }
}
