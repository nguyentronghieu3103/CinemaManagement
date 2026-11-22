using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cinema.WinForms.Features.Inventory
{
    public partial class ImportFnBModal : Form
    {
        private static readonly Dictionary<string, string[]> CatalogBySupplier = new()
        {
            ["Suntory PepsiCo"] = new[] { "Pepsi 32oz", "7Up 32oz", "Aquafina 500ml", "Tr\u00E0 Tea+" },
            ["C\u00F4ng ty N\u00F4ng S\u1EA3n B\u1EAFp V\u00E0ng"] = new[] { "B\u1EAFp Ng\u1ECDt (Size L)", "B\u1EAFp Ph\u00F4 Mai (Size L)", "B\u1EAFp Caramel (Size L)", "B\u1EAFp N\u1EA5m H\u1EA1t" },
            ["C\u00F4ng ty Bao B\u00EC Cinema"] = new[] { "Ly gi\u1EA5y in logo 32oz", "H\u1ED9p \u0111\u1EF1ng b\u1EAFp Size L", "\u1ED0ng h\u00FAt gi\u1EA5y" }
        };

        public ImportFnBModal()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            cboSupplier.Items.AddRange(new object[] { "Suntory PepsiCo", "C\u00F4ng ty N\u00F4ng S\u1EA3n B\u1EAFp V\u00E0ng", "C\u00F4ng ty Bao B\u00EC Cinema" });
            cboSupplier.SelectedIndex = 0;
            cboNewCategory.Items.AddRange(new object[] { "\u0110\u1ED3 u\u1ED1ng", "B\u1EAFp", "Bao b\u00EC", "Combo", "Kh\u00E1c" });
            cboNewCategory.SelectedIndex = 0;
            LoadCatalog();

            cboSupplier.SelectedIndexChanged += (_, __) => LoadCatalog();
            rbExisting.CheckedChanged += (_, __) => ToggleMode();
            rbNew.CheckedChanged += (_, __) => ToggleMode();

            void UpdateTotal(object? s, EventArgs e) => lblTotal.Text = $"T\u1ED5ng ti\u1EC1n phi\u1EBFu = S\u1ED1 l\u01B0\u1EE3ng x \u0110\u01A1n gi\u00E1 nh\u1EADp: {(numQty.Value * numPrice.Value):N0} \u0111";
            numQty.ValueChanged += UpdateTotal;
            numPrice.ValueChanged += UpdateTotal;
            UpdateTotal(null, EventArgs.Empty);

            btnCancel.Click += (_, __) => Close();
            btnConfirm.Click += (_, __) => { MessageBox.Show("\u0110\u00E3 nh\u1EADp kho (mock)."); Close(); };
        }

        private void LoadCatalog()
        {
            cboItem.Items.Clear();
            var supplier = cboSupplier.SelectedItem?.ToString() ?? "Suntory PepsiCo";
            if (CatalogBySupplier.TryGetValue(supplier, out var items))
                cboItem.Items.AddRange(items);
            if (cboItem.Items.Count > 0) cboItem.SelectedIndex = 0;
        }

        private void ToggleMode()
        {
            bool isNew = rbNew.Checked;
            cboItem.Visible = !isNew;
            txtNewName.Visible = isNew;
            cboNewCategory.Visible = isNew;
        }
    }
}
