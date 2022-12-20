using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsell_Lite.Utilitarios;

namespace Microsell_Lite.BaseDatos
{
    public partial class RestoreBD : Form
    {
        
        public RestoreBD()
        {
            InitializeComponent();           
        }
        Timer t = new Timer();

        double pbUnit;
        int pbWIDTH, pbHEIGHT, pbComplete;

        Bitmap bmp;
        Graphics g;
       

        SqlConnection con = new SqlConnection("Data Source =PROGAMADOR\\SQLEXPRESS;Initial Catalog =ALMACEN; User ID=sa;Password=SamiTask2021@*");
                  
         
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void RestoreBD_Load(object sender, EventArgs e)
        {
            
        }

        private void progressbar1()
        {
            pbWIDTH = pic_box.Width;
            pbHEIGHT = pic_box.Height;

            pbUnit = pbWIDTH / 100.0;

            pbComplete = 0;
            bmp = new Bitmap(pbWIDTH, pbHEIGHT);

            //timer
            t.Interval = 50;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();

            
        }
        private void t_Tick(object sender,EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Msm_Bueno ver2 = new Frm_Msm_Bueno();

            g = Graphics.FromImage(bmp);
            g.Clear(Color.GreenYellow);
            g.FillRectangle(Brushes.CornflowerBlue,new Rectangle(0,0,(int)(pbComplete*pbUnit),pbHEIGHT));
            g.DrawString(pbComplete+"%",new Font("Arial",pbHEIGHT/2),Brushes.Black,new PointF(pbWIDTH/2-pbHEIGHT,pbHEIGHT/10));

            pic_box.Image = bmp;

            pbComplete++;

            if (pbComplete > 100)
            {
                g.Dispose();
                t.Stop();

                fil.Show();
                ver2.Lbl_msm1.Text = "La Base de Datos Se Limpio Correctamente";
                ver2.ShowDialog();
                fil.Hide();
               
            }
        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txt_ubi.Text = dlg.SelectedPath;
                btn_Guardar.Enabled = true;
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ver2 = new Frm_Msm_Bueno();

            string database = con.Database.ToString();
            if (txt_ubi.Text==string.Empty)
            {
                

                fil.Show();
                ver.lbl_msm1.Text = "Ingresa la Ubicacion en donde desea Guardar";
                ver.ShowDialog();
                fil.Hide();
            }
            else
            {
                string cmd = "BACKUP DATABASE [" + database + "] TO DISK= '" + txt_ubi.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                con.Open();
                SqlCommand command = new SqlCommand(cmd,con);
                command.ExecuteNonQuery();

                fil.Show();
                ver2.Lbl_msm1.Text = "El Backup de la Base de Datos se Genero Correctamente";
                ver2.ShowDialog();
                fil.Hide();

                con.Close();
                btn_Guardar.Enabled = false;

                txt_ubi.Text = "";
                
            }
        }

        private void elButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                txtubi2.Text = dlg.FileName;
                btn_rest.Enabled = true;
            }
        }

        private void btn_rest_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            con.Open();

            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();
            Frm_Msm_Bueno ver2 = new Frm_Msm_Bueno();

            try
            {
                string str1 = string.Format("ALTER DATABASE["+database+"] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(str1,con);
                cmd1.ExecuteNonQuery();

                string str2 = "USE MASTER RESTORE DATABASE [" + database +"] FROM DISK='"+txtubi2.Text+"' WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(str2,con);
                cmd2.ExecuteNonQuery();

                string str3 = string.Format("ALTER DATABASE ["+database+"] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str3,con);
                cmd3.ExecuteNonQuery();

                fil.Show();
                ver2.Lbl_msm1.Text = "La Base de Datos se Restauro Correctamente";
                ver2.ShowDialog();
                fil.Hide();

                con.Close();

                txtubi2.Text = "";
            }
            catch (Exception)
            {

                throw;
            }
        }

       private void Limpiar_Datos()
        {
            con.Open();
            string query23 = "DBCC CHECKIDENT (Distrito, RESEED, 3)";
            string query22 = "DBCC CHECKIDENT (Categorias, RESEED, 0)";
            string query21 = "DBCC CHECKIDENT (Marcas, RESEED, 0)";
            string query20 = "DELETE FROM Caja";
            string query19 = "DELETE FROM Cierre_Caja";
            string query18 = "DELETE FROM Detalle_Temporal";
            string query17 = "DELETE FROM Temporal";
            string query14 = "DELETE FROM DocumentoCompras";
            string query13 = "DELETE FROM Detalle_DocumCompra";
            string query12 = "DELETE FROM Detalle_Kardex";
            string query11 = "DELETE FROM KardexProducto";
            string query15 = "DELETE FROM Marcas";
            string query16 = "DELETE FROM Proveedor";
            string query10 = "DELETE FROM Productos";
            string query9 = "DELETE FROM Categorias";
            string query8 = "DELETE FROM Cotizacion";
            string query7 = "DELETE FROM Detalle_Credito";
            string query6 = "DELETE FROM Credito";
            string query5 = "DELETE FROM Documento";
            string query1 = "DELETE FROM Detalle_Pedido";
            string query = "DELETE FROM Pedido";
            string query2 = "DELETE FROM Cliente";
            //string query3 = "DELETE FROM Distrito";    
            string query4 = "DELETE FROM Menu_xUsu";
            SqlCommand cmd23 = new SqlCommand(query23, con);
            SqlCommand cmd22 = new SqlCommand(query22, con);
            SqlCommand cmd21 = new SqlCommand(query21, con);
            SqlCommand cmd20 = new SqlCommand(query20, con);
            SqlCommand cmd19 = new SqlCommand(query19, con);
            SqlCommand cmd18 = new SqlCommand(query18, con);
            SqlCommand cmd17 = new SqlCommand(query17, con);
            SqlCommand cmd12 = new SqlCommand(query12, con);
            SqlCommand cmd11 = new SqlCommand(query11, con);
            SqlCommand cmd13 = new SqlCommand(query13, con);
            SqlCommand cmd15 = new SqlCommand(query15, con);
            SqlCommand cmd14 = new SqlCommand(query14, con);
            SqlCommand cmd16 = new SqlCommand(query16, con);
            SqlCommand cmd10 = new SqlCommand(query10, con);
            SqlCommand cmd9 = new SqlCommand(query9, con);
            SqlCommand cmd8 = new SqlCommand(query8, con);
            SqlCommand cmd7 = new SqlCommand(query7, con);
            SqlCommand cmd6 = new SqlCommand(query6, con);
            SqlCommand cmd5 = new SqlCommand(query5, con);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            //SqlCommand cmd3 = new SqlCommand(query3, con);
            SqlCommand cmd4 = new SqlCommand(query4, con);
            cmd23.ExecuteNonQuery();
            cmd22.ExecuteNonQuery();
            cmd21.ExecuteNonQuery();
            cmd20.ExecuteNonQuery();
            cmd19.ExecuteNonQuery();
            cmd18.ExecuteNonQuery();
            cmd17.ExecuteNonQuery();
            cmd16.ExecuteNonQuery();
            cmd15.ExecuteNonQuery();
            cmd14.ExecuteNonQuery();
            cmd13.ExecuteNonQuery();
            cmd12.ExecuteNonQuery();
            cmd11.ExecuteNonQuery();
            cmd10.ExecuteNonQuery();
            cmd9.ExecuteNonQuery();
            cmd8.ExecuteNonQuery();
            cmd7.ExecuteNonQuery();
            cmd6.ExecuteNonQuery();
            cmd5.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            //cmd3.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();
            con.Close();
        }
        private void elButton1_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();            
            Frm_Msm_Bueno ver2 = new Frm_Msm_Bueno();
            try
            {
                Limpiar_Datos();

                //Progressbar();

                progressbar1();
                
                
                //progressBar1.Value=progressBar1.Minimum;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
