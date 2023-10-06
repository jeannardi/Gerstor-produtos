
namespace Gestor_de_produtos
{
    partial class frmPlataforma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlataforma));
            this.txtPlataforma = new System.Windows.Forms.TextBox();
            this.txtPrecoFixo = new System.Windows.Forms.TextBox();
            this.txtPorcentagem = new System.Windows.Forms.TextBox();
            this.Plataforma = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btSalvarNovo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPlataforma
            // 
            this.txtPlataforma.Location = new System.Drawing.Point(12, 35);
            this.txtPlataforma.Name = "txtPlataforma";
            this.txtPlataforma.Size = new System.Drawing.Size(147, 20);
            this.txtPlataforma.TabIndex = 0;
            this.txtPlataforma.TextChanged += new System.EventHandler(this.txtPlataforma_TextChanged);
            // 
            // txtPrecoFixo
            // 
            this.txtPrecoFixo.Location = new System.Drawing.Point(12, 87);
            this.txtPrecoFixo.Name = "txtPrecoFixo";
            this.txtPrecoFixo.Size = new System.Drawing.Size(74, 20);
            this.txtPrecoFixo.TabIndex = 2;
            this.txtPrecoFixo.Text = "0,00";
            this.txtPrecoFixo.TextChanged += new System.EventHandler(this.txtPrecoFixo_TextChanged);
            this.txtPrecoFixo.Leave += new System.EventHandler(this.txtPrecoFixo_Leave);
            // 
            // txtPorcentagem
            // 
            this.txtPorcentagem.Location = new System.Drawing.Point(111, 87);
            this.txtPorcentagem.Name = "txtPorcentagem";
            this.txtPorcentagem.Size = new System.Drawing.Size(45, 20);
            this.txtPorcentagem.TabIndex = 1;
            this.txtPorcentagem.Text = "0";
            this.txtPorcentagem.Leave += new System.EventHandler(this.txtPorcentagem_Leave);
            // 
            // Plataforma
            // 
            this.Plataforma.AutoSize = true;
            this.Plataforma.Location = new System.Drawing.Point(9, 19);
            this.Plataforma.Name = "Plataforma";
            this.Plataforma.Size = new System.Drawing.Size(60, 13);
            this.Plataforma.TabIndex = 3;
            this.Plataforma.Text = "Plataforma:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Preço fixo R$:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Taxa %:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "+";
            // 
            // btSalvarNovo
            // 
            this.btSalvarNovo.Location = new System.Drawing.Point(85, 123);
            this.btSalvarNovo.Name = "btSalvarNovo";
            this.btSalvarNovo.Size = new System.Drawing.Size(73, 34);
            this.btSalvarNovo.TabIndex = 7;
            this.btSalvarNovo.Text = "Salvar";
            this.btSalvarNovo.UseVisualStyleBackColor = true;
            this.btSalvarNovo.Click += new System.EventHandler(this.btSalvarNovo_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(12, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Excluir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPlataforma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 169);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btSalvarNovo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Plataforma);
            this.Controls.Add(this.txtPorcentagem);
            this.Controls.Add(this.txtPrecoFixo);
            this.Controls.Add(this.txtPlataforma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPlataforma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plataformas Novo";
            this.Load += new System.EventHandler(this.frmPlataforma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlataforma;
        private System.Windows.Forms.TextBox txtPrecoFixo;
        private System.Windows.Forms.TextBox txtPorcentagem;
        private System.Windows.Forms.Label Plataforma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSalvarNovo;
        private System.Windows.Forms.Button button1;
    }
}