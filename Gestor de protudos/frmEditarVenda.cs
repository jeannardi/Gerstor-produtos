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
    public partial class frmEditarVenda : Form
    {
        decimal plataformavalor;
        int estoque = EditarVenda.AddEstoque;
        decimal Lucro;

        public frmEditarVenda()
        {
            InitializeComponent();
        }

        private void frmEditarVenda_Load(object sender, EventArgs e)
        {
            carregaPrecoVenda(EditarVenda.ProdutoID);
            //produto
            lblProduto.Text = EditarVenda.nomeProduto;
            txtVendaPreco.Text = EditarVenda.valProduto.ToString("N2");
            numericUpDown1.Value = EditarVenda.quantidade;
            comboBox1.Text = EditarVenda.Plataforma;
            //taxa
            txtCustoAds.Text = EditarVenda.vads.ToString("N2");

            //outro
            dateTimePicker1.Value = EditarVenda.datahora;



        }


        private void calculaLucro()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(config.connectionString);

                using (MySqlDataAdapter Reader = new MySqlDataAdapter("Select estoque From produtos where id= @id;", conn))
                {
                    Reader.SelectCommand.Parameters.AddWithValue("@id", EditarVenda.ProdutoID);
                    DataSet ds = new DataSet();
                    Reader.Fill(ds);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow Row = ds.Tables[0].Rows[0];
                        estoque = Row.Field<int>("estoque");
                        estoque += EditarVenda.quantidade;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



            decimal valProduto;
            decimal.TryParse(txtVendaPreco.Text.ToString().Replace("R$", "").Trim(), out valProduto);

            decimal CustoProduto = Convert.ToDecimal(EditarVenda.vcustounitario);
            decimal CustoPlataforma = Convert.ToDecimal(EditarVenda.vplataforma);

            decimal CustoLogistica = Convert.ToDecimal(EditarVenda.vlogistica);
            decimal custoads; 
            decimal.TryParse(txtCustoAds.Text.Replace("R$", "").Trim(), out custoads);

            
            decimal valorFixo = PlataformasMarket.Item(comboBox1.SelectedItem.ToString()).ValorFixo;
            decimal porcentagem = PlataformasMarket.Item(comboBox1.SelectedItem.ToString()).PorcentagemPLataforma;



            if (estoque >= 1 && numericUpDown1.Value >= 1)

            {

                decimal valProdutoLiquido = valProduto * (1 - porcentagem / 100m);
                plataformavalor = valProduto - valProdutoLiquido + valorFixo;

                Lucro = valProdutoLiquido - CustoProduto - CustoLogistica - custoads - valorFixo;
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




            //AdicionarProduto(descri, valProduto, CustoProduto, produtonome, estoque, CustoPlataforma2, CustoLogistica);
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

                        int idProduto = EditarVenda.ProdutoID;


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

                    int plataformaSelecionada = 0;
                    bool taxaencontrada = false;
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
                                    if (EditarVenda.Plataforma.Equals(Plat.PlataformaNome))
                                    {
                                        plataformaSelecionada = comboBox1.Items.Count - 1;
                                        taxaencontrada = true;
                                    }
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
                    if (!comboBox1.Items.Contains("Sem Taxa"))
                    {
                        comboBox1.Items.Add("Sem Taxa");
                    }
                    if (taxaencontrada)
                    {
                        comboBox1.SelectedIndex = plataformaSelecionada;
                    }
                    else
                    {
                        comboBox1.SelectedIndex = comboBox1.Items.Count -1;
                        if (EditarVenda.Plataforma != "Sem Taxa")
                        {
                            funcoes.ExibirNotificacao(comboBox1, $"A taxa: [{EditarVenda.Plataforma}] não existe mais", 4000, false, Color.Red, true);
                        }
                      
                    }
                    
                    txtVendaPreco.Text = EditarVenda.valProduto.ToString("N2");


                }
            }
            catch (MySqlException ex) { Console.WriteLine(ex.Message); }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
   

                PrecoDeVenda(EditarVenda.vcustounitario.ToString("N2"));

        }

        private void txtVendaPreco_TextChanged(object sender, EventArgs e)
        {
            calculaLucro();
            if (!EditarVenda.valProduto.ToString("N2").Equals(txtVendaPreco.Text))
            {
                btPreco.Visible = true;
            }
            else { btPreco.Visible = false; }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            calculaLucro();
        }

        private void txtCustoAds_TextChanged(object sender, EventArgs e)
        {
            calculaLucro();
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valProduto = 0;
                decimal vads = 0;
                decimal.TryParse(txtVendaPreco.Text.ToString().Replace("R$", "").Trim(), out valProduto);
                decimal.TryParse(txtCustoAds.Text.ToString().Replace("R$", "").Trim(), out vads);

                MySqlConnection conn = new MySqlConnection(config.connectionString);
                conn.Open();

                using (MySqlCommand cm = new MySqlCommand("UPDATE controle SET  vproduto=@vproduto, vplataforma=@vplataforma, vads=@vads, quantidade=@quantidade, lucro=@lucro, plataforma=@plataformanome, datahora=@datahora WHERE id=@id; UPDATE produtos SET  estoque = @estoque WHERE id=@idProduto;", conn))
                {
                    cm.Parameters.AddWithValue("@vproduto", valProduto);
                    cm.Parameters.AddWithValue("@vplataforma", plataformavalor);
                    cm.Parameters.AddWithValue("@vads", vads);
                    cm.Parameters.AddWithValue("@lucro", Lucro);
                    cm.Parameters.AddWithValue("@quantidade", (int)numericUpDown1.Value);
                    cm.Parameters.AddWithValue("@datahora", dateTimePicker1.Value);
                    cm.Parameters.AddWithValue("@plataformanome", comboBox1.SelectedItem.ToString());
                    cm.Parameters.AddWithValue("@id", EditarVenda.ID);
                    cm.Parameters.AddWithValue("@estoque", estoque);
                    cm.Parameters.AddWithValue("@idProduto", EditarVenda.ProdutoID);

                    cm.ExecuteNonQuery();
                    conn.Close();
                  
                    var mainForm = Application.OpenForms.OfType<frmPrincipal>().Single();

                    //MessageBox.Show(mainForm.CalendarioFim.ToLongDateString());
                    mainForm.ListaCaixa(mainForm.CalendarioInicio, mainForm.CalendarioFim);
                    funcoes.ExibirNotificacao(this, "Alteração salvo com sucesso!", 6000, true, Color.Green);
                    this.Close();
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
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

        private void txtVendaPreco_Leave(object sender, EventArgs e)
        {
            try
            {
                txtVendaPreco.Text = double.Parse(txtVendaPreco.Text).ToString("N2");
                calculaLucro();
            }
            catch (Exception ex)

            {
                txtVendaPreco.Text = "0,00";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPreco_Click(object sender, EventArgs e)
        {
            txtVendaPreco.Text = EditarVenda.valProduto.ToString("N2");
        }
    }

}
