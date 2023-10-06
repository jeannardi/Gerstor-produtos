using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_produtos
{
    public partial class frmAddRemoveEstoque : Form
    {
        public int IDPRODUTO;
        public bool add = true;
        public int Estqoue = 0;
        int NovoV = 0;
        public frmAddRemoveEstoque()
        {
            InitializeComponent();
        }

        private void frmAddRemoveEstoque_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(config.connectionString);

                MySqlDataAdapter DataAdapter = new MySqlDataAdapter("SELECT estoque From produtos WHERE id=@id;",conn);
                DataSet DS = new DataSet();
                DataAdapter.SelectCommand.Parameters.AddWithValue("@ID", IDPRODUTO);
                DataAdapter.Fill(DS);

 
                if (DS.Tables[0].Rows.Count >0)
                {
                    var Linha = DS.Tables[0].Rows[0];
                    numericUpDown1.Maximum = 9999999999;
                    Estqoue = Linha.Field<int>("estoque");
                    lblNovoValor.Text = Estqoue.ToString();
                    if (add)
                    {
                        label1.Text = "Adicionar ao estoque";
                        btAddRemove.Image = Properties.Resources.icons8_mais_24;
                        btAddRemove.Text = "Confirmar\nEntrada";
                        numericUpDown1.ForeColor = Color.Blue;
                        //Label status
                        var NovoV = Estqoue + numericUpDown1.Value;
                        label2.Text = $"Estoque: {Estqoue} + {(int)numericUpDown1.Value}";
                    }
                    else
                    {
                        numericUpDown1.Maximum = Estqoue;
                        numericUpDown1.ForeColor = Color.Red;
                        label1.Text = "Remover do estoque";
                        btAddRemove.Image = Properties.Resources.icons8_menos_24;
                        btAddRemove.Text = "Confirmar\nBaixa";

                        var NovoV = Estqoue - numericUpDown1.Value;
                        label2.Text = $"Estoque Atual: {Estqoue} - {(int)numericUpDown1.Value}";
                    }
                }
            }
            catch (MySqlException erro)
            {
                funcoes.ExibirNotificacao(this, "Não foi possivel alterar o estoque", 3000,true,Color.Red);
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           
           if (add)
            {
                NovoV = Estqoue + (int)numericUpDown1.Value;
                label2.Text = $"Estoque: {Estqoue} + {(int)numericUpDown1.Value}";
                lblNovoValor.Text = NovoV.ToString();
            }
            else
            {
                NovoV = Estqoue - (int)numericUpDown1.Value;
                label2.Text = $"Estoque Atual: {Estqoue} - {(int)numericUpDown1.Value}";
                lblNovoValor.Text = NovoV.ToString();
            }
           
        }

        private void btAddRemove_Click(object sender, EventArgs e)
        {
            if(NovoV >= 0) { 
            try
            {
                MySqlConnection con = new MySqlConnection(config.connectionString);
                    con.Open();

                using (MySqlCommand CMD = new MySqlCommand("UPDATE produtos SET estoque=@nestoque WHERE id=@id", con))
                {
                    CMD.Parameters.AddWithValue("@nestoque", NovoV);
                    CMD.Parameters.AddWithValue("@id", IDPRODUTO);
                    CMD.ExecuteNonQuery();
                    funcoes.ExibirNotificacao(this, $"Estoque alterado com sucesso! Para {NovoV}", 3000, true, Color.Green);
                    this.Close();
                    }
            }
            catch (MySqlException ErrorMysql)
            {
                funcoes.ExibirNotificacao(this, "Falhou existe algum problema ao tentar alterar o estoque.", 3000, true, Color.Red);
            }

            }
            else { btAddRemove.Enabled = false; }
        }
    }
}
