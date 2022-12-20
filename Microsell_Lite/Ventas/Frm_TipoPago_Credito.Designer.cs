
namespace Microsell_Lite.Ventas
{
    partial class Frm_TipoPago_Credito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TipoPago_Credito));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SaldoACuenta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_FechaVen = new System.Windows.Forms.DateTimePicker();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btn_procesar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.elButton1 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.lbl_TotalVenta = new System.Windows.Forms.Label();
            this.lbl_saldoPagarCred = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_procesar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.label2);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(324, 51);
            this.pnl_titu.TabIndex = 2;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(70, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Venta a Credito";
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(282, 9);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(31, 30);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 39);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Venta S/.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(324, 39);
            this.label4.TabIndex = 6;
            this.label4.Text = "A Cuenta S/.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_SaldoACuenta
            // 
            this.txt_SaldoACuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SaldoACuenta.Location = new System.Drawing.Point(111, 182);
            this.txt_SaldoACuenta.Name = "txt_SaldoACuenta";
            this.txt_SaldoACuenta.Size = new System.Drawing.Size(100, 29);
            this.txt_SaldoACuenta.TabIndex = 1;
            this.txt_SaldoACuenta.Text = "0";
            this.txt_SaldoACuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_SaldoACuenta.TextChanged += new System.EventHandler(this.txt_SaldoACuenta_TextChanged);
            this.txt_SaldoACuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SaldoACuenta_KeyPress);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(324, 39);
            this.label5.TabIndex = 8;
            this.label5.Text = "Saldo S/.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-1, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(324, 39);
            this.label6.TabIndex = 9;
            this.label6.Text = "Vencimiento:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(19, 378);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(294, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "(*) A cuenta no debe de ser superior a Total";
            this.label7.Visible = false;
            // 
            // dtp_FechaVen
            // 
            this.dtp_FechaVen.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_FechaVen.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtp_FechaVen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaVen.Location = new System.Drawing.Point(99, 338);
            this.dtp_FechaVen.Name = "dtp_FechaVen";
            this.dtp_FechaVen.Size = new System.Drawing.Size(116, 25);
            this.dtp_FechaVen.TabIndex = 491;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 399);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(324, 35);
            this.bunifuSeparator1.TabIndex = 492;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // btn_procesar
            // 
            this.btn_procesar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_procesar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_procesar.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_procesar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_procesar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_procesar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_procesar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_procesar.BorderStyle.EdgeRadius = 7;
            this.btn_procesar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_procesar.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_procesar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_procesar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_procesar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_procesar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_procesar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_procesar.Location = new System.Drawing.Point(163, 429);
            this.btn_procesar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_procesar.Name = "btn_procesar";
            this.btn_procesar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_procesar.Size = new System.Drawing.Size(148, 38);
            this.btn_procesar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_procesar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_procesar.TabIndex = 2;
            this.btn_procesar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_procesar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_procesar.TextStyle.Text = "Listo";
            this.btn_procesar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_procesar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_procesar.Click += new System.EventHandler(this.btn_procesar_Click);
            // 
            // elButton1
            // 
            this.elButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.elButton1.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elButton1.BackgroundStyle.SolidColor = System.Drawing.Color.Red;
            this.elButton1.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elButton1.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elButton1.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elButton1.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.elButton1.BorderStyle.EdgeRadius = 7;
            this.elButton1.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.elButton1.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.elButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.elButton1.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.elButton1.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elButton1.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elButton1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.elButton1.Location = new System.Drawing.Point(4, 429);
            this.elButton1.Margin = new System.Windows.Forms.Padding(4);
            this.elButton1.Name = "elButton1";
            this.elButton1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.elButton1.Size = new System.Drawing.Size(148, 38);
            this.elButton1.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.elButton1.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.elButton1.TabIndex = 3;
            this.elButton1.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elButton1.TextStyle.ForeColor = System.Drawing.Color.White;
            this.elButton1.TextStyle.Text = "Cancelar";
            this.elButton1.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.elButton1.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.elButton1.Click += new System.EventHandler(this.elButton1_Click);
            // 
            // lbl_TotalVenta
            // 
            this.lbl_TotalVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_TotalVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lbl_TotalVenta.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_TotalVenta.Location = new System.Drawing.Point(111, 99);
            this.lbl_TotalVenta.Name = "lbl_TotalVenta";
            this.lbl_TotalVenta.Size = new System.Drawing.Size(100, 23);
            this.lbl_TotalVenta.TabIndex = 495;
            this.lbl_TotalVenta.Text = "00.00";
            this.lbl_TotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_saldoPagarCred
            // 
            this.lbl_saldoPagarCred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_saldoPagarCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lbl_saldoPagarCred.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_saldoPagarCred.Location = new System.Drawing.Point(111, 261);
            this.lbl_saldoPagarCred.Name = "lbl_saldoPagarCred";
            this.lbl_saldoPagarCred.Size = new System.Drawing.Size(100, 23);
            this.lbl_saldoPagarCred.TabIndex = 496;
            this.lbl_saldoPagarCred.Text = "00.00";
            this.lbl_saldoPagarCred.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_TipoPago_Credito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(324, 486);
            this.Controls.Add(this.lbl_saldoPagarCred);
            this.Controls.Add(this.lbl_TotalVenta);
            this.Controls.Add(this.elButton1);
            this.Controls.Add(this.btn_procesar);
            this.Controls.Add(this.txt_SaldoACuenta);
            this.Controls.Add(this.dtp_FechaVen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.bunifuSeparator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_TipoPago_Credito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Pago a Credito";
            this.Load += new System.EventHandler(this.Frm_TipoPago_Credito_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_procesar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton elButton1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_procesar;
        internal System.Windows.Forms.TextBox txt_SaldoACuenta;
        internal System.Windows.Forms.DateTimePicker dtp_FechaVen;
        internal System.Windows.Forms.Label lbl_TotalVenta;
        internal System.Windows.Forms.Label lbl_saldoPagarCred;
        private System.Windows.Forms.Button btn_cerrar;
    }
}