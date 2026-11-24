using System;
using System.Windows.Forms;

namespace Cinema.WinForms.Features.Inventory
{
    public partial class EditFnBPriceModal : Form
    {
        private readonly string itemName;

        public EditFnBPriceModal(string name = "M\u00F3n F&B")
        {
            this.itemName = name;
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            Text = "S\u1EEDa Gi\u00E1 F&&B - " + itemName;
            void UpdatePreview(object? s, EventArgs e) => lblPreview.Text = $"Xem tr\u01B0\u1EDBc gi\u00E1 thu POS: {Math.Max(0, numBasePrice.Value - numDiscount.Value):N0} \u0111";
            numBasePrice.ValueChanged += UpdatePreview;
            numDiscount.ValueChanged += UpdatePreview;
            btnCancel.Click += (_, __) => Close();
            btnSave.Click += (_, __) => { MessageBox.Show("\u0110\u00E3 l\u01B0u gi\u00E1 (mock)."); Close(); };
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}