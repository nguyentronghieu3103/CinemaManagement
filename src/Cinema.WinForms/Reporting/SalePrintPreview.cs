using System.Drawing.Printing;
using Cinema.WinForms.Controls;
using Cinema.WinForms.Features.TicketSales;

namespace Cinema.WinForms.Reporting;

internal static class SalePrintPreview
{
    internal static void ShowTickets(IWin32Window owner, CompletedSale sale)
    {
        ShowtimeSelectedEventArgs selection = sale.Order.Selection.Showtime;
        ShowtimeOption showtime = selection.Showtime;
        string[][] pages = sale.Tickets.Select(ticket => new[]
        {
            "VÉ XEM PHIM",
            selection.MovieTitle,
            $"{showtime.StartsAt:dd/MM/yyyy HH:mm} · {SeatSelectionContext.RoomCaption(showtime.Room)}",
            $"Ghế {ticket.Seat.Code} · {ticket.Seat.TypeName}",
            $"Giá vé: {AuditoriumSeat.FormatPrice(ticket.Seat.Price)}",
            $"Mã vé: {ticket.Code}",
            "QR minh họa"
        }).ToArray();

        Show(owner, $"Đã chọn {pages.Length} vé để in", pages);
    }

    internal static void ShowInvoice(IWin32Window owner, CompletedSale sale)
    {
        string[] lines =
        [
            "HÓA ĐƠN BÁN HÀNG",
            $"Mã hóa đơn: {sale.InvoiceCode}",
            $"Thời gian: {sale.PaidAt:dd/MM/yyyy HH:mm}",
            $"Nhân viên: {sale.OperatorName}",
            $"Quầy: {sale.TerminalName}",
            "",
            .. sale.Order.Lines.Select(line =>
                $"{line.Description} × {line.Quantity}     {AuditoriumSeat.FormatPrice(line.Amount)}"),
            "",
            $"Tổng thanh toán: {AuditoriumSeat.FormatPrice(sale.Order.Total)}",
            .. sale.GetPaymentDetails()
        ];

        Show(owner, $"Đã chọn hóa đơn {sale.InvoiceCode} để in", [lines]);
    }

    private static void Show(IWin32Window owner, string summary, IReadOnlyList<string[]> pages)
    {
        const string title = "Xem trước bản in (demo)";
        using var document = new PrintDocument { DocumentName = title };
        if (!document.PrinterSettings.IsValid)
        {
            MessageBox.Show(owner, $"{summary}.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var headingFont = new Font("Segoe UI", 16F, FontStyle.Bold);
        using var bodyFont = new Font("Segoe UI", 11F);
        int pageIndex = 0;
        int lineIndex = 0;

        document.BeginPrint += (_, e) =>
        {
            // The preview toolbar also exposes a print command. Cancel every request to a printer.
            e.Cancel = e.PrintAction != PrintAction.PrintToPreview;
            pageIndex = lineIndex = 0;
        };

        document.PrintPage += (_, e) =>
        {
            if (e.Graphics is not { } graphics)
            {
                return;
            }

            Rectangle bounds = e.MarginBounds;
            float top = bounds.Top;
            graphics.DrawString("STORYLINE", headingFont, Brushes.Black, bounds.Left, top);
            top += headingFont.GetHeight(graphics) + 10;
            graphics.DrawString(title, bodyFont, Brushes.DimGray, bounds.Left, top);
            top += bodyFont.GetHeight(graphics) + 14;
            float bodyTop = top;
            string[] page = pages[pageIndex];
            while (lineIndex < page.Length)
            {
                string line = page[lineIndex];
                Font font = lineIndex == 0 ? headingFont : bodyFont;
                float height = Math.Max(font.GetHeight(graphics),
                    graphics.MeasureString(line, font, bounds.Width).Height) + 5;
                if (top > bodyTop && top + height > bounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                graphics.DrawString(line, font, Brushes.Black, new RectangleF(bounds.Left, top, bounds.Width, height));
                top += height;
                lineIndex++;
            }

            lineIndex = 0;
            e.HasMorePages = ++pageIndex < pages.Count;
        };

        using var preview = new PrintPreviewDialog
        {
            Document = document,
            Text = $"{title} · {summary}",
            StartPosition = FormStartPosition.CenterParent,
            ClientSize = new Size(800, 650),
            UseAntiAlias = true
        };
        preview.ShowDialog(owner);
    }
}
