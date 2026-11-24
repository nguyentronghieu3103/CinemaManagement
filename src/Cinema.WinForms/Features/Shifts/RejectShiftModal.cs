using System;
using System.Windows.Forms;

namespace Cinema.WinForms.Features.Shifts
{
    public partial class RejectShiftModal : Form
    {
        public RejectShiftModal()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            btnSend.Click += (_, __) => { MessageBox.Show("Đã gửi yêu cầu (mock)."); Close(); };
        }
    }
}