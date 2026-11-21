using System;
using System.Windows.Forms;

namespace Cinema.WinForms.Manager
{
    public partial class AddShowtimeModal : Form
    {
        public AddShowtimeModal()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            cboMovie.Items.AddRange(new[] { "Anh Trai V\u01B0\u1EE3t Ng\u00E0n S\u00F3ng Gi\u00F3 (\u0110ang chi\u1EBFu)", "Dune: Part Two (\u0110ang chi\u1EBFu)" });
            cboMovie.SelectedIndex = 0;
            cboRoom.Items.AddRange(new[] { "Ph\u00F2ng 01 - 2D", "Ph\u00F2ng 02 - 3D", "Ph\u00F2ng 03 - IMAX" });
            cboRoom.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
            dtpStartTime.Value = DateTime.Today.AddHours(14).AddMinutes(30);
            txtEndTime.Text = "16:50";
            btnCancel.Click += (_, __) => Close();
            btnSave.Click += (_, __) => { MessageBox.Show("\u0110\u00E3 l\u01B0u su\u1EA5t chi\u1EBFu (mock)."); Close(); };
        }
    }
}
