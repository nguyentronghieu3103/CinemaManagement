using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema.WinForms.Manager
{
    public partial class CustomerDetailModal : Form
    {
        private readonly string customerName;
        private readonly string tier;

        public CustomerDetailModal(string name, string tier)
        {
            this.customerName = name;
            this.tier = tier;
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            Text = "Chi ti\u1EBFt kh\u00E1ch - " + customerName;
            bool isMember = tier != "Kh\u00E1ch th\u01B0\u1EDDng";
            string tierDisplay = tier == "V\u00E0ng" || tier == "Gold" ? "Gold" : tier;
            string phone = isMember ? "0901234567" : "0977000111";
            string spend = tierDisplay == "Gold" ? "5.200.000 \u0111" : (tier == "B\u1EA1c" ? "2.800.000 \u0111" : (tier == "Chu\u1EA9n" ? "900.000 \u0111" : "120.000 \u0111"));
            lblInfo.Text = $"S\u0110T: {phone}  |  H\u1EA1ng th\u1EBB: {tierDisplay}  |  T\u1ED5ng chi ti\u00EAu: {spend}";

            lblPoint1Value.Text = isMember ? "520" : "0";
            lblPoint2Value.Text = isMember ? "100" : "0";
            lblPoint3Value.Text = isMember ? "420" : "0";

            gridHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            gridHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            gridHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            gridHistory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            gridHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            gridHistory.Rows.Add("VE-10021", "Mai 2", "D5", "95.000 \u0111", "20/11/2026", "+10");
            gridHistory.Rows.Add("VE-10045", "Anh Trai V\u01B0\u1EE3t Ng\u00E0n S\u00F3ng Gi\u00F3", "A5, A6", "180.000 \u0111", "21/11/2026", "+18");
            gridHistory.Rows.Add("VE-10088", "T\u1EA5m C\u00E1m", "F1", "0 \u0111", "22/11/2026", "-100");
            gridHistory.Rows.Add("VE-10102", "Dune: Part Two", "C8", "120.000 \u0111", "22/11/2026", "+12");

            btnRedeem.Enabled = isMember;
            btnRedeem.Click += (_, __) => MessageBox.Show("\u0110\u1ED5i \u0111i\u1EC3m (mock).", "Th\u00F4ng b\u00E1o", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
