using System;
using System.Drawing;
using System.Windows.Forms;
using Cinema.WinForms.Features.Pricing;

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
            gridPrice.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            gridPrice.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            gridPrice.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridPrice.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            gridPrice.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            gridPrice.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

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