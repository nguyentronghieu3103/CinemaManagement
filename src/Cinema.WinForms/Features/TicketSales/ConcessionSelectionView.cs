using System.ComponentModel;
using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.TicketSales;

public partial class ConcessionSelectionView : UserControl
{
    private static readonly Color Accent = Color.FromArgb(37, 99, 235);
    private static readonly Color Ink = Color.FromArgb(15, 23, 42);
    private readonly Dictionary<ConcessionProduct, int> quantities = [];
    private readonly (ConcessionCategory? Category, Button Button)[] categoryButtons;
    private readonly string catalogTitle;
    private readonly Font catalogTitleFont;
    private SeatSelectionContext? ticketSelection;
    private IReadOnlyList<ConcessionProduct> catalog = [];
    private ConcessionCategory? selectedCategory;
    private int productColumns;
    private int productRowHeight;

    public ConcessionSelectionView()
    {
        InitializeComponent();
        catalogTitle = lblTitle.Text;
        catalogTitleFont = lblTitle.Font;
        categoryButtons =
        [
            (null, btnAll), (ConcessionCategory.Combo, btnCombo), (ConcessionCategory.Popcorn, btnPopcorn),
            (ConcessionCategory.Drink, btnDrink), (ConcessionCategory.Snack, btnSnack)
        ];

        if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
        {
            foreach (var (category, button) in categoryButtons)
            {
                button.Click += (_, _) => SelectCategory(category);
            }

            picMovie.Paint += ConcessionProductCard.DrawPlaceholder;
            layoutWorkArea.SizeChanged += LayoutWorkArea_SizeChanged;
            pnlProductScroll.SizeChanged += PnlProductScroll_SizeChanged;
        }
    }

    internal event EventHandler? BackRequested;
    internal event Action<PaymentOrder>? ContinueRequested;

    internal void ShowFor(SeatSelectionContext selection, IReadOnlyList<ConcessionProduct> products)
    {
        bool newSelection = ticketSelection?.SelectionId != selection.SelectionId;
        ticketSelection = selection;
        catalog = products;
        if (newSelection)
        {
            quantities.Clear();
        }
        else
        {
            foreach (ConcessionProduct unavailable in quantities.Keys.Except(catalog).ToArray())
            {
                quantities.Remove(unavailable);
            }
        }

        SelectCategory(newSelection ? null : selectedCategory);
        ShowtimeOption showtime = selection.Showtime.Showtime;
        lblMovie.Text = selection.Showtime.MovieTitle;
        lblShowtime.Text = $"{showtime.StartsAt:dd/MM/yyyy  ·  HH:mm}";
        lblRoom.Text = $"{SeatSelectionContext.RoomCaption(showtime.Room)}  ·  {showtime.Format}";
        lblSeats.Text = $"Ghế: {string.Join(", ", selection.Seats.Select(seat => seat.Code))}";
        lblTicketCount.Text = $"Vé ({selection.PlaceCount} chỗ)";
        lblTicketAmount.Text = AuditoriumSeat.FormatPrice(selection.TicketSubtotal);
        lblNotice.Visible = false;
        btnContinue.Enabled = true;
        UpdateOrderSummary();
        UpdateResponsiveLayout();
    }

    internal void ClearDraft()
    {
        if (ticketSelection is null)
        {
            return;
        }

        ticketSelection = null;
        catalog = [];
        quantities.Clear();
        SelectCategory(null);
        lblMovie.Text = lblShowtime.Text = lblRoom.Text = lblSeats.Text = string.Empty;
        lblTicketCount.Text = "Vé";
        lblTicketAmount.Text = AuditoriumSeat.FormatPrice(0);
        lblNotice.Visible = true;
        btnContinue.Enabled = false;
        UpdateOrderSummary();
    }

    private void SelectCategory(ConcessionCategory? category)
    {
        selectedCategory = category;
        foreach (var (buttonCategory, button) in categoryButtons)
        {
            bool active = buttonCategory == category;
            button.BackColor = active ? Accent : Color.White;
            button.ForeColor = active ? Color.White : Ink;
            button.FlatAppearance.BorderColor = active ? Accent : Color.FromArgb(203, 213, 225);
            button.FlatAppearance.MouseOverBackColor = active ? Color.FromArgb(29, 78, 216) : Color.FromArgb(239, 246, 255);
        }

        RebuildProducts(ProductColumnCount());
        pnlProductScroll.AutoScrollPosition = Point.Empty;
    }

    private int ProductColumnCount()
    {
        int width = pnlProductScroll.ClientSize.Width;
        return width >= LogicalToDeviceUnits(474) ? 3 : width >= LogicalToDeviceUnits(310) ? 2 : 1;
    }

    private int ProductRowHeight() => LogicalToDeviceUnits(
        pnlProductScroll.ClientSize.Height >= LogicalToDeviceUnits(500) ? 211 : 174);

    private void RebuildProducts(int columns)
    {
        productColumns = columns;
        productRowHeight = ProductRowHeight();
        var products = catalog
            .Where(product => selectedCategory is null || product.Category == selectedCategory)
            .ToArray();
        int rows = (products.Length + columns - 1) / columns;
        lblEmptyCatalog.Text = catalog.Count == 0 ? "Chưa có bắp nước và combo" : "Danh mục này chưa có sản phẩm";
        lblEmptyCatalog.Visible = rows == 0;
        gridProducts.Visible = rows > 0;

        gridProducts.SuspendLayout();
        try
        {
            while (gridProducts.Controls.Count > 0)
            {
                gridProducts.Controls[0].Dispose();
            }

            gridProducts.ColumnStyles.Clear();
            gridProducts.RowStyles.Clear();
            gridProducts.ColumnCount = columns;
            gridProducts.RowCount = rows;
            gridProducts.Height = rows * productRowHeight;
            for (int column = 0; column < columns; column++)
            {
                gridProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columns));
            }

            for (int row = 0; row < rows; row++)
            {
                gridProducts.RowStyles.Add(new RowStyle(SizeType.Absolute, productRowHeight));
            }

            for (int index = 0; index < products.Length; index++)
            {
                ConcessionProduct product = products[index];
                var card = new ConcessionProductCard(product);
                card.SetQuantity(quantities.GetValueOrDefault(product));
                card.StepRequested += delta => ChangeQuantity(product, card, delta);
                gridProducts.Controls.Add(card, index % columns, index / columns);
            }
        }
        finally
        {
            gridProducts.ResumeLayout(true);
        }
    }

    private void ChangeQuantity(ConcessionProduct product, ConcessionProductCard card, int delta)
    {
        int quantity = Math.Max(0, quantities.GetValueOrDefault(product) + delta);
        if (quantity == 0)
        {
            quantities.Remove(product);
        }
        else
        {
            quantities[product] = quantity;
        }

        card.SetQuantity(quantity);
        UpdateOrderSummary();
    }

    private void UpdateOrderSummary()
    {
        decimal total = ticketSelection?.TicketSubtotal ?? 0m;
        orderItems.SuspendLayout();
        try
        {
            while (orderItems.Controls.Count > 0)
            {
                orderItems.Controls[0].Dispose();
            }

            orderItems.RowStyles.Clear();
            orderItems.RowCount = quantities.Count;
            int row = 0;
            foreach (ConcessionProduct product in catalog)
            {
                if (!quantities.TryGetValue(product, out int quantity))
                {
                    continue;
                }

                decimal lineAmount = quantity * product.Price;
                total += lineAmount;
                orderItems.RowStyles.Add(new RowStyle(SizeType.Absolute, LogicalToDeviceUnits(28)));
                orderItems.Controls.Add(OrderLabel($"{product.Name} × {quantity}", ContentAlignment.MiddleLeft), 0, row);
                orderItems.Controls.Add(OrderLabel(AuditoriumSeat.FormatPrice(lineAmount), ContentAlignment.MiddleRight), 1, row);
                row++;
            }
        }
        finally
        {
            orderItems.ResumeLayout(true);
        }

        lblTotal.Text = AuditoriumSeat.FormatPrice(total);
        UpdateOrderItemsHeight();
    }

    private static Label OrderLabel(string text, ContentAlignment alignment) => new()
    {
        Text = text,
        TextAlign = alignment,
        Dock = DockStyle.Fill,
        Margin = Padding.Empty,
        AutoEllipsis = true,
        UseMnemonic = false
    };

    private void UpdateResponsiveLayout()
    {
        int summaryWidth = Math.Max(LogicalToDeviceUnits(272), (int)Math.Round(layoutWorkArea.Width * 0.38));
        layoutWorkArea.ColumnStyles[1].Width = summaryWidth;
        UpdateCatalogHeading(layoutWorkArea.Width - summaryWidth < LogicalToDeviceUnits(305));
        bool compact = layoutWorkArea.Height < LogicalToDeviceUnits(365);
        bool stack = summaryWidth < LogicalToDeviceUnits(310);
        int buttonHeight = compact ? 36 : 42;
        layoutButtons.SuspendLayout();
        if (stack)
        {
            layoutButtons.SetCellPosition(btnContinue, new TableLayoutPanelCellPosition(0, 1));
            layoutButtons.SetColumnSpan(btnBack, 2);
            layoutButtons.SetColumnSpan(btnContinue, 2);
            btnBack.Margin = new Padding(0, 0, 0, LogicalToDeviceUnits(5));
        }
        else
        {
            layoutButtons.SetColumnSpan(btnBack, 1);
            layoutButtons.SetColumnSpan(btnContinue, 1);
            layoutButtons.SetCellPosition(btnContinue, new TableLayoutPanelCellPosition(1, 0));
            btnBack.Margin = new Padding(0, 0, LogicalToDeviceUnits(6), 0);
        }

        layoutButtons.RowStyles[0].SizeType = stack ? SizeType.Percent : SizeType.Absolute;
        layoutButtons.RowStyles[0].Height = stack ? 50F : LogicalToDeviceUnits(buttonHeight);
        layoutButtons.RowStyles[1].Height = stack ? 50F : 0F;
        layoutSummary.RowStyles[0].Height = LogicalToDeviceUnits(compact ? 27 : 34);
        layoutSummary.RowStyles[1].Height = LogicalToDeviceUnits(compact ? 88 : 100);
        layoutSummary.RowStyles[2].Height = LogicalToDeviceUnits(compact ? 29 : 38);
        layoutSummary.RowStyles[4].Height = LogicalToDeviceUnits(compact ? 38 : 48);
        layoutSummary.RowStyles[7].Height = LogicalToDeviceUnits(stack ? 2 * buttonHeight : buttonHeight);
        layoutSummary.RowStyles[8].Height = LogicalToDeviceUnits(compact ? 26 : 31);
        layoutMovieDetails.RowStyles[0].Height = LogicalToDeviceUnits(compact ? 18 : 23);
        layoutMovieDetails.RowStyles[1].Height = LogicalToDeviceUnits(compact ? 16 : 19);
        layoutMovieDetails.RowStyles[2].Height = LogicalToDeviceUnits(compact ? 16 : 19);
        layoutButtons.ResumeLayout(true);
        UpdateOrderItemsHeight();
    }

    private void UpdateCatalogHeading(bool stacked)
    {
        layoutHeading.SuspendLayout();
        layoutHeading.SetCellPosition(lblCountdown, new TableLayoutPanelCellPosition(1, stacked ? 1 : 0));
        layoutHeading.SetColumnSpan(lblTitle, stacked ? 2 : 1);
        lblTitle.Font = stacked ? lblSummary.Font : catalogTitleFont;
        lblTitle.UseCompatibleTextRendering = stacked;
        lblTitle.Text = stacked ? catalogTitle.Replace("BẮP NƯỚC", "BẮP\nNƯỚC", StringComparison.Ordinal) : catalogTitle;
        lblCountdown.Margin = new Padding(0, LogicalToDeviceUnits(stacked ? 0 : 9), 0, LogicalToDeviceUnits(stacked ? 4 : 9));
        layoutHeading.RowStyles[0].Height = LogicalToDeviceUnits(stacked ? 44 : 48);
        layoutHeading.RowStyles[1].Height = LogicalToDeviceUnits(stacked ? 27 : 0);
        layoutCatalog.RowStyles[0].Height = LogicalToDeviceUnits(stacked ? 71 : 48);
        layoutHeading.ResumeLayout(true);
    }

    private void UpdateOrderItemsHeight()
    {
        int remaining = layoutSummary.ClientSize.Height - layoutSummary.Padding.Vertical;
        for (int index = 0; index < layoutSummary.RowStyles.Count; index++)
        {
            RowStyle row = layoutSummary.RowStyles[index];
            if (index != 3 && row.SizeType == SizeType.Absolute)
            {
                remaining -= (int)row.Height;
            }
        }

        layoutSummary.RowStyles[3].Height = Math.Min(quantities.Count * LogicalToDeviceUnits(28), Math.Max(0, remaining));
    }

    private void LayoutWorkArea_SizeChanged(object? sender, EventArgs e) => UpdateResponsiveLayout();

    private void PnlProductScroll_SizeChanged(object? sender, EventArgs e)
    {
        int columns = ProductColumnCount();
        if (ticketSelection is not null && (columns != productColumns || productRowHeight != ProductRowHeight()))
        {
            RebuildProducts(columns);
        }
    }

    private void BtnBack_Click(object? sender, EventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    private void BtnContinue_Click(object? sender, EventArgs e)
    {
        if (ticketSelection is { } selection)
        {
            var concessions = catalog
                .Where(quantities.ContainsKey)
                .Select(product => new PaymentOrderLine(product.Name, quantities[product], product.Price));
            ContinueRequested?.Invoke(new PaymentOrder(selection, concessions));
        }
    }
}

internal enum ConcessionCategory
{
    Combo,
    Popcorn,
    Drink,
    Snack
}

internal sealed record ConcessionProduct(string Name, string Description, decimal Price, ConcessionCategory Category);

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
