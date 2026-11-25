using System;
using System.Windows.Forms;
using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.Members
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
            UiTheme.StyleGrid(grid);
            grid.CellFormatting += (_, e) =>
            {
                if (e.ColumnIndex == colTier.Index && e.Value is "V\u00E0ng" or "Gold" && e.CellStyle is { } style)
                {
                    style.BackColor = UiTheme.Amber;
                    style.ForeColor = UiTheme.TextMain;
                }
            };

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
