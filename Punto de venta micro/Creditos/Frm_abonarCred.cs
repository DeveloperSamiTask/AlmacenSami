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
                data = obj.RN_Listar_creditos_porValor(idCliente);
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
            //try
            //{
            //    double newsaldo = 0;
            //    newsaldo = Convert.ToDouble(txt_saldocred.Text) - Convert.ToDouble(txt_acuenta.Text);
            //    lbl_newsaldo.Text = newsaldo.ToString("###0.00");
            //    if (newsaldo ==0)
            //    {
            //        lbl_estado.Text = "Cancelado";
            //    }
            //    else
            //    {
            //        lbl_estado.Text = "Pendiente";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
          
        }

        private void cbo_tipopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbo_tipopago.SelectedIndex ==1)
            //{
            //    txt_nroOperacion.Enabled = true;
            //    txt_nroOperacion.Focus();
            //}
            //else
            //{
            //    txt_nroOperacion.Enabled = false;
            //    txt_nroOperacion.Text = "-";
            //}
        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            //RN_Credito obj = new RN_Credito();
            //EN_DetCredito det = new EN_DetCredito();
            //RN_CAja objca = new RN_CAja();
            //Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            //Frm_Filtro fil = new Frm_Filtro();
            //Frm_Print_NotaVenta prin = new Frm_Print_NotaVenta();
            //Frm_Advertencia ver = new Frm_Advertencia();
            //EN_Caja cj = new EN_Caja();

            //if (txt_acuenta.Text.Trim().Length ==0) { fil.Show(); ver.Lbl_Msm1.Text = "Ingresa el Importe a Abonar"; ver.ShowDialog(); fil.Hide(); txt_acuenta.Focus(); return; }
            //if ( Convert.ToDouble( txt_acuenta.Text) == 0) { fil.Show(); ver.Lbl_Msm1.Text = "El Importe a Abonar Debe Ser Mayor a Cero"; ver.ShowDialog(); fil.Hide(); txt_acuenta.Focus(); return; }
            //if (cbo_tipopago.SelectedIndex  == -1) { fil.Show(); ver.Lbl_Msm1.Text = "Elige un Tipo de Pago"; ver.ShowDialog(); fil.Hide(); cbo_tipopago.Focus(); return; }

            //try
            //{
            //    obj.RN_Abonar_Credito(lbl_idcredito.Text, Convert.ToDouble(lbl_newsaldo.Text), lbl_estado.Text);

            //    if (BD_Credito.credSaved ==true )
            //    {
            //        det.IdCredito = lbl_idcredito.Text;
            //        det.Acuenta = Convert.ToDouble(txt_acuenta.Text);
            //        det.SaldoActual = Convert.ToDouble(lbl_newsaldo.Text);
            //        det.FechaPago = dtp_fechapago.Value;
            //        det.TipoPago = cbo_tipopago.Text;
            //        det.NroOperacion = txt_nroOperacion.Text;
            //        det.IdUsu = Convert.ToInt32(Cls_Libreria.IdUsu);

            //        obj.RN_registrar_Detalle_Credito(det);

            //        if (BD_Credito.DetcredSaved ==true )
            //        {
            //            //Ahora Creamos un Movimiento de Caja:
            //            Guardar_IngresoCaja();

            //            //imprimir:
            //            Registrar_archivos_Temporales();

                        
            //            Frm_Print_NotaVenta nota = new Frm_Print_NotaVenta();

            //            fil.Show();
            //            nota.lbl_nroDoc.Text = "Nota Venta : " + lbl_idDoc.Text;
            //            nota.Tag = lbl_idcredito.Text;
            //            nota.ShowDialog();
            //            fil.Hide();

            //            this.Tag = "A";
            //            this.Close();
            //        }

                  
            //    }

                

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }


              

        private void Guardar_IngresoCaja()
        {

            //RN_CAja obj = new RN_CAja();
            //EN_Caja cja = new EN_Caja();

            //try
            //{
            //    cja.FechaCaja = dtp_fechapago.Value;
            //    cja.TipoCaja = "Entrada";
            //    cja.Concepto = "Abono de Credito";
            //    cja.DePara_Cliente = lbl_clien.Text;
            //    cja.Nr_Documento = lbl_idDoc.Text;
            //    cja.ImporteCaja = Convert.ToDouble(txt_acuenta.Text);
            //    cja.Idusu = Convert.ToInt32(Cls_Libreria.IdUsu);
            //    cja.TotalUtilidad = 0;
            //    cja.TipoPago = cbo_tipopago.Text;
            //    cja.GeneradoPor = "Abono";
            //    obj.RN_Registrar_Mov_Caja(cja);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}


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


    }
}
