
namespace Gestor_de_produtos
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btAddProduto = new System.Windows.Forms.Button();
            this.btEditProduto = new System.Windows.Forms.Button();
            this.btPlataforma = new System.Windows.Forms.Button();
            this.btEstoque = new System.Windows.Forms.Button();
            this.btVendas = new System.Windows.Forms.Button();
            this.tmrMenuPrincipal = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.blblLucro = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarBackupAgoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Calendario = new System.Windows.Forms.MonthCalendar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowMenu.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1022, 624);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // flowMenu
            // 
            this.flowMenu.BackColor = System.Drawing.Color.DimGray;
            this.flowMenu.Controls.Add(this.flowLayoutPanel2);
            this.flowMenu.Controls.Add(this.flowLayoutPanel1);
            this.flowMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowMenu.Location = new System.Drawing.Point(0, 0);
            this.flowMenu.Name = "flowMenu";
            this.flowMenu.Size = new System.Drawing.Size(59, 729);
            this.flowMenu.TabIndex = 3;
            this.flowMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.flowMenu_Paint);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.button3);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(171, 60);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DimGray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageIndex = 32;
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point(3, 6);
            this.button3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 56);
            this.button3.TabIndex = 5;
            this.button3.TabStop = false;
            this.button3.Text = "Menu";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-cardápio-48 (2).png");
            this.imageList1.Images.SetKeyName(1, "icons8-adicionar-propriedade-48.png");
            this.imageList1.Images.SetKeyName(2, "ark_productbox_arc_6255.png");
            this.imageList1.Images.SetKeyName(3, "icons8-pago-48.png");
            this.imageList1.Images.SetKeyName(4, "edit_pencil_6320.png");
            this.imageList1.Images.SetKeyName(5, "ark_productbox_arc_6255.png");
            this.imageList1.Images.SetKeyName(6, "packaging_22140.png");
            this.imageList1.Images.SetKeyName(7, "pie_chart_22137.png");
            this.imageList1.Images.SetKeyName(8, "Newfile_page_document_empty_6315.png");
            this.imageList1.Images.SetKeyName(9, "Edit_30734.png");
            this.imageList1.Images.SetKeyName(10, "Managervolumes_graphic_5997.png");
            this.imageList1.Images.SetKeyName(11, "playlist_list_6297.png");
            this.imageList1.Images.SetKeyName(12, "reminders_pin_pin_6024.png");
            this.imageList1.Images.SetKeyName(13, "icons8-editar-propriedade-48.png");
            this.imageList1.Images.SetKeyName(14, "3440923-discount-ecommerce-label-percentage-shopping-tag_107535.png");
            this.imageList1.Images.SetKeyName(15, "BagOK_icon-icons.com_51210.png");
            this.imageList1.Images.SetKeyName(16, "ecommerce_online_shopping_app_icon_192423 (1).png");
            this.imageList1.Images.SetKeyName(17, "ecommerce_online_shopping_app_icon_192423.png");
            this.imageList1.Images.SetKeyName(18, "ecommerce_online_shopping_icon_192443.png");
            this.imageList1.Images.SetKeyName(19, "ecommerce_shopping_label_price_tag_icon_227312.png");
            this.imageList1.Images.SetKeyName(20, "iconfindercartsaleshop4177568-115973_115942.png");
            this.imageList1.Images.SetKeyName(21, "iconfinderpricetagdiscountsaleshop4177579-115986_115929.png");
            this.imageList1.Images.SetKeyName(22, "shop-icon_34368.png");
            this.imageList1.Images.SetKeyName(23, "shoppaymentorderbuy-25_icon-icons.com_73882.png");
            this.imageList1.Images.SetKeyName(24, "valentineshopping_79338.png");
            this.imageList1.Images.SetKeyName(25, "task_document_paper_descending_priority_tasks_documents_icon_142254.png");
            this.imageList1.Images.SetKeyName(26, "Box_1_35524 (1).png");
            this.imageList1.Images.SetKeyName(27, "ui_interface_list_navigation_menu_switcher_icon_219789.png");
            this.imageList1.Images.SetKeyName(28, "Menu-80_icon-icons.com_57300.png");
            this.imageList1.Images.SetKeyName(29, "icons8-menu-quadrado-42.png");
            this.imageList1.Images.SetKeyName(30, "icons8-cardápio-42.png");
            this.imageList1.Images.SetKeyName(31, "menuu.png");
            this.imageList1.Images.SetKeyName(32, "icons8-thumbnail-view-42.png");
            this.imageList1.Images.SetKeyName(33, "icons8-thumbnail-view-42.png");
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btAddProduto);
            this.flowLayoutPanel1.Controls.Add(this.btEditProduto);
            this.flowLayoutPanel1.Controls.Add(this.btPlataforma);
            this.flowLayoutPanel1.Controls.Add(this.btEstoque);
            this.flowLayoutPanel1.Controls.Add(this.btVendas);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 68);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(214, 612);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btAddProduto
            // 
            this.btAddProduto.BackColor = System.Drawing.Color.DimGray;
            this.btAddProduto.FlatAppearance.BorderSize = 0;
            this.btAddProduto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btAddProduto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btAddProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddProduto.ForeColor = System.Drawing.Color.White;
            this.btAddProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddProduto.ImageIndex = 1;
            this.btAddProduto.ImageList = this.imageList1;
            this.btAddProduto.Location = new System.Drawing.Point(3, 3);
            this.btAddProduto.Margin = new System.Windows.Forms.Padding(0);
            this.btAddProduto.Name = "btAddProduto";
            this.btAddProduto.Size = new System.Drawing.Size(159, 51);
            this.btAddProduto.TabIndex = 8;
            this.btAddProduto.TabStop = false;
            this.btAddProduto.Text = "   Adicionar Produtos";
            this.btAddProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAddProduto.UseVisualStyleBackColor = false;
            this.btAddProduto.Click += new System.EventHandler(this.btAddProduto_Click);
            // 
            // btEditProduto
            // 
            this.btEditProduto.BackColor = System.Drawing.Color.DimGray;
            this.btEditProduto.FlatAppearance.BorderSize = 0;
            this.btEditProduto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btEditProduto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btEditProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEditProduto.ForeColor = System.Drawing.Color.White;
            this.btEditProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEditProduto.ImageIndex = 13;
            this.btEditProduto.ImageList = this.imageList1;
            this.btEditProduto.Location = new System.Drawing.Point(3, 54);
            this.btEditProduto.Margin = new System.Windows.Forms.Padding(0);
            this.btEditProduto.Name = "btEditProduto";
            this.btEditProduto.Size = new System.Drawing.Size(159, 51);
            this.btEditProduto.TabIndex = 6;
            this.btEditProduto.TabStop = false;
            this.btEditProduto.Text = "   Editar Produtos";
            this.btEditProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEditProduto.UseVisualStyleBackColor = false;
            this.btEditProduto.Click += new System.EventHandler(this.btEditProduto_Click);
            // 
            // btPlataforma
            // 
            this.btPlataforma.BackColor = System.Drawing.Color.DimGray;
            this.btPlataforma.FlatAppearance.BorderSize = 0;
            this.btPlataforma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btPlataforma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btPlataforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPlataforma.ForeColor = System.Drawing.Color.White;
            this.btPlataforma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPlataforma.ImageIndex = 23;
            this.btPlataforma.ImageList = this.imageList1;
            this.btPlataforma.Location = new System.Drawing.Point(3, 105);
            this.btPlataforma.Margin = new System.Windows.Forms.Padding(0);
            this.btPlataforma.Name = "btPlataforma";
            this.btPlataforma.Size = new System.Drawing.Size(159, 51);
            this.btPlataforma.TabIndex = 7;
            this.btPlataforma.TabStop = false;
            this.btPlataforma.Text = "   Plataformas";
            this.btPlataforma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPlataforma.UseVisualStyleBackColor = false;
            this.btPlataforma.Click += new System.EventHandler(this.btPlataforma_Click);
            // 
            // btEstoque
            // 
            this.btEstoque.BackColor = System.Drawing.Color.DimGray;
            this.btEstoque.FlatAppearance.BorderSize = 0;
            this.btEstoque.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btEstoque.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEstoque.ForeColor = System.Drawing.Color.White;
            this.btEstoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEstoque.ImageIndex = 26;
            this.btEstoque.ImageList = this.imageList1;
            this.btEstoque.Location = new System.Drawing.Point(3, 156);
            this.btEstoque.Margin = new System.Windows.Forms.Padding(0);
            this.btEstoque.Name = "btEstoque";
            this.btEstoque.Size = new System.Drawing.Size(159, 51);
            this.btEstoque.TabIndex = 9;
            this.btEstoque.TabStop = false;
            this.btEstoque.Text = "   Estoque";
            this.btEstoque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEstoque.UseVisualStyleBackColor = false;
            this.btEstoque.Click += new System.EventHandler(this.btEstoque_Click);
            // 
            // btVendas
            // 
            this.btVendas.BackColor = System.Drawing.Color.DimGray;
            this.btVendas.FlatAppearance.BorderSize = 0;
            this.btVendas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btVendas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVendas.ForeColor = System.Drawing.Color.White;
            this.btVendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btVendas.ImageIndex = 3;
            this.btVendas.ImageList = this.imageList1;
            this.btVendas.Location = new System.Drawing.Point(3, 207);
            this.btVendas.Margin = new System.Windows.Forms.Padding(0);
            this.btVendas.Name = "btVendas";
            this.btVendas.Size = new System.Drawing.Size(159, 51);
            this.btVendas.TabIndex = 5;
            this.btVendas.TabStop = false;
            this.btVendas.Text = "   Add Venda";
            this.btVendas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btVendas.UseVisualStyleBackColor = false;
            this.btVendas.Click += new System.EventHandler(this.btVendas_Click);
            // 
            // tmrMenuPrincipal
            // 
            this.tmrMenuPrincipal.Interval = 10;
            this.tmrMenuPrincipal.Tick += new System.EventHandler(this.tmrMenuPrincipal_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.blblLucro);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(63, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1287, 710);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::Gestor_de_produtos.Properties.Resources._897227_money_piggy_save_money_savings_icon;
            this.pictureBox1.Location = new System.Drawing.Point(949, 633);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 52);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // blblLucro
            // 
            this.blblLucro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.blblLucro.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blblLucro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.blblLucro.Location = new System.Drawing.Point(604, 640);
            this.blblLucro.MinimumSize = new System.Drawing.Size(100, 45);
            this.blblLucro.Name = "blblLucro";
            this.blblLucro.Size = new System.Drawing.Size(339, 45);
            this.blblLucro.TabIndex = 6;
            this.blblLucro.Text = "...";
            this.blblLucro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1306, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Exibindo: Hoje";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStatus.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // pgressBar1
            // 
            this.pgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pgressBar1.Name = "pgressBar1";
            this.pgressBar1.Size = new System.Drawing.Size(100, 16);
            this.pgressBar1.Step = 20;
            this.pgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgressBar1.Visible = false;
            this.pgressBar1.Click += new System.EventHandler(this.pgressBar1_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesToolStripMenuItem,
            this.criarBackupAgoraToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::Gestor_de_produtos.Properties.Resources.gear_icon_icons_com_70125;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ToolTipText = "Configurações";
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Image = global::Gestor_de_produtos.Properties.Resources.gear_icon_icons_com_70125;
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // criarBackupAgoraToolStripMenuItem
            // 
            this.criarBackupAgoraToolStripMenuItem.Name = "criarBackupAgoraToolStripMenuItem";
            this.criarBackupAgoraToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.criarBackupAgoraToolStripMenuItem.Text = "Criar Backup Agora";
            this.criarBackupAgoraToolStripMenuItem.Click += new System.EventHandler(this.criarBackupAgoraToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.pgressBar1,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1350, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Calendario
            // 
            this.Calendario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Calendario.CalendarDimensions = new System.Drawing.Size(1, 3);
            this.Calendario.Location = new System.Drawing.Point(9, 46);
            this.Calendario.MaxSelectionCount = 90;
            this.Calendario.Name = "Calendario";
            this.Calendario.TabIndex = 7;
            this.Calendario.TrailingForeColor = System.Drawing.Color.Gray;
            this.Calendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Calendario_DateChanged);
            this.Calendario.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Items.AddRange(new object[] {
            "Hoje",
            "Último Mês",
            "Último 3 Mêses"});
            this.comboBox1.Location = new System.Drawing.Point(6, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(232, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel3.Controls.Add(this.comboBox1);
            this.flowLayoutPanel3.Controls.Add(this.Calendario);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(1103, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.flowLayoutPanel3.MaximumSize = new System.Drawing.Size(247, 600);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(247, 600);
            this.flowLayoutPanel3.TabIndex = 11;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Principal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.Shown += new System.EventHandler(this.frmPrincipal_Shown);
            this.Resize += new System.EventHandler(this.frmPrincipal_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowMenu.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowMenu;
        private System.Windows.Forms.Timer tmrMenuPrincipal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label blblLucro;
        private System.Windows.Forms.Button btVendas;
        private System.Windows.Forms.Button btEditProduto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btPlataforma;
        private System.Windows.Forms.Button btAddProduto;
        private System.Windows.Forms.Button btEstoque;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar pgressBar1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criarBackupAgoraToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MonthCalendar Calendario;
    }
}

