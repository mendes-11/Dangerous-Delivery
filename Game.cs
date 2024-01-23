using System.Drawing;
using System.Windows.Forms;

public class Game : Form
{
    private Bitmap bmp;
    private Graphics g;
    private Parallax parallax;
    private Player player;

    public Game()
    {
        this.WindowState = FormWindowState.Maximized; 
        this.Text = "Dangerous Delivery";
        
        var pb = new PictureBox { Dock = DockStyle.Fill };
        var timer = new Timer { Interval = 20 };

        parallax = new Parallax();
        player = new Player();
        
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
            g.Clear(Color.Black);
            pb.Image = bmp;
            timer.Start();
        };

        timer.Tick += (sender, e) =>
        {
            g.Clear(Color.SkyBlue);
            parallax.Draw(g);
            player.Draw(g);
            pb.Refresh();
        };

        this.KeyDown += (sender, e) =>
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.Left:
                    player.MoveLeft();
                    break;
                case Keys.Right:
                    player.MoveRight();
                    break;
                case Keys.Up:
                    player.MoveUp();
                    break;
                case Keys.Down:
                    player.MoveDown();
                    break;
            }
        };

        this.Controls.Add(pb);
    }
}
