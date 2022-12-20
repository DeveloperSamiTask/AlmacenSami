namespace Microsell_Lite.Caja
{
    partial class Frm_Registrar_Gastos
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle31 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle32 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle33 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle34 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle35 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle36 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Registrar_Gastos));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_fondo = new System.Windows.Forms.Panel();
            this.cbo_tipoPago = new System.Windows.Forms.ComboBox();
            this.txt_Descripcion = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.txt_importe = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.txt_nroDoc = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.txt_cliente = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.txt_concepto = new Klik.Windows.Forms.v1.EntryLib.ELEntryBox();
            this.ElLabel6 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ElLabel5 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ElLabel4 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ElLabel3 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ElLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ElLabel2 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btn_cancelar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_aceptar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_fondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Descripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_importe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nroDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_concepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).BeginInit();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_fondo
            // 
            this.pnl_fondo.Controls.Add(this.pnl_titu);
            this.pnl_fondo.Controls.Add(this.cbo_tipoPago);
            this.pnl_fondo.Controls.Add(this.txt_Descripcion);
            this.pnl_fondo.Controls.Add(this.dtp_fecha);
            this.pnl_fondo.Controls.Add(this.txt_importe);
            this.pnl_fondo.Controls.Add(this.txt_nroDoc);
            this.pnl_fondo.Controls.Add(this.txt_cliente);
            this.pnl_fondo.Controls.Add(this.txt_concepto);
            this.pnl_fondo.Controls.Add(this.ElLabel6);
            this.pnl_fondo.Controls.Add(this.ElLabel5);
            this.pnl_fondo.Controls.Add(this.ElLabel4);
            this.pnl_fondo.Controls.Add(this.ElLabel3);
            this.pnl_fondo.Controls.Add(this.ElLabel1);
            this.pnl_fondo.Controls.Add(this.ElLabel2);
            this.pnl_fondo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_fondo.Location = new System.Drawing.Point(0, 0);
            this.pnl_fondo.Name = "pnl_fondo";
            this.pnl_fondo.Size = new System.Drawing.Size(519, 336);
            this.pnl_fondo.TabIndex = 465;
            // 
            // cbo_tipoPago
            // 
            this.cbo_tipoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_tipoPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_tipoPago.FormattingEnabled = true;
            this.cbo_tipoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Deposito"});
            this.cbo_tipoPago.Location = new System.Drawing.Point(172, 114);
            this.cbo_tipoPago.Name = "cbo_tipoPago";
            this.cbo_tipoPago.Size = new System.Drawing.Size(138, 23);
            this.cbo_tipoPago.TabIndex = 429;
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
            this.txt_Descripcion.Location = new System.Drawing.Point(166, 110);
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(149, 31);
            this.txt_Descripcion.TabIndex = 428;
            this.txt_Descripcion.ValidationStyle.MaxLength = 150;
            this.txt_Descripcion.ValidationStyle.PasswordChar = '\0';
            this.txt_Descripcion.ValidationStyle.StringValidationStyle.CharacterCasing = Klik.Windows.Forms.v1.EntryLib.CharacterCasing.Upper;
            this.txt_Descripcion.Value = "";
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(165, 60);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(149, 31);
            this.dtp_fecha.TabIndex = 426;
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
            this.txt_importe.Location = new System.Drawing.Point(165, 289);
            this.txt_importe.Name = "txt_importe";
            this.txt_importe.Size = new System.Drawing.Size(149, 31);
            this.txt_importe.TabIndex = 425;
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
            this.txt_nroDoc.Location = new System.Drawing.Point(165, 246);
            this.txt_nroDoc.Name = "txt_nroDoc";
            this.txt_nroDoc.Size = new System.Drawing.Size(149, 31);
            this.txt_nroDoc.TabIndex = 424;
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
            this.txt_cliente.Location = new System.Drawing.Point(165, 203);
            this.txt_cliente.Name = "txt_cliente";
            this.txt_cliente.Size = new System.Drawing.Size(335, 31);
            this.txt_cliente.TabIndex = 423;
            this.txt_cliente.ValidationStyle.MaxLength = 150;
            this.txt_cliente.ValidationStyle.PasswordChar = '\0';
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
            this.txt_concepto.Location = new System.Drawing.Point(165, 155);
            this.txt_concepto.Name = "txt_concepto";
            this.txt_concepto.Size = new System.Drawing.Size(335, 31);
            this.txt_concepto.TabIndex = 422;
            this.txt_concepto.ValidationStyle.MaxLength = 150;
            this.txt_concepto.ValidationStyle.PasswordChar = '\0';
            this.txt_concepto.Value = "";
            // 
            // ElLabel6
            // 
            this.ElLabel6.BackgroundStyle.GradientEndColor = System.Drawing.Color.White;
            this.ElLabel6.BackgroundStyle.GradientStartColor = System.Drawing.Color.White;
            this.ElLabel6.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElLabel6.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.ElLabel6.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElLabel6.BorderStyle.SolidColor = System.Drawing.Color.White;
            paintStyle31.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle31.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel6.FlashStyle = paintStyle31;
            this.ElLabel6.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel6.Location = new System.Drawing.Point(14, 289);
            this.ElLabel6.Name = "ElLabel6";
            this.ElLabel6.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel6.Size = new System.Drawing.Size(145, 31);
            this.ElLabel6.TabIndex = 420;
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
            paintStyle32.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle32.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel5.FlashStyle = paintStyle32;
            this.ElLabel5.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel5.Location = new System.Drawing.Point(14, 246);
            this.ElLabel5.Name = "ElLabel5";
            this.ElLabel5.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel5.Size = new System.Drawing.Size(145, 31);
            this.ElLabel5.TabIndex = 419;
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
            paintStyle33.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle33.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel4.FlashStyle = paintStyle33;
            this.ElLabel4.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel4.Location = new System.Drawing.Point(14, 203);
            this.ElLabel4.Name = "ElLabel4";
            this.ElLabel4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel4.Size = new System.Drawing.Size(145, 31);
            this.ElLabel4.TabIndex = 418;
            this.ElLabel4.TabStop = false;
            this.ElLabel4.TextStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel4.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ElLabel4.TextStyle.Text = "Pague a";
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
            paintStyle34.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle34.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel3.FlashStyle = paintStyle34;
            this.ElLabel3.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel3.Location = new System.Drawing.Point(14, 155);
            this.ElLabel3.Name = "ElLabel3";
            this.ElLabel3.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel3.Size = new System.Drawing.Size(145, 31);
            this.ElLabel3.TabIndex = 417;
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
            paintStyle35.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle35.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel1.FlashStyle = paintStyle35;
            this.ElLabel1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel1.Location = new System.Drawing.Point(14, 109);
            this.ElLabel1.Name = "ElLabel1";
            this.ElLabel1.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel1.Size = new System.Drawing.Size(145, 31);
            this.ElLabel1.TabIndex = 416;
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
            paintStyle36.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle36.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel2.FlashStyle = paintStyle36;
            this.ElLabel2.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel2.Location = new System.Drawing.Point(14, 60);
            this.ElLabel2.Name = "ElLabel2";
            this.ElLabel2.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElLabel2.Size = new System.Drawing.Size(145, 31);
            this.ElLabel2.TabIndex = 415;
            this.ElLabel2.TabStop = false;
            this.ElLabel2.TextStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel2.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ElLabel2.TextStyle.Text = "Fecha: ";
            this.ElLabel2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_cancelar.BackgroundStyle.GradientAngle = 0F;
            this.btn_cancelar.BackgroundStyle.GradientEndColor = System.Drawing.Color.OrangeRed;
            this.btn_cancelar.BackgroundStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancelar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelar.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancelar.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelar.DropDownArrowColor = System.Drawing.Color.White;
            this.btn_cancelar.EnableThemes = false;
            this.btn_cancelar.FlashStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_cancelar.FlashStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_cancelar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelar.FlashStyle.SolidColor = System.Drawing.Color.OrangeRed;
            this.btn_cancelar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(73, 348);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(121, 37);
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.Gainsboro;
            this.btn_cancelar.TabIndex = 469;
            this.btn_cancelar.TextStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_cancelar.TextStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.TextStyle.ForeColor = System.Drawing.Color.SlateGray;
            this.btn_cancelar.TextStyle.Text = "Cancelar";
            this.btn_cancelar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancelar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_aceptar.BackgroundStyle.GradientAngle = 0F;
            this.btn_aceptar.BackgroundStyle.GradientEndColor = System.Drawing.Color.OrangeRed;
            this.btn_aceptar.BackgroundStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.BorderStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.DropDownArrowColor = System.Drawing.Color.White;
            this.btn_aceptar.EnableThemes = false;
            this.btn_aceptar.FlashStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_aceptar.FlashStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_aceptar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.FlashStyle.SolidColor = System.Drawing.Color.OrangeRed;
            this.btn_aceptar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aceptar.Location = new System.Drawing.Point(260, 348);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(135, 37);
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.TabIndex = 468;
            this.btn_aceptar.TextStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.TextStyle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_aceptar.TextStyle.Text = "Aceptar";
            this.btn_aceptar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
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
            this.pnl_titu.Size = new System.Drawing.Size(519, 43);
            this.pnl_titu.TabIndex = 784;
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
            this.btn_cerrar.Location = new System.Drawing.Point(477, 4);
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
            this.label1.Size = new System.Drawing.Size(189, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro de Otros Gastos";
            // 
            // Frm_Registrar_Gastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(519, 404);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.pnl_fondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Registrar_Gastos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Gastos";
            this.Load += new System.EventHandler(this.Frm_Registrar_Gastos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Registrar_Gastos_KeyDown);
            this.pnl_fondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Descripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_importe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nroDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_concepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).EndInit();
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        internal System.Windows.Forms.Panel pnl_fondo;
        internal System.Windows.Forms.ComboBox cbo_tipoPago;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_Descripcion;
        internal System.Windows.Forms.DateTimePicker dtp_fecha;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_importe;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_nroDoc;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_cliente;
        internal Klik.Windows.Forms.v1.EntryLib.ELEntryBox txt_concepto;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel6;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel5;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel4;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel3;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel1;
        internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel2;
        internal Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancelar;
        internal Klik.Windows.Forms.v1.EntryLib.ELButton btn_aceptar;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
    }
}