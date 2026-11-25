using System;
using System.Windows.Forms;
using Cinema.WinForms.Features.Pricing;
using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.ShowtimeManagement
{
    public partial class UcScheduleCoordinator : UserControl
    {
        public UcScheduleCoordinator()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            UiTheme.StyleGrid(gridPrice);

            dtpDate.Value = new DateTime(2026, 11, 18);
            gridPrice.Rows.Add("SC-101", "Ph\u00F2ng 01", "Anh Trai V\u01B0\u1EE3t Ng\u00E0n S\u00F3ng Gi\u00F3", "09:00", "0 \u0111", "0 \u0111", "0 \u0111", "0 \u0111");
            gridPrice.Rows.Add("SC-102", "Ph\u00F2ng 02", "Dune: Part Two", "14:00", "90.000 \u0111", "120.000 \u0111", "200.000 \u0111", "10.000 \u0111");

            btnAdd.Click += (_, __) => new AddShowtimeModal().ShowDialog(FindForm());
            gridPrice.CellContentClick += (_, e) =>
            {
                if (e.RowIndex >= 0 && gridPrice.Columns[e.ColumnIndex].Name == "colEdit")
                    new EditShowtimePriceModal(gridPrice.Rows[e.RowIndex].Cells["colCode"].Value?.ToString() ?? "").ShowDialog(FindForm());
            };
        }
    }
}