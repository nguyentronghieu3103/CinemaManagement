using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.TicketSales;

internal sealed class ConcessionProductCard : Panel
{
    private static readonly Color Accent = Color.FromArgb(37, 99, 235);
    private static readonly Color Outline = Color.FromArgb(226, 232, 240);
    private readonly Font boldFont = new("Segoe UI", 9F, FontStyle.Bold);
    private readonly TableLayoutPanel body;
    private readonly Button decrease;
    private readonly Button increase;
    private readonly Label lblQuantity;

    internal ConcessionProductCard(ConcessionProduct product)
    {
        Dock = DockStyle.Fill;
        Margin = new Padding(0, 0, LogicalToDeviceUnits(8), LogicalToDeviceUnits(8));
        Padding = new Padding(LogicalToDeviceUnits(2));
        ForeColor = Color.FromArgb(15, 23, 42);
        AccessibleName = product.Name;

        body = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(LogicalToDeviceUnits(8)),
            ColumnCount = 1,
            RowCount = 5
        };
        body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        body.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        body.RowStyles.Add(new RowStyle(SizeType.Absolute, LogicalToDeviceUnits(22)));
        body.RowStyles.Add(new RowStyle(SizeType.Absolute, LogicalToDeviceUnits(18)));
        body.RowStyles.Add(new RowStyle(SizeType.Absolute, LogicalToDeviceUnits(24)));
        body.RowStyles.Add(new RowStyle(SizeType.Absolute, LogicalToDeviceUnits(32)));
        Controls.Add(body);

        var picture = new PictureBox
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 0, 0, LogicalToDeviceUnits(4)),
            BackColor = Color.FromArgb(241, 245, 249),
            TabStop = false
        };
        picture.Paint += DrawPlaceholder;
        body.Controls.Add(picture, 0, 0);
        body.Controls.Add(CreateLabel(product.Name, true, ForeColor), 0, 1);
        body.Controls.Add(CreateLabel(product.Description, false, Color.FromArgb(71, 85, 105)), 0, 2);
        body.Controls.Add(CreateLabel(AuditoriumSeat.FormatPrice(product.Price), true, ForeColor), 0, 3);

        var stepper = new TableLayoutPanel
        {
            ColumnCount = 5,
            RowCount = 1,
            Dock = DockStyle.Fill,
            Margin = Padding.Empty
        };
        stepper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        stepper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, LogicalToDeviceUnits(32)));
        stepper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, LogicalToDeviceUnits(44)));
        stepper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, LogicalToDeviceUnits(32)));
        stepper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        stepper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        body.Controls.Add(stepper, 0, 4);

        decrease = CreateStepButton("−", $"Giảm số lượng {product.Name}", -1);
        increase = CreateStepButton("+", $"Tăng số lượng {product.Name}", 1);
        lblQuantity = CreateLabel("0", true, ForeColor);
        lblQuantity.TextAlign = ContentAlignment.MiddleCenter;
        lblQuantity.AccessibleName = $"Số lượng {product.Name}";
        stepper.Controls.Add(decrease, 1, 0);
        stepper.Controls.Add(lblQuantity, 2, 0);
        stepper.Controls.Add(increase, 3, 0);
        SetQuantity(0);
    }

    internal event Action<int>? StepRequested;

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing)
        {
            boldFont.Dispose();
        }
    }

    internal void SetQuantity(int quantity)
    {
        bool selected = quantity > 0;
        lblQuantity.Text = quantity.ToString();
        decrease.Enabled = selected;
        increase.BackColor = selected ? Accent : Color.FromArgb(239, 246, 255);
        increase.ForeColor = selected ? Color.White : Accent;
        increase.FlatAppearance.BorderColor = selected ? Accent : Outline;
        increase.FlatAppearance.MouseOverBackColor = selected ? Color.FromArgb(29, 78, 216) : Color.FromArgb(219, 234, 254);
        BackColor = selected ? Accent : Outline;
        body.BackColor = selected ? Color.FromArgb(239, 246, 255) : Color.White;
    }

    internal static void DrawPlaceholder(object? sender, PaintEventArgs e)
    {
        if (sender is PictureBox picture && picture.ClientSize.Width > 1 && picture.ClientSize.Height > 1)
        {
            using var pen = new Pen(Color.FromArgb(203, 213, 225));
            int right = picture.ClientSize.Width - 1;
            int bottom = picture.ClientSize.Height - 1;
            e.Graphics.DrawRectangle(pen, 0, 0, right, bottom);
            e.Graphics.DrawLine(pen, 0, 0, right, bottom);
            e.Graphics.DrawLine(pen, right, 0, 0, bottom);
        }
    }

    private Button CreateStepButton(string text, string description, int delta)
    {
        var button = new Button
        {
            AccessibleName = description,
            Text = text,
            Dock = DockStyle.Fill,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.White,
            ForeColor = Accent,
            UseVisualStyleBackColor = false,
            Margin = new Padding(0, LogicalToDeviceUnits(2), 0, 0),
            Cursor = Cursors.Hand
        };
        button.FlatAppearance.BorderColor = Outline;
        button.Click += (_, _) => StepRequested?.Invoke(delta);
        return button;
    }

    private Label CreateLabel(string text, bool bold, Color color) => new()
    {
        Dock = DockStyle.Fill,
        Margin = Padding.Empty,
        Font = bold ? boldFont : null,
        ForeColor = color,
        Text = text,
        TextAlign = ContentAlignment.MiddleLeft,
        AutoEllipsis = true,
        UseMnemonic = false
    };
}
