using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_produtos
{

     class config
    {
        public static string server = "127.0.0.1";
        public static string database = "jjngestorprodutos";
        public static string uid = "root";
        public static string password = "zbr4563";
        public static string connectionString="";// = "SERVER=" + server + ";" + "DATABASE=" +
                                                 //database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        public static string MysqlBin = Properties.Settings.Default.mysqlbin;
        public static bool frmMenuPrincipal = false;
        public static frmPrincipal FormularioPrincipal;
    }

    class backup
    {
        public static void Restaura(string backupFilePath, string password)
        {
            string[] partes = config.connectionString.Split(';');

            string server = "127.0.0.1";
            string database = "";
            string uid = "root";

            // Percorrer o array de partes e separar as informações
            foreach (string parte in partes)
            {
                // Separar a parte em chave e valor com base no caractere '='
                string[] chaveValor = parte.Split('=');

                // Verificar qual é a chave e atribuir o valor à variável correspondente
                if (chaveValor[0] == "SERVER")
                {
                    server = chaveValor[1];
                }
                else if (chaveValor[0] == "DATABASE")
                {
                    database = chaveValor[1];
                }
                else if (chaveValor[0] == "UID")
                {
                    uid = chaveValor[1];
                }
          
            }

            config.MysqlBin = Properties.Settings.Default.mysqlbin;
            
            string comando = $"source {backupFilePath}";
            Console.WriteLine(comando);
            ProcessStartInfo startInfo = new ProcessStartInfo(config.MysqlBin + @"\mysql.exe", $"-u root --password={password} --connect_timeout=600 -e \"{comando}\"");

            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = false;

            Process process = new Process();
            process.StartInfo = startInfo;
            if (File.Exists(config.MysqlBin + @"\mysql.exe"))
            {
                process.Start();

            
            
            

            var estado = config.FormularioPrincipal.WindowState;
            config.FormularioPrincipal.Hide();
            Form NovoForm = new Form();
            Label Msg = new Label();
            NovoForm.Controls.Add(Msg);
            NovoForm.TopMost = true;
            NovoForm.FormBorderStyle = FormBorderStyle.None;

            Msg.TextAlign = ContentAlignment.MiddleCenter;
            Msg.Text = "Aguarde Restaurando backup \n Pode levar alguns minutos.";
            Msg.ForeColor = Color.White;
            Msg.BackColor = Color.Coral;
            Msg.AutoSize = false;
            Msg.Dock = DockStyle.Fill;
            NovoForm.StartPosition = FormStartPosition.CenterScreen;
            NovoForm.Size = new Size(200, 60);
            NovoForm.Show();
            Application.DoEvents();
            Thread.Sleep(1000);

   

            
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine("Saida >> " + output);
            string error = process.StandardError.ReadToEnd();
            Console.WriteLine("Erros >> " + error);
            if (process.ExitCode == 0)
            {
                //MessageBox.Show("Backup foi completado com sucesso");
                Msg.Text = "Backup foi completado com sucesso";
                Msg.ForeColor = Color.White;
                Msg.BackColor = Color.Green;
                Application.DoEvents();
                Application.Restart();
                Thread.Sleep(2000);
                NovoForm.Close();
                return;
            }
            else
            {
                //MessageBox.Show("Erro não foi possivel fazer o backup");
               
                Msg.Text = "Erro não foi possivel fazer o restaurar o backup";
                Console.Beep();
                   error = process.StandardError.ReadToEnd();
                    Console.WriteLine("Erros >> " + error);
  
                    Msg.ForeColor = Color.White;
                Msg.BackColor = Color.Red;
                Application.DoEvents();
                Thread.Sleep(2000);
            }

            Application.DoEvents();
            Thread.Sleep(2000);

            /////////////
            config.FormularioPrincipal.Show();
            config.FormularioPrincipal.WindowState = estado;
            NovoForm.Close();
            }
            else { MessageBox.Show("Não foi feito backup. Configure a pasta BIN do MYSQL."); }
        }
    

        public static void CriaBackup(string backupFilePath)
        {
            string[] partes = config.connectionString.Split(';');

            string server = "127.0.0.1";
            string database = "";
            string uid = "root";
            string password = "";

            // Percorrer o array de partes e separar as informações
            foreach (string parte in partes)
            {
                // Separar a parte em chave e valor com base no caractere '='
                string[] chaveValor = parte.Split('=');

                // Verificar qual é a chave e atribuir o valor à variável correspondente
                if (chaveValor[0] == "SERVER")
                {
                    server = chaveValor[1];
                }
                else if (chaveValor[0] == "DATABASE")
                {
                    database = chaveValor[1];
                }
                else if (chaveValor[0] == "UID")
                {
                    uid = chaveValor[1];
                }
                else if (chaveValor[0] == "PASSWORD")
                {
                    password = chaveValor[1];
                }
            }
            Console.WriteLine(server);
            Console.WriteLine(database);
            Console.WriteLine(uid);
            Console.WriteLine(password);


            config.MysqlBin = Properties.Settings.Default.mysqlbin;
            string fileName = config.MysqlBin + @"\mysqldump.exe";
            string arguments = string.Format("-u {0} --password={1} -B {2}", uid, password, database );
            ProcessStartInfo startInfo = new ProcessStartInfo(fileName, arguments);
            startInfo.Verb = "runas";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            Process process = new Process();
            process.StartInfo = startInfo;
     
            var estado = config.FormularioPrincipal.WindowState;
            config.FormularioPrincipal.Hide();
            Form NovoForm = new Form();
            Label Msg = new Label();
            NovoForm.Controls.Add(Msg);
            NovoForm.TopMost = true;
            NovoForm.FormBorderStyle = FormBorderStyle.None;
       
            Msg.TextAlign = ContentAlignment.MiddleCenter;
            Msg.Text = "Aguarde criando backup \n Pode levar alguns minutos.";
            Msg.ForeColor = Color.White;
            Msg.BackColor = Color.Coral;
            Msg.AutoSize = false;
            Msg.Dock = DockStyle.Fill;
            NovoForm.StartPosition = FormStartPosition.CenterScreen;
            NovoForm.Size = new Size(200, 60);
            NovoForm.Show();
            Application.DoEvents();
            Thread.Sleep(1000);


            if (File.Exists(fileName)) { 
                process.Start();
            
            // Ler a saída do console e gravar no arquivo de backup
            var  saidaFile = process.StandardOutput.ReadToEnd();
            using (StreamWriter sw = new StreamWriter(backupFilePath))
            {
                sw.Write(saidaFile);
            }
            
            process.WaitForExit();
    

            if (process.ExitCode == 0 && saidaFile.Contains("-- Dump completed on"))
            {
                //MessageBox.Show("Backup foi completado com sucesso");
                Msg.Text = "Backup foi completado com sucesso";
                Msg.ForeColor = Color.White;
                Msg.BackColor = Color.Green;
                Application.DoEvents();
            }
            else
            {
                //MessageBox.Show("Erro não foi possivel fazer o backup");

                Msg.Text = "Erro não foi possivel fazer o backup";
                Console.Beep();
                
                Msg.ForeColor = Color.White;
                Msg.BackColor = Color.Red;
                Application.DoEvents();
                Thread.Sleep(2000);
            }
       
            Application.DoEvents();
            Thread.Sleep(2000);

            /////////////
            config.FormularioPrincipal.Show();
            config.FormularioPrincipal.WindowState = estado;
            NovoForm.Close();
            }
            else { MessageBox.Show("Não foi feito backup. Configure a pasta BIN do MYSQLDUMP."); }
        }
    }
    public static class PlataformasMarket
    {
        private static List<ObjPlataformas> Lista = new List<ObjPlataformas>();

        public static void AdicionarPlataforma(int id, string Plataforma, decimal ValorFixo, decimal Porcentagem)
        {
            ObjPlataformas NovaPlataforma = new ObjPlataformas(id, Plataforma, ValorFixo, Porcentagem);
            Lista.Add(NovaPlataforma);
        }

        public static List<ObjPlataformas> ListaPlataforma()
        {
            return Lista;
        }
        public static void LimparLista()
        {
            Lista.Clear();
        }

        public static ObjPlataformas Item(string nome)
        {
            var objeto = Lista.FirstOrDefault(o => o.PlataformaNome == nome);
            if (objeto != null)
            {
                return objeto;


            }
            return null;
        }
    }
    public class ObjPlataformas
    {
        public  int id { get; }
        public string PlataformaNome { get; }
        public decimal ValorFixo { get; }
        public decimal PorcentagemPLataforma { get; }
        public decimal ValorProduto { get; set; }

        public ObjPlataformas(int idd, string Plataforma, decimal vFixo, decimal Porcentagem)
        {
            id = idd;
            PlataformaNome = Plataforma;
            ValorFixo = vFixo;
            PorcentagemPLataforma = Porcentagem;
        }
    }


    // Edição de vendas a tecla ENTER do datagridview no formulario principal
    public static class EditarVenda
    {
        public static int ID { get; set; }
        public static int AddEstoque { get; set; }
        public static int quantidade { get; set; }
        public static int ProdutoID { get; set; }

        public static string nomeProduto { get; set; }
        public static string descricao { get; set; }



        public static decimal valProduto { get; set; }
        public static decimal vcustounitario { get; set; }
        public static decimal vlogistica { get; set; }
        public static decimal vads { get; set; }

        public static decimal vplataforma { get; set; }
        public static decimal lucro { get; set; }

        public static DateTime datahora { get; set; }
        public static String Plataforma { get; set; }



    }
  public static class funcoes
    {
        private static List<Form> notificationForms = new List<Form>();

        private static void LimpaNotificações()
        {
          foreach(Form notf in notificationForms.ToList())
            {
                try { 
                notf.Close();
                }
                catch (ObjectDisposedException)
                {

                }
            }
        }
        public static void ExibirNotificacao(Control controle, string mensagem, int duracao, bool centro, Color? cor = null, bool? LimpaNotificao = false)
        {
            // Cria uma nova janela pop-up com as propriedades desejadas
            if (LimpaNotificao??false)
            {
                LimpaNotificações();
            }
            Form notificationForm = new Form();
            notificationForm.FormBorderStyle = FormBorderStyle.None;
            
            notificationForm.BackColor = Color.Coral;
      
                notificationForm.BackColor = cor?? Color.Coral;
   
            notificationForm.ForeColor = Color.White;
            notificationForm.StartPosition = FormStartPosition.Manual;
            notificationForm.Opacity = 0;
            notificationForm.TopMost = true;

            // Adiciona um Label na janela pop-up com a mensagem desejada
            Label messageLabel = new Label();
            messageLabel.Text = mensagem;
            messageLabel.Dock = DockStyle.Fill;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            notificationForm.Controls.Add(messageLabel);

            // Obtém a posição do controle em relação à janela do formulário principal
            Point controlLocation = controle.PointToScreen(Point.Empty);
            controlLocation.Offset(0, controle.Height );


            if (centro)
            {
                controlLocation.Offset(controle.Width / 2 - 150/2, -controle.Height/2 - 40/2);
            }
            // Define a posição da janela pop-up em relação ao controle

            notificationForm.Location = controlLocation;

            // Define o tamanho da janela pop-up e a exibe
            notificationForm.Size = new Size(150, 40);

            if((controle is TextBox) || (controle is NumericUpDown))
            {
                notificationForm.KeyPress += (sender, e) =>
                {
                    notificationForm.Close();
                };
                notificationForm.Shown += (sender, e) =>
                {
                    // Define o foco para o controle TextBox
                    controle.Focus();
                };

                messageLabel.Click += (sender, e) =>
                {
                    // Remove o foco do controle TextBox
                    controle.Focus();

                    // ...
                };
            }
   

   
            //remover da lista
            notificationForm.FormClosed += (sender, e) =>
            {
                notificationForms.Remove(notificationForm);
            };
            // Configura um Timer para aumentar gradualmente a opacidade da janela pop-up
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 50;
            timer1.Tick += (sender, e) =>
            {
                if (!notificationForm.IsDisposed) { 
                try
                {
                    if (notificationForm.Opacity < 1)
                {
                   
                        notificationForm.Opacity += 0.10;
           
                    
                }
                else
                {
                    timer1.Stop();
                }
                }

                catch (ObjectDisposedException ex) {  }
                catch { }
                }
            };
            timer1.Start();
            //fechar se clicar no label
            messageLabel.Click += (sender, e) =>
            {
                timer1.Enabled = false;
                notificationForm.Close();
            };
            // Configura um Timer para fechar a janela pop-up depois de alguns segundos
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = duracao;
            timer.Tick += (sender, e) =>
            {
                notificationForm.Close();
                timer.Stop();
            };
            timer.Start();

            notificationForm.Show();
            notificationForms.Add(notificationForm);
        }

    }
    public static class ListaDados
    {
        private static List<ItemDados> Lista = new List<ItemDados>();

        public static void AdicionarItem(DateTime DataHora, decimal ValorTotal, int NumeroDeVendas)
        {
            ItemDados Dado = new ItemDados(DataHora, ValorTotal, NumeroDeVendas);
            Lista.Add(Dado);
        }
        public static List<ItemDados> MostrarLista()
        {
            return Lista;
        }


    }

    public class ItemDados
    {
        public DateTime dataHora { get; }
        public decimal valorTotal { get; }
        public int numeroDeVendas { get; }

        public ItemDados(DateTime dataHora, decimal valorTotal, int numeroDeVendas)
        {
            this.dataHora = dataHora;
            this.valorTotal = valorTotal;
            this.numeroDeVendas = numeroDeVendas;
        }
    }
}

