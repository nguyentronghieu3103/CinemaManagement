using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cinema.WinForms.Manager
{
    public partial class UcFnBConcession : UserControl
    {
        private readonly List<(string Code, string Name, string Supplier, string Cat, string List, string Promo, string Pos, string Stock)> menuItems = new()
        {
            ("DR01", "Pepsi 32oz", "Suntory PepsiCo", "\u0110\u1ED3 u\u1ED1ng", "35.000 \u0111", "0 \u0111", "35.000 \u0111", "120"),
            ("DR02", "7Up 32oz", "Suntory PepsiCo", "\u0110\u1ED3 u\u1ED1ng", "35.000 \u0111", "0 \u0111", "35.000 \u0111", "90"),
            ("DR03", "Aquafina 500ml", "Suntory PepsiCo", "\u0110\u1ED3 u\u1ED1ng", "20.000 \u0111", "0 \u0111", "20.000 \u0111", "150"),
            ("DR04", "Tr\u00E0 Tea+", "Suntory PepsiCo", "\u0110\u1ED3 u\u1ED1ng", "25.000 \u0111", "0 \u0111", "25.000 \u0111", "80"),
            ("BP01", "B\u1EAFp Ng\u1ECDt (Size L)", "C\u00F4ng ty N\u00F4ng S\u1EA3n B\u1EAFp V\u00E0ng", "B\u1EAFp", "55.000 \u0111", "5.000 \u0111", "50.000 \u0111", "60"),
            ("BP02", "B\u1EAFp Ph\u00F4 Mai (Size L)", "C\u00F4ng ty N\u00F4ng S\u1EA3n B\u1EAFp V\u00E0ng", "B\u1EAFp", "60.000 \u0111", "5.000 \u0111", "55.000 \u0111", "55"),
            ("BP03", "B\u1EAFp Caramel (Size L)", "C\u00F4ng ty N\u00F4ng S\u1EA3n B\u1EAFp V\u00E0ng", "B\u1EAFp", "60.000 \u0111", "5.000 \u0111", "55.000 \u0111", "50"),
            ("BP04", "B\u1EAFp N\u1EA5m H\u1EA1t", "C\u00F4ng ty N\u00F4ng S\u1EA3n B\u1EAFp V\u00E0ng", "B\u1EAFp", "65.000 \u0111", "0 \u0111", "65.000 \u0111", "40"),
            ("PK01", "Ly gi\u1EA5y in logo 32oz", "C\u00F4ng ty Bao B\u00EC Cinema", "Bao b\u00EC", "2.000 \u0111", "0 \u0111", "2.000 \u0111", "500"),
            ("PK02", "H\u1ED9p \u0111\u1EF1ng b\u1EAFp Size L", "C\u00F4ng ty Bao B\u00EC Cinema", "Bao b\u00EC", "3.000 \u0111", "0 \u0111", "3.000 \u0111", "400"),
            ("PK03", "\u1ED0ng h\u00FAt gi\u1EA5y", "C\u00F4ng ty Bao B\u00EC Cinema", "Bao b\u00EC", "500 \u0111", "0 \u0111", "500 \u0111", "1000"),
        };

        public UcFnBConcession()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            StyleGrid(gridMenu);
            StyleGrid(gridHist);

            cboSupplier.Items.AddRange(new object[] { "Suntory PepsiCo", "C\u00F4ng ty N\u00F4ng S\u1EA3n B\u1EAFp V\u00E0ng", "C\u00F4ng ty Bao B\u00EC Cinema" });
            cboSupplier.SelectedIndex = 0;
            cboSupplier.SelectedIndexChanged += (_, __) => LoadMenu();

            gridHist.Rows.Add("PN-001", "21/11/2026 09:20", "Suntory PepsiCo", "Pepsi 32oz", "100", "1.500.000 \u0111", "QL-001");
            gridHist.Rows.Add("PN-002", "21/11/2026 10:05", "C\u00F4ng ty N\u00F4ng S\u1EA3n B\u1EAFp V\u00E0ng", "B\u1EAFp Ng\u1ECDt (Size L)", "50", "1.250.000 \u0111", "QL-001");

            btnAddImport.Click += (_, __) => new ImportFnBModal().ShowDialog(FindForm());
            gridMenu.CellContentClick += (_, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == colMEdit.Index)
                {
                    var name = gridMenu.Rows[e.RowIndex].Cells[colMName.Index].Value?.ToString() ?? "M\u00F3n F&B";
                    new EditFnBPriceModal(name).ShowDialog(FindForm());
                }
            };

            LoadMenu();
        }

        private void LoadMenu()
        {
            gridMenu.Rows.Clear();
            var supplier = cboSupplier.SelectedItem?.ToString() ?? "";
            foreach (var it in menuItems.Where(x => x.Supplier == supplier))
                gridMenu.Rows.Add(it.Code, it.Name, it.Supplier, it.Cat, it.List, it.Promo, it.Pos, it.Stock);
        }

        private static void StyleGrid(DataGridView g)
        {
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            g.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }
    }
}
