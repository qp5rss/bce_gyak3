using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qp5rss_gyak5.MnbServiceReference;
using qp5rss_gyak5.Entities;
using System.Xml;

namespace qp5rss_gyak5
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();

        public Form1()
        {
            InitializeComponent();
            ProcessXML(LoadMNB());
            FillChart();
        }

        private string LoadMNB()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            var response = mnbService.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;
            dataGridView.DataSource = Rates;

            return result.ToString();
        }

        private void ProcessXML(string input)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(input);

            foreach(XmlElement element in xml.DocumentElement)
            {
                var tempRate = new RateData();

                tempRate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                tempRate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);

                if (unit != 0) tempRate.Value = value / unit;

                Rates.Add(tempRate);
            }
        }

        private void FillChart()
        {
            chart.DataSource = Rates;

            var series = chart.Series[0];
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chart.Legends[0];
            legend.Enabled = false;

            var chartArea = chart.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }
    }
}
