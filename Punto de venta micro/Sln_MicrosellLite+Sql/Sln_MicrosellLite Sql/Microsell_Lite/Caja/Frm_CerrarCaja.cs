using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using Microsell_Lite.Utilitarios;
using Microsell_Lite.Informe;

namespace Microsell_Lite.Caja
{
    public partial class Frm_CerrarCaja : Form
    {
        public Frm_CerrarCaja()
        {
            InitializeComponent();
        }

        private void Pnl_Titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario ui = new Utilitario();
            if (e.Button ==MouseButtons.Left )
            {
                ui.Mover_formulario(this);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Frm_CerrarCaja_Load(object sender, EventArgs e)
        {
            Listar_Caja_delDia();
            Buscar_Caja_porBoleta();
            Buscar_Caja_porFactura();
            Buscar_Caja_porNota();
            Buscar_Caja_porOtrosIngresos();
            Buscar_Caja_porAbono();
            Buscar_Caja_porDeposito();
            Buscar_Ventas_aCredito();
            //salidas
            Buscar_Salidas_Deposito();
            Buscar_Salidas_Efectivo();
            Calcular_Ganacias_delDia();
        }
        
        private void Listar_Caja_delDia()
        {
            DataTable dato = new DataTable();
            RN_Cierre_Caja obj = new RN_Cierre_Caja();

            try
            {
                dato = obj.RN_Listar_Cierre_Caja_DelDia();
                if (dato.Rows.Count >0)
                {
                    lbl_idcaja.Text = dato.Rows[0]["Id_cierre"].ToString();
                    Lbl_aperturaCaja.Text= dato.Rows[0]["Apertura_Caja"].ToString();
                    Lbl_estado.Text= dato.Rows[0]["Estado_cierre"].ToString();
                    Lbl_fechaCaja.Text= dato.Rows[0]["Fecha_Cierre"].ToString();

                    if (Lbl_estado.Text.Trim()=="Cerrado")
                    {
                        btn_aceptar.Enabled = false;
                    }
                    else
                    {
                        btn_aceptar.Enabled = true;
                    }

                }
                else
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Advertencia ver = new Frm_Advertencia();

                    fil.Show();
                    ver.lbl_msm1.Text = "Por Favor, Tienes que Iniciar Caja, para poder Acceder al Cierre";
                    ver.ShowDialog();
                    fil.Hide();

                    btn_aceptar.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: "+ex.Message,"Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void Buscar_Caja_porBoleta()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Doc("Boleta");
            if (dato.Rows.Count >0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);                

                }
                Lbl_Efectivo_boleta.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_Efectivo_boleta.Text = "00";
            }
        }

        private void Buscar_Caja_porFactura()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Doc("Factura");
            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_Efectivo_factura.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_Efectivo_factura.Text = "00";
            }
        }

        private void Buscar_Caja_porNota()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Doc("Nota Venta");
            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_Efectivo_Notas.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_Efectivo_Notas.Text = "00";
            }
        }

        private void Buscar_Caja_porOtrosIngresos()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Doc("Otros");
            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_otroIngresoEfectivo.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_otroIngresoEfectivo.Text = "00";
            }
            
            }

        private void Buscar_Caja_porAbono()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ventas_PorTipo_Doc("Abono");
            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_CreditoAbonado.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_CreditoAbonado.Text = "00";
            }

        }

        private void Buscar_Caja_porDeposito()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_ventas_ADeposito();
            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_Ingreso_Deposito.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_Ingreso_Deposito.Text = "00";
            }

        }

        private void Buscar_Ventas_aCredito()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_ventas_Acredito();
            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_TotalCreditos.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_TotalCreditos.Text = "00";
            }

        }

        private void Buscar_Salidas_Efectivo()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Gastos_porTipoPago("Efectivo");
            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                Lbl_SalidaEfectivo.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_SalidaEfectivo.Text = "00";
            }

        }

        private void Buscar_Salidas_Deposito()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Gastos_porTipoPago("Deposito");
            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["ImporteCaja"]);

                }
                lbl_SalienDeposi.Text = subImporte.ToString("###0.00");
            }
            else
            {
                lbl_SalienDeposi.Text = "00";
            }

        }

        private void Calcular_Ganacias_delDia()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            DataTable dato = new DataTable();

            double subImporte = 0;

            dato = obj.RN_Calcular_Ganancias_deldia();
            if (dato.Rows.Count > 0)
            {
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];

                    subImporte = subImporte + Convert.ToDouble(dr["TotalUti"]);

                }
                Lbl_UtilidadTotal.Text = subImporte.ToString("###0.00");
            }
            else
            {
                Lbl_UtilidadTotal.Text = "00";
            }

        }

        private void Btn_calcular_Click(object sender, EventArgs e)
        {
            double xxtotalingreso = 0;
            double xxtotalegreso = 0;
            double ingresobruto = 0;

            double ventaTotalNeto = 0;

            try
            {
                //total ingreso bruto
                ingresobruto = Convert.ToDouble(Lbl_Efectivo_boleta.Text) + Convert.ToDouble(Lbl_Efectivo_factura.Text) + Convert.ToDouble(Lbl_Efectivo_Notas.Text) + Convert.ToDouble(Lbl_otroIngresoEfectivo.Text) + Convert.ToDouble(Lbl_CreditoAbonado.Text);
                Lbl_totalIngreso.Text = ingresobruto.ToString("###0.00");

                xxtotalingreso = ingresobruto + Convert.ToDouble(Lbl_aperturaCaja.Text);
                lbl_totalingre_bruto.Text = xxtotalingreso.ToString("###0.00");

                //salidasxx

                xxtotalegreso = Convert.ToDouble(Lbl_SalidaEfectivo.Text);
                Lbl_Total_Salida.Text =Convert.ToString( xxtotalegreso + Convert.ToDouble(lbl_SalienDeposi.Text));
                lbl_xTotalEgreso.Text= Convert.ToString(xxtotalegreso + Convert.ToDouble(lbl_SalienDeposi.Text));

                //ahora el neto
                ventaTotalNeto = Convert.ToDouble(lbl_totalingre_bruto.Text)- Convert.ToDouble(Lbl_Total_Salida.Text);
                lbl_IngresoEfectivo_Neto.Text = ventaTotalNeto.ToString("###0.00");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txt_totalEntregar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                double saldonext = 0;

                saldonext = Convert.ToDouble(lbl_IngresoEfectivo_Neto.Text)-Convert.ToDouble(txt_totalEntregar.Text);
                txt_SaldoNext.Text = saldonext.ToString("###0.00");
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            guardar_cierre_caja();
        }

        private void guardar_cierre_caja()
        {
            RN_Cierre_Caja obj = new RN_Cierre_Caja();
            EN_CierreCaja ci = new EN_CierreCaja();

            try
            {
                ci.Idcierre = lbl_idcaja.Text;
                ci.AperturCaja = Convert.ToDouble(Lbl_aperturaCaja.Text);
                ci.TotalIngreso= Convert.ToDouble(Lbl_totalIngreso.Text);
                ci.TotalEgreso= Convert.ToDouble(Lbl_Total_Salida.Text);
                ci.IdUsu= Convert.ToInt32(Cls_Libreria.IdUsu);
                ci.TotalDeposito= Convert.ToDouble(Lbl_Ingreso_Deposito.Text);
                ci.TotalGanancia= Convert.ToDouble(Lbl_UtilidadTotal.Text);
                ci.TotalEntregado= Convert.ToDouble(txt_totalEntregar.Text);
                ci.SaldoSiguiente= Convert.ToDouble(txt_SaldoNext.Text);
                ci.TotalBoleta= Convert.ToDouble(Lbl_Efectivo_boleta.Text);
                ci.TotalFactura= Convert.ToDouble(Lbl_Efectivo_factura.Text);
                ci.TotalNota= Convert.ToDouble(Lbl_Efectivo_Notas.Text);
                ci.TotalCreditoCobrado= Convert.ToDouble(Lbl_CreditoAbonado.Text);
                ci.TotalCreditoEmitido= Convert.ToDouble(Lbl_TotalCreditos.Text);

                obj.RN_registrar_Cierrede_Caja(ci);

                if (BD_Cierre_Caja.saved==true)
                {
                    Frm_Filtro fil = new Frm_Filtro();
                    Frm_Msm_Bueno ver = new Frm_Msm_Bueno();

                    fil.Show();
                    ver.Lbl_msm1.Text = "El Cierre de Caja se ha Guardado Correctamente";
                    ver.ShowDialog();
                    fil.Hide();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Frm_CerrarCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {

        }
    }
}
