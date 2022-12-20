namespace Microsell_Lite.Utilitarios

{
    partial class Frm_TipoCambio
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
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle2 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TipoCambio));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.elLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.txt_precio = new System.Windows.Forms.TextBox();
            this.ElDivider1 = new Klik.Windows.Forms.v1.EntryLib.ELDivider();
            this.txt_preAc = new System.Windows.Forms.TextBox();
            this.elLabel2 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btn_aceptar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.bt_cancelar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.lbl_idproducto = new System.Windows.Forms.Label();
            this.lbl_tipoProducto = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_cancelar)).BeginInit();
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
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(318, 51);
            this.pnl_titu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actualizar Tipo de Cambio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // elLabel1
            // 
            this.elLabel1.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elLabel1.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            this.elLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            paintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle2.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel1.FlashStyle = paintStyle2;
            this.elLabel1.ForegroundImageStyle.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.elLabel1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.elLabel1.Location = new System.Drawing.Point(54, 74);
            this.elLabel1.Name = "elLabel1";
            this.elLabel1.Size = new System.Drawing.Size(230, 48);
            this.elLabel1.TabIndex = 3;
            this.elLabel1.TabStop = false;
            this.elLabel1.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.elLabel1.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.elLabel1.TextStyle.Text = "Actual S/";
            this.elLabel1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_precio
            // 
            this.txt_precio.BackColor = System.Drawing.Color.White;
            this.txt_precio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_precio.Enabled = false;
            this.txt_precio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_precio.ForeColor = System.Drawing.Color.DimGray;
            this.txt_precio.Location = new System.Drawing.Point(122, 80);
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.Size = new System.Drawing.Size(108, 31);
            this.txt_precio.TabIndex = 1;
            this.txt_precio.Text = "0";
            this.txt_precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_precio.TextChanged += new System.EventHandler(this.txt_precio_TextChanged);
            this.txt_precio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_precio_KeyPress);
            // 
            // ElDivider1
            // 
            this.ElDivider1.FadeStyle = Klik.Windows.Forms.v1.EntryLib.DividerFadeStyles.Center;
            this.ElDivider1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ElDivider1.Location = new System.Drawing.Point(33, 124);
            this.ElDivider1.Name = "ElDivider1";
            this.ElDivider1.Size = new System.Drawing.Size(267, 14);
            this.ElDivider1.TabIndex = 475;
            this.ElDivider1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // txt_preAc
            // 
            this.txt_preAc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_preAc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_preAc.ForeColor = System.Drawing.Color.DimGray;
            this.txt_preAc.Location = new System.Drawing.Point(129, 147);
            this.txt_preAc.Name = "txt_preAc";
            this.txt_preAc.Size = new System.Drawing.Size(97, 31);
            this.txt_preAc.TabIndex = 2;
            this.txt_preAc.Text = "0";
            this.txt_preAc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_preAc.TextChanged += new System.EventHandler(this.txt_cant_TextChanged);
            this.txt_preAc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // elLabel2
            // 
            this.elLabel2.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.elLabel2.BackgroundStyle.SolidColor = System.Drawing.Color.White;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.elLabel2.FlashStyle = paintStyle1;
            this.elLabel2.ForegroundImageStyle.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.elLabel2.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.elLabel2.Location = new System.Drawing.Point(54, 141);
            this.elLabel2.Name = "elLabel2";
            this.elLabel2.Size = new System.Drawing.Size(230, 48);
            this.elLabel2.TabIndex = 476;
            this.elLabel2.TabStop = false;
            this.elLabel2.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elLabel2.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.elLabel2.TextStyle.Text = "Nuevo S/";
            this.elLabel2.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.BackgroundStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_aceptar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.EdgeRadius = 7;
            this.btn_aceptar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_aceptar.BorderStyle.SolidColor = System.Drawing.Color.Gainsboro;
            this.btn_aceptar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_aceptar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_aceptar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_aceptar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.Location = new System.Drawing.Point(162, 214);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.btn_aceptar.Size = new System.Drawing.Size(138, 40);
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.YellowGreen;
            this.btn_aceptar.TabIndex = 3;
            this.btn_aceptar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_aceptar.TextStyle.Text = "Aceptar";
            this.btn_aceptar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.bt_cancelar.BackgroundStyle.SolidColor = System.Drawing.Color.Tomato;
            this.bt_cancelar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bt_cancelar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bt_cancelar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bt_cancelar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.bt_cancelar.BorderStyle.EdgeRadius = 7;
            this.bt_cancelar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.bt_cancelar.BorderStyle.SolidColor = System.Drawing.Color.Tomato;
            this.bt_cancelar.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_cancelar.DropDownArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.bt_cancelar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.bt_cancelar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.bt_cancelar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bt_cancelar.Location = new System.Drawing.Point(13, 214);
            this.bt_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.bt_cancelar.Size = new System.Drawing.Size(121, 40);
            this.bt_cancelar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.Salmon;
            this.bt_cancelar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.Salmon;
            this.bt_cancelar.TabIndex = 4;
            this.bt_cancelar.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cancelar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.bt_cancelar.TextStyle.Text = "Cancelar";
            this.bt_cancelar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bt_cancelar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // lbl_idproducto
            // 
            this.lbl_idproducto.AutoSize = true;
            this.lbl_idproducto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_idproducto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_idproducto.ForeColor = System.Drawing.Color.Silver;
            this.lbl_idproducto.Location = new System.Drawing.Point(412, 255);
            this.lbl_idproducto.Name = "lbl_idproducto";
            this.lbl_idproducto.Size = new System.Drawing.Size(13, 13);
            this.lbl_idproducto.TabIndex = 482;
            this.lbl_idproducto.Text = "0";
            this.lbl_idproducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_tipoProducto
            // 
            this.lbl_tipoProducto.AutoSize = true;
            this.lbl_tipoProducto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_tipoProducto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipoProducto.ForeColor = System.Drawing.Color.Silver;
            this.lbl_tipoProducto.Location = new System.Drawing.Point(446, 255);
            this.lbl_tipoProducto.Name = "lbl_tipoProducto";
            this.lbl_tipoProducto.Size = new System.Drawing.Size(13, 13);
            this.lbl_tipoProducto.TabIndex = 484;
            this.lbl_tipoProducto.Text = "0";
            this.lbl_tipoProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_TipoCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 268);
            this.Controls.Add(this.lbl_tipoProducto);
            this.Controls.Add(this.lbl_idproducto);
            this.Controls.Add(this.bt_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.txt_preAc);
            this.Controls.Add(this.elLabel2);
            this.Controls.Add(this.ElDivider1);
            this.Controls.Add(this.txt_precio);
            this.Controls.Add(this.elLabel1);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_TipoCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edicion de Precio";
            this.Load += new System.EventHandler(this.Frm_Edit_Precio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Edit_Precio2_KeyDown);
            this.pnl_titu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElDivider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_cancelar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel1;
        private Klik.Windows.Forms.v1.EntryLib.ELLabel elLabel2;
        internal Klik.Windows.Forms.v1.EntryLib.ELDivider ElDivider1;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_aceptar;
        private Klik.Windows.Forms.v1.EntryLib.ELButton bt_cancelar;
        internal System.Windows.Forms.TextBox txt_precio;
        internal System.Windows.Forms.TextBox txt_preAc;
        internal System.Windows.Forms.Label lbl_idproducto;
        internal System.Windows.Forms.Label lbl_tipoProducto;
    }
}