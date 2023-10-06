using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_produtos
{
    public partial class frmAddProduto : Form
    {
        public bool Alterar=false;
        public int AlterarProdutoID;
        public frmAddProduto()
        {
            InitializeComponent();
        }

        private void btAddProduto_Click(object sender, EventArgs e)
        {
            decimal valProduto;
            decimal CustoProduto;

            decimal CustoLogistica;
            int estoque;

            if (txtValCusto.Text.Length > 0 && txtProdutoNome.Text.Length > 0  && txtEstoque.Text.Length > 0 && txtEstoque.Text.Length > 0 && txtValLogistica.Text.Length > 0)
            {

                if ( decimal.TryParse(txtValCusto.Text.Replace("R$", "").Trim(), out CustoProduto))
                {

                    decimal.TryParse(txtValCusto.Text.Replace("R$", "").Trim(), out CustoProduto);
                    decimal.TryParse(txtValLogistica.Text.Replace("R$", "").Trim(), out CustoLogistica);
                    int.TryParse(txtEstoque.Text.Replace("R$", "").Trim(), out estoque);
    



                    decimal Lucro =  CustoProduto - CustoLogistica;


                    AdicionarProduto(txtDescri.Text, 0, CustoProduto, txtProdutoNome.Text, estoque, CustoLogistica);
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor válido para o valor do produto e unidades");
                }
            }
            else { funcoes.ExibirNotificacao(this, "Preencha todos os campos da maneira correta.", 3000, true); }
        }
        private void carregaPrecoVenda()
        {
            lvPlataformas.Items.Clear();
            try
            {
                MySqlConnection conn = new MySqlConnection(config.connectionString);
                conn.Open();
                using (MySqlDataAdapter Leitor = new MySqlDataAdapter("SELECT * FROM precovenda where produtoid=@id;", conn))
                {
                    DataSet DS = new DataSet();
                    Leitor.SelectCommand.Parameters.AddWithValue("@id", AlterarProdutoID);
                    Leitor.Fill(DS);
                    //MessageBox.Show(DS.Tables[0].Rows.Count.ToString());
     
                        //adiciona todas plataformas
                        foreach (ObjPlataformas Plat in PlataformasMarket.ListaPlataforma())
                        {
                            ListViewItem item = new ListViewItem(Plat.PlataformaNome);
                            item.Tag = Convert.ToDecimal("0,00");
                            item.SubItems.Add("0,00");
                            item.SubItems[0].Tag = Plat.id;
                            item.ForeColor = Color.Gray;

                            //Console.WriteLine(Plat.PlataformaNome);
                        if (DS.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow Linhas in DS.Tables[0].Rows)
                            {
                                //verifica se o item que ta sendo criado tem a mesma plataforma na tabela do mysql


                                string produtoid_plataforma_id = Linhas.Field<string>("id");
                                int produtoid = Linhas.Field<int>("produtoid");
                                int plataformaid = Linhas.Field<int>("plataformaid");
                                decimal valor = Linhas.Field<decimal>("valor");

                                //se tiver o valor ele altera pro valor que ja tem na tabela
                                if (Plat.id == plataformaid)
                                {
                                    item.ForeColor = Color.Black;
                                    item.Tag = valor;
                                    item.SubItems[1].Text = valor.ToString("N2");
                                    item.SubItems[1].Tag = produtoid_plataforma_id;
                                    //  Console.WriteLine($"é  {Plat.id} igual a {plataformaid}");
                                    break;
                                }
                                else
                                {
                                    //Console.WriteLine($"diferente {Plat.id} diferente {plataformaid}");
                                }
                            }
                        }
                            if(!item.Text.Equals("Sem Taxa"))
                            {
                                lvPlataformas.Items.Add(item);
                            }
                          

                        }
                        //Corre tabela e altera 
                  
                    


                }
            }
            catch (MySqlException ex) { Console.WriteLine(ex.Message); }
        }
    
        private void frmAddProduto_Load(object sender, EventArgs e)
        {
            if (Alterar == true)
            {
                btAddProduto.Text = "Salvar";
                btExcluir.Visible = true;
                try
                {
                    MySqlConnection conn = new MySqlConnection(config.connectionString);
                    conn.Open();
                    using (MySqlDataAdapter Leitor = new MySqlDataAdapter("SELECT * FROM produtos where id=@id;", conn))
                    {
                        DataSet DS = new DataSet();
                        Leitor.SelectCommand.Parameters.AddWithValue("ID", AlterarProdutoID);
                        Leitor.Fill(DS);
                        
                        //Console.WriteLine(DS.Tables[0].Rows.Count);
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            DataRow DR = DS.Tables[0].Rows[0];
                            txtProdutoNome.Text = DR.Field<String>("nome");
                            txtDescri.Text = DR.Field<String>("descricao");
                            txtEstoque.Text = DR.Field<Int32>("estoque").ToString();
                            txtValCusto.Text = DR.Field<decimal>("vcustounitario").ToString("N2");
                            txtValLogistica.Text = DR.Field<decimal>("vlogistica").ToString("N2");
                            
                            carregaPrecoVenda();
                        }

                        
                    }
                }
                catch (MySqlException ex){ Console.WriteLine(ex.Message); }
            }
            else
            {
                foreach (ObjPlataformas Plat in PlataformasMarket.ListaPlataforma())
                {
                    ListViewItem item = new ListViewItem(Plat.PlataformaNome);
                    item.Tag = Convert.ToDecimal("0,00");
                    item.SubItems.Add("0,00");
                    item.SubItems[0].Tag = Plat.id;
                    item.ForeColor = Color.Gray;

                    lvPlataformas.Items.Add(item);

                }
            }
        }


        private void AdicionarProduto(string descricao, decimal valProduto, decimal valUnitario, string nome, int estoque, decimal logistica)
        {

            using (MySqlConnection connection = new MySqlConnection(config.connectionString))
            {
                try
                {
                    string mensagem = "Produto cadastrado com sucesso!";
                    connection.Open();
                    string cmd = "INSERT INTO produtos (nome, descricao,vlogistica, vcustounitario, estoque) VALUES (@nome, @description, @logistica, @unitValue, @estoque)";
                    if (Alterar)
                    {
                        cmd = "UPDATE produtos SET nome=@nome, descricao=@description,vlogistica=@logistica,vcustounitario=@unitValue,estoque=@estoque where id=@id;";
                        mensagem = "Salvo com sucesso!";
                    }
                    using (MySqlCommand command = new MySqlCommand(cmd, connection))
                    {
                        command.Parameters.AddWithValue("@nome", nome);
                        command.Parameters.AddWithValue("@description", descricao);
                        command.Parameters.AddWithValue("@valProduto", valProduto);
                        command.Parameters.AddWithValue("@logistica", logistica);
                        command.Parameters.AddWithValue("@unitValue", valUnitario);
                        command.Parameters.AddWithValue("@estoque", estoque);
                        command.Parameters.AddWithValue("@id", AlterarProdutoID);
                        command.Parameters.AddWithValue("@idVenda", AlterarProdutoID.ToString()) ;
                        command.Parameters.AddWithValue("@plataformaID", (int)999);
                        command.Parameters.AddWithValue("@DeletaVendaID", "Nao existe");
                        command.ExecuteNonQuery();
                        funcoes.ExibirNotificacao(this, mensagem, 3000, true,Color.Green);
                        string IDVenda = command.LastInsertedId.ToString();
                        if (Alterar==true)
                        {
                            IDVenda = AlterarProdutoID.ToString();
                            
                        }

                        foreach (ListViewItem Plat in lvPlataformas.Items)
                        {
                            try
                            {
                                decimal ver = (decimal)Plat.Tag;
                                string IDDELETA = (string)Plat.SubItems[1].Tag;
                                command.Parameters[9].Value = IDDELETA;
                                if (ver > 0)
                                {
                                
                                command.Parameters[6].Value = IDVenda; // ID do produto - ele pega do lastindex
                                command.Parameters[8].Value = Plat.SubItems[0].Tag;
                                command.Parameters[7].Value = IDVenda + Plat.SubItems[0].Tag; // ID Gerado pelos outros dois IDs
                                command.Parameters[2].Value = Plat.Tag; // Carrega Valor venda do listview


                                cmd = ("INSERT INTO precovenda (id, valor, plataformaid, produtoid) VALUES(@idVenda,@valProduto,@plataformaID,@id) ON DUPLICATE KEY UPDATE valor = @valProduto;");
                                command.CommandText = cmd;
                                command.ExecuteNonQuery();
                                }else if(ver == 0 & IDDELETA!=null)
                                {
                                    Console.WriteLine($"{Plat.Text} tem o valor -> {Plat.SubItems[0].Tag.ToString()} e possuie o id = {IDDELETA}");
                                    cmd = ("DELETE FROM precovenda where id=@DeletaVendaID;");
                                    command.CommandText = cmd;
                                    command.ExecuteNonQuery();
                                }
                            }
                            catch ( MySqlException erros)
                            {
                                MessageBox.Show(erros.Message);
                            }
                        }

                        connection.Close();
                        Close();
                    }
                }
                catch (MySqlException ex)
                {
                    funcoes.ExibirNotificacao(this, "Ocorreu um erro com o mysql", 3000, true, Color.Red);

                }
            }
        }

        private void txtValUnitario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValCusto_Leave(object sender, EventArgs e)
        {
            try
            {
                txtValCusto.Text = double.Parse(txtValCusto.Text).ToString("N2");

            }
            catch (Exception ex)

            {
                txtValCusto.Text = "0,00";
            }
        }

        private void txtValLogistica_Leave(object sender, EventArgs e)
        {
            try
            {
                txtValLogistica.Text = double.Parse(txtValLogistica.Text).ToString("N2");

            }
            catch (Exception ex)

            {
                txtValLogistica.Text = "0,00";
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(config.connectionString);
                conn.Open();
                DialogResult result = MessageBox.Show($"Você tem certeza que deseja excluir {txtProdutoNome.Text} dos registros de propdutos?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result== DialogResult.Yes) { 
                try
                {
                    using (MySqlCommand DeleteCMD = new MySqlCommand("Delete from produtos where id=@id; DELETE FROM precovenda where produtoid Like @id;", conn))
                    {
                        DeleteCMD.Parameters.AddWithValue("@id", AlterarProdutoID);

                        DeleteCMD.ExecuteNonQuery();

                        funcoes.ExibirNotificacao(this, "Deletado com sucesso!", 3000, true, Color.Green);
                        this.Close();
                    }
                }
                catch
                {
                    funcoes.ExibirNotificacao(this, "Não foi possivel deletar", 3000, true);
                }
                }
            }
            catch
            {
                funcoes.ExibirNotificacao(this, "Não foi possivel deletar", 3000, true);
            }
        }



        private void txtValCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;


            if (!char.IsControl(ch) && !char.IsDigit(ch) && ch != '.' && ch != ',')
            {
                e.Handled = true;
            }

            if (ch == '.' && txtValCusto.Text.Contains("."))
            {
                e.Handled = true;
            }


            if (ch == ',' && txtValCusto.Text.Contains(","))
            {
                e.Handled = true;
            }

            if (ch == ',' && txtValCusto.Text.IndexOf(',') == txtValCusto.Text.Length - 1)
            {
                e.Handled = true;
            }
        }

        private void txtValLogistica_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;


            if (!char.IsControl(ch) && !char.IsDigit(ch) && ch != '.' && ch != ',')
            {
                e.Handled = true; 
            }

            if (ch == '.' && txtValLogistica.Text.Contains("."))
            {
                e.Handled = true; 
            }

    
            if (ch == ',' && txtValLogistica.Text.Contains(","))
            {
                e.Handled = true; 
            }

            if (ch == ',' && txtValLogistica.Text.IndexOf(',') == txtValLogistica.Text.Length - 1)
            {
                e.Handled = true; 
            }
        }

        private void txtEstoque_Leave(object sender, EventArgs e)
        {
            int res = 0;
            if (!int.TryParse(txtEstoque.Text,out res) )
            {
                txtEstoque.Text = "0";
            }
     
            
        }

        private void txtEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lvPlataformas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPlataformas.SelectedItems.Count > 0)
            {
                lvPlataformas.ContextMenuStrip = contextMenuStrip1;
                ListViewItem Item = lvPlataformas.SelectedItems[0];

                string plataforma = Item.Text;

                btPreçoVenda.Text = $"Definir preço de venda [{plataforma}]";
                btDesativar.Text = $"Desativar [{plataforma}]";

                funcoes.ExibirNotificacao(lvPlataformas, $"Preço venda para o cliente final, na plataforma:\n[{plataforma}]", 5000, false, Color.CornflowerBlue, true);

            }
            else
            {
                lvPlataformas.ContextMenuStrip = null;
            }


        }

        private void lvPlataformas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (lvPlataformas.SelectedItems.Count > 0)
                {
                    decimal valor = Convert.ToDecimal(lvPlataformas.SelectedItems[0].Tag);
                    frmEditarPlatProdutoVenda frmEdita = new frmEditarPlatProdutoVenda();
                    frmEdita.valor = Convert.ToDecimal(valor);
                    frmEdita.ShowDialog();
                    decimal Nvalor = frmEdita.valor;
                    lvPlataformas.SelectedItems[0].Tag = Nvalor;

                    string valorTexto = Nvalor.ToString("N2");

                    lvPlataformas.SelectedItems[0].SubItems[1].Text = valorTexto;
                }
            }
        }

        private void txtValCusto_Enter(object sender, EventArgs e)
        {
            funcoes.ExibirNotificacao(txtValCusto, "Quanto você pagou por esse produto?", 5000, false,Color.CornflowerBlue,true);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            funcoes.ExibirNotificacao(txtValCusto, "Quanto você pagou por esse produto?", 5000, false, Color.CornflowerBlue);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            funcoes.ExibirNotificacao(txtValLogistica, "Gastos unitarios. Ex: Embalagem, Frete unitario pago ao fornecedor!", 5000, false, Color.CornflowerBlue, true);
        }

        private void txtValLogistica_Enter(object sender, EventArgs e)
        {
            funcoes.ExibirNotificacao(txtValLogistica, "Gastos unitarios. Ex: Embalagem, Frete unitario pago ao fornecedor!", 5000, false, Color.CornflowerBlue, true);
        }

        private void AlterarPreço()
        {
            if (lvPlataformas.SelectedItems.Count > 0)
            {
                decimal valor = Convert.ToDecimal(lvPlataformas.SelectedItems[0].Tag);
                frmEditarPlatProdutoVenda frmEdita = new frmEditarPlatProdutoVenda();
                frmEdita.valor = Convert.ToDecimal(valor);
                frmEdita.ShowDialog();
                decimal Nvalor = frmEdita.valor;
                lvPlataformas.SelectedItems[0].Tag = Nvalor;

                string valorTexto = Nvalor.ToString("N2");

                lvPlataformas.SelectedItems[0].SubItems[1].Text = valorTexto;
            }
        }
        private void lvPlataformas_DoubleClick(object sender, EventArgs e)
        {
            AlterarPreço();
        }

        private void txtValCusto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProdutoNome_Enter(object sender, EventArgs e)
        {
            funcoes.ExibirNotificacao(txtProdutoNome, "Digite nome para o produto ex: Panela Inox Tramontina", 5000, false, Color.CornflowerBlue, true);
        }

        private void lvPlataformas_Enter(object sender, EventArgs e)
        {

        }

        private void btDesativar_Click(object sender, EventArgs e)
        {
            if (lvPlataformas.SelectedItems.Count > 0)
            {
                ListViewItem Item = lvPlataformas.SelectedItems[0];

                string plataforma = Item.Text;

                btDesativar.Text = $"Desativar [{plataforma}]";

                DialogResult result = MessageBox.Show($"Você tem certeza que deseja desativar {plataforma} no produto {txtProdutoNome.Text}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Item.Tag = (decimal)0;
                    Item.SubItems[1].Text = "0,00";
                    Item.ForeColor = Color.Gray;
                    lvPlataformas.SelectedItems.Clear();
                }
            }
        }

        private void btPreçoVenda_Click(object sender, EventArgs e)
        {
            AlterarPreço();
        }

        private void txtDescri_Enter(object sender, EventArgs e)
        {
            funcoes.ExibirNotificacao(txtDescri, "Adiciona algum tipo de descrição caso nescessario.", 5000, false, Color.CornflowerBlue, true);
        }
    }
}
