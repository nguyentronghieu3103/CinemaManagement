using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema.WinForms.Manager
{
    public partial class UcCustomerLoyalty : UserControl
    {
        public UcCustomerLoyalty()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            grid.Rows.Add("KH-001", "Nguy\u1EC5n V\u0103n A", "0901234567", "V\u00E0ng", "5.200.000 \u0111", "520", "100", "420", "Xem L\u1ECBch S\u1EED");
            grid.Rows.Add("KH-002", "Tr\u1EA7n Th\u1ECB B", "0912345678", "B\u1EA1c", "2.800.000 \u0111", "280", "50", "230", "Xem L\u1ECBch S\u1EED");
            grid.Rows.Add("KH-003", "L\u00EA V\u0103n C", "0987654321", "Chu\u1EA9n", "900.000 \u0111", "90", "0", "90", "Xem L\u1ECBch S\u1EED");
            grid.Rows.Add("KH-004", "Kh\u00E1ch v\u00E3ng lai", "0977000111", "Kh\u00E1ch th\u01B0\u1EDDng", "120.000 \u0111", "0", "0", "0", "Xem L\u1ECBch S\u1EED");

            btnAdd.Click += (_, __) => new RegisterCustomerModal().ShowDialog(FindForm());
            grid.CellContentClick += (_, e) =>
            {
                if (e.RowIndex >= 0 && grid.Columns[e.ColumnIndex].Name == "colView")
                    new CustomerDetailModal(grid.Rows[e.RowIndex].Cells["colName"].Value?.ToString() ?? "", grid.Rows[e.RowIndex].Cells["colTier"].Value?.ToString() ?? "").ShowDialog(FindForm());
            };

            // Z-order: higher index docks first; Fill docks last (index 0)
            Controls.SetChildIndex(pnlHeader, 1);
            Controls.SetChildIndex(grid, 0);
        }
    }
}
