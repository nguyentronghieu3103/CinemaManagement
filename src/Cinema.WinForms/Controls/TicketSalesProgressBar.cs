using System.ComponentModel;

namespace Cinema.WinForms.Controls;

public sealed class TicketSalesProgressBar : UserControl
{
    private static readonly string[] StepNames =
        ["Chọn suất chiếu", "Chọn ghế", "Chọn bắp nước", "Thanh toán", "Hoàn tất & in vé"];

    private readonly Label[] steps = new Label[StepNames.Length];
    private int activeStep = 1;

    public TicketSalesProgressBar()
    {
        var layout = new TableLayoutPanel
        {
            ColumnCount = StepNames.Length,
            RowCount = 1,
            Dock = DockStyle.Fill,
            Margin = Padding.Empty
        };
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        for (int index = 0; index < steps.Length; index++)
        {
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            var label = new Label
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, index == steps.Length - 1 ? 0 : 6, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                UseMnemonic = false
            };
            steps[index] = label;
            layout.Controls.Add(label, index, 0);
        }

        AutoScaleMode = AutoScaleMode.Dpi;
        Controls.Add(layout);
        Margin = Padding.Empty;
        TabStop = false;
        UpdateSteps();
    }

    [DefaultValue(1)]
    public int ActiveStep
    {
        get => activeStep;
        set
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 1);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, steps.Length);
            activeStep = value;
            UpdateSteps();
        }
    }

    private void UpdateSteps()
    {
        for (int index = 0; index < steps.Length; index++)
        {
            int stepNumber = index + 1;
            Label label = steps[index];
            bool completed = stepNumber < activeStep;
            bool showCheck = completed || (stepNumber == steps.Length && activeStep == steps.Length);
            label.Text = $"{(showCheck ? "✓  " : string.Empty)}{stepNumber}. {StepNames[index]}";
            (label.BackColor, label.ForeColor) = stepNumber.CompareTo(activeStep) switch
            {
                < 0 => (Color.FromArgb(219, 234, 254), Color.FromArgb(30, 64, 175)),
                0 => (Color.FromArgb(37, 99, 235), Color.White),
                _ => (Color.FromArgb(226, 232, 240), Color.FromArgb(51, 65, 85))
            };
        }
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // TicketSalesProgressBar
        // 
        Name = "TicketSalesProgressBar";
        Size = new Size(212, 171);
        ResumeLayout(false);

    }
}
