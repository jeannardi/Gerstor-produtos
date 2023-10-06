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
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
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
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter("SELECT id,nome,descricao,vcustounitario,vlogistica,estoque FROM produtos where nome Like @nome;", conn))
                    {
                        adaptador.SelectCommand.Parameters.AddWithValue("nome", "%" + Parametro + "%");
                        DataSet gaby = new DataSet();
                        adaptador.Fill(gaby);

                        dataGridView1.DataSource = gaby.Tables[0];
                        dataGridView1.ClearSelection();
                        if (dataGridView1.Columns.Count > 0)
                        {
                            dataGridView1.Columns[0].Visible = false;
                            dataGridView1.Columns[1].HeaderText = "Nome";
                            dataGridView1.Columns[1].Width = 270;
                            dataGridView1.Columns[2].HeaderText = "Descrição";
                            dataGridView1.Columns[3].HeaderText = "V. Produto";
                            dataGridView1.Columns[4].HeaderText = "V. Logistica";
                            dataGridView1.Columns[5].HeaderText = "Estoque";
                            dataGridView1.Columns[5].Width = 84;

                            dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
                            dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
                        }
                        
                    }
                    
                }
                catch(MySqlException erroQuery)
                {
                    MessageBox.Show(erroQuery.Message.ToString(),"Erro query");
                }
                
            }
            catch(MySqlException erro)
            {
                MessageBox.Show(erro.Message.ToString(),"Erro de conexão");
            }
        }

        private void btFiltro_Click(object sender, EventArgs e)
        {
            
            LerProdutos(txtFiltro.Text);
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btFiltro.PerformClick();
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            frmAddProduto frmModificar = new frmAddProduto();
            frmModificar.ShowDialog();
            LerProdutos(txtFiltro.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
   
            funcoes.ExibirNotificacao(dataGridView1, "Precione tecla [Enter] para editar.", 5000, true);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(dataGridView1.SelectedRows.Count == 1)
                {
                    e.SuppressKeyPress = true;
                    DataGridViewRow RowSelecionada = dataGridView1.SelectedRows[0];
                    frmAddProduto frmModificar = new frmAddProduto();
                    frmModificar.Text = "Alterar Produto";
                    frmModificar.AlterarProdutoID = Convert.ToInt32(RowSelecionada.Cells[0].Value);
                    frmModificar.Alterar = true;
                    frmModificar.ShowDialog();
                    LerProdutos(txtFiltro.Text);
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {

                DataGridViewRow RowSelecionada = dataGridView1.SelectedRows[0];
                frmAddProduto frmModificar = new frmAddProduto();
                frmModificar.Text = "Alterar Produto";
                frmModificar.AlterarProdutoID = Convert.ToInt32(RowSelecionada.Cells[0].Value);
                frmModificar.Alterar = true;
                frmModificar.ShowDialog();
                LerProdutos(txtFiltro.Text);
            }


        }
        }
    
}
