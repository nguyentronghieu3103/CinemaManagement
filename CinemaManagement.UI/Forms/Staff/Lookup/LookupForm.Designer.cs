namespace CinemaManagement.UI.Forms.Staff.Lookup
{
    partial class LookupForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Text = "Tra Cứu Vé";
            this.BackColor = System.Drawing.Color.FromArgb(249, 245, 242);

            this.Controls.Add(new System.Windows.Forms.Label { Text = "Form Tra Cứu Vé - Loading...", AutoSize = true, Location = new System.Drawing.Point(50, 50) });
        }
    }
}
