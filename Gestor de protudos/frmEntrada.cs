using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestor_de_produtos.Properties;
using MySql.Data.MySqlClient;

namespace Gestor_de_produtos
{
    public partial class frmEntrada : Form
    {
        public MySqlConnection connection;
        public bool TrocarDados = true;
        public frmEntrada()
        {
            InitializeComponent();
        }

        private void frmEntrada_Load(object sender, EventArgs e)
        {

                
                txtVendaPreco.Text = "0,00";
                lblLucro.Text = "0,00";
                dataGridView1.ClearSelection();

    

            ListaCaixa("");
        }



        private void ListaCaixa(string filtro)
        {
            connection = new MySqlConnection(config.connectionString);
            try
            {

                connection.Open();
      

                string  querysql = "SELECT id,nome,descricao,vcustounitario,vlogistica,estoque FROM produtos where nome LIKE @filtro and estoque >= 1;";

    
                MySqlDataAdapter adapter = new MySqlDataAdapter(querysql, connection);
  
                    adapter.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                DataSet ds = new DataSet();

                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Produto Nome";
                dataGridView1.Columns[2].HeaderText = "Descrição";
                dataGridView1.Columns[3].HeaderText = "Custo Unitario";
                dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[4].HeaderText = "Custo Logistica";
                dataGridView1.Columns[5].HeaderText = "Estoque";

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtVendaPreco.Text = "0,00";
            ListaCaixa(textBox1.Text);
        }

        private void btAddVenda_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && comboBox1.SelectedIndex >= 0)
            {
                
                int LinhaSelecionada = dataGridView1.SelectedCells[0].RowIndex;

                int idProduto;
                int.TryParse(dataGridView1.Rows[LinhaSelecionada].Cells[0].Value.ToString(),out idProduto);
                int estoque;
                int.TryParse(dataGridView1.Rows[LinhaSelecionada].Cells[5].Value.ToString(), out estoque);

                string produtonome = dataGridView1.Rows[LinhaSelecionada].Cells[1].Value.ToString();
                string descri = dataGridView1.Rows[LinhaSelecionada].Cells[2].Value.ToString();



                decimal valProduto;
                decimal CustoProduto;
          
    
                decimal CustoLogistica;
                decimal custoads;
    

                if (decimal.TryParse(txtVendaPreco.Text.ToString().Replace("R$", "").Trim(), out valProduto))
                {

                    decimal.TryParse(dataGridView1.Rows[LinhaSelecionada].Cells[3].Value.ToString(), out CustoProduto);
                    decimal.TryParse(dataGridView1.Rows[LinhaSelecionada].Cells[4].Value.ToString().Replace("R$", "").Trim(), out CustoLogistica);
                    decimal.TryParse(txtCustoAds.Text.Replace("R$", "").Trim(), out custoads);

                    if (estoque >= 1 && numericUpDown1.Value >= 1)
                    {
                        decimal valorFixo = PlataformasMarket.Item(comboBox1.SelectedItem.ToString()).ValorFixo;
                        decimal porcentagem = PlataformasMarket.Item(comboBox1.SelectedItem.ToString()).PorcentagemPLataforma;



                        if (estoque >= 1 && numericUpDown1.Value >= 1)

                        {

                            decimal valProdutoLiquido = valProduto * (1 - porcentagem / 100m);
                            decimal plataformavalor = valProduto - valProdutoLiquido + valorFixo;

                            decimal Lucro = valProdutoLiquido - CustoProduto - CustoLogistica - custoads - valorFixo;
                            numericUpDown1.Maximum = estoque;
                            Lucro = Lucro * numericUpDown1.Value;
                            lblLucro.Text = Lucro.ToString("C");

                            estoque = estoque - (int)numericUpDown1.Value;

                            if (estoque < 0)
                            {
                                estoque = 0;
                            }

                            AdicionarProduto(descri, valProduto, CustoProduto, numericUpDown1.Value, produtonome, custoads, plataformavalor, CustoLogistica, Lucro, idProduto, estoque);
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor válido para o valor do produto e unidades");
                }

            }
            else
            {
                lblLucro.Text = "0,00";
            }
        }
        private void AdicionarProduto(string descricao, decimal valProduto, decimal valUnitario,decimal quatidade, string nome,decimal custoads, decimal plataformaCusto, decimal logistica, decimal lucro,int idProduto,int estoque)
        {

            using (MySqlConnection connection = new MySqlConnection(config.connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("INSERT INTO controle (produtonome, descricao,quantidade, vproduto, vlogistica, vcustounitario, vplataforma, vads,datahora,lucro,produtoid,plataforma) VALUES (@nome, @description, @quantos, @valProduto, @logistica, @unitValue, @valplataforma, @adsCost, @datahora, @lucro, @idProduto,@plataformaNome); UPDATE produtos SET  estoque = @estoque WHERE id=@idProduto;", connection))
                    {
                        command.Parameters.AddWithValue("@nome", nome);
                        command.Parameters.AddWithValue("@description", descricao);
                        command.Parameters.AddWithValue("@quantos", quatidade);
                        command.Parameters.AddWithValue("@valProduto", valProduto);
                        command.Parameters.AddWithValue("@logistica", logistica);
                        command.Parameters.AddWithValue("@unitValue", valUnitario);
                        command.Parameters.AddWithValue("@valplataforma", plataformaCusto);
                        command.Parameters.AddWithValue("@adsCost", custoads);
                        command.Parameters.AddWithValue("@datahora", DateTime.Now);
                        command.Parameters.AddWithValue("@lucro", lucro);
                        command.Parameters.AddWithValue("@idProduto", idProduto);
                        command.Parameters.AddWithValue("@estoque", estoque);
                        command.Parameters.AddWithValue("@plataformaNome", comboBox1.SelectedItem.ToString());
                        //produto q vem da lista usado apenas para add plataforma + produto na tabela de  precovenda
                        int plataformaid = PlataformasMarket.Item(comboBox1.SelectedItem.ToString()).id;
                        command.Parameters.AddWithValue("@idVenda", idProduto.ToString() + plataformaid.ToString());
                        command.Parameters.AddWithValue("@plataformaID", plataformaid);
                        command.ExecuteNonQuery();
                        

                       // string cmd = ("INSERT INTO precovenda (id, valor, plataformaid, produtoid) VALUES(@idVenda,@valProduto,@plataformaID,@idProduto) ON DUPLICATE KEY UPDATE valor = @valProduto;");
                       // command.CommandText = cmd;
                        //command.ExecuteNonQuery();


                        funcoes.ExibirNotificacao(this, "Venda registrada com Sucesso!", 4000, true, Color.Green);
                        var mainForm = Application.OpenForms.OfType<frmPrincipal>().Single();
                        
                        mainForm.ListaCaixa(mainForm.CalendarioInicio,mainForm.CalendarioFim);

                        
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "Erro mysql");

                }
            }
            Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
            if (dataGridView1.SelectedCells.Count > 0 )
            {
                int LinhaSelecionada = dataGridView1.SelectedCells[0].RowIndex;
                decimal vProduto = decimal.Parse(dataGridView1.Rows[LinhaSelecionada].Cells[3].Value.ToString());
                int vEstoque = int.Parse(dataGridView1.Rows[LinhaSelecionada].Cells[5].Value.ToString());
                string  nomeproduto = dataGridView1.Rows[LinhaSelecionada].Cells[1].Value.ToString();
                int id = (int)dataGridView1.Rows[LinhaSelecionada].Cells[0].Value;
                this.Text = "Produto Vendido [" + nomeproduto + "]";
                if (vEstoque <=0)
                {
                    btAddVenda.Enabled = false;
                }
                else {
                    btAddVenda.Enabled = true;
                    txtVendaPreco.Text = vProduto.ToString("N2");
                    // PrecoDeVenda(vProduto.ToString("N2"));
                    carregaPrecoVenda(id);
                }
            }

            
        }

        private void calculaLucro()
        {
            if (dataGridView1.SelectedCells.Count > 0 && comboBox1.SelectedIndex >=0)
            {

                int LinhaSelecionada = dataGridView1.SelectedCells[0].RowIndex;

                int idProduto;
                int.TryParse(dataGridView1.Rows[LinhaSelecionada].Cells[0].Value.ToString(), out idProduto);
                int estoque;
                int.TryParse(dataGridView1.Rows[LinhaSelecionada].Cells[5].Value.ToString(), out estoque);

                string produtonome = dataGridView1.Rows[LinhaSelecionada].Cells[1].Value.ToString();
                string descri = dataGridView1.Rows[LinhaSelecionada].Cells[2].Value.ToString();



                decimal valProduto;
                decimal CustoProduto;


                decimal CustoLogistica;
                decimal custoads;


                if (decimal.TryParse(txtVendaPreco.Text.ToString().Replace("R$", "").Trim(), out valProduto))
                {

                    decimal.TryParse(dataGridView1.Rows[LinhaSelecionada].Cells[3].Value.ToString(), out CustoProduto);
                    decimal.TryParse(dataGridView1.Rows[LinhaSelecionada].Cells[4].Value.ToString().Replace("R$", "").Trim(), out CustoLogistica);
                    decimal.TryParse(txtCustoAds.Text.Replace("R$", "").Trim(), out custoads);

                    if (estoque >= 1 && numericUpDown1.Value >= 1)
                    {
                        decimal valorFixo = PlataformasMarket.Item(comboBox1.SelectedItem.ToString()).ValorFixo;
                        decimal porcentagem = PlataformasMarket.Item(comboBox1.SelectedItem.ToString()).PorcentagemPLataforma;



                        if (estoque >= 1 && numericUpDown1.Value >= 1)

                        {

                            decimal valProdutoLiquido = valProduto * (1 - porcentagem / 100m);
                            decimal plataformavalor = valProduto - valProdutoLiquido + valorFixo;

                            decimal Lucro = valProdutoLiquido - CustoProduto - CustoLogistica - custoads - valorFixo;
                            numericUpDown1.Maximum = estoque;
                            Lucro = Lucro * numericUpDown1.Value;
                            lblLucro.Text = Lucro.ToString("C");

                            estoque = estoque - (int)numericUpDown1.Value;

                            if (estoque < 0)
                            {
                                estoque = 0;
                            }

                            //AdicionarProduto(descri, valProduto, CustoProduto, numericUpDown1.Value, produtonome, custoads, plataformavalor, CustoLogistica, Lucro, idProduto, estoque);
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor válido para o valor do produto e unidades");
                }

            }
            else
            {
                lblLucro.Text = "0,00";
            }
        }



        private void txtCustoAds_TextChanged(object sender, EventArgs e)
        {
            calculaLucro();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {
            calculaLucro();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
   
                calculaLucro(); 
           
        }

        private void txtVendaPreco_Leave(object sender, EventArgs e)
        {
            try
            {
                txtVendaPreco.Text = double.Parse(txtVendaPreco.Text).ToString("N2");
                calculaLucro();
            }
            catch (Exception ex)

            {
                txtVendaPreco.Text = "";
            }
        }

        private void txtVendaPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;


            if (!char.IsControl(ch) && !char.IsDigit(ch) && ch != '.' && ch != ',')
            {
                e.Handled = true;
            }

            if (ch == '.' && txtVendaPreco.Text.Contains("."))
            {
                e.Handled = true;
            }


            if (ch == ',' && txtVendaPreco.Text.Contains(","))
            {
                e.Handled = true;
            }

            if (ch == ',' && txtVendaPreco.Text.IndexOf(',') == txtVendaPreco.Text.Length - 1)
            {
                e.Handled = true;
            }
        }

        private void txtCustoAds_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;


            if (!char.IsControl(ch) && !char.IsDigit(ch) && ch != '.' && ch != ',')
            {
                e.Handled = true;
            }

            if (ch == '.' && txtCustoAds.Text.Contains("."))
            {
                e.Handled = true;
            }


            if (ch == ',' && txtCustoAds.Text.Contains(","))
            {
                e.Handled = true;
            }

            if (ch == ',' && txtCustoAds.Text.IndexOf(',') == txtCustoAds.Text.Length - 1)
            {
                e.Handled = true;
            }
        }

        private void txtVendaPreco_TextChanged(object sender, EventArgs e)
        {
            calculaLucro();
        }
        private void PrecoDeVenda(string CustoPreco)
        {
            decimal fixo = PlataformasMarket.Item(comboBox1.SelectedItem.ToString()).ValorFixo;
            decimal porcentagem = PlataformasMarket.Item(comboBox1.SelectedItem.ToString()).PorcentagemPLataforma;
            int platID = PlataformasMarket.Item(comboBox1.SelectedItem.ToString()).id;
            lblTaxaPlataforma.Text = "Desconto plataforma (" + porcentagem.ToString("0.0\\%") + " + " + fixo.ToString("c") + ")";
            // MessageBox.Show();
            try
            {
                MySqlConnection conn = new MySqlConnection(config.connectionString);
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT valor FROM precovenda WHERE id = @id", conn))
                {
                    if (dataGridView1.SelectedCells.Count > 0) { 
                    int LinhaSelecionada = dataGridView1.SelectedCells[0].RowIndex;
                    int idProduto;
                    int.TryParse(dataGridView1.Rows[LinhaSelecionada].Cells[0].Value.ToString(), out idProduto);


                    cmd.Parameters.AddWithValue("@id", idProduto.ToString() + platID);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        decimal preco = reader.GetDecimal(0);
                        txtVendaPreco.Text = preco.ToString("N2");
                        // Faça algo com o preço carregado
                    }
                    else { txtVendaPreco.Text = CustoPreco; }
                }
                    else { txtVendaPreco.Text = CustoPreco; }
                }
            }
            catch
            {
                txtVendaPreco.Text = CustoPreco;
            }
            calculaLucro();
        }
        private void carregaPrecoVenda(int produtoid)
        {
            comboBox1.Items.Clear();
            try
            {
                MySqlConnection conn = new MySqlConnection(config.connectionString);
                conn.Open();
                using (MySqlDataAdapter Leitor = new MySqlDataAdapter("SELECT * FROM precovenda where produtoid=@id;", conn))
                {
                    DataSet DS = new DataSet();
                    Leitor.SelectCommand.Parameters.AddWithValue("@id", produtoid);
                    Leitor.Fill(DS);
                    //MessageBox.Show(DS.Tables[0].Rows.Count.ToString());
               

                        //adiciona todas plataformas
                        foreach (ObjPlataformas Plat in PlataformasMarket.ListaPlataforma())
                        {

                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow Linhas in DS.Tables[0].Rows)
                            {
                                //verifica se o item que ta sendo criado tem a mesma plataforma na tabela do mysql


                                string produtoid_plataforma_id = Linhas.Field<string>("id");
                                produtoid = Linhas.Field<int>("produtoid");
                                int plataformaid = Linhas.Field<int>("plataformaid");
                                decimal valor = Linhas.Field<decimal>("valor");
                                //se tiver o valor ele altera pro valor que ja tem na tabela
                                if (Plat.id == plataformaid && valor > 0)
                                {
                                    comboBox1.Items.Add(Plat.PlataformaNome);
                                    //  Console.WriteLine($"é  {Plat.id} igual a {plataformaid}");
                                    break;
                                }
                                else
                                {
                                    //Console.WriteLine($"diferente {Plat.id} diferente {plataformaid}");
                                }
                            }

                        }
                        }
                        //Corre tabela e altera 
                        if(!comboBox1.Items.Contains("Sem Taxa")){
                            comboBox1.Items.Add("Sem Taxa");
                        }
                        comboBox1.SelectedIndex = 0;
                    


                }
            }
            catch (MySqlException ex) { Console.WriteLine(ex.Message); }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                decimal valorpreco;
                var linha = dataGridView1.SelectedRows[0];
                decimal.TryParse(linha.Cells[3].Value.ToString(), out valorpreco);
                
                PrecoDeVenda(valorpreco.ToString("N2"));
            }
        }

        private void txtCustoAds_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCustoAds.Text = double.Parse(txtCustoAds.Text).ToString("N2");
                calculaLucro();
            }
            catch (Exception ex)

            {
                txtCustoAds.Text = "0,00";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }

}
