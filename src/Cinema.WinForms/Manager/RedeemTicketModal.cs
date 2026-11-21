using System;
using System.Windows.Forms;

namespace Cinema.WinForms.Manager
{
    public partial class RedeemTicketModal : Form
    {
        public RedeemTicketModal()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            cboMovie.Items.AddRange(new[] { "Dune: Phần Hai", "Mai" });
            cboMovie.SelectedIndex = 0;
            cboRoom.Items.AddRange(new[] { "Phòng 01", "Phòng 02" });
            cboRoom.SelectedIndex = 0;
            cboSeat.Items.AddRange(new[] { "Ghế Thường - 100 điểm", "Ghế VIP - 150 điểm" });
            cboSeat.SelectedIndex = 0;
            btnOk.Click += (_, __) => { MessageBox.Show("Đã đổi vé (mock)."); Close(); };
        }
    }
}