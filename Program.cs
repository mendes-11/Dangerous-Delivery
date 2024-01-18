using System.Drawing;
using System.Windows.Forms;


ApplicationConfiguration.Initialize();

Bitmap bmp = null;
Graphics g = null;

Parallax parallax = new Parallax();

parallax.Layers.Add(new CasasLayer(5));
parallax.Layers.Add(new CalcadasLayer(10));
parallax.Layers.Add(new RuasLayer(15));

var pb = new PictureBox { Dock = DockStyle.Fill, };
var timer = new Timer { Interval = 20, };

var form = new Form
{
    WindowState = FormWindowState.Maximized,
    Text = "Dangerous Delivery",
    Controls = { pb },
};

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
    pb.Refresh();
};

form.KeyDown += (o, e) =>
{
    switch (e.KeyCode)
    {
        case Keys.Escape:
            Application.Exit();
            break;
    }
};

Application.Run(form);