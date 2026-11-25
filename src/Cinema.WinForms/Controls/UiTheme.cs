using System.Drawing;
using System.Windows.Forms;

namespace Cinema.WinForms.Controls
{
    internal static class UiTheme
    {
        public static readonly Color SidebarBg = ColorTranslator.FromHtml("#1E293B");
        public static readonly Color SidebarHover = ColorTranslator.FromHtml("#273549");
        public static readonly Color SidebarActive = ColorTranslator.FromHtml("#334155");
        public static readonly Color SidebarAccent = ColorTranslator.FromHtml("#3B82F6");
        public static readonly Color SidebarText = ColorTranslator.FromHtml("#CBD5E1");
        public static readonly Color MainBg = ColorTranslator.FromHtml("#F1F5F9");
        public static readonly Color CardBg = Color.White;
        public static readonly Color Border = ColorTranslator.FromHtml("#E2E8F0");
        public static readonly Color Primary = ColorTranslator.FromHtml("#2563EB");
        public static readonly Color Amber = ColorTranslator.FromHtml("#D97706");
        public static readonly Color TextMain = ColorTranslator.FromHtml("#0F172A");
        public static readonly Color TextMuted = ColorTranslator.FromHtml("#64748B");
        public static readonly Color Success = ColorTranslator.FromHtml("#16A34A");
        public static readonly Color Danger = ColorTranslator.FromHtml("#DC2626");

        public static Font H1 = new Font("Segoe UI", 18F, FontStyle.Bold);
        public static Font H2 = new Font("Segoe UI", 13F, FontStyle.Bold);
        public static Font H3 = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static Font Body = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        public static Font Small = new Font("Segoe UI", 8.5F, FontStyle.Regular);

        public static Button PrimaryButton(string text)
        {
            var b = new Button { Text = text, BackColor = Primary, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Height = 36, Cursor = Cursors.Hand };
            b.FlatAppearance.BorderSize = 0; return b;
        }
        public static Button SecondaryButton(string text)
        {
            var b = new Button { Text = text, BackColor = Color.White, ForeColor = TextMain, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Regular), Height = 36, Cursor = Cursors.Hand };
            b.FlatAppearance.BorderColor = Border; return b;
        }
        public static Button SuccessButton(string text) { var b = PrimaryButton(text); b.BackColor = Success; return b; }
        public static Button DangerOutlineButton(string text)
        {
            var b = new Button { Text = text, BackColor = Color.White, ForeColor = Danger, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Height = 36, Cursor = Cursors.Hand };
            b.FlatAppearance.BorderColor = Danger; b.FlatAppearance.BorderSize = 1; return b;
        }
        public static Panel Card(int w, int h)
        {
            var card = new Panel { Width = w, Height = h, BackColor = CardBg };
            card.Paint += DrawCardBorder;
            return card;
        }

        public static void DrawCardBorder(object? sender, PaintEventArgs e)
        {
            var card = (Control)sender!;
            ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle, Border, ButtonBorderStyle.Solid);
        }
        public static Label Title(string text, float size = 18F) => new Label { Text = text, Font = new Font("Segoe UI", size, FontStyle.Bold), ForeColor = TextMain, AutoSize = true };
        public static Label Muted(string text) => new Label { Text = text, Font = Small, ForeColor = TextMuted, AutoSize = true };
        public static DataGridView Grid()
        {
            var g = new DataGridView { BackgroundColor = Color.White, BorderStyle = BorderStyle.None, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, RowHeadersVisible = false, AllowUserToAddRows = false, AllowUserToResizeRows = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false, EnableHeadersVisualStyles = false, Font = Body, ColumnHeadersHeight = 38, RowTemplate = { Height = 34 } };
            StyleGrid(g);
            return g;
        }

        public static void StyleGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.BackgroundColor = CardBg;
            grid.GridColor = Border;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            grid.ColumnHeadersDefaultCellStyle.BackColor = MainBg;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextMain;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = MainBg;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextMain;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.DefaultCellStyle.BackColor = CardBg;
            grid.DefaultCellStyle.ForeColor = TextMain;
            grid.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE");
            grid.DefaultCellStyle.SelectionForeColor = TextMain;
        }
        public static void StyleTab(TabControl tab) { tab.Font = Body; tab.Padding = new Point(14, 7); }
        public static Label FieldLabel(string t, int x, int y) => new Label { Text = t, Location = new Point(x, y), AutoSize = true, ForeColor = TextMain, Font = H3 };
    }
}
