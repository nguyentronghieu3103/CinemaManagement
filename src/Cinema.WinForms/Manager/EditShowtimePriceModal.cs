using System;
using System.Windows.Forms;

namespace Cinema.WinForms.Manager
{
    public partial class EditShowtimePriceModal : Form
    {
        private readonly string code;

        public EditShowtimePriceModal(string code)
        {
            this.code = code;
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            Text = "Sửa Giá Suất - " + code;
            btnSave.Click += (_, __) => { MessageBox.Show("Đã lưu biểu giá (mock)."); Close(); };
        }
    }
}