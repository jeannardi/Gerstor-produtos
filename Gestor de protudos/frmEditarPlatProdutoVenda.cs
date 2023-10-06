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
    public partial class frmEditarPlatProdutoVenda : Form
    {
        public decimal valor;
        public frmEditarPlatProdutoVenda()
        {
            InitializeComponent();
        }

        private void frmEditarPlatProdutoVenda_Load(object sender, EventArgs e)
        {
            textBox1.Text = valor.ToString("N2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            valor = Convert.ToDecimal(textBox1.Text);
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;


            if (!char.IsControl(ch) && !char.IsDigit(ch) && ch != '.' && ch != ',')
            {
                e.Handled = true;
            }

            if (ch == '.' && textBox1.Text.Contains("."))
            {
                e.Handled = true;
            }


            if (ch == ',' && textBox1.Text.Contains(","))
            {
                e.Handled = true;
            }

            if (ch == ',' && textBox1.Text.IndexOf(',') == textBox1.Text.Length - 1)
            {
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = double.Parse(textBox1.Text).ToString("N2");

            }
            catch (Exception ex)

            {
                textBox1.Text = "0,00";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var kk = double.Parse(textBox1.Text).ToString("N2");
                button1.Enabled = true;
            }
            catch (Exception ex)

            {
                button1.Enabled = false;
            }
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
