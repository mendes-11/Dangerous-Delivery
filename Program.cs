using System;
using System.Drawing;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

Bitmap bmp = null;
Graphics g = null;


Fundo fundo = new Fundo();
Moto moto = new Moto();

var pb = new PictureBox {
    Dock = DockStyle.Fill,
};

var timer = new Timer {
    Interval = 20,
};

var form = new Form {
    WindowState = FormWindowState.Maximized,
    // FormBorderStyle = FormBorderStyle.None,
    Text = "Delivery",
    Controls = { pb }
};

form.Load += (o, e) =>
{
    bmp = new Bitmap(
        pb.Width, 
        pb.Height
    );
    g = Graphics.FromImage(bmp);
    g.Clear(Color.Black);
    pb.Image = bmp;
    timer.Start();
};

timer.Tick += (o, e) =>
{
    g.Clear(Color.White);

    // g.FillRectangle(Brushes.Purple,
    //     0, 0, .3f * pb.Width, pb.Height
    // );

    fundo.Draw(g, pb.Width, pb.Height);
    moto.Draw(g, pb.Width, pb.Height);

    pb.Refresh();
};

form.KeyDown += (o, e) =>
{
    switch (e.KeyCode)
    {
        case Keys.Escape:
            Application.Exit();
            break;
        
        case Keys.D:
            break;
        
        case Keys.A:
            break;
    }
};

form.KeyUp += (o, e) =>
{
    switch (e.KeyCode)
    {
    }
};

Application.Run(form);





public class Fundo
{
    public int X { get; set; }
    public int Y { get; set; }
    public float Size { get; set; }
    private Image img;
    private DateTime lastDamage = DateTime.MinValue;
    public Fundo()
    {
        this.img = Bitmap.FromFile("c.png");
    }

    public void Draw(Graphics g, int width, int height)
    {

        g.DrawImage(img, 
            390 , 100,
            920,
            920
        );
    }
}

public class Moto
{
    public int X { get; set; }
    public int Y { get; set; }
    public float Size { get; set; }
    private Image img;
    private DateTime lastDamage = DateTime.MinValue;
    public Moto()
    {
        this.img = Bitmap.FromFile("moto1.png");
    }

    public void Draw(Graphics g, int width, int height)
    {

        g.DrawImage(img, 
            550 , 560,
            600,
            600
        );
    }
}