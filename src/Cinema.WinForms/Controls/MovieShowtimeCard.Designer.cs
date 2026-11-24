namespace Cinema.WinForms.Controls;

partial class MovieShowtimeCard
{
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            picPoster?.Image?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieShowtimeCard));
        layoutCard = new TableLayoutPanel();
        picPoster = new PictureBox();
        layoutMovie = new TableLayoutPanel();
        layoutTitle = new TableLayoutPanel();
        lblMovieTitle = new Label();
        lblRating = new Label();
        lblDetails = new Label();
        flowShowtimes = new FlowLayoutPanel();
        layoutCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
        layoutMovie.SuspendLayout();
        layoutTitle.SuspendLayout();
        SuspendLayout();
        //
        // layoutCard
        //
        layoutCard.BackColor = Color.White;
        layoutCard.ColumnCount = 2;
        layoutCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
        layoutCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutCard.Controls.Add(picPoster, 0, 0);
        layoutCard.Controls.Add(layoutMovie, 1, 0);
        layoutCard.Dock = DockStyle.Fill;
        layoutCard.Name = "layoutCard";
        layoutCard.Padding = new Padding(12);
        layoutCard.RowCount = 1;
        layoutCard.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        //
        // picPoster
        //
        picPoster.AccessibleName = "Poster phim";
        picPoster.BackColor = Color.FromArgb(248, 250, 252);
        picPoster.Image = (Image)resources.GetObject("picPoster.Image");
        picPoster.Dock = DockStyle.Fill;
        picPoster.Margin = new Padding(0, 1, 14, 1);
        picPoster.Name = "picPoster";
        picPoster.SizeMode = PictureBoxSizeMode.StretchImage;
        picPoster.TabStop = false;
        //
        // layoutMovie
        //
        layoutMovie.ColumnCount = 1;
        layoutMovie.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutMovie.Controls.Add(layoutTitle, 0, 0);
        layoutMovie.Controls.Add(lblDetails, 0, 1);
        layoutMovie.Controls.Add(flowShowtimes, 0, 2);
        layoutMovie.Dock = DockStyle.Fill;
        layoutMovie.Margin = Padding.Empty;
        layoutMovie.Name = "layoutMovie";
        layoutMovie.RowCount = 3;
        layoutMovie.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        layoutMovie.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
        layoutMovie.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        //
        // layoutTitle
        //
        layoutTitle.ColumnCount = 3;
        layoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        layoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
        layoutTitle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutTitle.Controls.Add(lblMovieTitle, 0, 0);
        layoutTitle.Controls.Add(lblRating, 1, 0);
        layoutTitle.Dock = DockStyle.Fill;
        layoutTitle.Margin = Padding.Empty;
        layoutTitle.Name = "layoutTitle";
        layoutTitle.RowCount = 1;
        layoutTitle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        //
        // lblMovieTitle
        //
        lblMovieTitle.AutoEllipsis = true;
        lblMovieTitle.AutoSize = true;
        lblMovieTitle.Dock = DockStyle.Fill;
        lblMovieTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        lblMovieTitle.Margin = Padding.Empty;
        lblMovieTitle.Name = "lblMovieTitle";
        lblMovieTitle.Text = "Tên phim";
        lblMovieTitle.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblRating
        //
        lblRating.Anchor = AnchorStyles.Left;
        lblRating.BackColor = Color.FromArgb(254, 243, 199);
        lblRating.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblRating.ForeColor = Color.FromArgb(146, 64, 14);
        lblRating.Margin = new Padding(4, 0, 0, 0);
        lblRating.Name = "lblRating";
        lblRating.Size = new Size(40, 24);
        lblRating.TextAlign = ContentAlignment.MiddleCenter;
        //
        // lblDetails
        //
        lblDetails.Dock = DockStyle.Fill;
        lblDetails.ForeColor = Color.FromArgb(100, 116, 139);
        lblDetails.Margin = Padding.Empty;
        lblDetails.Name = "lblDetails";
        lblDetails.Text = "Thể loại  •  Thời lượng";
        lblDetails.TextAlign = ContentAlignment.MiddleLeft;
        //
        // flowShowtimes
        //
        flowShowtimes.Dock = DockStyle.Fill;
        flowShowtimes.Margin = Padding.Empty;
        flowShowtimes.Name = "flowShowtimes";
        flowShowtimes.Padding = new Padding(0, 4, 0, 0);
        flowShowtimes.WrapContents = false;
        //
        // MovieShowtimeCard
        //
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(226, 232, 240);
        Controls.Add(layoutCard);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.FromArgb(15, 23, 42);
        MinimumSize = new Size(0, 164);
        Name = "MovieShowtimeCard";
        Padding = new Padding(1);
        Size = new Size(510, 164);
        TabStop = false;
        layoutCard.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
        layoutMovie.ResumeLayout(false);
        layoutTitle.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel layoutCard;
    private PictureBox picPoster;
    private TableLayoutPanel layoutMovie;
    private TableLayoutPanel layoutTitle;
    private Label lblMovieTitle;
    private Label lblRating;
    private Label lblDetails;
    private FlowLayoutPanel flowShowtimes;
}
