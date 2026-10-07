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

namespace CinemaManagement.UI.Forms.Staff.Lookup
{
    public partial class LookupForm : Form, IStaffPage
    {
        private readonly StaffHeaderControl _header = new() { ActivePage = StaffPage.Lookup };
        private readonly ITicketService? _ticketService;
        private CardPanel? _selectedRow;

        public StaffPage NextPage { get; private set; } = StaffPage.Home;

        public LookupForm()
        {
            PermissionGuard.EnsurePermission(PermissionConstants.CHECKIN);
            _ticketService = Program.Services?.GetService<ITicketService>();
            
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            _header.NavigateRequested += (page) => { NextPage = page; this.Close(); };
            _header.LogoutRequested += () => { NextPage = StaffPage.SignOut; this.Close(); };

            SetupUI();
        }

        private async Task PerformSearch()
        {
            if (_ticketService == null) return;
            string query = _txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(query)) return;

            _btnSearch.Text = "⏳ ĐANG TÌM...";
            _btnSearch.Enabled = false;

            try
            {
                var result = await _ticketService.SearchTicketsAsync(query);
                
                _flpResultItems.Controls.Clear();
                _pnlDetails.Visible = false;

                if (result.IsSuccess && result.Data != null && result.Data.Count > 0)
                {
                    _lblResultsTag.Text = $"{result.Data.Count} bản ghi khớp";
                    foreach (var dto in result.Data)
                    {
                        var row = CreateResultRow(dto);
                        _flpResultItems.Controls.Add(row);
                    }
                    _pnlResults.Visible = true;
                }
                else
                {
                    _lblResultsTag.Text = "0 bản ghi khớp";
                    _pnlResults.Visible = true;
                    var lblNoData = new Label { Text = "Không tìm thấy kết quả nào phù hợp.", ForeColor = AppColors.TextMuted, AutoSize = true, Margin = new Padding(20) };
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
                _selectedRow.BorderColor = Color.FromArgb(230, 220, 220); // default border
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
