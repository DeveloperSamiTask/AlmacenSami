namespace Microsell_Lite.Caja
{
    partial class Frm_Reg_otroIngresos
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle2 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle3 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle4 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle5 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle6 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Reg_otroIngresos));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.cbo_tipoPago = new System.Windows.Forms.ComboBox();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.txt_importe = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.txt_nroDoc = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.txt_cliente = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.txt_concepto = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.txt_Descripcion = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.ElLabel6 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ElLabel5 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ElLabel4 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ElLabel3 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ElLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ElLabel2 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btn_cancelPago = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_Generar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txt_importe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nroDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_concepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Descripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Generar)).BeginInit();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // cbo_tipoPago
            // 
            this.cbo_tipoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_tipoPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_tipoPago.FormattingEnabled = true;
            this.cbo_tipoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Deposito"});
            this.cbo_tipoPago.Location = new System.Drawing.Point(193, 110);
            this.cbo_tipoPago.Name = "cbo_tipoPago";
            this.cbo_tipoPago.Size = new System.Drawing.Size(138, 23);
            this.cbo_tipoPago.TabIndex = 440;
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(187, 57);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(149, 31);
            this.dtp_fecha.TabIndex = 439;
            // 
            // txt_importe
            // 
            this.txt_importe.CaptionStyle.CaptionSize = 0;
            this.txt_importe.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.txt_importe.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.txt_importe.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_importe.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White;
            this.txt_importe.CaptionStyle.TextStyle.Text = "ElEntryBox1";
            this.txt_importe.EditBoxStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.txt_importe.EditBoxStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_importe.EditBoxStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_importe.EditBoxStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_importe.Location = new System.Drawing.Point(187, 286);
            this.txt_importe.Name = "txt_importe";
            this.txt_importe.Size = new System.Drawing.Size(149, 31);
            this.txt_importe.TabIndex = 438;
            this.txt_importe.ValidationStyle.MaxLength = 150;
            this.txt_importe.ValidationStyle.PasswordChar = '\0';
            this.txt_importe.ValidationStyle.StringValidationStyle.CharacterCasing = Klik.Windows.Forms.v1.EntryLib.CharacterCasing.Upper;
            this.txt_importe.Value = "";
            // 
            // txt_nroDoc
            // 
            this.txt_nroDoc.CaptionStyle.CaptionSize = 0;
            this.txt_nroDoc.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.txt_nroDoc.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.txt_nroDoc.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_nroDoc.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White;
            this.txt_nroDoc.CaptionStyle.TextStyle.Text = "ElEntryBox1";
            this.txt_nroDoc.EditBoxStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.txt_nroDoc.EditBoxStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nroDoc.EditBoxStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_nroDoc.EditBoxStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_nroDoc.Location = new System.Drawing.Point(187, 243);
            this.txt_nroDoc.Name = "txt_nroDoc";
            this.txt_nroDoc.Size = new System.Drawing.Size(149, 31);
            this.txt_nroDoc.TabIndex = 437;
            this.txt_nroDoc.ValidationStyle.MaxLength = 150;
            this.txt_nroDoc.ValidationStyle.PasswordChar = '\0';
            this.txt_nroDoc.ValidationStyle.StringValidationStyle.CharacterCasing = Klik.Windows.Forms.v1.EntryLib.CharacterCasing.Upper;
            this.txt_nroDoc.Value = "";
            // 
            // txt_cliente
            // 
            this.txt_cliente.CaptionStyle.CaptionSize = 0;
            this.txt_cliente.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.txt_cliente.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.txt_cliente.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_cliente.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White;
            this.txt_cliente.CaptionStyle.TextStyle.Text = "ElEntryBox1";
            this.txt_cliente.EditBoxStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.txt_cliente.EditBoxStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cliente.EditBoxStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_cliente.EditBoxStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_cliente.Location = new System.Drawing.Point(187, 200);
            this.txt_cliente.Name = "txt_cliente";
            this.txt_cliente.Size = new System.Drawing.Size(335, 31);
            this.txt_cliente.TabIndex = 436;
            this.txt_cliente.ValidationStyle.MaxLength = 150;
            this.txt_cliente.ValidationStyle.PasswordChar = '\0';
            this.txt_cliente.ValidationStyle.StringValidationStyle.CharacterCasing = Klik.Windows.Forms.v1.EntryLib.CharacterCasing.Upper;
            this.txt_cliente.Value = "";
            // 
            // txt_concepto
            // 
            this.txt_concepto.CaptionStyle.CaptionSize = 0;
            this.txt_concepto.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.txt_concepto.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.txt_concepto.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_concepto.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White;
            this.txt_concepto.CaptionStyle.TextStyle.Text = "ElEntryBox1";
            this.txt_concepto.EditBoxStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.txt_concepto.EditBoxStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_concepto.EditBoxStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_concepto.EditBoxStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_concepto.Location = new System.Drawing.Point(187, 152);
            this.txt_concepto.Name = "txt_concepto";
            this.txt_concepto.Size = new System.Drawing.Size(335, 31);
            this.txt_concepto.TabIndex = 435;
            this.txt_concepto.ValidationStyle.MaxLength = 150;
            this.txt_concepto.ValidationStyle.PasswordChar = '\0';
            this.txt_concepto.ValidationStyle.StringValidationStyle.CharacterCasing = Klik.Windows.Forms.v1.EntryLib.CharacterCasing.Upper;
            this.txt_concepto.Value = "";
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.CaptionStyle.CaptionSize = 0;
            this.txt_Descripcion.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.txt_Descripcion.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.txt_Descripcion.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_Descripcion.CaptionStyle.TextStyle.ForeColor = System.Drawing.Color.White;
            this.txt_Descripcion.CaptionStyle.TextStyle.Text = "ElEntryBox1";
            this.txt_Descripcion.EditBoxStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.txt_Descripcion.EditBoxStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Descripcion.EditBoxStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_Descripcion.EditBoxStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.txt_Descripcion.Location = new System.Drawing.Point(187, 106);
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(149, 31);
            this.txt_Descripcion.TabIndex = 434;
            this.txt_Descripcion.ValidationStyle.MaxLength = 150;
            this.txt_Descripcion.ValidationStyle.PasswordChar = '\0';
            this.txt_Descripcion.ValidationStyle.StringValidationStyle.CharacterCasing = Klik.Windows.Forms.v1.EntryLib.CharacterCasing.Upper;
            this.txt_Descripcion.Value = "";
            // 
            // ElLabel6
            // 
            this.ElLabel6.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.ElLabel6.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.ElLabel6.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElLabel6.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.ElLabel6.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElLabel6.BorderStyle.SolidColor = System.Drawing.Color.White;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel6.FlashStyle = paintStyle1;
            this.ElLabel6.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel6.Location = new System.Drawing.Point(37, 286);
            this.ElLabel6.Name = "ElLabel6";
            this.ElLabel6.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel6.Size = new System.Drawing.Size(145, 31);
            this.ElLabel6.TabIndex = 433;
            this.ElLabel6.TabStop = false;
            this.ElLabel6.TextStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel6.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ElLabel6.TextStyle.Text = "Importe S/";
            this.ElLabel6.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElLabel5
            // 
            this.ElLabel5.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.ElLabel5.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.ElLabel5.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElLabel5.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.ElLabel5.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElLabel5.BorderStyle.SolidColor = System.Drawing.Color.White;
            paintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle2.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel5.FlashStyle = paintStyle2;
            this.ElLabel5.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel5.Location = new System.Drawing.Point(37, 243);
            this.ElLabel5.Name = "ElLabel5";
            this.ElLabel5.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel5.Size = new System.Drawing.Size(145, 31);
            this.ElLabel5.TabIndex = 432;
            this.ElLabel5.TabStop = false;
            this.ElLabel5.TextStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel5.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ElLabel5.TextStyle.Text = "Nro de Documento";
            this.ElLabel5.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElLabel4
            // 
            this.ElLabel4.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.ElLabel4.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.ElLabel4.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElLabel4.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.ElLabel4.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElLabel4.BorderStyle.SolidColor = System.Drawing.Color.White;
            paintStyle3.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle3.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel4.FlashStyle = paintStyle3;
            this.ElLabel4.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel4.Location = new System.Drawing.Point(37, 200);
            this.ElLabel4.Name = "ElLabel4";
            this.ElLabel4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel4.Size = new System.Drawing.Size(145, 31);
            this.ElLabel4.TabIndex = 431;
            this.ElLabel4.TabStop = false;
            this.ElLabel4.TextStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel4.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ElLabel4.TextStyle.Text = "Recibi de:";
            this.ElLabel4.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElLabel3
            // 
            this.ElLabel3.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.ElLabel3.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.ElLabel3.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElLabel3.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.ElLabel3.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElLabel3.BorderStyle.SolidColor = System.Drawing.Color.White;
            paintStyle4.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle4.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel3.FlashStyle = paintStyle4;
            this.ElLabel3.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel3.Location = new System.Drawing.Point(37, 152);
            this.ElLabel3.Name = "ElLabel3";
            this.ElLabel3.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel3.Size = new System.Drawing.Size(145, 31);
            this.ElLabel3.TabIndex = 430;
            this.ElLabel3.TabStop = false;
            this.ElLabel3.TextStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel3.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ElLabel3.TextStyle.Text = "Concepto - Detalle";
            this.ElLabel3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElLabel1
            // 
            this.ElLabel1.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.ElLabel1.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.ElLabel1.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElLabel1.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.ElLabel1.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElLabel1.BorderStyle.SolidColor = System.Drawing.Color.White;
            paintStyle5.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle5.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel1.FlashStyle = paintStyle5;
            this.ElLabel1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel1.Location = new System.Drawing.Point(37, 106);
            this.ElLabel1.Name = "ElLabel1";
            this.ElLabel1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel1.Size = new System.Drawing.Size(145, 31);
            this.ElLabel1.TabIndex = 429;
            this.ElLabel1.TabStop = false;
            this.ElLabel1.TextStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel1.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ElLabel1.TextStyle.Text = "Tipo Pago: ";
            this.ElLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElLabel2
            // 
            this.ElLabel2.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.ElLabel2.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.ElLabel2.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElLabel2.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.ElLabel2.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElLabel2.BorderStyle.SolidColor = System.Drawing.Color.White;
            paintStyle6.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle6.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel2.FlashStyle = paintStyle6;
            this.ElLabel2.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel2.Location = new System.Drawing.Point(37, 57);
            this.ElLabel2.Name = "ElLabel2";
            this.ElLabel2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel2.Size = new System.Drawing.Size(145, 31);
            this.ElLabel2.TabIndex = 428;
            this.ElLabel2.TabStop = false;
            this.ElLabel2.TextStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel2.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ElLabel2.TextStyle.Text = "Fecha: ";
            this.ElLabel2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // btn_cancelPago
            // 
            this.btn_cancelPago.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_cancelPago.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelPago.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancelPago.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelPago.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelPago.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelPago.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelPago.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelPago.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelPago.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cancelPago.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancelPago.Location = new System.Drawing.Point(115, 343);
            this.btn_cancelPago.Name = "btn_cancelPago";
            this.btn_cancelPago.Size = new System.Drawing.Size(124, 39);
            this.btn_cancelPago.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BackgroundImageFilterColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BorderGradientEndColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BorderGradientStartColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.LightGray;
            this.btn_cancelPago.TabIndex = 782;
            this.btn_cancelPago.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelPago.TextStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.btn_cancelPago.TextStyle.Text = "Cancelar";
            this.btn_cancelPago.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancelPago.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancelPago.Click += new System.EventHandler(this.btn_cancelPago_Click);
            // 
            // btn_Generar
            // 
            this.btn_Generar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Generar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_Generar.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.btn_Generar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Generar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Generar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Generar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_Generar.BorderStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(192)))));
            this.btn_Generar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_Generar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_Generar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Generar.Location = new System.Drawing.Point(287, 343);
            this.btn_Generar.Name = "btn_Generar";
            this.btn_Generar.Size = new System.Drawing.Size(134, 39);
            this.btn_Generar.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BackgroundImageFilterColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BorderGradientEndColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BorderGradientStartColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_Generar.TabIndex = 781;
            this.btn_Generar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_Generar.TextStyle.Text = "Aceptar";
            this.btn_Generar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Generar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_Generar.Click += new System.EventHandler(this.btn_Generar_Click);
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DimGray;
            this.pnl_titu.Controls.Add(this.label22);
            this.pnl_titu.Controls.Add(this.btn_cerrar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(543, 43);
            this.pnl_titu.TabIndex = 783;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Oxygen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Image = ((System.Drawing.Image)(resources.GetObject("label22.Image")));
            this.label22.Location = new System.Drawing.Point(4, 1);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(50, 42);
            this.label22.TabIndex = 75;
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
            this.btn_cerrar.Location = new System.Drawing.Point(501, 4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Oxygen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(60, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro de Otros Ingresos";
            // 
            // Frm_Reg_otroIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(543, 408);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.btn_cancelPago);
            this.Controls.Add(this.btn_Generar);
            this.Controls.Add(this.cbo_tipoPago);
            this.Controls.Add(this.dtp_fecha);
            this.Controls.Add(this.txt_importe);
            this.Controls.Add(this.txt_nroDoc);
            this.Controls.Add(this.txt_cliente);
            this.Controls.Add(this.txt_concepto);
            this.Controls.Add(this.txt_Descripcion);
            this.Controls.Add(this.ElLabel6);
            this.Controls.Add(this.ElLabel5);
            this.Controls.Add(this.ElLabel4);
            this.Controls.Add(this.ElLabel3);
            this.Controls.Add(this.ElLabel1);
            this.Controls.Add(this.ElLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Reg_otroIngresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Otros Ingresos";
            this.Load += new System.EventHandler(this.Frm_Reg_otroIngresos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Reg_otroIngresos_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txt_importe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nroDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_concepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Descripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Generar)).EndInit();
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        internal System.Windows.Forms.ComboBox cbo_tipoPago;
        internal System.Windows.Forms.DateTimePicker dtp_fecha;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_importe;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_nroDoc;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_cliente;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_concepto;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_Descripcion;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel6;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel5;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel4;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel3;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel1;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel2;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancelPago;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_Generar;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
    }
}