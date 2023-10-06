using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Gestor_de_produtos
{
    public partial class frmMysql : Form
    {
        public frmMysql()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string server = TxtIp.Text;
             string database = "jjngestorprodutos";
             string uid = "root";
             string password = TxtSenha.Text;
             string TesteconnectionString = "SERVER=" + server + ";" + "DATABASE=" +
                               database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(TesteconnectionString))
                {
                    conn.Open();
                    config.connectionString = TesteconnectionString;
                    config.FormularioPrincipal.Inicio();
                    funcoes.ExibirNotificacao(button1,"Conecção bem sucedida!",3000,true,Color.Green);
                    SalvarConn(TesteconnectionString);
                    
                    conn.Close();
                    this.Close();
                    
                }

            }catch(MySqlException erro)
            {
                funcoes.ExibirNotificacao(button1, "Impossivel connectar ao mysql!", 3000, true, Color.Red);
            }

    }
        private void SalvarConn(String Senha)
        {
            // Nome do arquivo de configuração
            string configFile = "config.xml";

            // Se o arquivo não existir, crie um novo documento XML com um elemento raiz
            if (!File.Exists(configFile))
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("Config");
                doc.AppendChild(root);
                doc.Save(configFile);
            }

            // Carregue o arquivo de configuração no documento XML
            XmlDocument configDoc = new XmlDocument();
            configDoc.Load(configFile);

            // Obtenha o elemento "Senha" do arquivo de configuração
            XmlElement senhaElement = (XmlElement)configDoc.SelectSingleNode("//conn");

            // Se o elemento "Senha" não existir, crie um novo elemento e adicione-o ao arquivo de configuração
            if (senhaElement == null)
            {
                senhaElement = configDoc.CreateElement("conn");
                configDoc.DocumentElement.AppendChild(senhaElement);
            }

            // Obtenha a senha do usuário e criptografe-a


            string senhaCriptografada = CriptografarSenha(Senha);

            // Defina o valor da senha criptografada no elemento "Senha"
            senhaElement.InnerText = senhaCriptografada;

            // Salve as alterações no arquivo de configuração
            configDoc.Save(configFile);

        }
        static string CriptografarSenha(string senha)
        {
            byte[] data = Encoding.UTF8.GetBytes(senha);
            byte[] result;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] key = md5.ComputeHash(Encoding.UTF8.GetBytes("chave_de_criptografia"));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                {
                    Key = key,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    result = transform.TransformFinalBlock(data, 0, data.Length);
                }
            }

            return Convert.ToBase64String(result);
        }
        static string DescriptografarSenha(string senhaCriptografada)
        {
            byte[] data = Convert.FromBase64String(senhaCriptografada);
            byte[] result;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] key = md5.ComputeHash(Encoding.UTF8.GetBytes("chave_de_criptografia"));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                {
                    Key = key,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    result = transform.TransformFinalBlock(data, 0, data.Length);
                }
            }

            return Encoding.UTF8.GetString(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
