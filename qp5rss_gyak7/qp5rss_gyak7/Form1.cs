using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qp5rss_gyak7.Entities;

namespace qp5rss_gyak7
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticks;
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();

        public Form1()
        {
            InitializeComponent();
            Ticks = context.Ticks.ToList();
            dataGridView.DataSource = Ticks;

            CreatePortfolio();
        }

        private void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Value = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Value = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Value = 10 });

            dataGridViewPortfolio.DataSource = Portfolio;
        }
    }
}
