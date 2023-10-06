
namespace Gestor_de_produtos
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtBin = new System.Windows.Forms.TextBox();
            this.txtBackup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btSelecionarBin = new System.Windows.Forms.Button();
            this.btSelecionarBackup = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btRestaurar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSqlFile = new System.Windows.Forms.TextBox();
            this.btSelecionarSql = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 312);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btSelecionarBackup);
            this.tabPage1.Controls.Add(this.btSelecionarBin);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtBackup);
            this.tabPage1.Controls.Add(this.txtBin);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(429, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Definições";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(429, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mysql";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtBin
            // 
            this.txtBin.Location = new System.Drawing.Point(6, 63);
            this.txtBin.Name = "txtBin";
            this.txtBin.Size = new System.Drawing.Size(324, 20);
            this.txtBin.TabIndex = 0;
            // 
            // txtBackup
            // 
            this.txtBackup.Location = new System.Drawing.Point(6, 105);
            this.txtBackup.Name = "txtBackup";
            this.txtBackup.Size = new System.Drawing.Size(324, 20);
            this.txtBackup.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pasta bin do mysql:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pasta de backup:";
            // 
            // btSelecionarBin
            // 
            this.btSelecionarBin.Location = new System.Drawing.Point(336, 63);
            this.btSelecionarBin.Name = "btSelecionarBin";
            this.btSelecionarBin.Size = new System.Drawing.Size(85, 20);
            this.btSelecionarBin.TabIndex = 6;
            this.btSelecionarBin.Text = "Selecionar";
            this.btSelecionarBin.UseVisualStyleBackColor = true;
            this.btSelecionarBin.Click += new System.EventHandler(this.btSelecionarBin_Click);
            // 
            // btSelecionarBackup
            // 
            this.btSelecionarBackup.Location = new System.Drawing.Point(336, 105);
            this.btSelecionarBackup.Name = "btSelecionarBackup";
            this.btSelecionarBackup.Size = new System.Drawing.Size(85, 20);
            this.btSelecionarBackup.TabIndex = 7;
            this.btSelecionarBackup.Text = "Selecionar";
            this.btSelecionarBackup.UseVisualStyleBackColor = true;
            this.btSelecionarBackup.Click += new System.EventHandler(this.btSelecionarBackup_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Configurar MySql";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btSelecionarSql);
            this.tabPage3.Controls.Add(this.txtSqlFile);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.btRestaurar);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.txtPassword);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(429, 286);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Restaurar banco de dados";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Senha atual do mysql:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(54, 182);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(324, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // btRestaurar
            // 
            this.btRestaurar.ForeColor = System.Drawing.Color.Red;
            this.btRestaurar.Location = new System.Drawing.Point(161, 218);
            this.btRestaurar.Name = "btRestaurar";
            this.btRestaurar.Size = new System.Drawing.Size(87, 41);
            this.btRestaurar.TabIndex = 8;
            this.btRestaurar.Text = "Iniciar Restauração";
            this.btRestaurar.UseVisualStyleBackColor = true;
            this.btRestaurar.Click += new System.EventHandler(this.btRestaurar_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(80, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 41);
            this.label4.TabIndex = 9;
            this.label4.Text = "Todos os dados no banco de dados atual serão subistituidos pelos dados do backup";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSqlFile
            // 
            this.txtSqlFile.Location = new System.Drawing.Point(52, 133);
            this.txtSqlFile.Name = "txtSqlFile";
            this.txtSqlFile.Size = new System.Drawing.Size(326, 20);
            this.txtSqlFile.TabIndex = 10;
            // 
            // btSelecionarSql
            // 
            this.btSelecionarSql.Location = new System.Drawing.Point(277, 156);
            this.btSelecionarSql.Name = "btSelecionarSql";
            this.btSelecionarSql.Size = new System.Drawing.Size(101, 20);
            this.btSelecionarSql.TabIndex = 11;
            this.btSelecionarSql.Text = "Selecionar";
            this.btSelecionarSql.UseVisualStyleBackColor = true;
            this.btSelecionarSql.Click += new System.EventHandler(this.btSelecionarSql_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Arquivo de dump do mysql (*.sql):";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 312);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btSelecionarBackup;
        private System.Windows.Forms.Button btSelecionarBin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBackup;
        private System.Windows.Forms.TextBox txtBin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btSelecionarSql;
        private System.Windows.Forms.TextBox txtSqlFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btRestaurar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
    }
}