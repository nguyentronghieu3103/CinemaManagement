using System.Drawing.Drawing2D;
using System.Globalization;

namespace Cinema.WinForms.Controls;

public partial class SeatMapControl : UserControl
{
    private static readonly Color StandardColor = Color.FromArgb(226, 232, 240);
    private static readonly Color VipColor = Color.FromArgb(237, 233, 254);
    private static readonly Color CoupleColor = Color.FromArgb(252, 231, 243);
    private static readonly Color SelectedColor = Color.FromArgb(37, 99, 235);
    private static readonly Color SoldColor = Color.FromArgb(148, 163, 184);
    private static readonly Color HeldColor = Color.FromArgb(254, 243, 199);
    private static readonly Color HeldTextColor = Color.FromArgb(146, 64, 14);

    private readonly Dictionary<string, Button> seatButtons = [];

    public SeatMapControl()
    {
        InitializeComponent();
    }

    internal event Action<AuditoriumSeat>? SeatClicked;

    internal void SetSeats(IReadOnlyList<AuditoriumSeat> seats)
    {
        seatGrid.SuspendLayout();
        try
        {
            while (seatGrid.Controls.Count > 0)
            {
                seatGrid.Controls[0].Dispose();
            }

            seatButtons.Clear();
            var columns = seats.SelectMany(seat => Enumerable.Range(seat.Column, seat.Places)).Distinct().Order();
            foreach (int column in columns)
            {
                seatGrid.Controls.Add(CreateCaption(column.ToString(CultureInfo.InvariantCulture)), GetGridColumn(column), 0);
            }

            foreach (char rowName in seats.Select(seat => seat.Row).Distinct().Order())
            {
                int row = rowName - 'A' + 1;
                seatGrid.Controls.Add(CreateCaption(rowName.ToString()), 0, row);
                seatGrid.Controls.Add(CreateCaption(rowName.ToString()), seatGrid.ColumnCount - 1, row);
            }

            foreach (AuditoriumSeat seat in seats)
            {
                AddSeat(seat);
            }
        }
        finally
        {
            seatGrid.ResumeLayout(true);
        }

        pnlViewport.AutoScrollPosition = Point.Empty;
        CenterMap();
    }

    internal void SetSelected(AuditoriumSeat seat, bool selected)
    {
        Button button = seatButtons[seat.Code];
        string status = selected ? "Đang chọn" : seat.Availability switch
        {
            SeatAvailability.Sold => "Đã bán",
            SeatAvailability.Held => "Đang giữ",
            _ => "Trống"
        };

        (Color background, Color foreground, string mark) = (selected, seat.Availability, seat.Type) switch
        {
            (true, _, _) => (SelectedColor, Color.White, "✓"),
            (_, SeatAvailability.Sold, _) => (SoldColor, ForeColor, "×"),
            (_, SeatAvailability.Held, _) => (HeldColor, HeldTextColor, "◷"),
            (_, _, SeatType.Vip) => (VipColor, Color.FromArgb(91, 33, 182), "V"),
            (_, _, SeatType.Couple) => (CoupleColor, Color.FromArgb(157, 23, 77), "2"),
            _ => (StandardColor, ForeColor, string.Empty)
        };

        button.BackColor = background;
        button.ForeColor = foreground;
        button.FlatAppearance.BorderColor = selected ? Color.FromArgb(29, 78, 216) : SoldColor;
        button.FlatAppearance.MouseOverBackColor = button.TabStop ? ControlPaint.Light(background, 0.1f) : background;
        button.FlatAppearance.MouseDownBackColor = background;
        button.Text = mark;
        button.AccessibleDescription = status;
    }

    private void AddSeat(AuditoriumSeat seat)
    {
        bool available = seat.Availability == SeatAvailability.Available;
        string description = $"{seat.Code} · {seat.TypeName} · {AuditoriumSeat.FormatPrice(seat.Price)}";
        int horizontalMargin = LogicalToDeviceUnits(3);
        int verticalMargin = LogicalToDeviceUnits(1);
        var button = new Button
        {
            Name = $"seat{seat.Code}",
            AccessibleName = description,
            AutoSize = false,
            Dock = DockStyle.Fill,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(horizontalMargin, verticalMargin, horizontalMargin, verticalMargin),
            TabIndex = seatButtons.Count,
            TabStop = available,
            Cursor = available ? Cursors.Hand : Cursors.Default,
            UseVisualStyleBackColor = false
        };

        if (available)
        {
            button.Click += (_, _) => SeatClicked?.Invoke(seat);
        }
        else
        {
            description += seat.Availability == SeatAvailability.Sold ? " · Đã bán" : " · Đang giữ";
        }

        seatToolTip.SetToolTip(button, description);
        seatButtons.Add(seat.Code, button);
        SetSelected(seat, false);
        seatGrid.Controls.Add(button, GetGridColumn(seat.Column), seat.Row - 'A' + 1);
        seatGrid.SetColumnSpan(button, seat.Places);
    }

    private static Label CreateCaption(string text) => new()
    {
        Text = text,
        Dock = DockStyle.Fill,
        Margin = Padding.Empty,
        TextAlign = ContentAlignment.MiddleCenter
    };

    private static int GetGridColumn(int column) => column <= 6 ? column : column + 1;

    private void PnlViewport_Resize(object? sender, EventArgs e) => CenterMap();

    private void CenterMap()
    {
        bool compact = pnlViewport.Height < LogicalToDeviceUnits(472);
        int screenHeight = LogicalToDeviceUnits(compact ? 40 : 57);
        int legendHeight = LogicalToDeviceUnits(compact ? 36 : 51);
        int columnsHeight = LogicalToDeviceUnits(compact ? 20 : 24);
        int seatHeight = LogicalToDeviceUnits(compact ? 23 : 30);
        int gridHeight = columnsHeight + (seatGrid.RowCount - 1) * seatHeight;
        int mapHeight = screenHeight + gridHeight + legendHeight;
        int scrollbarWidth = SystemInformation.VerticalScrollBarWidth;
        int mapWidth = Math.Clamp(pnlViewport.Width - scrollbarWidth, LogicalToDeviceUnits(500), LogicalToDeviceUnits(620));

        pnlViewport.SuspendLayout();
        layoutMap.SuspendLayout();
        seatGrid.SuspendLayout();
        try
        {
            seatGrid.RowStyles[0].Height = columnsHeight;
            for (int row = 1; row < seatGrid.RowCount; row++)
            {
                seatGrid.RowStyles[row].Height = seatHeight;
            }

            layoutMap.RowStyles[0].Height = screenHeight;
            layoutMap.RowStyles[1].Height = gridHeight;
            layoutMap.RowStyles[2].Height = legendHeight;
            layoutMap.Size = new Size(mapWidth, mapHeight);
            pnlViewport.AutoScrollMinSize = layoutMap.Size;
            Point offset = pnlViewport.AutoScrollPosition;
            int x = Math.Max(0, (pnlViewport.ClientSize.Width - mapWidth) / 2);
            layoutMap.Location = new Point(x + offset.X, offset.Y);
        }
        finally
        {
            seatGrid.ResumeLayout(true);
            layoutMap.ResumeLayout(true);
            pnlViewport.ResumeLayout(true);
        }
    }

    private void PnlScreen_Paint(object? sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        float inset = pnlScreen.Width * 0.10f;
        float right = pnlScreen.Width - inset;
        float bottom = pnlScreen.Height - LogicalToDeviceUnits(5);
        float rise = LogicalToDeviceUnits(9);
        using var border = new Pen(SoldColor, LogicalToDeviceUnits(3));
        e.Graphics.DrawBezier(border, inset, bottom, inset * 2, bottom - rise, right - inset, bottom - rise, right, bottom);
    }
}

internal enum SeatType
{
    Standard,
    Vip,
    Couple
}

internal enum SeatAvailability
{
    Available,
    Sold,
    Held
}

internal sealed record AuditoriumSeat(char Row, int Column, SeatType Type, decimal Price, SeatAvailability Availability)
{
    internal static readonly CultureInfo MoneyCulture = CultureInfo.GetCultureInfo("vi-VN");

    public string Code => $"{Row}{Column}";

    public string TypeName => Type switch
    {
        SeatType.Vip => "VIP",
        SeatType.Couple => "Đôi",
        _ => "Thường"
    };

    internal int Places => Type == SeatType.Couple ? 2 : 1;

    internal static string FormatPrice(decimal price) => $"{price.ToString("N0", MoneyCulture)} đ";
}
