using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class Game : Form
{
    private Bitmap bmp;
    private Graphics g;
    private Parallax parallax;
    private FoodLanche foodLanche;
    private Player player;
    private Pause pause;

    private bool isPaused = false;

    public Game()
    {
        this.WindowState = FormWindowState.Maximized;
        this.Text = "Dangerous Delivery";

        var pb = new PictureBox { Dock = DockStyle.Fill };
        var timer = new Timer { Interval = 1000 / 60, };

        parallax = new Parallax();
        foodLanche = new FoodLanche();
        player = new Player();
        pause = new Pause();
        pause.ResumeGame += (sender, e) => ResumeGame();

        parallax.Layers.Add(new SkyLayer(40));
        parallax.Layers.Add(new CityLayer(70));
        parallax.Layers.Add(new SlumLayer(110));
        parallax.Layers.Add(new CasasLayer(150));
        parallax.Layers.Add(new RuasLayer(210));
        parallax.Layers.Add(new CalcadasLayer(180));

        this.Load += (sender, e) =>
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.CompositingQuality = CompositingQuality.AssumeLinear;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;

            g.Clear(Color.Black);
            pb.Image = bmp;
            timer.Start();
        };

        timer.Tick += (sender, e) =>
        {
            if (!isPaused)
            {
                g.Clear(Color.SkyBlue);
                parallax.Draw(g);
                foodLanche.Draw(g);
                player.Draw(g);
                pb.Refresh();
            }
        };

        this.KeyDown += (o, e) =>
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            else if (!isPaused && e.KeyCode == Keys.P)
            {
                TogglePause();
            }
            else if (isPaused && e.KeyCode == Keys.P)
            {
                TogglePause();
            }
            else if (!isPaused)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        player.MoveLeft();
                        break;
                    case Keys.D:
                        player.MoveRight();
                        break;
                    case Keys.W:
                        player.MoveUp();
                        break;
                    case Keys.S:
                        player.MoveDown();
                        break;
                }
            }
        };

        FormClosed += delegate
        {
            Application.Exit();
        };

        // this.FormBorderStyle = FormBorderStyle.None;

        this.Controls.Add(pb);
    }

    private void ResumeGame()
    {
        isPaused = false;
        pause.HidePause();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pause.ShowPause();
        }
        else
        {
            ResumeGame();
        }
    }
}
