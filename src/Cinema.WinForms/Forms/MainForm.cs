using System;
using System.Drawing;
using System.Windows.Forms;
using Cinema.WinForms.Features.Inventory;
using Cinema.WinForms.Features.Members;
using Cinema.WinForms.Features.MovieManagement;
using Cinema.WinForms.Features.Refunds;
using Cinema.WinForms.Features.Reports;
using Cinema.WinForms.Features.Shifts;
using Cinema.WinForms.Features.ShowtimeManagement;

namespace Cinema.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private Button? activeMenuBtn;
        private Button[] menuButtons = Array.Empty<Button>();

        public MainForm()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            menuButtons = new[] { btnMenu1, btnMenu2, btnMenu3, btnMenu4, btnMenu5, btnMenu6 };
            for (int i = 0; i < menuButtons.Length; i++)
            {
                int idx = i;
                menuButtons[i].Click += (_, __) => MenuClick(idx);
            }

            topbar.Paint += (_, e) => e.Graphics.DrawLine(new Pen(Color.FromArgb(226, 232, 240)), 0, topbar.Height - 1, topbar.Width, topbar.Height - 1);
            topbar.Resize += (_, __) => { lblBell.Left = topbar.Width - 70; lblBadge.Left = topbar.Width - 48; };
            lblBell.Click += (_, __) => OpenApprovalQueue();
            lblBadge.Click += (_, __) => OpenApprovalQueue();
            lblStatusTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Z-order fix: in WinForms, higher index (back) docks first, index 0 (front) docks last.
            // Edge controls must dock first; Fill must dock last to occupy remaining space.
            statusStrip.Dock = DockStyle.Bottom;
            sidebar.Dock = DockStyle.Left;
            topbar.Dock = DockStyle.Top;
            contentHost.Dock = DockStyle.Fill;
            Controls.SetChildIndex(sidebar, 3);      // dock first
            Controls.SetChildIndex(topbar, 2);       // dock second
            Controls.SetChildIndex(statusStrip, 1);  // dock third
            Controls.SetChildIndex(contentHost, 0);  // Fill docks last (front)

            ShowView(new UcDashboard(), btnMenu1);
        }

        private void MenuClick(int index)
        {
            UserControl view = index switch
            {
                0 => new UcDashboard(),
                1 => new UcMoviesAndHalls(),
                2 => new UcScheduleCoordinator(),
                3 => new UcFnBConcession(),
                4 => new UcShiftApproval(),
                5 => new UcCustomerLoyalty(),
                _ => new UcDashboard()
            };
            ShowView(view, menuButtons[index]);
        }

        private void ShowView(UserControl view, Button menuBtn)
        {
            contentHost.Controls.Clear();
            view.Dock = DockStyle.Fill;
            contentHost.Controls.Add(view);

            if (activeMenuBtn != null)
            {
                activeMenuBtn.BackColor = Color.FromArgb(30, 41, 59);
                activeMenuBtn.ForeColor = Color.FromArgb(203, 213, 225);
                activeMenuBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }

            activeMenuBtn = menuBtn;
            activeMenuBtn.BackColor = Color.FromArgb(51, 65, 85);
            activeMenuBtn.ForeColor = Color.White;
            activeMenuBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            activeIndicator.Visible = true;
            activeIndicator.Location = new Point(0, menuBtn.Top + menuPanel.Top);
            activeIndicator.BringToFront();
        }

        private void OpenApprovalQueue()
        {
            using var f = new FrmApprovalQueue();
            f.ShowDialog(this);
        }
    }
}