
namespace ErpModuloAlmacenMP
{
    partial class DashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContact = new System.Windows.Forms.Button();
            this.btnSubMenuConfig = new System.Windows.Forms.Button();
            this.pnlSubMenuConfig = new System.Windows.Forms.Panel();
            this.btnConfigMateriaPrima = new System.Windows.Forms.Button();
            this.btnConfigClientes = new System.Windows.Forms.Button();
            this.btnConfigUsuarios = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pnlSubMenuMP = new System.Windows.Forms.Panel();
            this.btnReporteProveedorMP = new System.Windows.Forms.Button();
            this.btnReporteSMP = new System.Windows.Forms.Button();
            this.btnReporteEMP = new System.Windows.Forms.Button();
            this.btnReporteInventarioMP = new System.Windows.Forms.Button();
            this.btnConfigMP = new System.Windows.Forms.Button();
            this.btnSalidasMP = new System.Windows.Forms.Button();
            this.btnEntradaMP = new System.Windows.Forms.Button();
            this.btnSubMenuMateriaP = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblCharge = new System.Windows.Forms.Label();
            this.pnlFormloader = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnlSubMenuConfig.SuspendLayout();
            this.pnlSubMenuMP.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            this.panel1.Controls.Add(this.btnContact);
            this.panel1.Controls.Add(this.btnSubMenuConfig);
            this.panel1.Controls.Add(this.pnlSubMenuConfig);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.pnlSubMenuMP);
            this.panel1.Controls.Add(this.btnSubMenuMateriaP);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 800);
            this.panel1.TabIndex = 3;
            // 
            // btnContact
            // 
            this.btnContact.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnContact.FlatAppearance.BorderSize = 0;
            this.btnContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContact.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnContact.Image = ((System.Drawing.Image)(resources.GetObject("btnContact.Image")));
            this.btnContact.Location = new System.Drawing.Point(0, 649);
            this.btnContact.Margin = new System.Windows.Forms.Padding(4);
            this.btnContact.Name = "btnContact";
            this.btnContact.Size = new System.Drawing.Size(232, 52);
            this.btnContact.TabIndex = 27;
            this.btnContact.Text = "Contacto       ";
            this.btnContact.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnContact.UseVisualStyleBackColor = true;
            this.btnContact.Click += new System.EventHandler(this.btnContact_Click);
            // 
            // btnSubMenuConfig
            // 
            this.btnSubMenuConfig.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubMenuConfig.FlatAppearance.BorderSize = 0;
            this.btnSubMenuConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubMenuConfig.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubMenuConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnSubMenuConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnSubMenuConfig.Image")));
            this.btnSubMenuConfig.Location = new System.Drawing.Point(0, 701);
            this.btnSubMenuConfig.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubMenuConfig.Name = "btnSubMenuConfig";
            this.btnSubMenuConfig.Size = new System.Drawing.Size(232, 52);
            this.btnSubMenuConfig.TabIndex = 26;
            this.btnSubMenuConfig.Text = "Configuración";
            this.btnSubMenuConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSubMenuConfig.UseVisualStyleBackColor = true;
            this.btnSubMenuConfig.Click += new System.EventHandler(this.btnSubMenuConfig_Click);
            // 
            // pnlSubMenuConfig
            // 
            this.pnlSubMenuConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.pnlSubMenuConfig.Controls.Add(this.btnConfigMateriaPrima);
            this.pnlSubMenuConfig.Controls.Add(this.btnConfigClientes);
            this.pnlSubMenuConfig.Controls.Add(this.btnConfigUsuarios);
            this.pnlSubMenuConfig.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSubMenuConfig.Location = new System.Drawing.Point(0, 753);
            this.pnlSubMenuConfig.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSubMenuConfig.Name = "pnlSubMenuConfig";
            this.pnlSubMenuConfig.Size = new System.Drawing.Size(232, 158);
            this.pnlSubMenuConfig.TabIndex = 25;
            this.pnlSubMenuConfig.Visible = false;
            // 
            // btnConfigMateriaPrima
            // 
            this.btnConfigMateriaPrima.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfigMateriaPrima.FlatAppearance.BorderSize = 0;
            this.btnConfigMateriaPrima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigMateriaPrima.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigMateriaPrima.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnConfigMateriaPrima.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigMateriaPrima.Image")));
            this.btnConfigMateriaPrima.Location = new System.Drawing.Point(0, 104);
            this.btnConfigMateriaPrima.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfigMateriaPrima.Name = "btnConfigMateriaPrima";
            this.btnConfigMateriaPrima.Size = new System.Drawing.Size(232, 52);
            this.btnConfigMateriaPrima.TabIndex = 18;
            this.btnConfigMateriaPrima.Text = "Materia Prima     \r\n";
            this.btnConfigMateriaPrima.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfigMateriaPrima.UseVisualStyleBackColor = true;
            this.btnConfigMateriaPrima.Click += new System.EventHandler(this.btnConfigMateriaPrima_Click);
            // 
            // btnConfigClientes
            // 
            this.btnConfigClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfigClientes.FlatAppearance.BorderSize = 0;
            this.btnConfigClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigClientes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnConfigClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigClientes.Image")));
            this.btnConfigClientes.Location = new System.Drawing.Point(0, 52);
            this.btnConfigClientes.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfigClientes.Name = "btnConfigClientes";
            this.btnConfigClientes.Size = new System.Drawing.Size(232, 52);
            this.btnConfigClientes.TabIndex = 17;
            this.btnConfigClientes.Text = "Proveedores     ";
            this.btnConfigClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfigClientes.UseVisualStyleBackColor = true;
            this.btnConfigClientes.Click += new System.EventHandler(this.btnConfigClientes_Click);
            // 
            // btnConfigUsuarios
            // 
            this.btnConfigUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfigUsuarios.FlatAppearance.BorderSize = 0;
            this.btnConfigUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigUsuarios.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnConfigUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigUsuarios.Image")));
            this.btnConfigUsuarios.Location = new System.Drawing.Point(0, 0);
            this.btnConfigUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfigUsuarios.Name = "btnConfigUsuarios";
            this.btnConfigUsuarios.Size = new System.Drawing.Size(232, 52);
            this.btnConfigUsuarios.TabIndex = 13;
            this.btnConfigUsuarios.Text = "Usuarios           ";
            this.btnConfigUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfigUsuarios.UseVisualStyleBackColor = true;
            this.btnConfigUsuarios.Click += new System.EventHandler(this.btnConfigUsuarios_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(0, 911);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(232, 52);
            this.button3.TabIndex = 24;
            this.button3.Text = "Cerrar Sesión     ";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pnlSubMenuMP
            // 
            this.pnlSubMenuMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(74)))), ((int)(((byte)(84)))));
            this.pnlSubMenuMP.Controls.Add(this.btnReporteProveedorMP);
            this.pnlSubMenuMP.Controls.Add(this.btnReporteSMP);
            this.pnlSubMenuMP.Controls.Add(this.btnReporteEMP);
            this.pnlSubMenuMP.Controls.Add(this.btnReporteInventarioMP);
            this.pnlSubMenuMP.Controls.Add(this.btnConfigMP);
            this.pnlSubMenuMP.Controls.Add(this.btnSalidasMP);
            this.pnlSubMenuMP.Controls.Add(this.btnEntradaMP);
            this.pnlSubMenuMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubMenuMP.Location = new System.Drawing.Point(0, 281);
            this.pnlSubMenuMP.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSubMenuMP.Name = "pnlSubMenuMP";
            this.pnlSubMenuMP.Size = new System.Drawing.Size(232, 368);
            this.pnlSubMenuMP.TabIndex = 8;
            this.pnlSubMenuMP.Visible = false;
            // 
            // btnReporteProveedorMP
            // 
            this.btnReporteProveedorMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReporteProveedorMP.FlatAppearance.BorderSize = 0;
            this.btnReporteProveedorMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteProveedorMP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteProveedorMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnReporteProveedorMP.Image = ((System.Drawing.Image)(resources.GetObject("btnReporteProveedorMP.Image")));
            this.btnReporteProveedorMP.Location = new System.Drawing.Point(0, 314);
            this.btnReporteProveedorMP.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporteProveedorMP.Name = "btnReporteProveedorMP";
            this.btnReporteProveedorMP.Size = new System.Drawing.Size(232, 52);
            this.btnReporteProveedorMP.TabIndex = 16;
            this.btnReporteProveedorMP.Text = "R. Proveedor           ";
            this.btnReporteProveedorMP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReporteProveedorMP.UseVisualStyleBackColor = true;
            this.btnReporteProveedorMP.Click += new System.EventHandler(this.btnReporteProveedorMP_Click);
            // 
            // btnReporteSMP
            // 
            this.btnReporteSMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReporteSMP.FlatAppearance.BorderSize = 0;
            this.btnReporteSMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteSMP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteSMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnReporteSMP.Image = ((System.Drawing.Image)(resources.GetObject("btnReporteSMP.Image")));
            this.btnReporteSMP.Location = new System.Drawing.Point(0, 260);
            this.btnReporteSMP.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporteSMP.Name = "btnReporteSMP";
            this.btnReporteSMP.Size = new System.Drawing.Size(232, 54);
            this.btnReporteSMP.TabIndex = 15;
            this.btnReporteSMP.Text = "R. Traspasos          ";
            this.btnReporteSMP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReporteSMP.UseVisualStyleBackColor = true;
            this.btnReporteSMP.Click += new System.EventHandler(this.btnReporteSMP_Click);
            // 
            // btnReporteEMP
            // 
            this.btnReporteEMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReporteEMP.FlatAppearance.BorderSize = 0;
            this.btnReporteEMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteEMP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteEMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnReporteEMP.Image = ((System.Drawing.Image)(resources.GetObject("btnReporteEMP.Image")));
            this.btnReporteEMP.Location = new System.Drawing.Point(0, 208);
            this.btnReporteEMP.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporteEMP.Name = "btnReporteEMP";
            this.btnReporteEMP.Size = new System.Drawing.Size(232, 52);
            this.btnReporteEMP.TabIndex = 14;
            this.btnReporteEMP.Text = "Reportes        ";
            this.btnReporteEMP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReporteEMP.UseVisualStyleBackColor = true;
            this.btnReporteEMP.Click += new System.EventHandler(this.btnReporteEMP_Click);
            // 
            // btnReporteInventarioMP
            // 
            this.btnReporteInventarioMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReporteInventarioMP.FlatAppearance.BorderSize = 0;
            this.btnReporteInventarioMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteInventarioMP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteInventarioMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnReporteInventarioMP.Image = ((System.Drawing.Image)(resources.GetObject("btnReporteInventarioMP.Image")));
            this.btnReporteInventarioMP.Location = new System.Drawing.Point(0, 156);
            this.btnReporteInventarioMP.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporteInventarioMP.Name = "btnReporteInventarioMP";
            this.btnReporteInventarioMP.Size = new System.Drawing.Size(232, 52);
            this.btnReporteInventarioMP.TabIndex = 13;
            this.btnReporteInventarioMP.Text = "Inventario       ";
            this.btnReporteInventarioMP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReporteInventarioMP.UseVisualStyleBackColor = true;
            this.btnReporteInventarioMP.Click += new System.EventHandler(this.btnReporteInventarioMP_Click);
            // 
            // btnConfigMP
            // 
            this.btnConfigMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfigMP.FlatAppearance.BorderSize = 0;
            this.btnConfigMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigMP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnConfigMP.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigMP.Image")));
            this.btnConfigMP.Location = new System.Drawing.Point(0, 104);
            this.btnConfigMP.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfigMP.Name = "btnConfigMP";
            this.btnConfigMP.Size = new System.Drawing.Size(232, 52);
            this.btnConfigMP.TabIndex = 12;
            this.btnConfigMP.Text = "Configuración";
            this.btnConfigMP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfigMP.UseVisualStyleBackColor = true;
            this.btnConfigMP.Click += new System.EventHandler(this.btnConfigMP_Click);
            // 
            // btnSalidasMP
            // 
            this.btnSalidasMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalidasMP.FlatAppearance.BorderSize = 0;
            this.btnSalidasMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalidasMP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalidasMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnSalidasMP.Image = ((System.Drawing.Image)(resources.GetObject("btnSalidasMP.Image")));
            this.btnSalidasMP.Location = new System.Drawing.Point(0, 52);
            this.btnSalidasMP.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalidasMP.Name = "btnSalidasMP";
            this.btnSalidasMP.Size = new System.Drawing.Size(232, 52);
            this.btnSalidasMP.TabIndex = 8;
            this.btnSalidasMP.Text = "Salidas           ";
            this.btnSalidasMP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalidasMP.UseVisualStyleBackColor = true;
            this.btnSalidasMP.Click += new System.EventHandler(this.btnSalidasMP_Click);
            // 
            // btnEntradaMP
            // 
            this.btnEntradaMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEntradaMP.FlatAppearance.BorderSize = 0;
            this.btnEntradaMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntradaMP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntradaMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnEntradaMP.Image = ((System.Drawing.Image)(resources.GetObject("btnEntradaMP.Image")));
            this.btnEntradaMP.Location = new System.Drawing.Point(0, 0);
            this.btnEntradaMP.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntradaMP.Name = "btnEntradaMP";
            this.btnEntradaMP.Size = new System.Drawing.Size(232, 52);
            this.btnEntradaMP.TabIndex = 7;
            this.btnEntradaMP.Text = "Pesaje           ";
            this.btnEntradaMP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEntradaMP.UseVisualStyleBackColor = true;
            this.btnEntradaMP.Click += new System.EventHandler(this.btnEntradaMP_Click);
            // 
            // btnSubMenuMateriaP
            // 
            this.btnSubMenuMateriaP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubMenuMateriaP.FlatAppearance.BorderSize = 0;
            this.btnSubMenuMateriaP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubMenuMateriaP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubMenuMateriaP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnSubMenuMateriaP.Image = ((System.Drawing.Image)(resources.GetObject("btnSubMenuMateriaP.Image")));
            this.btnSubMenuMateriaP.Location = new System.Drawing.Point(0, 229);
            this.btnSubMenuMateriaP.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubMenuMateriaP.Name = "btnSubMenuMateriaP";
            this.btnSubMenuMateriaP.Size = new System.Drawing.Size(232, 52);
            this.btnSubMenuMateriaP.TabIndex = 7;
            this.btnSubMenuMateriaP.Text = "Almacén Materia";
            this.btnSubMenuMateriaP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSubMenuMateriaP.UseVisualStyleBackColor = true;
            this.btnSubMenuMateriaP.Click += new System.EventHandler(this.btnSubMenuMateriaP_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(238)))));
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.Location = new System.Drawing.Point(0, 177);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(232, 52);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Inicio                ";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(58)))), ((int)(((byte)(84)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.lblArea);
            this.panel2.Controls.Add(this.lblCharge);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 177);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(185)))), ((int)(((byte)(212)))));
            this.lblName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Location = new System.Drawing.Point(89, 47);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "User Name";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(185)))), ((int)(((byte)(212)))));
            this.lblArea.Location = new System.Drawing.Point(89, 80);
            this.lblArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(42, 17);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "Area";
            // 
            // lblCharge
            // 
            this.lblCharge.AutoSize = true;
            this.lblCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(185)))), ((int)(((byte)(212)))));
            this.lblCharge.Location = new System.Drawing.Point(89, 113);
            this.lblCharge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(60, 17);
            this.lblCharge.TabIndex = 2;
            this.lblCharge.Text = "Charge";
            // 
            // pnlFormloader
            // 
            this.pnlFormloader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFormloader.Location = new System.Drawing.Point(253, 0);
            this.pnlFormloader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFormloader.Name = "pnlFormloader";
            this.pnlFormloader.Size = new System.Drawing.Size(1148, 800);
            this.pnlFormloader.TabIndex = 5;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(1401, 800);
            this.Controls.Add(this.pnlFormloader);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Almacén Materia Prima";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DashBoard_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DashBoard_FormClosed);
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.panel1.ResumeLayout(false);
            this.pnlSubMenuConfig.ResumeLayout(false);
            this.pnlSubMenuMP.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnContact;
        private System.Windows.Forms.Button btnSubMenuConfig;
        private System.Windows.Forms.Panel pnlSubMenuConfig;
        private System.Windows.Forms.Button btnConfigMateriaPrima;
        private System.Windows.Forms.Button btnConfigClientes;
        private System.Windows.Forms.Button btnConfigUsuarios;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel pnlSubMenuMP;
        private System.Windows.Forms.Button btnReporteProveedorMP;
        private System.Windows.Forms.Button btnReporteSMP;
        private System.Windows.Forms.Button btnReporteEMP;
        private System.Windows.Forms.Button btnReporteInventarioMP;
        private System.Windows.Forms.Button btnConfigMP;
        private System.Windows.Forms.Button btnSalidasMP;
        private System.Windows.Forms.Button btnEntradaMP;
        private System.Windows.Forms.Button btnSubMenuMateriaP;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblCharge;
        private System.Windows.Forms.Panel pnlFormloader;
    }
}