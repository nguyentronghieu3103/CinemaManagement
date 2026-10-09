using CinemaManagement.UI.Theme;
using CinemaManagement.Common.DTOs.Tickets;

namespace CinemaManagement.UI.Forms.Staff.Lookup
{
    public partial class LookupForm
    {
        private TableLayoutPanel _mainScroll;
        private TextBox _txtSearch;
        private PillButton _btnSearch;
        
        private Panel _pnlTop;
        private CardPanel _pnlSearchCard;
        private Panel _pnlResults;
        private FlowLayoutPanel _flpResultItems;
        private Label _lblResultsTag;
        
        private Panel _pnlDetails;
        private Label _lblDetailCusName;
        private Label _lblDetailCusPhone;
        private Label _lblDetailStaff;
        
        private Label _lblDetailMovieName;
        private Label _lblDetailMovieSpec;
        private Label _lblDetailRoomSpec;
        
        private Label _lblDetailFbName;
        private Label _lblDetailFbStatus;
        private Label _lblDetailFbPrice;
        
        private Label _lblBarcode;

        private void SetupUI()
        {
            this.Controls.Clear();
            this.Controls.Add(_header);
            _header.Dock = DockStyle.Top;

            this.BackColor = AppColors.PageBackground;
            this.Font = new Font("Segoe UI", 10F);

            _mainScroll = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(40)
            };
            _mainScroll.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            _mainScroll.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            _mainScroll.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            _mainScroll.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            _mainScroll.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            
            this.Controls.Add(_mainScroll);
            _mainScroll.BringToFront();

            BuildSearchSection();
            BuildResultsSection();
            BuildDetailsSection();
            
            _mainScroll.Controls.Add(_pnlTop, 0, 0);
            _mainScroll.Controls.Add(_pnlSearchCard, 0, 1);
            _mainScroll.Controls.Add(_pnlResults, 0, 2);
            _mainScroll.Controls.Add(_pnlDetails, 0, 3);
        }

        private void BuildSearchSection()
        {
            // Title Header
            _pnlTop = new Panel { Dock = DockStyle.Fill, Height = 60, Margin = new Padding(0) };
            
            var lblTitle = new Label
            {
                Text = "TRA CỨU VÉ",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                AutoSize = true,
                Location = new Point(0, 10)
            };
            _pnlTop.Controls.Add(lblTitle);

            var pnlSupport = new Panel
            {
                BackColor = Color.FromArgb(20, AppColors.Primary),
                Size = new Size(400, 40),
                Location = new Point(_pnlTop.Width - 400, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            UiKit.DoubleBuffer(pnlSupport);
            pnlSupport.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var r = new Rectangle(0, 0, pnlSupport.Width - 1, pnlSupport.Height - 1);
                using var path = UiKit.RoundRect(r, 8);
                using var brush = new SolidBrush(pnlSupport.BackColor);
                e.Graphics.FillPath(brush, path);
                
                // Draw Icon (Info)
                e.Graphics.DrawString("ℹ", new Font("Segoe UI", 12F, FontStyle.Bold), new SolidBrush(AppColors.Primary), new PointF(10, 8));
                e.Graphics.DrawString("Hỗ trợ tra cứu tức thì qua Mã Barcode, SĐT hội viên hoặc Số hóa đơn", 
                    new Font("Segoe UI", 9F), new SolidBrush(AppColors.TextDark), new PointF(30, 10));
            };
            _pnlTop.Controls.Add(pnlSupport);
            
            // Search Box Card
            _pnlSearchCard = new CardPanel
            {
                Dock = DockStyle.Fill,
                Height = 150,
                Padding = new Padding(20),
                Margin = new Padding(0, 20, 0, 20)
            };
            
            var lblSearchPrompt = new Label
            {
                Text = "Mã vé / Mã hóa đơn / Số điện thoại",
                Font = new Font("Segoe UI", 10F),
                ForeColor = AppColors.TextMuted,
                AutoSize = true,
                Location = new Point(20, 20)
            };
            _pnlSearchCard.Controls.Add(lblSearchPrompt);

            // Input wrapper
            var pnlInput = new Panel
            {
                BackColor = Color.FromArgb(250, 245, 245),
                Location = new Point(20, 50),
                Size = new Size(_pnlSearchCard.Width - 250, 45),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            pnlInput.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var r = new Rectangle(0, 0, pnlInput.Width - 1, pnlInput.Height - 1);
                using var path = UiKit.RoundRect(r, 8);
                using var brush = new SolidBrush(pnlInput.BackColor);
                e.Graphics.FillPath(brush, path);
                using var pen = new Pen(Color.FromArgb(230, 220, 220));
                e.Graphics.DrawPath(pen, path);
            };

            _txtSearch = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(250, 245, 245),
                Font = new Font("Segoe UI", 12F),
                Location = new Point(40, 12),
                Width = pnlInput.Width - 80,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                PlaceholderText = "Nhập thông tin...",
                AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = AutoCompleteSource.CustomSource
            };
            
            // Dummy suggestions
            var suggestions = new AutoCompleteStringCollection();
            suggestions.AddRange(new string[] { "VE000325", "0908 123 456", "HD-2026-9082", "VE000400", "0987654321" });
            _txtSearch.AutoCompleteCustomSource = suggestions;

            _txtSearch.KeyDown += async (s, e) => { if (e.KeyCode == Keys.Enter) await PerformSearch(); };
            pnlInput.Controls.Add(_txtSearch);
            _pnlSearchCard.Controls.Add(pnlInput);

            _btnSearch = new PillButton
            {
                Text = "🔍 TÌM KIẾM",
                NormalColor = AppColors.Primary,
                HoverColor = UiKit.Blend(AppColors.Primary, Color.White, 0.2f),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(_pnlSearchCard.Width - 210, 50),
                Size = new Size(180, 45),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Radius = 8
            };
            _btnSearch.Click += async (s, e) => await PerformSearch();
            _pnlSearchCard.Controls.Add(_btnSearch);

            // Quick tips
            var lblTips = new Label
            {
                Text = "Gợi ý tìm nhanh:",
                Font = new Font("Segoe UI", 9F),
                ForeColor = AppColors.TextMuted,
                AutoSize = true,
                Location = new Point(20, 110)
            };
            _pnlSearchCard.Controls.Add(lblTips);
            
            int tipX = 130;
            string[] tips = { "VE000325", "0908 123 456", "HD-2026-9082" };
            foreach (var t in tips)
            {
                var btn = new PillButton
                {
                    Text = t,
                    GhostStyle = true,
                    NormalColor = Color.FromArgb(240, 240, 240),
                    ForeColor = AppColors.TextDark,
                    Font = new Font("Segoe UI", 9F),
                    Location = new Point(tipX, 105),
                    Size = new Size(100, 30),
                    Radius = 15
                };
                btn.Click += (s, e) => { _txtSearch.Text = t; _btnSearch.PerformClick(); };
                _pnlSearchCard.Controls.Add(btn);
                tipX += 110;
            }
        }

        private void BuildResultsSection()
        {
            _pnlResults = new Panel { Dock = DockStyle.Fill, AutoSize = true, Visible = false, Margin = new Padding(0) };
            
            var pnlHeader = new Panel { Dock = DockStyle.Top, Height = 40 };
            
            var lblTitle = new Label
            {
                Text = "KẾT QUẢ TRA CỨU",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = AppColors.TextDark,
                AutoSize = true,
                Location = new Point(0, 10)
            };
            pnlHeader.Controls.Add(lblTitle);

            _lblResultsTag = new Label
            {
                Text = "0 bản ghi khớp",
                BackColor = Color.FromArgb(250, 230, 210),
                ForeColor = AppColors.Primary,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(170, 12),
                Padding = new Padding(5)
            };
            pnlHeader.Controls.Add(_lblResultsTag);

            var lblHint = new Label
            {
                Text = "Nhấp vào hàng để xem và tương tác",
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = AppColors.TextMuted,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            pnlHeader.Controls.Add(lblHint);
            
            pnlHeader.Resize += (s, e) => lblHint.Left = pnlHeader.Width - lblHint.Width;

            _pnlResults.Controls.Add(pnlHeader);

            // Columns Header
            var pnlCols = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.FromArgb(250, 245, 245) };
            string[] cols = { "MÃ VÉ", "PHIM", "SUẤT CHIẾU", "GHẾ", "THANH TOÁN", "CHECK-IN" };
            int[] colX = { 20, 200, 400, 570, 700, 850 };
            
            for (int i = 0; i < cols.Length; i++)
            {
                pnlCols.Controls.Add(new Label
                {
                    Text = cols[i],
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = AppColors.TextMuted,
                    AutoSize = true,
                    Location = new Point(colX[i], 12)
                });
            }
            _pnlResults.Controls.Add(pnlCols);

            _flpResultItems = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(0, 10, 0, 10)
            };
            _pnlResults.Controls.Add(_flpResultItems);
        }

        private void BuildDetailsSection()
        {
            _pnlDetails = new Panel { Dock = DockStyle.Fill, AutoSize = true, Visible = false, Padding = new Padding(0, 20, 0, 0), Margin = new Padding(0) };

            var pnlActions = new Panel { Dock = DockStyle.Top, Height = 60 };
            
            // Highlight bar
            var lblHighlight = new Label
            {
                Text = "● Hàng được tô sáng là vé đang được chọn để thao tác nghiệp vụ",
                ForeColor = AppColors.Primary,
                Font = new Font("Segoe UI", 9F),
                AutoSize = true,
                Location = new Point(0, 10)
            };
            pnlActions.Controls.Add(lblHighlight);

            var btnCancel = new PillButton { Text = "⊗ HỦY VÉ", NormalColor = Color.FromArgb(255, 220, 220), ForeColor = Color.Maroon, Location = new Point(pnlActions.Width - 120, 0), Size = new Size(100, 40), Anchor = AnchorStyles.Top | AnchorStyles.Right, Radius = 6 };
            var btnPrint = new PillButton { Text = "🖨 IN LẠI", NormalColor = Color.FromArgb(160, 60, 60), ForeColor = Color.White, Location = new Point(pnlActions.Width - 230, 0), Size = new Size(100, 40), Anchor = AnchorStyles.Top | AnchorStyles.Right, Radius = 6 };
            var btnView = new PillButton { Text = "👁 XEM CHI TIẾT", NormalColor = Color.White, ForeColor = AppColors.TextDark, Location = new Point(pnlActions.Width - 370, 0), Size = new Size(130, 40), Anchor = AnchorStyles.Top | AnchorStyles.Right, Radius = 6 };
            
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Controls.Add(btnPrint);
            pnlActions.Controls.Add(btnView);
            
            _pnlDetails.Controls.Add(pnlActions);

            var pnlDetailCard = new CardPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(20), Margin = new Padding(0, 20, 0, 20) };
            
            var lblTitle = new Label { Text = "🧾 THÔNG TIN CHI TIẾT VÉ ĐANG CHỌN", Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = AppColors.TextDark, AutoSize = true, Location = new Point(20, 20) };
            _lblBarcode = new Label { Text = "MÃ BARCODE: -", BackColor = Color.FromArgb(250, 240, 240), Font = new Font("Segoe UI", 9F), ForeColor = AppColors.TextDark, AutoSize = true, Location = new Point(pnlDetailCard.Width - 250, 20), Anchor = AnchorStyles.Top | AnchorStyles.Right, Padding = new Padding(5) };
            
            pnlDetailCard.Controls.Add(lblTitle);
            pnlDetailCard.Controls.Add(_lblBarcode);

            var tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 3,
                RowCount = 1,
                Padding = new Padding(0, 60, 0, 0)
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            
            tlp.Controls.Add(CreateDetailBox("KHÁCH HÀNG & THANH TOÁN", out _lblDetailCusName, out _lblDetailCusPhone, out _lblDetailStaff), 0, 0);
            tlp.Controls.Add(CreateDetailBox("THÔNG SỐ KỸ THUẬT CHIẾU", out _lblDetailMovieName, out _lblDetailMovieSpec, out _lblDetailRoomSpec), 1, 0);
            tlp.Controls.Add(CreateDetailBox("DỊCH VỤ ĐI KÈM (F&B)", out _lblDetailFbName, out _lblDetailFbStatus, out _lblDetailFbPrice), 2, 0);
            
            pnlDetailCard.Controls.Add(tlp);
            _pnlDetails.Controls.Add(pnlDetailCard);
        }

        private Panel CreateDetailBox(string title, out Label line1, out Label line2, out Label line3)
        {
            var pnl = new Panel { Dock = DockStyle.Fill, Margin = new Padding(10), BackColor = Color.FromArgb(250, 245, 245), Height = 120 };
            pnl.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var r = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
                using var path = UiKit.RoundRect(r, 8);
                using var brush = new SolidBrush(pnl.BackColor);
                e.Graphics.FillPath(brush, path);
            };

            var lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 8F, FontStyle.Bold), ForeColor = AppColors.TextMuted, AutoSize = true, Location = new Point(15, 15) };
            line1 = new Label { Text = "-", Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = AppColors.TextDark, AutoSize = true, Location = new Point(15, 40) };
            line2 = new Label { Text = "-", Font = new Font("Segoe UI", 9F), ForeColor = AppColors.TextDark, AutoSize = true, Location = new Point(15, 65) };
            line3 = new Label { Text = "-", Font = new Font("Segoe UI", 9F), ForeColor = AppColors.TextMuted, AutoSize = true, Location = new Point(15, 85) };
            
            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(line1);
            pnl.Controls.Add(line2);
            pnl.Controls.Add(line3);
            
            return pnl;
        }

        private CardPanel CreateResultRow(TicketDetailDto dto)
        {
            var row = new CardPanel
            {
                Size = new Size(_flpResultItems.Width - 20, 80),
                Margin = new Padding(10, 5, 10, 5),
                Cursor = Cursors.Hand
            };
            
            row.Click += (s, e) => SelectRow(row, dto);

            int[] colX = { 20, 200, 400, 570, 700, 850 };

            // Col 1: Mã vé
            row.Controls.Add(new Label { Text = "🎟 " + dto.RepresentativeTicketCode, Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = AppColors.Primary, AutoSize = true, Location = new Point(colX[0], 20) });
            row.Controls.Add(new Label { Text = "Mã HĐ: " + dto.InvoiceCode, Font = new Font("Segoe UI", 9F), ForeColor = AppColors.TextMuted, AutoSize = true, Location = new Point(colX[0], 45) });

            // Col 2: Phim
            row.Controls.Add(new Label { Text = dto.MovieName, Font = new Font("Segoe UI", 11F), ForeColor = AppColors.TextDark, AutoSize = true, Location = new Point(colX[1], 20) });
            row.Controls.Add(new Label { Text = $"{dto.Genre} • {dto.Format}", Font = new Font("Segoe UI", 9F), ForeColor = AppColors.TextMuted, AutoSize = true, Location = new Point(colX[1], 45) });

            // Col 3: Suất chiếu
            row.Controls.Add(new Label { Text = $"🕒 {dto.GioBatDau:hh\\:mm}", Font = new Font("Segoe UI", 11F), ForeColor = AppColors.TextDark, AutoSize = true, Location = new Point(colX[2], 20) });
            row.Controls.Add(new Label { Text = $"{dto.NgayChieu:dd/MM/yyyy} • {dto.RoomName}", Font = new Font("Segoe UI", 9F), ForeColor = AppColors.TextMuted, AutoSize = true, Location = new Point(colX[2], 45) });

            // Col 4: Ghế
            row.Controls.Add(new Label { Text = dto.Seats, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.Maroon, AutoSize = true, Location = new Point(colX[3], 20) });
            row.Controls.Add(new Label { Text = dto.SeatType, Font = new Font("Segoe UI", 9F), ForeColor = AppColors.TextMuted, AutoSize = true, Location = new Point(colX[3], 45) });

            // Col 5: Thanh toán
            row.Controls.Add(new Label { Text = $"✔ {dto.TrangThaiThanhToan}", Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = dto.TrangThaiThanhToan == "ĐÃ TT" ? Color.Green : Color.Orange, AutoSize = true, Location = new Point(colX[4], 15) });
            row.Controls.Add(new Label { Text = $"{dto.TongTien:N0}đ\n{dto.PhuongThucThanhToan}", Font = new Font("Segoe UI", 9F), ForeColor = AppColors.TextMuted, AutoSize = true, Location = new Point(colX[4], 35) });

            // Col 6: Check-in
            row.Controls.Add(new Label { Text = dto.TrangThaiCheckIn, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.White, BackColor = dto.TrangThaiCheckIn == "ĐÃ CHECK-IN" ? Color.Maroon : Color.Gray, AutoSize = true, Location = new Point(colX[5], 20), Padding = new Padding(5) });
            if (!string.IsNullOrEmpty(dto.CheckInTimeStr))
                row.Controls.Add(new Label { Text = dto.CheckInTimeStr, Font = new Font("Segoe UI", 9F), ForeColor = AppColors.TextMuted, AutoSize = true, Location = new Point(colX[5], 50) });

            // Assign click event to all children to bubble up
            foreach (Control c in row.Controls)
                c.Click += (s, e) => SelectRow(row, dto);

            return row;
        }
    }
}
