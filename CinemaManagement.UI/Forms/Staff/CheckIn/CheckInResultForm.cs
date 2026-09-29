using CinemaManagement.Common.DTOs.Tickets;
using CinemaManagement.UI.Theme;

namespace CinemaManagement.UI.Forms.Staff.CheckIn
{
    public partial class CheckInResultForm : Form
    {
        public CheckInResultForm(CheckInTicketDto ticket)
        {
            InitializeComponent();
            BackColor = Color.White;

            btnConfirm.DialogResult = DialogResult.OK;       // OK = nhân viên muốn check-in
            btnClose.DialogResult = DialogResult.Cancel;     // Esc cũng đóng popup
            CancelButton = btnClose;
            AcceptButton = ticket.CoTheCheckIn ? btnConfirm : btnClose;   // Enter = nút chính

            StyleButton(btnConfirm, AppColors.HeaderBackground, Color.White);
            StyleButton(btnClose, AppColors.InputBackground, AppColors.TextDark);

            Bind(ticket);
        }
        private void Bind(CheckInTicketDto t)
        {
            lblTicketCode.Text = t.MaVe;
            lblMovie.Text = t.TenPhim;
            lblRoom.Text = t.TenPhong;
            lblShowtime.Text = $"{t.GioBatDau.ToString(@"hh\:mm")} • {t.NgayChieu:dd/MM/yyyy}";
            lblSeat.Text = t.ViTriGhe;
            lblSameInvoice.Text = $"Cùng hóa đơn: {t.SoVeDaCheckInCungHoaDon}/{t.TongVeCungHoaDon} vé đã check-in";

            if (t.CoTheCheckIn)
            {
                lblBanner.Text = "Vé hợp lệ";
                lblBanner.BackColor = AppColors.SuccessSoft;
                lblBanner.ForeColor = AppColors.Success;
            }
            else
            {
                lblBanner.Text = t.LyDoTuChoi;
                lblBanner.BackColor = AppColors.DangerSoft;
                lblBanner.ForeColor = AppColors.StatusRed;
                btnConfirm.Visible = false;       // vé không hợp lệ thì không có nút xác nhận
            }
        }
        private static void StyleButton(Button b, Color back, Color fore)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = back;
            b.ForeColor = fore;
            b.Cursor = Cursors.Hand;
        }
    }
}
