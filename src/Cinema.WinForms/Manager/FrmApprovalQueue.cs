using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema.WinForms.Manager
{
    public partial class FrmApprovalQueue : Form
    {
        public FrmApprovalQueue()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            gridQueue.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            gridQueue.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            gridQueue.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridQueue.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            gridQueue.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            gridQueue.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            gridQueue.Rows.Add("VE-10234", "Anh Trai V\u01B0\u1EE3t Ng\u00E0n S\u00F3ng Gi\u00F3", "A5, A6", "180.000 \u0111", "Kh\u00E1ch b\u1EADn vi\u1EC7c \u0111\u1ED9t xu\u1EA5t");
            gridQueue.Rows.Add("VE-10251", "Mai 2", "C3", "95.000 \u0111", "\u0110\u1EB7t nh\u1EA7m su\u1EA5t chi\u1EBFu");
            gridQueue.Rows.Add("VE-10277", "T\u1EA5m C\u00E1m", "F1, F2", "320.000 \u0111", "S\u1EF1 c\u1ED1 k\u1EF9 thu\u1EADt ph\u00F2ng chi\u1EBFu");

            btnApprove.Click += (_, __) => HandleAction(true);
            btnReject.Click += (_, __) => HandleAction(false);
            btnClose.Click += (_, __) => Close();
        }

        private void HandleAction(bool approve)
        {
            if (gridQueue.CurrentRow == null) return;
            string ticket = gridQueue.CurrentRow.Cells[0].Value?.ToString() ?? "";
            string msg = approve
                ? $"\u0110\u00E3 ch\u1EA5p thu\u1EADn ho\u00E0n ti\u1EC1n cho {ticket} (mock)."
                : $"\u0110\u00E3 t\u1EEB ch\u1ED1i y\u00EAu c\u1EA7u h\u1EE7y v\u00E9 {ticket} (mock).";
            MessageBox.Show(msg, "Th\u00F4ng b\u00E1o", MessageBoxButtons.OK, approve ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}
