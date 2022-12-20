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
using Microsell_Lite.Ventas;
using ThoughtWorks.QRCode.Codec;
using System.IO;

namespace Microsell_Lite.Creditos
{
    public partial class Frm_abonarCred : Form
    {
        public Frm_abonarCred()
        {
            InitializeComponent();
        }

        private void Frm_abonarCred_Load(object sender, EventArgs e)
        {
            dtp_fechapago.Value = dtp_Hoy.Value;
            Buscar_credito(this.Tag.ToString());
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
        private void Buscar_credito(string idCliente)
        {
            RN_Credito obj = new RN_Credito();
            DataTable data = new DataTable();
       

            try
            {
                data = obj.RN_Listar_Creditos_porValor(idCliente);
                if (data.Rows.Count > 0)
                {
                    lbl_idcredito.Text = Convert.ToString(data.Rows[0]["IdNotaCred"]);
                    lbl_clien.Text = Convert.ToString(data.Rows[0]["Nom_Cliente"]);
                    lbl_idDoc.Text  = Convert.ToString(data.Rows[0]["Id_Doc"]);
                    txt_totalcred .Text = Convert.ToString(data.Rows[0]["Total_Cre"]);
                    txt_saldocred.Text  = Convert.ToString(data.Rows[0]["Saldo_Pdnte"]);                  

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void txt_acuenta_TextChanged(object sender, EventArgs e)
        {
            txt_acuenta.Text = txt_acuenta.Text.Replace(",", ".");            

            try
            {
                double newsaldo = 0;
                newsaldo = Convert.ToDouble(txt_saldocred.Text) - Convert.ToDouble(txt_acuenta.Text);
                txt_newsaldo.Text = newsaldo.ToString("###0.00");
                if (newsaldo == 0)
                {
                    lbl_estado.Text = "Cancelado";
                }
                else
                {
                    lbl_estado.Text = "Pendiente";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbo_tipopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipopago.SelectedIndex == 1)
            {
                txt_nroOperacion.Enabled = true;
                txt_nroOperacion.Focus();
            }
            else
            {
                txt_nroOperacion.Enabled = false;
                txt_nroOperacion.Text = "-";
            }
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            RN_Credito obj = new RN_Credito();
            EN_DetCredito det = new EN_DetCredito();
            RN_Caja objca = new RN_Caja();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Print_NotaVenta prin = new Frm_Print_NotaVenta();
            Frm_Advertencia ver = new Frm_Advertencia();
            EN_Caja cj = new EN_Caja();
            RN_Temporal objre = new RN_Temporal();

            if (txt_acuenta.Text.Trim().Length == 0) { fil.Show(); ver.lbl_msm1.Text = "Ingresa el Importe a Abonar"; ver.ShowDialog(); fil.Hide(); txt_acuenta.Focus(); return; }
            //if (Convert.ToDouble(txt_acuenta.Text) == 0) { fil.Show(); ver.lbl_msm1.Text = "El Importe a Abonar Debe Ser Mayor a Cero"; ver.ShowDialog(); fil.Hide(); txt_acuenta.Focus(); return; }
            if (cbo_tipopago.SelectedIndex == -1) { fil.Show(); ver.lbl_msm1.Text = "Elige un Tipo de Pago"; ver.ShowDialog(); fil.Hide(); cbo_tipopago.Focus(); return; }

            if (Convert.ToDouble(txt_acuenta.Text) > Convert.ToDouble(txt_saldocred.Text)) { fil.Show(); ver.lbl_msm1.Text = "El Importe a Cuenta no debe, Ni debe ser MAYOR a Total a Pagar"; ver.ShowDialog(); fil.Hide(); txt_acuenta.Focus(); return; }

            try
            {
                obj.RN_Abonar_Credito(lbl_idcredito.Text, Convert.ToDouble(txt_newsaldo.Text), lbl_estado.Text);

                if (BD_Credito.Credsaved == true)
                {
                    det.IdNotaCredito = lbl_idcredito.Text;
                    det.Acuenta = Convert.ToDouble(txt_acuenta.Text);
                    det.SaldoActual = Convert.ToDouble(txt_newsaldo.Text);
                    det.FechaPago = dtp_fechapago.Value;
                    det.TipoPago = cbo_tipopago.Text;
                    det.NroOpera = txt_nroOperacion.Text;
                    det.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);

                    obj.RN_Registrar_Detalle_Credito(det);

                    if (BD_Credito.CredDetsaved == true)
                    {
                        //Ahora Creamos un Movimiento de Caja:
                        Guardar_IngresoCaja();

                        //imprimir:
                        //objre.RN_Eliminar_Temporal(lbl_idDoc.Text);
                        //Registrar_archivos_Temporales();



                        Frm_Print_NotaVenta nota = new Frm_Print_NotaVenta();

                        fil.Show();
                        nota.lbl_nroDoc.Text = "Nota Venta : " + lbl_idDoc.Text;
                        nota.Tag = lbl_idcredito.Text;
                        nota.ShowDialog();
                        fil.Hide();

                        this.Tag = "A";
                        this.Close();
                    }


                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        //private void Registrar_Archivos_Temporales()
        //{
        //    RN_Temporal obj = new RN_Temporal();
        //    EN_Temporal tem = new EN_Temporal();
        //    EN_Det_Temporal det = new EN_Det_Temporal();

        //    string dias = dtp_fechapago.Value.Day.ToString();
        //    string mes = dtp_fechapago.Value.Month.ToString();
        //    string año = dtp_fechapago.Value.Year.ToString();

        //    int totalEspacio = 0;
        //    int totalFila = .Items.Count;

        //    try
        //    {
        //        tem.IdTemporal = txt_NroDoc.Text;
        //        tem.FechaEmi = dtp_FechaEmi.Value.ToString();
        //        tem.NomCliente = txt_cliente.Text;
        //        tem.Ruc = lbl_Dni.Text;
        //        tem.Direccion = lbl_Direccion.Text;
        //        tem.SubTotal = lbl_subtotal.Text;
        //        tem.Igv = lbl_igv.Text;
        //        tem.Total = lbl_TotalPagar.Text;
        //        tem.Sonletra = lbl_son.Text;
        //        tem.Vendedor = Cls_Libreria.Nombres;

        //        obj.RN_Registrar_Temporal(tem);

        //        if (BD_Temporal.saved == true)
        //        {
        //            //guardar el detalle
        //            for (int i = 0; i < lsv_Det.Items.Count; i++)
        //            {
        //                var lis = lsv_Det.Items[i];


        //                det.IdTempo = txt_NroDoc.Text;
        //                det.CodProd = lis.SubItems[0].Text;
        //                det.Canti = lis.SubItems[2].Text;
        //                det.Producto = lis.SubItems[1].Text;
        //                det.Precio = lis.SubItems[3].Text;
        //                det.Importe = lis.SubItems[4].Text;
        //                obj.RN_Registrar_DetTemporal(det);
        //            }


        //            int veces = 0;
        //            totalEspacio = 11 - totalFila;//8
        //            if (totalEspacio < 11)
        //            {
        //                for (int x = 1; x <= totalEspacio; x++)
        //                {
        //                    det.IdTempo = txt_NroDoc.Text;
        //                    det.CodProd = "";
        //                    det.Canti = "";
        //                    det.Producto = "";
        //                    det.Precio = "";
        //                    det.Importe = "";

        //                    obj.RN_Registrar_DetTemporal(det);
        //                }
        //                veces += 1;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}


        private void Guardar_IngresoCaja()
        {

            RN_Caja obj = new RN_Caja();
            EN_Caja cja = new EN_Caja();

            try
            {
                cja.Fecha_Caja = dtp_fechapago.Value;
                cja.Tipo_Caja = "Entrada";
                cja.Concepto = "Abono de Credito, "+lbl_idcredito.Text;
                cja.DePara_Cliente = lbl_clien.Text;
                cja.Nr_Documento = lbl_idDoc.Text;
                cja.ImporteCaja = Convert.ToDouble(txt_acuenta.Text);
                cja.Idusu = Convert.ToInt32(Cls_Libreria.IdUsu);
                cja.TotalUtilidad = 0;
                cja.TipoPago = cbo_tipopago.Text;
                cja.GeneradoPor = "Abono";
                obj.RN_Registrar_Mov_Caja(cja);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }



        public void GenerarQR(string tipodoc, string totalDoc, string Cliente, string nroDoc, string rutaqr)
        {
            QRCodeEncoder generarCodigoQR = new QRCodeEncoder();
            generarCodigoQR.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            generarCodigoQR.QRCodeScale = Int32.Parse("4");

            try
            {
                generarCodigoQR.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //La versión "0" calcula automáticamente el tamaño
                generarCodigoQR.QRCodeVersion = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Generar QR 1: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //' -----------------------------------------------------
            string contenido;
            contenido = "Nro: " + nroDoc + "\r\n" + "Documento: " + tipodoc + "\r\n" + "Total: " + totalDoc + "\r\n" + "Cliente: " + Cliente;

            System.Drawing.Bitmap imgQR;

            try
            {

                imgQR = new System.Drawing.Bitmap(generarCodigoQR.Encode(contenido, System.Text.Encoding.UTF8));
                pic_qr.Image = imgQR;
                // imgQR.Save(rutaqr); //'Aqui Guarda la Primera Imagen QR en .BMP
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Generar QR 2: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        public static byte[] Convertir_Imagen_Bytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }

        private void Frm_abonarCred_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
