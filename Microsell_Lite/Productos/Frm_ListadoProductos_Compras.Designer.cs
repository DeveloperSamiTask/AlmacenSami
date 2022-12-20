namespace Microsell_Lite.Productos
{
    partial class Frm_ListadoProductos_Compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ListadoProductos_Compras));
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_TotalItems = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Pedido = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_buscar = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lsv_produ = new System.Windows.Forms.ListView();
            this.pnl_sms = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbo_LlenarSinSalir = new System.Windows.Forms.CheckBox();
            this.cbo_VerTodo = new System.Windows.Forms.CheckBox();
            this.cbo_Coti = new System.Windows.Forms.CheckBox();
            this.cbo_Todo = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_xpreCompra = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnl_Carrito = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_continuar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.lbl_TotalItem = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lsv_Ped = new System.Windows.Forms.ListView();
            this.lbl_IdProdu = new System.Windows.Forms.Label();
            this.lbl_Nom_Prod = new System.Windows.Forms.Label();
            this.lbl_TipoProd = new System.Windows.Forms.Label();
            this.lbl_Uti_Unit = new System.Windows.Forms.Label();
            this.lbl_und = new System.Windows.Forms.Label();
            this.lbl_pre_unit = new System.Windows.Forms.Label();
            this.lbl_importe = new System.Windows.Forms.Label();
            this.lbl_cant = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_sms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnl_Carrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_continuar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(60, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Explorador de Productos";
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
            this.pnl_titu.Size = new System.Drawing.Size(1085, 43);
            this.pnl_titu.TabIndex = 2;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btn_cerrar.Location = new System.Drawing.Point(1043, 4);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(32, 32);
            this.btn_cerrar.TabIndex = 6;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lbl_TotalItems);
            this.panel1.Controls.Add(this.lbl_total);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Controls.Add(this.btn_Pedido);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_buscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1085, 41);
            this.panel1.TabIndex = 3;
            // 
            // lbl_TotalItems
            // 
            this.lbl_TotalItems.AutoSize = true;
            this.lbl_TotalItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalItems.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_TotalItems.Location = new System.Drawing.Point(377, 22);
            this.lbl_TotalItems.Name = "lbl_TotalItems";
            this.lbl_TotalItems.Size = new System.Drawing.Size(23, 15);
            this.lbl_TotalItems.TabIndex = 47;
            this.lbl_TotalItems.Text = "00";
            // 
            // lbl_total
            // 
            this.lbl_total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_total.Location = new System.Drawing.Point(957, 3);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(54, 30);
            this.lbl_total.TabIndex = 20;
            this.lbl_total.Text = "0,00";
            this.lbl_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_total.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(352, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 15);
            this.label16.TabIndex = 46;
            this.label16.Text = "Total Items";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(932, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 15);
            this.label14.TabIndex = 19;
            this.label14.Text = "S/";
            this.label14.Visible = false;
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.Location = new System.Drawing.Point(724, 1);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Add.Size = new System.Drawing.Size(128, 38);
            this.btn_Add.TabIndex = 18;
            this.btn_Add.Text = "Elegir Prod.";
            this.btn_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Pedido
            // 
            this.btn_Pedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Pedido.FlatAppearance.BorderSize = 0;
            this.btn_Pedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pedido.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Pedido.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pedido.Image")));
            this.btn_Pedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Pedido.Location = new System.Drawing.Point(867, 2);
            this.btn_Pedido.Name = "btn_Pedido";
            this.btn_Pedido.Size = new System.Drawing.Size(58, 38);
            this.btn_Pedido.TabIndex = 17;
            this.btn_Pedido.Text = "00";
            this.btn_Pedido.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_Pedido.UseVisualStyleBackColor = true;
            this.btn_Pedido.Click += new System.EventHandler(this.btn_Pedido_Click);
            // 
            // label2
            // 
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(299, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 30);
            this.label2.TabIndex = 16;
            this.toolTip1.SetToolTip(this.label2, "Buscar Proveedor");
            // 
            // txt_buscar
            // 
            this.txt_buscar.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_buscar.HintForeColor = System.Drawing.Color.Empty;
            this.txt_buscar.HintText = "Buscar Productos por Nombre,Marca,ID";
            this.txt_buscar.isPassword = false;
            this.txt_buscar.LineFocusedColor = System.Drawing.Color.Blue;
            this.txt_buscar.LineIdleColor = System.Drawing.Color.DarkGray;
            this.txt_buscar.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txt_buscar.LineThickness = 2;
            this.txt_buscar.Location = new System.Drawing.Point(11, 6);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(321, 31);
            this.txt_buscar.TabIndex = 0;
            this.txt_buscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_buscar.OnValueChanged += new System.EventHandler(this.txt_buscar_OnValueChanged);
            this.txt_buscar.Enter += new System.EventHandler(this.txt_buscar_Enter);
            this.txt_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_buscar_KeyDown);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // lsv_produ
            // 
            this.lsv_produ.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_produ.ForeColor = System.Drawing.Color.DimGray;
            this.lsv_produ.FullRowSelect = true;
            this.lsv_produ.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsv_produ.HideSelection = false;
            this.lsv_produ.Location = new System.Drawing.Point(0, 84);
            this.lsv_produ.Name = "lsv_produ";
            this.lsv_produ.Size = new System.Drawing.Size(1082, 483);
            this.lsv_produ.TabIndex = 17;
            this.lsv_produ.UseCompatibleStateImageBehavior = false;
            this.lsv_produ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsv_provee_KeyDown);
            this.lsv_produ.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsv_provee_MouseDoubleClick);
            // 
            // pnl_sms
            // 
            this.pnl_sms.BackColor = System.Drawing.Color.White;
            this.pnl_sms.Controls.Add(this.label4);
            this.pnl_sms.Controls.Add(this.pictureBox1);
            this.pnl_sms.Controls.Add(this.label8);
            this.pnl_sms.Location = new System.Drawing.Point(0, 534);
            this.pnl_sms.Name = "pnl_sms";
            this.pnl_sms.Size = new System.Drawing.Size(1085, 35);
            this.pnl_sms.TabIndex = 18;
            this.pnl_sms.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(0, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1085, 52);
            this.label4.TabIndex = 3;
            this.label4.Text = "INTENTA REALIZAR TU BUSQUEDA CON OTROS VALORES";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(302, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(509, 293);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Tomato;
            this.label8.Location = new System.Drawing.Point(0, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1085, 52);
            this.label8.TabIndex = 0;
            this.label8.Text = "BUSQUEDA SIN RESULTADO";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(142, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(609, 24);
            this.label6.TabIndex = 22;
            this.label6.Text = "Nombre del Producto";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(2, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "ID";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(744, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 24);
            this.label3.TabIndex = 24;
            this.label3.Text = "Marca";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DimGray;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(884, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 24);
            this.label7.TabIndex = 25;
            this.label7.Text = "Stock A";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DimGray;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(982, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 24);
            this.label10.TabIndex = 27;
            this.label10.Text = "Estado";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbo_LlenarSinSalir
            // 
            this.cbo_LlenarSinSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbo_LlenarSinSalir.AutoSize = true;
            this.cbo_LlenarSinSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_LlenarSinSalir.ForeColor = System.Drawing.Color.Green;
            this.cbo_LlenarSinSalir.Location = new System.Drawing.Point(918, 42);
            this.cbo_LlenarSinSalir.Name = "cbo_LlenarSinSalir";
            this.cbo_LlenarSinSalir.Size = new System.Drawing.Size(164, 21);
            this.cbo_LlenarSinSalir.TabIndex = 28;
            this.cbo_LlenarSinSalir.Text = "Llenar Carrito sin Salir";
            this.cbo_LlenarSinSalir.UseVisualStyleBackColor = true;
            // 
            // cbo_VerTodo
            // 
            this.cbo_VerTodo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbo_VerTodo.AutoSize = true;
            this.cbo_VerTodo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_VerTodo.ForeColor = System.Drawing.Color.Green;
            this.cbo_VerTodo.Location = new System.Drawing.Point(740, 42);
            this.cbo_VerTodo.Name = "cbo_VerTodo";
            this.cbo_VerTodo.Size = new System.Drawing.Size(173, 21);
            this.cbo_VerTodo.TabIndex = 29;
            this.cbo_VerTodo.Text = "Ver todos sin Excepcion";
            this.cbo_VerTodo.UseVisualStyleBackColor = true;
            this.cbo_VerTodo.CheckedChanged += new System.EventHandler(this.cbo_VerTodo_CheckedChanged);
            // 
            // cbo_Coti
            // 
            this.cbo_Coti.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbo_Coti.AutoSize = true;
            this.cbo_Coti.Enabled = false;
            this.cbo_Coti.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Coti.ForeColor = System.Drawing.Color.Green;
            this.cbo_Coti.Location = new System.Drawing.Point(531, 42);
            this.cbo_Coti.Name = "cbo_Coti";
            this.cbo_Coti.Size = new System.Drawing.Size(203, 21);
            this.cbo_Coti.TabIndex = 30;
            this.cbo_Coti.Text = "Agregar en Modo Cotizacion";
            this.cbo_Coti.UseVisualStyleBackColor = true;
            // 
            // cbo_Todo
            // 
            this.cbo_Todo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbo_Todo.AutoSize = true;
            this.cbo_Todo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Todo.ForeColor = System.Drawing.Color.Green;
            this.cbo_Todo.Location = new System.Drawing.Point(467, 42);
            this.cbo_Todo.Name = "cbo_Todo";
            this.cbo_Todo.Size = new System.Drawing.Size(58, 21);
            this.cbo_Todo.TabIndex = 31;
            this.cbo_Todo.Text = "Todo";
            this.cbo_Todo.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(4, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 20);
            this.label13.TabIndex = 35;
            this.label13.Text = "Estado:";
            // 
            // lbl_xpreCompra
            // 
            this.lbl_xpreCompra.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_xpreCompra.AutoSize = true;
            this.lbl_xpreCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_xpreCompra.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_xpreCompra.Location = new System.Drawing.Point(442, 41);
            this.lbl_xpreCompra.Name = "lbl_xpreCompra";
            this.lbl_xpreCompra.Size = new System.Drawing.Size(17, 20);
            this.lbl_xpreCompra.TabIndex = 43;
            this.lbl_xpreCompra.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(68, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 20);
            this.label17.TabIndex = 44;
            this.label17.Text = "-";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.cbo_LlenarSinSalir);
            this.panel2.Controls.Add(this.lbl_xpreCompra);
            this.panel2.Controls.Add(this.cbo_VerTodo);
            this.panel2.Controls.Add(this.cbo_Coti);
            this.panel2.Controls.Add(this.cbo_Todo);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 531);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1085, 71);
            this.panel2.TabIndex = 45;
            // 
            // pnl_Carrito
            // 
            this.pnl_Carrito.BackColor = System.Drawing.Color.Gray;
            this.pnl_Carrito.Controls.Add(this.label19);
            this.pnl_Carrito.Controls.Add(this.label15);
            this.pnl_Carrito.Controls.Add(this.btn_continuar);
            this.pnl_Carrito.Controls.Add(this.lbl_TotalItem);
            this.pnl_Carrito.Controls.Add(this.label18);
            this.pnl_Carrito.Controls.Add(this.lsv_Ped);
            this.pnl_Carrito.Location = new System.Drawing.Point(691, 105);
            this.pnl_Carrito.Name = "pnl_Carrito";
            this.pnl_Carrito.Size = new System.Drawing.Size(391, 420);
            this.pnl_Carrito.TabIndex = 46;
            this.pnl_Carrito.Visible = false;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.DimGray;
            this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(338, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 24);
            this.label19.TabIndex = 55;
            this.label19.Text = "Cant";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.DimGray;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(335, 24);
            this.label15.TabIndex = 54;
            this.label15.Text = "Nombre Producto";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_continuar
            // 
            this.btn_continuar.BackgroundStyle.GradientEndColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_continuar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_continuar.BackgroundStyle.SolidColor = System.Drawing.Color.Orange;
            this.btn_continuar.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btn_continuar.BorderStyle.SolidColor = System.Drawing.Color.Orange;
            this.btn_continuar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_continuar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_continuar.ForegroundImageStyle.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btn_continuar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_continuar.Location = new System.Drawing.Point(197, 5);
            this.btn_continuar.Name = "btn_continuar";
            this.btn_continuar.Size = new System.Drawing.Size(187, 34);
            this.btn_continuar.StateStyles.DisabledStyle.TextFont = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.btn_continuar.StateStyles.DisabledStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_continuar.StateStyles.FocusStyle.TextFont = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.btn_continuar.StateStyles.FocusStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_continuar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.Blue;
            this.btn_continuar.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.btn_continuar.StateStyles.HoverStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_continuar.StateStyles.PressedStyle.TextFont = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.btn_continuar.StateStyles.PressedStyle.TextForeColor = System.Drawing.Color.White;
            this.btn_continuar.TabIndex = 3;
            this.btn_continuar.TextStyle.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_continuar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_continuar.TextStyle.Text = "Continuar Venta[F5]";
            this.btn_continuar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_continuar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_continuar.Click += new System.EventHandler(this.btn_continuar_Click);
            // 
            // lbl_TotalItem
            // 
            this.lbl_TotalItem.AutoSize = true;
            this.lbl_TotalItem.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalItem.ForeColor = System.Drawing.Color.White;
            this.lbl_TotalItem.Location = new System.Drawing.Point(131, 11);
            this.lbl_TotalItem.Name = "lbl_TotalItem";
            this.lbl_TotalItem.Size = new System.Drawing.Size(30, 23);
            this.lbl_TotalItem.TabIndex = 1;
            this.lbl_TotalItem.Text = "00";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(3, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(130, 23);
            this.label18.TabIndex = 0;
            this.label18.Text = "Cantidad Item:";
            // 
            // lsv_Ped
            // 
            this.lsv_Ped.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_Ped.ForeColor = System.Drawing.Color.DimGray;
            this.lsv_Ped.FullRowSelect = true;
            this.lsv_Ped.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsv_Ped.HideSelection = false;
            this.lsv_Ped.Location = new System.Drawing.Point(3, 45);
            this.lsv_Ped.Name = "lsv_Ped";
            this.lsv_Ped.ShowItemToolTips = true;
            this.lsv_Ped.Size = new System.Drawing.Size(385, 372);
            this.lsv_Ped.TabIndex = 78;
            this.lsv_Ped.UseCompatibleStateImageBehavior = false;
            // 
            // lbl_IdProdu
            // 
            this.lbl_IdProdu.AutoSize = true;
            this.lbl_IdProdu.Location = new System.Drawing.Point(869, 182);
            this.lbl_IdProdu.Name = "lbl_IdProdu";
            this.lbl_IdProdu.Size = new System.Drawing.Size(60, 13);
            this.lbl_IdProdu.TabIndex = 46;
            this.lbl_IdProdu.Text = "lbl_IdProdu";
            this.lbl_IdProdu.Visible = false;
            // 
            // lbl_Nom_Prod
            // 
            this.lbl_Nom_Prod.AutoSize = true;
            this.lbl_Nom_Prod.Location = new System.Drawing.Point(869, 208);
            this.lbl_Nom_Prod.Name = "lbl_Nom_Prod";
            this.lbl_Nom_Prod.Size = new System.Drawing.Size(73, 13);
            this.lbl_Nom_Prod.TabIndex = 47;
            this.lbl_Nom_Prod.Text = "lbl_Nom_Prod";
            this.lbl_Nom_Prod.Visible = false;
            // 
            // lbl_TipoProd
            // 
            this.lbl_TipoProd.AutoSize = true;
            this.lbl_TipoProd.Location = new System.Drawing.Point(869, 239);
            this.lbl_TipoProd.Name = "lbl_TipoProd";
            this.lbl_TipoProd.Size = new System.Drawing.Size(66, 13);
            this.lbl_TipoProd.TabIndex = 48;
            this.lbl_TipoProd.Text = "lbl_TipoProd";
            this.lbl_TipoProd.Visible = false;
            // 
            // lbl_Uti_Unit
            // 
            this.lbl_Uti_Unit.AutoSize = true;
            this.lbl_Uti_Unit.Location = new System.Drawing.Point(872, 270);
            this.lbl_Uti_Unit.Name = "lbl_Uti_Unit";
            this.lbl_Uti_Unit.Size = new System.Drawing.Size(61, 13);
            this.lbl_Uti_Unit.TabIndex = 49;
            this.lbl_Uti_Unit.Text = "lbl_Uti_Unit";
            this.lbl_Uti_Unit.Visible = false;
            // 
            // lbl_und
            // 
            this.lbl_und.AutoSize = true;
            this.lbl_und.Location = new System.Drawing.Point(872, 301);
            this.lbl_und.Name = "lbl_und";
            this.lbl_und.Size = new System.Drawing.Size(41, 13);
            this.lbl_und.TabIndex = 50;
            this.lbl_und.Text = "lbl_und";
            this.lbl_und.Visible = false;
            // 
            // lbl_pre_unit
            // 
            this.lbl_pre_unit.AutoSize = true;
            this.lbl_pre_unit.Location = new System.Drawing.Point(872, 332);
            this.lbl_pre_unit.Name = "lbl_pre_unit";
            this.lbl_pre_unit.Size = new System.Drawing.Size(61, 13);
            this.lbl_pre_unit.TabIndex = 51;
            this.lbl_pre_unit.Text = "lbl_pre_unit";
            this.lbl_pre_unit.Visible = false;
            // 
            // lbl_importe
            // 
            this.lbl_importe.AutoSize = true;
            this.lbl_importe.Location = new System.Drawing.Point(872, 363);
            this.lbl_importe.Name = "lbl_importe";
            this.lbl_importe.Size = new System.Drawing.Size(57, 13);
            this.lbl_importe.TabIndex = 52;
            this.lbl_importe.Text = "lbl_importe";
            this.lbl_importe.Visible = false;
            // 
            // lbl_cant
            // 
            this.lbl_cant.AutoSize = true;
            this.lbl_cant.Location = new System.Drawing.Point(872, 392);
            this.lbl_cant.Name = "lbl_cant";
            this.lbl_cant.Size = new System.Drawing.Size(44, 13);
            this.lbl_cant.TabIndex = 53;
            this.lbl_cant.Text = "lbl_cant";
            this.lbl_cant.Visible = false;
            // 
            // Frm_ListadoProductos_Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1085, 602);
            this.Controls.Add(this.pnl_sms);
            this.Controls.Add(this.pnl_Carrito);
            this.Controls.Add(this.lbl_cant);
            this.Controls.Add(this.lbl_importe);
            this.Controls.Add(this.lbl_pre_unit);
            this.Controls.Add(this.lbl_und);
            this.Controls.Add(this.lbl_Uti_Unit);
            this.Controls.Add(this.lbl_TipoProd);
            this.Controls.Add(this.lbl_Nom_Prod);
            this.Controls.Add(this.lbl_IdProdu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.lsv_produ);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_ListadoProductos_Compras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Productos Compras";
            this.Load += new System.EventHandler(this.Frm_Proveedor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_ListadoProductos_Compras_KeyDown);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_sms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnl_Carrito.ResumeLayout(false);
            this.pnl_Carrito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_continuar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView lsv_produ;
        private System.Windows.Forms.Panel pnl_sms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txt_buscar;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Pedido;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_xpreCompra;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_TotalItems;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.CheckBox cbo_Todo;
        internal System.Windows.Forms.CheckBox cbo_Coti;
        internal System.Windows.Forms.CheckBox cbo_VerTodo;
        internal System.Windows.Forms.CheckBox cbo_LlenarSinSalir;
        private System.Windows.Forms.Panel pnl_Carrito;
        private System.Windows.Forms.Label lbl_TotalItem;
        private System.Windows.Forms.Label label18;
        private Klik.Windows.Forms.v1.EntryLib.ELButton btn_continuar;
        internal System.Windows.Forms.Label lbl_cant;
        internal System.Windows.Forms.Label lbl_importe;
        internal System.Windows.Forms.Label lbl_pre_unit;
        internal System.Windows.Forms.Label lbl_und;
        internal System.Windows.Forms.Label lbl_Uti_Unit;
        internal System.Windows.Forms.Label lbl_TipoProd;
        internal System.Windows.Forms.Label lbl_Nom_Prod;
        internal System.Windows.Forms.Label lbl_IdProdu;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.ListView lsv_Ped;
    }
}