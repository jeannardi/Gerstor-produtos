using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gestor_de_produtos
{
    public partial class frmPlataforma : Form
    {
        public string platNome = "";
        public decimal preçofixo = 0;
        public int porcentagem = 0;
        public int idPlataforma;
        public frmPlataforma()
        {
            InitializeComponent();
        }

        private void btSalvarNovo_Click(object sender, EventArgs e)
        {
            if(txtPlataforma.Text.Length < 2)
            {
                funcoes.ExibirNotificacao(this, "Coloque um nome na plataforma", 2000, true);
                txtPlataforma.Focus();
                return;
            }

            MySqlConnection conn = new MySqlConnection(config.connectionString);

            try
            {
                conn.Open();
                try
                {
                    using (MySqlCommand command = new MySqlCommand("INSERT INTO plataformas (plataforma,valorfixo, porcentagem) VALUES (@nomeplataforma,@precofixo, @porcentagem) ON DUPLICATE KEY UPDATE plataforma = @nomeplataforma, valorfixo = @precofixo,porcentagem=@porcentagem;", conn))
                    {
                        command.Parameters.AddWithValue("@nomeplataforma", txtPlataforma.Text);
                        command.Parameters.AddWithValue("@porcentagem", decimal.Parse(txtPorcentagem.Text));
                        command.Parameters.AddWithValue("@precofixo", decimal.Parse(txtPrecoFixo.Text));
                        command.ExecuteNonQuery();
                        conn.Close();
                        funcoes.ExibirNotificacao(this, $"Plataforma {txtPlataforma.Text} adicionada", 2000, true,Color.Green);
                        this.Close();
                    }
                     
                }
                catch (MySqlException QueryError)
                {
                    MessageBox.Show(  QueryError.Message, "Erro na query ");
                }
            }
            catch(MySqlException errorc)
            {
                MessageBox.Show("Erro ao conectar no servidor: " + errorc.Message, "Problema de conecxão ");
            }

        }

        private void txtPorcentagem_Leave(object sender, EventArgs e)
        {
 
        }

        private void txtPrecoFixo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecoFixo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPrecoFixo.Text = decimal.Parse(txtPrecoFixo.Text).ToString("N2");

            }
            catch (Exception ex)

            {
                txtPrecoFixo.Text = "0,00";
            }
        }

        private void frmPlataforma_Load(object sender, EventArgs e)
        {
            
            if (!platNome.Equals("")){
                this.Text = "Editar";
                txtPlataforma.ReadOnly = true;
            }
            else
            {
                txtPlataforma.ReadOnly = false;
                this.Text = "Nova plataforma";
            }
            txtPlataforma.Text = platNome;
            txtPrecoFixo.Text = preçofixo.ToString("N2");
            txtPorcentagem.Text= porcentagem.ToString();
            this.ActiveControl = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idPlataforma > 0) { 
          
            MySqlConnection conn = new MySqlConnection(config.connectionString);

            try
            {
                conn.Open();
                try
                {
                    using (MySqlCommand command = new MySqlCommand("DELETE FROM plataformas where id=@idplata; DELETE FROM precovenda where plataformaid Like @idplata;", conn))
                    {
                        command.Parameters.AddWithValue("@nomeplataforma", platNome);
                        command.Parameters.AddWithValue("@idplata", idPlataforma);

                        command.ExecuteNonQuery();
                        conn.Close();
                        funcoes.ExibirNotificacao(this, $"Plataforma {txtPlataforma.Text} Excluida", 2000, true, Color.Red);
                        this.Close();
                    }

                }
                catch (MySqlException QueryError)
                {
                    MessageBox.Show(QueryError.Message, "Erro na query ");
                }
            }
            catch (MySqlException errorc)
            {
                MessageBox.Show("Erro ao conectar no servidor: " + errorc.Message, "Problema de conecxão ");
            }
        }
        }

        private void txtPlataforma_TextChanged(object sender, EventArgs e)
        {
            if (txtPlataforma.Text.ToLower() == "sem taxa") 
            {
                funcoes.ExibirNotificacao(txtPlataforma, "[Sem Taxa] é padrão do sistema então você nao pode user esse nome!", 4000, false);
                txtPlataforma.Text = "";
            }
        }
    }
}
