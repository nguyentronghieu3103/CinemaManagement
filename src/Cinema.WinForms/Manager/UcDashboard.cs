using System;
using System.Windows.Forms;

namespace Cinema.WinForms.Manager
{
    public partial class UcDashboard : UserControl
    {
        public UcDashboard()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            lnkKpi4Desc.Click += (_, __) =>
            {
                using var f = new FrmApprovalQueue();
                f.ShowDialog(FindForm());
            };

            // Z-order: higher index docks first; Fill docks last (index 0)
            Controls.SetChildIndex(pnlHeader, 2);
            Controls.SetChildIndex(tlpKpi, 1);
            Controls.SetChildIndex(tlpBottom, 0);
        }
    }
}
