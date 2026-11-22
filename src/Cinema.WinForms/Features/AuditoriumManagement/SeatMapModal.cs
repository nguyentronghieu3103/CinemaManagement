using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema.WinForms.Features.AuditoriumManagement
{
    public partial class SeatMapModal : Form
    {
        private readonly string roomName;
        private string selectedTool = "normal";
        private readonly Button[,] seats = new Button[8, 12];

        public SeatMapModal(string roomName)
        {
            this.roomName = roomName;
            InitializeComponent();
            BuildSeats();
            SetupRuntime();
        }

        private void BuildSeats()
        {
            string[] rows = { "A", "B", "C", "D", "E", "F", "G", "H" };
            for (int r = 0; r < 8; r++)
            {
                var lbl = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(15, 23, 42),
                    Location = new Point(10, 18 + r * 48),
                    Text = rows[r]
                };
                seatPanel.Controls.Add(lbl);

                for (int c = 0; c < 12; c++)
                {
                    var btn = new Button
                    {
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                        Location = new Point(36 + c * 74, 12 + r * 48),
                        Size = new Size(66, 34),
                        Text = rows[r] + (c + 1),
                        Tag = (r, c),
                        TabStop = false
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    ApplySeatStyle(btn, SeatTypeFor(r, c));
                    btn.Click += Seat_Click;
                    seats[r, c] = btn;
                    seatPanel.Controls.Add(btn);
                }
            }
        }

        private static string SeatTypeFor(int r, int c)
        {
            if (r >= 6 && c >= 10) return "locked"; // H11,H12 demo
            if (r >= 6) return "couple";
            if (r >= 3 && r <= 5) return "vip";
            return "normal";
        }

        private void ApplySeatStyle(Button btn, string type)
        {
            btn.AccessibleDescription = type;
            switch (type)
            {
                case "vip":
                    btn.BackColor = Color.FromArgb(217, 119, 6);
                    btn.ForeColor = Color.White;
                    break;
                case "couple":
                    btn.BackColor = Color.FromArgb(236, 72, 153);
                    btn.ForeColor = Color.White;
                    break;
                case "locked":
                    btn.BackColor = Color.FromArgb(17, 24, 39);
                    btn.ForeColor = Color.White;
                    break;
                default:
                    btn.BackColor = Color.FromArgb(156, 163, 175);
                    btn.ForeColor = Color.FromArgb(15, 23, 42);
                    break;
            }
        }

        private void Seat_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn) ApplySeatStyle(btn, selectedTool);
        }

        private void SetupRuntime()
        {
            Text = "S\u01A1 \u0111\u1ED3 gh\u1EBF - " + roomName;
            btnToolNormal.Click += (_, __) => SelectTool("normal");
            btnToolVip.Click += (_, __) => SelectTool("vip");
            btnToolCouple.Click += (_, __) => SelectTool("couple");
            btnToolLock.Click += (_, __) => SelectTool("locked");
            SelectTool("normal");
            btnSave.Click += (_, __) => { MessageBox.Show("\u0110\u00E3 l\u01B0u s\u01A1 \u0111\u1ED3 (mock)."); Close(); };
        }

        private void SelectTool(string tool)
        {
            selectedTool = tool;
            ResetToolButtons();
            Button active = tool switch
            {
                "vip" => btnToolVip,
                "couple" => btnToolCouple,
                "locked" => btnToolLock,
                _ => btnToolNormal
            };
            active.FlatAppearance.BorderSize = 2;
            active.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
        }

        private void ResetToolButtons()
        {
            foreach (var b in new[] { btnToolNormal, btnToolVip, btnToolCouple, btnToolLock })
            {
                b.FlatAppearance.BorderSize = 0;
                b.FlatAppearance.BorderColor = b.BackColor;
            }
        }
    }
}
