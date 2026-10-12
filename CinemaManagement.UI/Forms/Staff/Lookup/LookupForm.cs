#pragma warning disable CS8618
using System;
using System.Drawing;
using System.Windows.Forms;
using CinemaManagement.Common.Constants;
using CinemaManagement.UI.Navigation;
using CinemaManagement.UI.Helpers;
using CinemaManagement.UI.Session;
using CinemaManagement.UI.UserControls.Common;
using CinemaManagement.BLL.Services.Tickets;
using CinemaManagement.Common.DTOs.Tickets;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using CinemaManagement.UI.Theme;

using CinemaManagement.Common.Enums;

namespace CinemaManagement.UI.Forms.Staff.Lookup
{
    public partial class LookupForm : Form, IStaffPage
    {
        private readonly StaffHeaderControl _header = new() { ActivePage = StaffPage.Lookup };
        private readonly ITicketService? _ticketService;
        private CardPanel? _selectedRow;
        private TicketFilterMode _currentFilter = TicketFilterMode.All;

        public StaffPage NextPage { get; private set; } = StaffPage.Home;

        public LookupForm() : this(TicketFilterMode.All)
        {
        }

        public LookupForm(TicketFilterMode initialFilter)
        {
            PermissionGuard.EnsurePermission(PermissionConstants.CHECKIN);
            _ticketService = Program.Services?.GetService<ITicketService>();
            _currentFilter = initialFilter;
            
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            _header.NavigateRequested += (page) => { NextPage = page; this.Close(); };
            _header.LogoutRequested += () => { NextPage = StaffPage.SignOut; this.Close(); };

            SetupUI();

            this.Shown += async (s, e) =>
            {
                UpdateFilterButtons();
                if (_currentFilter != TicketFilterMode.All)
                {
                    await PerformSearch();
                }
            };
        }

        public async Task SwitchFilterAsync(TicketFilterMode mode)
        {
            _currentFilter = mode;
            UpdateFilterButtons();
            await PerformSearch();
        }

        private void UpdateFilterButtons()
        {
            if (_btnFilterTodaySales == null || _btnFilterTodayCheckIn == null || _btnFilterAll == null) return;
            SetFilterButtonStyle(_btnFilterTodaySales, _currentFilter == TicketFilterMode.TodaySales, AppColors.Primary);
            SetFilterButtonStyle(_btnFilterTodayCheckIn, _currentFilter == TicketFilterMode.TodayCheckIn, AppColors.Success);
            SetFilterButtonStyle(_btnFilterAll, _currentFilter == TicketFilterMode.All, AppColors.Surface2, AppColors.TextPrimary);
        }

        private static void SetFilterButtonStyle(PillButton btn, bool isActive, Color activeColor, Color? activeText = null)
        {
            if (isActive)
            {
                btn.NormalColor = activeColor;
                btn.ForeColor = activeText ?? Color.White;
                btn.BorderColor = Color.Empty;
                btn.GhostStyle = false;
            }
            else
            {
                btn.NormalColor = Color.FromArgb(242, 242, 245);
                btn.ForeColor = AppColors.TextDark;
                btn.BorderColor = Color.FromArgb(215, 215, 220);
                btn.GhostStyle = false;
            }
            btn.Invalidate();
        }

        private async Task PerformSearch()
        {
            if (_ticketService == null) return;
            string query = _txtSearch.Text.Trim();

            // Nếu đang ở chế độ xem Tất cả mà chưa nhập thông tin tìm kiếm thì không quét toàn bộ DB
            if (_currentFilter == TicketFilterMode.All && string.IsNullOrEmpty(query))
            {
                _pnlResults.Visible = false;
                _pnlDetails.Visible = false;
                return;
            }

            _btnSearch.Text = "⏳ ĐANG TÌM...";
            _btnSearch.Enabled = false;

            try
            {
                var result = await _ticketService.GetTicketsAsync(_currentFilter, query);
                
                _flpResultItems.Controls.Clear();
                _pnlDetails.Visible = false;

                if (result.IsSuccess && result.Data != null && result.Data.Count > 0)
                {
                    string filterTag = _currentFilter switch
                    {
                        TicketFilterMode.TodaySales => "vé bán hôm nay",
                        TicketFilterMode.TodayCheckIn => "vé đã check-in hôm nay",
                        _ => "bản ghi khớp"
                    };
                    _lblResultsTag.Text = $"{result.Data.Count} {filterTag}";
                    _lblResultsTag.Visible = true;
                    foreach (var dto in result.Data)
                    {
                        var row = CreateResultRow(dto);
                        _flpResultItems.Controls.Add(row);
                    }
                    _pnlResults.Visible = true;
                }
                else
                {
                    _lblResultsTag.Text = "0 bản ghi";
                    _lblResultsTag.Visible = true;
                    _pnlResults.Visible = true;
                    string emptyMsg = _currentFilter switch
                    {
                        TicketFilterMode.TodaySales => "Hôm nay chưa có vé nào được bán.",
                        TicketFilterMode.TodayCheckIn => "Hôm nay chưa có vé nào được check-in.",
                        _ => "Không tìm thấy kết quả nào phù hợp."
                    };
                    var lblNoData = new Label { Text = emptyMsg, ForeColor = AppColors.TextMuted, AutoSize = true, Margin = new Padding(20) };
                    _flpResultItems.Controls.Add(lblNoData);
                }
            }
            finally
            {
                _btnSearch.Text = "🔍 TÌM KIẾM";
                _btnSearch.Enabled = true;
            }
        }

        private void SelectRow(CardPanel row, TicketDetailDto dto)
        {
            if (_selectedRow != null)
            {
                _selectedRow.BorderColor = Color.FromArgb(220, 220, 220); // default border
                _selectedRow.Refresh();
            }

            _selectedRow = row;
            _selectedRow.BorderColor = AppColors.Primary;
            _selectedRow.Refresh();

            // Fill Details
            _lblBarcode.Text = $"MÃ BARCODE: {dto.Barcode}";
            
            _lblDetailCusName.Text = dto.KhachHangTen;
            _lblDetailCusPhone.Text = $"SĐT: {dto.KhachHangSdt} • Thẻ tích lũy: {dto.DiemTichLuy} điểm";
            _lblDetailStaff.Text = $"NV Bán vé: {dto.NvBanVe}";
            
            _lblDetailMovieName.Text = $"{dto.MovieName} ({dto.Genre})";
            _lblDetailMovieSpec.Text = $"Thời lượng: {dto.ThoiLuong} phút • Định dạng {dto.Format}";
            _lblDetailRoomSpec.Text = $"Phòng chiếu {dto.RoomName} • {dto.ManChieu}";

            _lblDetailFbName.Text = dto.Combos.Count > 0 ? string.Join("\n", dto.Combos) : "Không có";
            _lblDetailFbStatus.Text = $"Trạng thái F&&B: {dto.TrangThaiFb}";
            _lblDetailFbPrice.Text = $"Hóa đơn kèm: {dto.InvoiceCode} ({dto.ComboTotal:N0}đ)";

            _pnlDetails.Visible = true;
            _mainScroll.ScrollControlIntoView(_pnlDetails);
        }
    }
}
