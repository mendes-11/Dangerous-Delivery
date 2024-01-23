using System.Drawing;
using System.Windows.Forms;

public class Menu : Form
{
    private Bitmap bmp;
    private Graphics g;

    public Menu()
    {
        var pb = new PictureBox { Dock = DockStyle.Fill };
        var timer = new Timer { Interval = 20 };

        this.WindowState = FormWindowState.Maximized;
        this.Text = "Dangerous Delivery";

        Game game = new Game();
        var playButton = new Button();
        playButton.Text = "Jogar";
        playButton.Size = new Size(100, 50);
        playButton.Location = new Point(500, 500);
        this.Controls.Add(playButton);

        this.Controls.Add(pb);

        playButton.Click += (o, e) =>
        {
            this.Hide();
            game.Show();
        };

        this.Load += (o, e) =>
        {
            bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            g = Graphics.FromImage(bmp);
            pb.Image = bmp;
            g.Clear(Color.Black);
            timer.Start();
        };

        timer.Tick += (o, e) =>
        {
            g.Clear(Color.SkyBlue);
            pb.Refresh();
        };

        this.KeyDown += (o, e) =>
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        };
    }
}
