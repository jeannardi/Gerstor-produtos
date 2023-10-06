
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Gestor_de_produtos
{


    public partial class frmPrincipal : Form
    {
        public MySqlConnection connection;

   

        Label EstoqueBaixo = new Label();
        public frmPrincipal()
        {
            InitializeComponent();

        }
        double CalcularLucro(double valorProduto, double custoProduto)
        {
            double custoPlataforma = valorProduto * 0.22;
            double lucro = valorProduto - custoProduto - custoPlataforma;
            return lucro;
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
        private bool CarregaConn()
        {
            // Nome do arquivo de configuração
            string configFile = "config.xml";

            // Se o arquivo não existir, crie um novo documento XML com um elemento raiz
            if (File.Exists(configFile))
            {
                XmlDocument configDoc = new XmlDocument();
                configDoc.Load(configFile);

                // Obtenha o elemento "Senha" do arquivo de configuração
                XmlElement connElement = (XmlElement)configDoc.SelectSingleNode("//conn");

                // Se o elemento "Senha" não existir, crie um novo elemento e adicione-o ao arquivo de configuração
                if (connElement == null)
                {
                    connElement = configDoc.CreateElement("conn");
                    configDoc.DocumentElement.AppendChild(connElement);


                }

                string connArmazenadanoXML = connElement.InnerText;
                string ConnDescriptografada = DescriptografarSenha(connArmazenadanoXML);

                //Console.WriteLine(ConnDescriptografada);
                //Testa Conn mysql
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(ConnDescriptografada))
                    {
                        conn.Open();
                        config.connectionString = ConnDescriptografada;
                        
                        
                        conn.Close();
                        return true;
                    }

                }
                catch (MySqlException erro)
                {
                    funcoes.ExibirNotificacao(this, "Impossivel connectar ao mysql!", 3000, true, Color.Red);
                    return false;
                }catch(ArgumentException)
                {
                    funcoes.ExibirNotificacao(this, "Impossivel connectar ao mysql!", 3000, true, Color.Red);
                    return false;
                }

                
               

            }
            funcoes.ExibirNotificacao(this, "Configure o Mysql para acessar aos dados!", 3000, true, Color.Blue);
            
            return false;

        }
        public void estoquebaixo()
        {
            try
            {
                int valorbaixo = Properties.Settings.Default.estoquebaixo;
                MySqlConnection conn = new MySqlConnection(config.connectionString);
                conn.Open();

                // Executar a consulta e obter o resultado
                using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM produtos WHERE estoque <= @Baixo", conn))
                {
                    command.Parameters.AddWithValue("@Baixo", valorbaixo);
                    var resultado = Convert.ToInt32(command.ExecuteScalar());
                    //Console.WriteLine(resultado.ToString());

                    if (resultado > 0) {
                        this.ActiveControl = null;
                        
                        EstoqueBaixo.Size = new Size(20, 20);
                        FontFamily fontFamily = new FontFamily("Arial");
                        Font font = new Font(fontFamily,11,FontStyle.Bold, GraphicsUnit.Pixel);
                        EstoqueBaixo.Font = font;
                        EstoqueBaixo.Text = resultado.ToString();
                        EstoqueBaixo.ForeColor = Color.White;
                        EstoqueBaixo.BackColor = Color.Transparent;
                        EstoqueBaixo.Image = Properties.Resources.fundolabel;
                        EstoqueBaixo.ImageAlign = ContentAlignment.MiddleCenter;
                        EstoqueBaixo.TextAlign = ContentAlignment.MiddleCenter;

                        if (btEstoque.Controls.Count == 0)
                        {
                            btEstoque.Controls.Add(EstoqueBaixo);
                            funcoes.ExibirNotificacao(btEstoque, $"Existem {resultado} com baixo estoque.", 3000, false, Color.OrangeRed);
                        }

                    }
                    else
                    {
                        //Console.WriteLine(btEstoque.Controls.Count.ToString());
                        if (btEstoque.Controls.Count > 0)
                        {
                            btEstoque.Controls.Clear();
                            Console.WriteLine("Removido controle label do botao de estoque");
                        }
                    }
                }
                
            }
            catch (MySqlException e )
            {

            }
        }
        public void Inicio()
        {
            estoquebaixo();


                DateTime Inicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                DateTime fim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                Calendario.SetSelectionRange(Inicio.AddMonths(-6), fim);
                comboBox1.SelectedIndex = 0;
                CalendarioInicio = Inicio;
                CalendarioFim = fim;
                //ListaCaixa(Inicio, fim);
                PlataformasMarket.LimparLista();
                carregaPlataformas();
                // PlataformasMarket.LimparLista();
            
        }
        private void frmPrincipal_Load(object sender, EventArgs e)

        {
            config.FormularioPrincipal = this;
            


        }
        
        public void carregaPlataformas()
        {
  
            
            try
            {
                MySqlConnection conn = new MySqlConnection(config.connectionString);
                conn.Open();
               using(MySqlDataAdapter adaptadorSql = new MySqlDataAdapter("Select * from plataformas;", conn))
                {
                    DataSet ds = new DataSet();
                    adaptadorSql.Fill(ds);
                    
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       foreach(DataRow Linha in ds.Tables[0].Rows)
                        {
                            int ID = Linha.Field<int>("id");
                            string plataforma = Linha.Field<string>("plataforma");
                            decimal valorFixo = Linha.Field<decimal>("valorfixo");
                            decimal porcentagem = Linha.Field<decimal>("porcentagem");
                            PlataformasMarket.AdicionarPlataforma(ID, plataforma, valorFixo, porcentagem);
                        }
                    }
                }

            }
            catch(MySqlException Erro)
            {
                Console.WriteLine("Erro ao carregar Plataformas");
            }
            PlataformasMarket.AdicionarPlataforma(0, "Sem Taxa", 0, 0);
        }
        public class FiltroData
        {
            public static DateTime Inicio;
            public static DateTime fim;

            
    }
        public DateTime CalendarioInicio
        {
            get { return Calendario.SelectionStart; }
            set { Calendario.SelectionStart = value; }
            
        }
        public DateTime CalendarioFim
        {
            get { return Calendario.SelectionEnd; }
            set { Calendario.SelectionEnd = value; }
        }
        public async void ListaCaixa(DateTime data1, DateTime data2)
        {
            //MessageBox.Show("antes  " + data2.ToLongDateString());
            //data1 = new DateTime(data1.Year, data1.Month, data1.Day, 0, 0, 0);
            //data2 = new DateTime(data2.Year, data2.Month, data2.Day, 23, 59, 59);

            //MessageBox.Show("depois " + CalendarioFim.ToLongDateString());


            if (data1.Date == data2.Date) {

                lblStatus.Text = "Hoje (" + data1.ToShortDateString() + ")";
            }
            else { 
                lblStatus.Text = data1.ToShortDateString() + " até " + data2.ToShortDateString(); 

            }
            pgressBar1.Visible = true;
            pgressBar1.Value =0;
            pgressBar1.PerformStep();
                   connection = new MySqlConnection(config.connectionString);
            try
            {

                pgressBar1.PerformStep();
                dataGridView1.Visible = false;
                dataGridView1.DataSource = null;
                connection.Open();
                
                string Query = "SELECT id, produtonome,descricao,quantidade,vproduto,vcustounitario,vlogistica,vads,vplataforma,lucro,datahora,produtoid, plataforma FROM controle where datahora between @data AND @datafim Order by datahora ASC;";
             
   
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@data", data1);
                adapter.SelectCommand.Parameters.AddWithValue("@datafim", data2);
                DataSet ds = new DataSet();
                pgressBar1.PerformStep();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
   
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 280;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[8].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[7].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[9].DefaultCellStyle.Format = "c";

                dataGridView1.Columns[1].HeaderText = "Nome do Produto";
                dataGridView1.Columns[2].HeaderText = "Descrição";
                dataGridView1.Columns[3].HeaderText = "Quantidade";
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[4].HeaderText = "Preço de venda";
                dataGridView1.Columns[5].HeaderText = "Custo do produto";
                dataGridView1.Columns[6].HeaderText = "Logistica";
                dataGridView1.Columns[7].HeaderText = "Custo do ADS";
                dataGridView1.Columns[8].HeaderText = "Plataforma";
                dataGridView1.Columns[8].Width = 70;
                dataGridView1.Columns[9].HeaderText = "Lucro";
                dataGridView1.Columns[10].HeaderText = "Data Hora";
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].HeaderText = "Plataforma";
                dataGridView1.ClearSelection();

                DataTable dataTable = ds.Tables[0];
                pgressBar1.PerformStep();
                decimal total = await CalculateTotalAsync(dataTable);
                blblLucro.Text = total.ToString("c") ;
                if (total < 0)
                {
                    blblLucro.ForeColor = Color.Red;
                }
                else { blblLucro.ForeColor = Color.Black; }
                pgressBar1.Value = 100;
                pgressBar1.Visible = false;
            }
            catch (MySqlException ex)
            {
                pgressBar1.Value = 100;
                pgressBar1.Visible = false;
                MessageBox.Show(ex.Message);
            }
            dataGridView1.Visible = true;
        }

        private async Task<decimal> CalculateTotalAsync(DataTable dataTable)
        {

            return await Task.Run(() => {
                decimal total = 0;
 
                foreach (DataRow row in dataTable.Rows)
                {
                    decimal vproduto = row.Field<decimal>("vproduto");
                    int quantidade = row.Field<int>("quantidade");
                    decimal vlogistica = row.Field<decimal>("vlogistica");
                    decimal vcustounitario = row.Field<decimal>("vcustounitario");
                    decimal vplataforma = row.Field<decimal>("vplataforma");
                    decimal custovads = row.Field<decimal>("vads");
                    decimal CustoPlataforma = Convert.ToDecimal(vplataforma);


                    decimal Lucro = vproduto - vcustounitario - vlogistica - custovads - CustoPlataforma;

                    Lucro = Lucro * quantidade;



                    //MessageBox.Show(Lucro.ToString("C"));

                    total += Lucro;

                }

                return total;
            });

        }

        private void btMenu_Click(object sender, EventArgs e)
        {

        }

        private void tmrMenuPrincipal_Tick(object sender, EventArgs e)
        {
            int valor = 15;
            if (config.frmMenuPrincipal == true)
            {
                if (panel1.Left <= 170)
                {

                    panel1.Left += valor;
                    panel1.Width -= valor;


                }
                else if (panel1.Left <= 180)
                {
                    panel1.Left += 1;
                    panel1.Width -= 1;
                }
              
                else { flowMenu.Width = 169; tmrMenuPrincipal.Stop();  }
        
            }
            else
            {
                if (panel1.Left >= 70)
                {

                    panel1.Left -= valor;
                    panel1.Width += valor;
                }
                else if (panel1.Left >= 68) {
                    panel1.Left -= 1;
                    panel1.Width += 1;
                }
                else { flowMenu.Width = 58;  tmrMenuPrincipal.Stop(); }
            }
            Console.WriteLine($"{panel1.Left} width {panel1.Width}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
   
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btVenda_Click(object sender, EventArgs e)
        {
           new frmEntrada().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
            {
                e.CellStyle.ForeColor = Color.DarkRed;
            }
            if (e.ColumnIndex == 9)
            {
                decimal val = Convert.ToDecimal(e.Value);
                if (val < 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            timer3.Enabled = false;
            timer2.Enabled = true;
            timer2.Start();


            if (config.frmMenuPrincipal == true)
            {
                config.frmMenuPrincipal = false;
                panel1.Width = this.Width - 78;
                panel1.Left = 63;
                
                //Application.DoEvents();
                flowMenu.Width = 58;

            }
            else
            {
                panel1.Width = this.Width - 196;
                panel1.Left = 180;
                
               // Application.DoEvents();
                flowMenu.Width = 169;

                config.frmMenuPrincipal = true;
            }
     

            //tmrMenuPrincipal.Start();
        }

 

        private void btVendas_Click(object sender, EventArgs e)

        {
            this.ActiveControl = null;
            new frmEntrada().ShowDialog();
            estoquebaixo();


        }

        private void btEditProduto_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            new frmProdutos().ShowDialog();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
          if(comboBox1.Items.Count > 3){
                comboBox1.Items.RemoveAt(3);
            }

            CalendarioInicio = new DateTime(e.Start.Year, e.Start.Month, e.Start.Day, 0, 0, 0);
            CalendarioFim = new DateTime(e.End.Year, e.End.Month, e.End.Day, 23, 59, 59);

            ListaCaixa(CalendarioInicio, CalendarioFim);
            string adicionar;
            if (CalendarioInicio.Date == CalendarioFim.Date)
            {
                adicionar = CalendarioInicio.ToShortDateString();
            }
            else
            {
                adicionar = CalendarioInicio.ToShortDateString() + " até " + CalendarioFim.ToShortDateString();
            }

            if (CalendarioInicio.Date == DateTime.Now.Date && CalendarioFim.Date == DateTime.Now.Date)
            {
                comboBox1.SelectedIndex = 0;
            }
            else { 
            comboBox1.Items.Add(adicionar);
            comboBox1.SelectedIndex = 3;
            }
        }

       
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
            
        {

            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedRows.Count == 1)
            {


                e.SuppressKeyPress = true;
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                EditarVenda.ID= Convert.ToInt32(row.Cells[0].Value);
                EditarVenda.nomeProduto = Convert.ToString(row.Cells[1].Value);
                EditarVenda.ProdutoID = Convert.ToInt32(row.Cells[11].Value);
                EditarVenda.quantidade= Convert.ToInt32(row.Cells[3].Value);
                //info produto
                EditarVenda.valProduto = Convert.ToDecimal(row.Cells[4].Value);
                EditarVenda.vcustounitario= Convert.ToDecimal(row.Cells[5].Value);
                //taxas
                EditarVenda.vlogistica = Convert.ToDecimal(row.Cells[6].Value);
        
                EditarVenda.vads = Convert.ToDecimal(row.Cells[7].Value);

                //outrps
                EditarVenda.datahora = Convert.ToDateTime(row.Cells[10].Value);
                EditarVenda.Plataforma = Convert.ToString(row.Cells[12].Value);
                frmEditarVenda aa = new frmEditarVenda();
                aa.ShowDialog();
            }else if (e.KeyCode == Keys.Enter && dataGridView1.SelectedRows.Count > 1)
            {
                funcoes.ExibirNotificacao(dataGridView1, "Selecione apenas 1 produto para editar por vez.", 5000, true);
                e.SuppressKeyPress = true;
                
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var registros = dataGridView1.SelectedRows.Count;
                    var guarda = dataGridView1.SelectedRows;
                    DialogResult result = MessageBox.Show($"Você tem certeza que deseja excluir este(s) {registros} registro(s) de venda?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {

                
                        using (MySqlConnection connection = new MySqlConnection(config.connectionString))
                        {
                            connection.Open();

                            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                            {
                                try
                                {
                                    if (row.Index > -1) {
                                        int id = Convert.ToInt32(row.Cells[0].Value);
                                        int AddEstoque = Convert.ToInt32(row.Cells[3].Value);
                                        int ProdutoID = Convert.ToInt32(row.Cells[11].Value); ;

                                     
                                        string deleteQuery = "DELETE FROM controle WHERE id = @id";

                                        using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                                        {
                                            command.Parameters.AddWithValue("@id", id);
                                            command.ExecuteNonQuery();
                                            funcoes.ExibirNotificacao(dataGridView1, $"{registros} registro(s) de venda foram excluido(s).", 5000, true,Color.Red);
                                        }
                                        try
                                        {
                                            int Estoque;
                                            using (MySqlDataAdapter adapter = new MySqlDataAdapter("Select estoque from produtos where id=@produtoid", connection))
                                            {
                                                adapter.SelectCommand.Parameters.AddWithValue("@produtoid", ProdutoID);
                                                DataSet ds = new DataSet();
                                                adapter.Fill(ds);

                                                if (ds.Tables[0].Rows.Count ==1)
                                                {
                                                Estoque = (int)ds.Tables[0].Rows[0][0];
                                                    using (MySqlCommand command = new MySqlCommand("UPDATE produtos SET  estoque = @estoque WHERE id=@produtoid;", connection))
                                                    {
                                                        Estoque = Estoque + AddEstoque;
                                                        command.Parameters.AddWithValue("@estoque", Estoque);
                                                        command.Parameters.AddWithValue("@produtoid", ProdutoID);
                                                        command.ExecuteNonQuery();
                                                    }
                                                }

                                        
                                            }
                            

                        


                                        }
                                        catch(MySqlException errorEstoque)
                                        {

                                        }
                                    }
                                }
                                catch(MySqlException error)
                                {
                                    
                                    MessageBox.Show(error.Message, "Mysql Erro");
                                }
           
                            }
                            connection.Close();
                            ListaCaixa(CalendarioInicio, CalendarioFim);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma ou mais linhas para excluir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            try {


                timer3.Enabled = false;
                timer2.Enabled = true;
                timer2.Start();


                if (config.frmMenuPrincipal == true)
                {
                    config.frmMenuPrincipal = false;
                    panel1.Width = this.Width - 78;
                    panel1.Left = 63;

                    //Application.DoEvents();
                    flowMenu.Width = 58;

                }
                else
                {
                    panel1.Width = this.Width - 196;
                    panel1.Left = 180;

                    // Application.DoEvents();
                    flowMenu.Width = 169;

                    config.frmMenuPrincipal = true;
                }
            }
            catch (Exception ex) {
            
            
            };

  

            }

        private void flowMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



           
            switch (comboBox1.SelectedIndex)
            {
                case  0:
                    CalendarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    CalendarioFim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                    Calendario.SetSelectionRange(CalendarioInicio, CalendarioFim);
                    ListaCaixa(CalendarioInicio, CalendarioFim);
                    if (comboBox1.Items.Count > 3)
                    {comboBox1.Items.RemoveAt(3);}
                    break;
                case  1:
                    CalendarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddMonths(-1);
                    CalendarioFim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                    Calendario.SetSelectionRange(CalendarioInicio, CalendarioFim);
                    ListaCaixa(CalendarioInicio, CalendarioFim);
                    if (comboBox1.Items.Count > 3)
                    { comboBox1.Items.RemoveAt(3); }
                    break;
                case 2:
                    CalendarioInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddMonths(-3);
                    CalendarioFim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                    Calendario.SetSelectionRange(CalendarioInicio, CalendarioFim);
                    ListaCaixa(CalendarioInicio, CalendarioFim);
                    if (comboBox1.Items.Count > 3)
                    { comboBox1.Items.RemoveAt(3); }
                    break;
            }


           
        }

        private void Calendario_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void btPlataforma_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            new frmListaPlataformas().ShowDialog();
            PlataformasMarket.LimparLista();
            carregaPlataformas();

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //backup.CriaBackup(@"c:\testehj.sql");
            
        }

        private void frmPrincipal_Shown(object sender, EventArgs e)
        {
            if (!CarregaConn())
            {
                new frmMysql().ShowDialog(this);

            }
            else
            {
                Inicio();
            }
        }

        private void btAddProduto_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            frmAddProduto frmModificar = new frmAddProduto();
            frmModificar.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            new frmEstoque().ShowDialog();
        }

        private void btEstoque_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            new frmEstoque().ShowDialog();
            estoquebaixo();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmSettings().ShowDialog();
        }

        private void btCriarBackup_Click(object sender, EventArgs e)
        {

        }

        private void criarBackupAgoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = DateTime.Now.Date.ToShortDateString()+ ".sql";
            data=data.Replace("/","_");
            backup.CriaBackup(Properties.Settings.Default.backupfolder + @"\" + data);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {



            if (flowLayoutPanel3.Width >= 200)
            {
                flowLayoutPanel3.Width -= 2;
            }
            else { flowLayoutPanel3.Width = 200; timer3.Enabled = true;  timer2.Stop(); }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (timer2.Enabled)
            {
                timer2.Stop();
            }

                if (flowLayoutPanel3.Width <= 247)
            {
                flowLayoutPanel3.Width += 2;
            }
            else { flowLayoutPanel3.Width = 247; timer3.Stop(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer3.Enabled = false;
            timer2.Enabled = true;
            timer2.Start();
            if (config.frmMenuPrincipal == true)
            {
                config.frmMenuPrincipal = false;


            }
            else
            {

                config.frmMenuPrincipal = true;
            }
            tmrMenuPrincipal.Enabled = true;
            tmrMenuPrincipal.Start();
        }
        private void botaoCoresMuda(Color cor)
        {
            foreach(Control Controle in flowLayoutPanel1.Controls)
            {
                if (Controle is Button)
                {
                    Application.DoEvents();
                    Controle.ForeColor = cor;
                }
            }

        }
    }
}
