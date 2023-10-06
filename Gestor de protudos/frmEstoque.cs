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
    public partial class frmEstoque : Form
    {
        public frmEstoque()
        {
            InitializeComponent();
        }

        private void frmEstoque_Load(object sender, EventArgs e)
        {
           numericUpDown1.Value = Properties.Settings.Default.estoquebaixo;
            LerProdutos("");
            
        }
        public void LerProdutos(string Parametro)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(config.connectionString);
                conn.Open();

                try
                {
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter("SELECT id,estoque,nome,descricao FROM produtos where nome Like @nome ORDER BY estoque ASC;", conn))
                    {
                        adaptador.SelectCommand.Parameters.AddWithValue("nome", "%" + Parametro + "%");
                        DataSet dt = new DataSet();
                        adaptador.Fill(dt);

                        dataGridView1.DataSource = dt.Tables[0];
                        dataGridView1.ClearSelection();
                        if (dataGridView1.Columns.Count > 0)
                        {
                            dataGridView1.Columns[0].Visible = false;
                            dataGridView1.Columns[1].HeaderText = "Estoque";
                            dataGridView1.Columns[2].Width = 270;
                            dataGridView1.Columns[2].HeaderText = "Produto Nome";
                            dataGridView1.Columns[3].Width = 400;
                            dataGridView1.Columns[3].HeaderText = "Descrição do produto";
                        }
                        
                    }
                   
                }
                catch (MySqlException erroQuery)
                {
                    MessageBox.Show(erroQuery.Message.ToString(), "Erro query");
                }

            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.Message.ToString(), "Erro de conexão");
            }
          
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
 
            if (e.ColumnIndex == 1)
            {
                int valorBaixo = Properties.Settings.Default.estoquebaixo;
                int val = Convert.ToInt32(e.Value);
                if (val <= valorBaixo)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                frmAddRemoveEstoque fEstoque = new frmAddRemoveEstoque();
                DataGridViewRow ROW = dataGridView1.SelectedRows[0];
                fEstoque.IDPRODUTO = Convert.ToInt32(ROW.Cells[0].Value);
                fEstoque.add = true;
                fEstoque.Text="Entrada no Estoque";
                this.ActiveControl = null;
                fEstoque.ShowDialog();
                LerProdutos("");

            }
            else { funcoes.ExibirNotificacao(dataGridView1, "Selecione o produto para alterar seu estoque!", 4000, true); Console.Beep(); }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                frmAddRemoveEstoque fEstoque = new frmAddRemoveEstoque();
                DataGridViewRow ROW = dataGridView1.SelectedRows[0];
                fEstoque.IDPRODUTO = Convert.ToInt32(ROW.Cells[0].Value);
                fEstoque.add = false;
                fEstoque.Text = "Baixa no Estoque";
              
                this.ActiveControl = null;
                fEstoque.ShowDialog();
                LerProdutos("");

            }
            else { funcoes.ExibirNotificacao(dataGridView1, "Selecione o produto para alterar seu estoque!", 4000, true); Console.Beep(); }
        }

        private void frmEstoque_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.estoquebaixo = (int)numericUpDown1.Value; ;
            Properties.Settings.Default.Save();
            LerProdutos("");
            funcoes.ExibirNotificacao(numericUpDown1, $"Estoque baixo é considerando quando é igual ou menor que [{numericUpDown1.Value}]", 4000, true, Color.RoyalBlue);
            this.ActiveControl = null;
            config.FormularioPrincipal.estoquebaixo();
        }
    }
}
