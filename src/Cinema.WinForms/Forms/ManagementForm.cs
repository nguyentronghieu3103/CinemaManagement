using System;
using System.Drawing;
using System.Windows.Forms;
using Cinema.WinForms.Controls;
using Cinema.WinForms.Features.Inventory;
using Cinema.WinForms.Features.Members;
using Cinema.WinForms.Features.MovieManagement;
using Cinema.WinForms.Features.Refunds;
using Cinema.WinForms.Features.Reports;
using Cinema.WinForms.Features.Shifts;
using Cinema.WinForms.Features.ShowtimeManagement;

namespace Cinema.WinForms.Forms
{
    public partial class ManagementForm : Form
    {
        private Button? activeMenuBtn;
        private Button[] menuButtons = Array.Empty<Button>();

        public ManagementForm()
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
                menuButtons[i].Paint += PaintActiveMenuStripe;
            }

            topbar.Paint += (_, e) =>
            {
                using var border = new Pen(UiTheme.Border);
                e.Graphics.DrawLine(border, 0, topbar.ClientSize.Height - 1, topbar.ClientSize.Width, topbar.ClientSize.Height - 1);
            };
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
            if (contentHost.Controls.Count > 0)
            {
                contentHost.Controls[0].Dispose();
            }

            view.Dock = DockStyle.Fill;
            contentHost.Controls.Add(view);

            if (activeMenuBtn != null)
            {
                activeMenuBtn.BackColor = UiTheme.SidebarBg;
                activeMenuBtn.ForeColor = UiTheme.SidebarText;
                activeMenuBtn.FlatAppearance.MouseOverBackColor = UiTheme.SidebarHover;
                activeMenuBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }

            activeMenuBtn = menuBtn;
            activeMenuBtn.BackColor = UiTheme.SidebarActive;
            activeMenuBtn.ForeColor = UiTheme.CardBg;
            activeMenuBtn.FlatAppearance.MouseOverBackColor = UiTheme.SidebarActive;
            activeMenuBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            activeMenuBtn.Invalidate();
        }

        private void PaintActiveMenuStripe(object? sender, PaintEventArgs e)
        {
            if (sender is Button button && button == activeMenuBtn)
            {
                using var accent = new SolidBrush(UiTheme.SidebarAccent);
                e.Graphics.FillRectangle(accent, 0, 0, button.LogicalToDeviceUnits(4), button.ClientSize.Height);
            }
        }

        private void OpenApprovalQueue()
        {
            using var f = new FrmApprovalQueue();
            f.ShowDialog(this);
        }
    }
}
