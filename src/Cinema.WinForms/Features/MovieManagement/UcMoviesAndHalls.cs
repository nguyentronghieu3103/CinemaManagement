using System;
using System.Windows.Forms;
using Cinema.WinForms.Features.AuditoriumManagement;
using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.MovieManagement
{
    public partial class UcMoviesAndHalls : UserControl
    {
        public UcMoviesAndHalls()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            dtpDate.Value = new DateTime(2026, 11, 18);

            UiTheme.StyleGrid(gridMovies);

            gridMovies.Rows.Add("M01", "Anh Trai V\u01B0\u1EE3t Ng\u00E0n S\u00F3ng Gi\u00F3", "148 ph\u00FAt", "Ca nh\u1EA1c / Th\u1EF1c t\u1EBF", "P", "01/11/2026 \u2794 30/11/2026", "\u0110ang chi\u1EBFu");
            gridMovies.Rows.Add("M02", "Dune: Part Two", "166 ph\u00FAt", "Khoa h\u1ECDc vi\u1EC5n t\u01B0\u1EDFng", "T13", "15/10/2026 \u2794 20/11/2026", "\u0110ang chi\u1EBFu");

            btnHall1.Click += (_, __) => new SeatMapModal("Ph\u00F2ng 01 (2D Digital)").ShowDialog(FindForm());
            btnHall2.Click += (_, __) => new SeatMapModal("Ph\u00F2ng 02 (3D Digital)").ShowDialog(FindForm());
            btnHall3.Click += (_, __) => new SeatMapModal("Ph\u00F2ng 03 (2D Digital)").ShowDialog(FindForm());
            btnHall4.Click += (_, __) => new SeatMapModal("Ph\u00F2ng 04 (2D Digital)").ShowDialog(FindForm());
        }
    }
}
