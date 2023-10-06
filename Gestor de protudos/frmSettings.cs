using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_produtos
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btSelecionarBin_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBin = new FolderBrowserDialog();
            folderBin.Description = "Selecione a pasta bin do mysql";
            folderBin.SelectedPath = Properties.Settings.Default.mysqlbin;
            folderBin.ShowNewFolderButton = false;
            folderBin.ShowDialog();

            if(File.Exists(folderBin.SelectedPath + @"\mysql.exe") && File.Exists(folderBin.SelectedPath + @"\mysqldump.exe"))
            {
                Properties.Settings.Default.mysqlbin = folderBin.SelectedPath;
                Properties.Settings.Default.Save();
                txtBin.Text = folderBin.SelectedPath;
                funcoes.ExibirNotificacao(txtBin, "Pasta do bin do mysql selecionada.", 2000, false, Color.Green);
            }
            else
            {
                txtBin.Text = "Pasta invalida";
                funcoes.ExibirNotificacao(txtBin, "Pasta invalida, selecione a pasta bin do mysql.", 4000, false, Color.Red);
            }

        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtBin.Text = Properties.Settings.Default.mysqlbin;
            txtBackup.Text = Properties.Settings.Default.backupfolder;
        }

        private void btSelecionarBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBin = new FolderBrowserDialog();
            folderBin.Description = "Selecione a pasta backup";
            folderBin.SelectedPath = Properties.Settings.Default.backupfolder;
            folderBin.ShowNewFolderButton = true;
            folderBin.ShowDialog();

            if (Directory.Exists(folderBin.SelectedPath))
            {
                // Verifica se é possível escrever na pasta
                if ((File.GetAttributes(folderBin.SelectedPath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    txtBackup.Text = "Pasta invalida";
                    funcoes.ExibirNotificacao(txtBackup, "Não tem permisssões para salvar backup nessa pasta.", 4000, false, Color.Red);
                }
                else
                {
                    Properties.Settings.Default.backupfolder = folderBin.SelectedPath;
                    Properties.Settings.Default.Save();

                    txtBackup.Text = folderBin.SelectedPath;
                    funcoes.ExibirNotificacao(txtBackup, "Pasta do backup selecionada.", 2000, false, Color.Green);
                }
            }
            else
            {
                Console.WriteLine("A pasta não existe.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            new frmMysql().ShowDialog();
        }

        private void Commands(string cmd)
        {
            string connectionString = "Server=localhost;Uid=root;Pwd=" + txtPassword.Text + ";";
 

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(cmd, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {

                }

            }

        }
        private void btRestaurar_Click(object sender, EventArgs e)
        {
            if (File.Exists(@txtSqlFile.Text)) {
                Commands("SET GLOBAL net_buffer_length=1000000;");
                Commands("SET GLOBAL max_allowed_packet=1000000000;");
                Commands("SET GLOBAL foreign_key_checks = 0;");
                funcoes.ExibirNotificacao(this, "Iniciando backup!.", 2000, false, Color.Green);
                backup.Restaura(@txtSqlFile.Text, txtPassword.Text);
                Commands("SET GLOBAL foreign_key_checks = 1;");
              
            }
        }

        private void btSelecionarSql_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileSQLDialog = new OpenFileDialog();
            FileSQLDialog.Title = "Selecione SQL, DUMP para restauração do banco de dados.";
            FileSQLDialog.InitialDirectory = Properties.Settings.Default.backupfolder;
            FileSQLDialog.CheckFileExists = true;
            FileSQLDialog.CheckPathExists = true;
            FileSQLDialog.Filter = "Backup SQL e DUMP(*.sql; *.dump)| *.sql; *.dump";

            if (FileSQLDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtém o caminho completo do arquivo selecionado
                txtSqlFile.Text = FileSQLDialog.FileName;
                funcoes.ExibirNotificacao(txtSqlFile, "Backup Selecionado com sucesso!.", 2000, false, Color.Green);
            }
        }
    }
}
