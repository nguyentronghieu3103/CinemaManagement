using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace CinemaManagement.UI.UserControls.Common
{
    public partial class RevenueChartControl : UserControl
    {
        public RevenueChartControl()
        {
            InitializeComponent();
            var columnSeries = new ColumnSeries<double>
            {
                Values = new double[] { 15, 20, 12, 25, 30, 45, 50 },
                Name = "Doanh thu (Triệu VNĐ)"
            };
            cartesianChart1.Series = new ISeries[] { columnSeries };
            cartesianChart1.XAxes = new Axis[]
            {
        new Axis
        {
            Labels = new string[] { "T2", "T3", "T4", "T5", "T6", "T7", "CN" },
            Name = "Ngày trong tuần"
        }
            };
            cartesianChart1.YAxes = new Axis[]
            {
        new Axis { Name = "Triệu VNĐ" }
            };
        }

        private void cartesianChart1_Load(object sender, EventArgs e)
        {

        }
    }
}
