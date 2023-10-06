using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestor_de_produtos
{
    public partial class frmDadosGrafico : Form
    {
        public frmDadosGrafico()
        {
            InitializeComponent();
        }

        private void frmDadosGrafico_Load(object sender, EventArgs e)
        {
            Random rd = new Random();
            DateTime dh = new DateTime(2022, 12, 01);
            for(int j=0; j < 31; j++)
            {
                dh = dh.AddDays(1);
    
                int NumeroVenda = rd.Next(1, 101);
                decimal ValorVenda = 0 * NumeroVenda;
                ListaDados.AdicionarItem(dh, ValorVenda, NumeroVenda);
            }
            




            chart1.Series.Clear();
            chart1.Series.Add("MySeries");
            chart1.Series["MySeries"].ChartType = SeriesChartType.RangeColumn;

            double[] myData = new double[] { 10, 15, 12, 40, 33 };
            DateTime[] myDates = new DateTime[] { new DateTime(2023, 3, 15), new DateTime(2023, 3, 16), new DateTime(2023, 3, 17), new DateTime(2023, 3, 18), new DateTime(2023, 3, 19) };

           foreach (ItemDados Item in ListaDados.MostrarLista())
            {
                Console.WriteLine(Item.numeroDeVendas);
                chart1.Series["MySeries"].Points.AddXY(Item.dataHora, Item.numeroDeVendas);
        
            }

            chart1.Titles.Add("My Chart Title");
            chart1.Legends.Add("My Legend");
    
     

            chart1.Series["MySeries"].Color = Color.FromArgb(255, 128, 128);
            chart1.Series["MySeries"].BackGradientStyle = GradientStyle.TopBottom;
            chart1.Series["MySeries"].BackSecondaryColor = Color.FromArgb(255, 192, 192);

            foreach (var series in chart1.Series)
            {
                foreach (var point in series.Points)
                {
                    double xValue = point.XValue;
                    DateTime date = DateTime.FromOADate(xValue);
                    //point.Label = date.ToString("dd/MM/yyyy");
                    point.ToolTip = date.ToString("dd/MM/yyyy");
                }
            }


   
        }

    
    }
}
