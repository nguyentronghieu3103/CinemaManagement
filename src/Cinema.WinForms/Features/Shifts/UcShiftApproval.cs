using System;
using System.Windows.Forms;
using Cinema.WinForms.Controls;

namespace Cinema.WinForms.Features.Shifts
{
    public partial class UcShiftApproval : UserControl
    {
        public UcShiftApproval()
        {
            InitializeComponent();
            SetupRuntime();
        }

        private void SetupRuntime()
        {
            UiTheme.StyleGrid(gridShifts);

            gridShifts.Rows.Add("NV-012", "Ca s\u00E1ng", "21/11/2026 14:05", "Ch\u1EDD duy\u1EC7t");
            gridShifts.Rows.Add("NV-015", "Ca t\u1ED1i", "21/11/2026 22:10", "\u0110\u00E3 duy\u1EC7t");

            btnApprove.Click += (_, __) => MessageBox.Show("\u0110\u00E3 duy\u1EC7t ch\u1ED1t ca (mock).");
            btnReject.Click += (_, __) => new RejectShiftModal().ShowDialog(FindForm());

            rightCard.Resize += (_, __) => LayoutRightCard();
            Load += (_, __) => LayoutRightCard();
            LayoutRightCard();

            // Z-order: higher index docks first; Fill docks last (index 0)
            Controls.SetChildIndex(pnlHeader, 1);
            Controls.SetChildIndex(split, 0);
        }

        private void LayoutRightCard()
        {
            int pad = 12;
            int gap = 10;
            int available = rightCard.ClientSize.Width - pad * 2 - gap * 3;
            int cardW = Math.Max(120, available / 4);
            var cards = new[] { info1, info2, info3, info4 };
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Left = pad + i * (cardW + gap);
                cards[i].Width = cardW;
                cards[i].Top = 55;
            }

            int lineW = rightCard.ClientSize.Width - pad * 2;
            foreach (var line in new[] { line1, line2, line3 })
            {
                line.Left = pad;
                line.Width = Math.Max(200, lineW);
            }

            int rightEdge = rightCard.ClientSize.Width - pad;
            btnReject.Left = rightEdge - btnReject.Width;
            btnApprove.Left = btnReject.Left - 10 - btnApprove.Width;
            lblNote.Left = pad;
            lblNote.Width = Math.Max(100, lineW);
        }
    }
}