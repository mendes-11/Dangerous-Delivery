using System.Drawing;
using System.Windows.Forms;

public class Game
{
    private Bitmap bmp;
    private Graphics g;
    private Parallax parallax;
    private Player player;

    public void Initialize()
    {
        ApplicationConfiguration.Initialize();

        parallax = new Parallax();
        player = new Player();

        parallax.Layers.Add(new SkyLayer(40));
        parallax.Layers.Add(new CityLayer(70));
        parallax.Layers.Add(new SlumLayer(110));
        parallax.Layers.Add(new CasasLayer(150));
        parallax.Layers.Add(new RuasLayer(210));
        parallax.Layers.Add(new CalcadasLayer(180));
    }

    public void Run(Form form)
    {
        var pb = new PictureBox { Dock = DockStyle.Fill, };
        var timer = new Timer { Interval = 20, };

       
        form.WindowState = FormWindowState.Maximized;
        form.Text = "Dangerous Delivery";
        form.Controls.Add(pb);
       

        form.Load += (o, e) =>
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            pb.Image = bmp;
            timer.Start();
        };

        timer.Tick += (o, e) =>
        {
            g.Clear(Color.SkyBlue);
            parallax.Draw(g);
            player.Draw(g);
            pb.Refresh();
        };

        form.KeyDown += (o, e) =>
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
        Application.Run(form);
    }
}
