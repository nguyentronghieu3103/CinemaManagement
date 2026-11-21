using System;
using System.Windows.Forms;

namespace Cinema.WinForms.Manager
{
    public partial class RegisterCustomerModal : Form
    {
        public RegisterCustomerModal()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            cboTier.SelectedIndex = 0;
            rbMember.CheckedChanged += (_, __) => ApplyCustomerType();
            rbGuest.CheckedChanged += (_, __) => ApplyCustomerType();
            ApplyCustomerType();

            btnSave.Click += (_, __) => { MessageBox.Show("\u0110\u00E3 l\u01B0u h\u1ED3 s\u01A1 (mock)."); Close(); };
        }

        private void ApplyCustomerType()
        {
            bool isMember = rbMember.Checked;
            cboTier.Enabled = isMember;
            numPoints.Enabled = isMember;

            if (isMember)
            {
                if (cboTier.SelectedItem == null || cboTier.SelectedItem.ToString() == "Kh\u00E1ch th\u01B0\u1EDDng")
                    cboTier.SelectedIndex = 0;
                if (numPoints.Value == 0) numPoints.Value = 50;
            }
            else
            {
                // lock guest to fixed tier/points
                if (!cboTier.Items.Contains("Kh\u00E1ch th\u01B0\u1EDDng"))
                    cboTier.Items.Add("Kh\u00E1ch th\u01B0\u1EDDng");
                cboTier.SelectedItem = "Kh\u00E1ch th\u01B0\u1EDDng";
                numPoints.Value = 0;
            }
        }
    }
}
