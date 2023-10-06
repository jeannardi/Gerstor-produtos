
namespace Gestor_de_produtos
{
    partial class frmAddProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddProduto));
            this.txtProdutoNome = new System.Windows.Forms.TextBox();
            this.txtDescri = new System.Windows.Forms.TextBox();
            this.txtValCusto = new System.Windows.Forms.TextBox();
            this.txtValLogistica = new System.Windows.Forms.TextBox();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lvPlataformas = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btExcluir = new System.Windows.Forms.Button();
            this.btAddProduto = new System.Windows.Forms.Button();
            this.btPreçoVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.btDesativar = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProdutoNome
            // 
            this.txtProdutoNome.Location = new System.Drawing.Point(12, 44);
            this.txtProdutoNome.Name = "txtProdutoNome";
            this.txtProdutoNome.Size = new System.Drawing.Size(447, 20);
            this.txtProdutoNome.TabIndex = 0;
            this.txtProdutoNome.Enter += new System.EventHandler(this.txtProdutoNome_Enter);
            // 
            // txtDescri
            // 
            this.txtDescri.Location = new System.Drawing.Point(12, 70);
            this.txtDescri.Multiline = true;
            this.txtDescri.Name = "txtDescri";
            this.txtDescri.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescri.Size = new System.Drawing.Size(451, 82);
            this.txtDescri.TabIndex = 2;
            this.txtDescri.Enter += new System.EventHandler(this.txtDescri_Enter);
            // 
            // txtValCusto
            // 
            this.txtValCusto.Location = new System.Drawing.Point(12, 182);
            this.txtValCusto.Name = "txtValCusto";
            this.txtValCusto.Size = new System.Drawing.Size(81, 20);
            this.txtValCusto.TabIndex = 3;
            this.txtValCusto.Text = "0,00";
            this.txtValCusto.TextChanged += new System.EventHandler(this.txtValCusto_TextChanged);
            this.txtValCusto.Enter += new System.EventHandler(this.txtValCusto_Enter);
            this.txtValCusto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValCusto_KeyPress);
            this.txtValCusto.Leave += new System.EventHandler(this.txtValCusto_Leave);
            // 
            // txtValLogistica
            // 
            this.txtValLogistica.Location = new System.Drawing.Point(99, 182);
            this.txtValLogistica.Name = "txtValLogistica";
            this.txtValLogistica.Size = new System.Drawing.Size(108, 20);
            this.txtValLogistica.TabIndex = 4;
            this.txtValLogistica.Text = "0,00";
            this.txtValLogistica.Enter += new System.EventHandler(this.txtValLogistica_Enter);
            this.txtValLogistica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValLogistica_KeyPress);
            this.txtValLogistica.Leave += new System.EventHandler(this.txtValLogistica_Leave);
            // 
            // txtEstoque
            // 
            this.txtEstoque.Location = new System.Drawing.Point(213, 182);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(81, 20);
            this.txtEstoque.TabIndex = 6;
            this.txtEstoque.Text = "100";
            this.txtEstoque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstoque_KeyPress);
            this.txtEstoque.Leave += new System.EventHandler(this.txtEstoque_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nome do produto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(9, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Preço de venda nas plataformas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(9, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Custo Unitario";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Brown;
            this.label4.Location = new System.Drawing.Point(96, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Custo Logistica";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Estoque";
            // 
            // lvPlataformas
            // 
            this.lvPlataformas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvPlataformas.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lvPlataformas.FullRowSelect = true;
            this.lvPlataformas.GridLines = true;
            this.lvPlataformas.HideSelection = false;
            this.lvPlataformas.Location = new System.Drawing.Point(12, 235);
            this.lvPlataformas.MultiSelect = false;
            this.lvPlataformas.Name = "lvPlataformas";
            this.lvPlataformas.Size = new System.Drawing.Size(447, 132);
            this.lvPlataformas.TabIndex = 15;
            this.lvPlataformas.UseCompatibleStateImageBehavior = false;
            this.lvPlataformas.View = System.Windows.Forms.View.Details;
            this.lvPlataformas.SelectedIndexChanged += new System.EventHandler(this.lvPlataformas_SelectedIndexChanged);
            this.lvPlataformas.DoubleClick += new System.EventHandler(this.lvPlataformas_DoubleClick);
            this.lvPlataformas.Enter += new System.EventHandler(this.lvPlataformas_Enter);
            this.lvPlataformas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvPlataformas_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Plataforma Nome";
            this.columnHeader1.Width = 336;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Preço de venda";
            this.columnHeader2.Width = 90;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btPreçoVenda,
            this.btDesativar});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 48);
            // 
            // btExcluir
            // 
            this.btExcluir.Image = global::Gestor_de_produtos.Properties.Resources.icons8_apagar_para_sempre_24;
            this.btExcluir.Location = new System.Drawing.Point(274, 373);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(89, 35);
            this.btExcluir.TabIndex = 8;
            this.btExcluir.Text = "&Excluir";
            this.btExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Visible = false;
            this.btExcluir.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btAddProduto
            // 
            this.btAddProduto.Image = global::Gestor_de_produtos.Properties.Resources.icons8_selecionado_24;
            this.btAddProduto.Location = new System.Drawing.Point(369, 373);
            this.btAddProduto.Name = "btAddProduto";
            this.btAddProduto.Size = new System.Drawing.Size(90, 35);
            this.btAddProduto.TabIndex = 7;
            this.btAddProduto.Text = "Adicionar";
            this.btAddProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAddProduto.UseVisualStyleBackColor = true;
            this.btAddProduto.Click += new System.EventHandler(this.btAddProduto_Click);
            // 
            // btPreçoVenda
            // 
            this.btPreçoVenda.ForeColor = System.Drawing.Color.Black;
            this.btPreçoVenda.Image = global::Gestor_de_produtos.Properties.Resources.ic_attach_money_128_28210;
            this.btPreçoVenda.Name = "btPreçoVenda";
            this.btPreçoVenda.Size = new System.Drawing.Size(193, 22);
            this.btPreçoVenda.Text = "Definir preço de venda";
            this.btPreçoVenda.Click += new System.EventHandler(this.btPreçoVenda_Click);
            // 
            // btDesativar
            // 
            this.btDesativar.Image = global::Gestor_de_produtos.Properties.Resources.icons8_menos_24;
            this.btDesativar.Name = "btDesativar";
            this.btDesativar.Size = new System.Drawing.Size(193, 22);
            this.btDesativar.Text = "Remover [Plataforma]";
            this.btDesativar.Click += new System.EventHandler(this.btDesativar_Click);
            // 
            // frmAddProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 418);
            this.Controls.Add(this.lvPlataformas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEstoque);
            this.Controls.Add(this.txtValLogistica);
            this.Controls.Add(this.txtValCusto);
            this.Controls.Add(this.txtDescri);
            this.Controls.Add(this.txtProdutoNome);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btAddProduto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAddProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Novo produto";
            this.Load += new System.EventHandler(this.frmAddProduto_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddProduto;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.TextBox txtProdutoNome;
        private System.Windows.Forms.TextBox txtDescri;
        private System.Windows.Forms.TextBox txtValCusto;
        private System.Windows.Forms.TextBox txtValLogistica;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvPlataformas;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btPreçoVenda;
        private System.Windows.Forms.ToolStripMenuItem btDesativar;
    }
}