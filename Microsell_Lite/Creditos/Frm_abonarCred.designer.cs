namespace Microsell_Lite.Creditos
{
    partial class Frm_abonarCred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_abonarCred));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_clien = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_totalcred = new Guna.UI.WinForms.GunaTextBox();
            this.txt_saldocred = new Guna.UI.WinForms.GunaTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_acuenta = new Guna.UI.WinForms.GunaTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_listo = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancel = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_tipopago = new Guna.UI.WinForms.GunaComboBox();
            this.txt_nroOperacion = new Guna.UI.WinForms.GunaTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_fechapago = new Guna.UI.WinForms.GunaDateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_idcredito = new System.Windows.Forms.Label();
            this.lbl_idDoc = new System.Windows.Forms.Label();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pic_qr = new System.Windows.Forms.PictureBox();
            this.txt_obs = new Guna.UI.WinForms.GunaTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtp_Hoy = new System.Windows.Forms.DateTimePicker();
            this.txt_newsaldo = new Guna.UI.WinForms.GunaTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_qr)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnl_titu;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.pictureBox1);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(454, 83);
            this.pnl_titu.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(192, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oxygen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(154, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Abonar Credito";
            // 
            // lbl_clien
            // 
            this.lbl_clien.Font = new System.Drawing.Font("Oxygen", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_clien.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_clien.Location = new System.Drawing.Point(13, 97);
            this.lbl_clien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_clien.Name = "lbl_clien";
            this.lbl_clien.Size = new System.Drawing.Size(412, 27);
            this.lbl_clien.TabIndex = 3;
            this.lbl_clien.Text = "Cliente";
            this.lbl_clien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(47, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total crédito";
            // 
            // txt_totalcred
            // 
            this.txt_totalcred.BackColor = System.Drawing.Color.Transparent;
            this.txt_totalcred.BaseColor = System.Drawing.Color.White;
            this.txt_totalcred.BorderColor = System.Drawing.Color.Silver;
            this.txt_totalcred.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_totalcred.Enabled = false;
            this.txt_totalcred.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_totalcred.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_totalcred.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_totalcred.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalcred.Location = new System.Drawing.Point(39, 173);
            this.txt_totalcred.Name = "txt_totalcred";
            this.txt_totalcred.PasswordChar = '\0';
            this.txt_totalcred.Radius = 10;
            this.txt_totalcred.Size = new System.Drawing.Size(114, 30);
            this.txt_totalcred.TabIndex = 5;
            this.txt_totalcred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_saldocred
            // 
            this.txt_saldocred.BackColor = System.Drawing.Color.Transparent;
            this.txt_saldocred.BaseColor = System.Drawing.Color.White;
            this.txt_saldocred.BorderColor = System.Drawing.Color.Silver;
            this.txt_saldocred.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_saldocred.Enabled = false;
            this.txt_saldocred.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_saldocred.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_saldocred.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_saldocred.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_saldocred.Location = new System.Drawing.Point(182, 173);
            this.txt_saldocred.Name = "txt_saldocred";
            this.txt_saldocred.PasswordChar = '\0';
            this.txt_saldocred.Radius = 10;
            this.txt_saldocred.Size = new System.Drawing.Size(114, 30);
            this.txt_saldocred.TabIndex = 7;
            this.txt_saldocred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(190, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Saldo a Pagar";
            // 
            // txt_acuenta
            // 
            this.txt_acuenta.BackColor = System.Drawing.Color.Transparent;
            this.txt_acuenta.BaseColor = System.Drawing.Color.White;
            this.txt_acuenta.BorderColor = System.Drawing.Color.Silver;
            this.txt_acuenta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_acuenta.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_acuenta.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_acuenta.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_acuenta.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_acuenta.Location = new System.Drawing.Point(39, 258);
            this.txt_acuenta.Name = "txt_acuenta";
            this.txt_acuenta.PasswordChar = '\0';
            this.txt_acuenta.Radius = 10;
            this.txt_acuenta.Size = new System.Drawing.Size(102, 36);
            this.txt_acuenta.TabIndex = 1;
            this.txt_acuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_acuenta.TextChanged += new System.EventHandler(this.txt_acuenta_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(39, 236);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Deja a Cuenta";
            // 
            // btn_listo
            // 
            this.btn_listo.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.BackgroundStyle.SolidColor = System.Drawing.Color.DodgerBlue;
            this.btn_listo.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_listo.BorderStyle.EdgeRadius = 7;
            this.btn_listo.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_listo.BorderStyle.SolidColor = System.Drawing.Color.DodgerBlue;
            this.btn_listo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_listo.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_listo.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_listo.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_listo.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.Location = new System.Drawing.Point(239, 456);
            this.btn_listo.Name = "btn_listo";
            this.btn_listo.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_listo.Size = new System.Drawing.Size(147, 49);
            this.btn_listo.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_listo.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Oxygen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_listo.TabIndex = 13;
            this.btn_listo.TextStyle.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listo.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_listo.TextStyle.Text = "Pagar";
            this.btn_listo.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_listo.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_listo.Click += new System.EventHandler(this.btn_listo_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancel.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancel.BorderStyle.EdgeRadius = 7;
            this.btn_cancel.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_cancel.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancel.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancel.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cancel.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.Location = new System.Drawing.Point(37, 456);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicSilver;
            this.btn_cancel.Size = new System.Drawing.Size(152, 49);
            this.btn_cancel.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancel.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Oxygen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.StateStyles.PressedStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancel.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_cancel.TabIndex = 12;
            this.btn_cancel.TextStyle.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.TextStyle.Text = "Cancelar";
            this.btn_cancel.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(46, 434);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(340, 16);
            this.bunifuSeparator1.TabIndex = 14;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(255, 236);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tipo Pago";
            // 
            // cbo_tipopago
            // 
            this.cbo_tipopago.BackColor = System.Drawing.Color.Transparent;
            this.cbo_tipopago.BaseColor = System.Drawing.Color.White;
            this.cbo_tipopago.BorderColor = System.Drawing.Color.Silver;
            this.cbo_tipopago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_tipopago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipopago.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_tipopago.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_tipopago.ForeColor = System.Drawing.Color.Black;
            this.cbo_tipopago.FormattingEnabled = true;
            this.cbo_tipopago.Items.AddRange(new object[] {
            "Efectivo",
            "Deposito"});
            this.cbo_tipopago.Location = new System.Drawing.Point(257, 268);
            this.cbo_tipopago.Name = "cbo_tipopago";
            this.cbo_tipopago.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cbo_tipopago.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_tipopago.Radius = 10;
            this.cbo_tipopago.Size = new System.Drawing.Size(141, 26);
            this.cbo_tipopago.TabIndex = 16;
            this.cbo_tipopago.SelectedIndexChanged += new System.EventHandler(this.cbo_tipopago_SelectedIndexChanged);
            // 
            // txt_nroOperacion
            // 
            this.txt_nroOperacion.BackColor = System.Drawing.Color.Transparent;
            this.txt_nroOperacion.BaseColor = System.Drawing.Color.White;
            this.txt_nroOperacion.BorderColor = System.Drawing.Color.Silver;
            this.txt_nroOperacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_nroOperacion.Enabled = false;
            this.txt_nroOperacion.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_nroOperacion.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_nroOperacion.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_nroOperacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_nroOperacion.Location = new System.Drawing.Point(259, 334);
            this.txt_nroOperacion.Name = "txt_nroOperacion";
            this.txt_nroOperacion.PasswordChar = '\0';
            this.txt_nroOperacion.Radius = 10;
            this.txt_nroOperacion.Size = new System.Drawing.Size(139, 30);
            this.txt_nroOperacion.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(267, 312);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Nro Operacion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(39, 312);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 19);
            this.label7.TabIndex = 19;
            this.label7.Text = "Fecha Pago";
            // 
            // dtp_fechapago
            // 
            this.dtp_fechapago.BackColor = System.Drawing.Color.Transparent;
            this.dtp_fechapago.BaseColor = System.Drawing.Color.White;
            this.dtp_fechapago.BorderColor = System.Drawing.Color.Silver;
            this.dtp_fechapago.CustomFormat = null;
            this.dtp_fechapago.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtp_fechapago.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_fechapago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_fechapago.ForeColor = System.Drawing.Color.Black;
            this.dtp_fechapago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fechapago.Location = new System.Drawing.Point(39, 334);
            this.dtp_fechapago.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fechapago.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fechapago.Name = "dtp_fechapago";
            this.dtp_fechapago.OnHoverBaseColor = System.Drawing.Color.White;
            this.dtp_fechapago.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_fechapago.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtp_fechapago.OnPressedColor = System.Drawing.Color.Black;
            this.dtp_fechapago.Radius = 10;
            this.dtp_fechapago.Size = new System.Drawing.Size(134, 30);
            this.dtp_fechapago.TabIndex = 20;
            this.dtp_fechapago.Text = "29/06/2020";
            this.dtp_fechapago.Value = new System.DateTime(2020, 6, 29, 18, 30, 24, 546);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // lbl_idcredito
            // 
            this.lbl_idcredito.AutoSize = true;
            this.lbl_idcredito.Font = new System.Drawing.Font("Oxygen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_idcredito.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_idcredito.Location = new System.Drawing.Point(456, 188);
            this.lbl_idcredito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_idcredito.Name = "lbl_idcredito";
            this.lbl_idcredito.Size = new System.Drawing.Size(11, 15);
            this.lbl_idcredito.TabIndex = 22;
            this.lbl_idcredito.Text = "-";
            this.toolTip1.SetToolTip(this.lbl_idcredito, "Nuevo Saldo");
            // 
            // lbl_idDoc
            // 
            this.lbl_idDoc.AutoSize = true;
            this.lbl_idDoc.Font = new System.Drawing.Font("Oxygen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_idDoc.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_idDoc.Location = new System.Drawing.Point(456, 216);
            this.lbl_idDoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_idDoc.Name = "lbl_idDoc";
            this.lbl_idDoc.Size = new System.Drawing.Size(11, 15);
            this.lbl_idDoc.TabIndex = 23;
            this.lbl_idDoc.Text = "-";
            this.toolTip1.SetToolTip(this.lbl_idDoc, "Nuevo Saldo");
            // 
            // lbl_estado
            // 
            this.lbl_estado.AutoSize = true;
            this.lbl_estado.Font = new System.Drawing.Font("Oxygen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estado.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_estado.Location = new System.Drawing.Point(456, 240);
            this.lbl_estado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(11, 15);
            this.lbl_estado.TabIndex = 24;
            this.lbl_estado.Text = "-";
            this.toolTip1.SetToolTip(this.lbl_estado, "Nuevo Saldo");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pic_qr
            // 
            this.pic_qr.Location = new System.Drawing.Point(486, 274);
            this.pic_qr.Name = "pic_qr";
            this.pic_qr.Size = new System.Drawing.Size(153, 151);
            this.pic_qr.TabIndex = 25;
            this.pic_qr.TabStop = false;
            // 
            // txt_obs
            // 
            this.txt_obs.BackColor = System.Drawing.Color.Transparent;
            this.txt_obs.BaseColor = System.Drawing.Color.White;
            this.txt_obs.BorderColor = System.Drawing.Color.Silver;
            this.txt_obs.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_obs.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_obs.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_obs.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_obs.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_obs.Location = new System.Drawing.Point(37, 399);
            this.txt_obs.Name = "txt_obs";
            this.txt_obs.PasswordChar = '\0';
            this.txt_obs.Radius = 10;
            this.txt_obs.Size = new System.Drawing.Size(388, 30);
            this.txt_obs.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(37, 377);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 19);
            this.label8.TabIndex = 27;
            this.label8.Text = "Deja a Cuenta";
            // 
            // dtp_Hoy
            // 
            this.dtp_Hoy.Location = new System.Drawing.Point(404, 373);
            this.dtp_Hoy.Name = "dtp_Hoy";
            this.dtp_Hoy.Size = new System.Drawing.Size(38, 20);
            this.dtp_Hoy.TabIndex = 28;
            this.dtp_Hoy.Visible = false;
            // 
            // txt_newsaldo
            // 
            this.txt_newsaldo.BackColor = System.Drawing.Color.Transparent;
            this.txt_newsaldo.BaseColor = System.Drawing.Color.White;
            this.txt_newsaldo.BorderColor = System.Drawing.Color.Silver;
            this.txt_newsaldo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_newsaldo.Enabled = false;
            this.txt_newsaldo.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_newsaldo.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_newsaldo.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_newsaldo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newsaldo.Location = new System.Drawing.Point(328, 173);
            this.txt_newsaldo.Name = "txt_newsaldo";
            this.txt_newsaldo.PasswordChar = '\0';
            this.txt_newsaldo.Radius = 10;
            this.txt_newsaldo.Size = new System.Drawing.Size(114, 30);
            this.txt_newsaldo.TabIndex = 30;
            this.txt_newsaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Oxygen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(336, 151);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 19);
            this.label9.TabIndex = 29;
            this.label9.Text = "Saldo Nuevo";
            // 
            // Frm_abonarCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 517);
            this.Controls.Add(this.txt_newsaldo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtp_Hoy);
            this.Controls.Add(this.txt_obs);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pic_qr);
            this.Controls.Add(this.lbl_estado);
            this.Controls.Add(this.lbl_idDoc);
            this.Controls.Add(this.lbl_idcredito);
            this.Controls.Add(this.dtp_fechapago);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_nroOperacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbo_tipopago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_listo);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txt_acuenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_saldocred);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_totalcred);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_clien);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.bunifuSeparator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_abonarCred";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abonar Credito";
            this.Load += new System.EventHandler(this.Frm_abonarCred_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_abonarCred_KeyDown);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_listo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_qr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_clien;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaTextBox txt_acuenta;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaTextBox txt_saldocred;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaTextBox txt_totalcred;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_listo;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancel;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Guna.UI.WinForms.GunaDateTimePicker dtp_fechapago;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaTextBox txt_nroOperacion;
        private System.Windows.Forms.Label label6;
        private Guna.UI.WinForms.GunaComboBox cbo_tipopago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_idDoc;
        private System.Windows.Forms.Label lbl_idcredito;
        private System.Windows.Forms.Label lbl_estado;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pic_qr;
        private Guna.UI.WinForms.GunaTextBox txt_obs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtp_Hoy;
        private Guna.UI.WinForms.GunaTextBox txt_newsaldo;
        private System.Windows.Forms.Label label9;
    }
}