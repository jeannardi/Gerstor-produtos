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
    public partial class frmListaPlataformas : Form
    {
        public frmListaPlataformas()
        {
            InitializeComponent();
        }
        public void LerProdutos(string Parametro)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(config.connectionString);
                conn.Open();

                try
                {
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter("SELECT id,plataforma,valorfixo,porcentagem FROM plataformas where plataforma Like @nome;", conn))
                    {
                        adaptador.SelectCommand.Parameters.AddWithValue("nome", "%" + Parametro + "%");
                        DataSet gaby = new DataSet();
                        adaptador.Fill(gaby);

                        DataRow linnhaadd = gaby.Tables[0].NewRow();
                        linnhaadd["id"] = 0;
                        linnhaadd["plataforma"] = "Sem Taxa";
                        linnhaadd["valorfixo"] = (decimal)0;
                        linnhaadd["porcentagem"] = (decimal)0;
         

                        gaby.Tables[0].Rows.Add(linnhaadd);
                        dataGridView1.DataSource = gaby.Tables[0];
                        dataGridView1.ClearSelection();
                        if (dataGridView1.Columns.Count > 0)
                        {
                            dataGridView1.Columns[0].Visible = false;
                            dataGridView1.Columns[1].HeaderText = "Plataforma";
                            dataGridView1.Columns[1].Width = 270;
                            dataGridView1.Columns[2].HeaderText = "Valor Fixo";
                            dataGridView1.Columns[2].Width = 90;
                            dataGridView1.Columns[3].HeaderText = "Porcentagem";
                            dataGridView1.Columns[3].Width = 84;

                            dataGridView1.Columns[2].DefaultCellStyle.Format = "c";
                            dataGridView1.Columns[3].DefaultCellStyle.Format = "0.0\\%";
                            //ToString("0\\%")
                            
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
        private void btFiltro_Click(object sender, EventArgs e)
        {
            LerProdutos(txtFiltro.Text);
        }

        private void frmListaPlataformas_Load(object sender, EventArgs e)
        {
            LerProdutos("");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
  
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            new frmPlataforma().ShowDialog();
            LerProdutos("");
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    e.SuppressKeyPress = true;
                    DataGridViewRow Linha = dataGridView1.SelectedRows[0];
                    int id = Convert.ToInt32(Linha.Cells[0].Value);
                    string Nome = Linha.Cells[1].Value.ToString();
                    decimal valorFixo = Convert.ToDecimal(Linha.Cells[2].Value);
                    int porcetagem = Convert.ToInt32(Linha.Cells[3].Value);
                    if (Nome.ToLower() != "sem taxa") { 
                    frmPlataforma plata = new frmPlataforma();
                    plata.platNome = Nome;
                    plata.preçofixo = valorFixo;
                    plata.porcentagem = porcetagem;
                    plata.idPlataforma = id;
                    plata.ShowDialog();
                    LerProdutos("");
                    dataGridView1.ClearSelection();
                    }
                    else
                    {
                        funcoes.ExibirNotificacao(dataGridView1, "Sem taxa é padrão do sistema não pode ser alterado", 4000, true);
                    }
                }
                }
            }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow Linha = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(Linha.Cells[0].Value);
                string Nome = Linha.Cells[1].Value.ToString();
                decimal valorFixo = Convert.ToDecimal(Linha.Cells[2].Value);
                int porcetagem = Convert.ToInt32(Linha.Cells[3].Value);
                if (Nome.ToLower() != "sem taxa") { 
                frmPlataforma plata = new frmPlataforma();
                plata.platNome = Nome;
                plata.preçofixo = valorFixo;
                plata.porcentagem = porcetagem;
                plata.idPlataforma = id;
                plata.ShowDialog();
                LerProdutos("");
                dataGridView1.ClearSelection();
                }
                else
                {
                    funcoes.ExibirNotificacao(dataGridView1, "Sem taxa é padrão do sistema não pode ser alterado", 4000, true);
                }
            }
        }
    }
    
}
