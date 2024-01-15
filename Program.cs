using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

ApplicationConfiguration.Initialize();

Bitmap bmp = null;
Graphics g = null;
List<string> caminhosCasas = new List<string>
{
    "Image/CASA1B.png",
    "Image/CASA2B.png",
    "Image/CASA3B.png",
    "Image/CASA4B.png",
    "Image/CASA5B.png",
    "Image/CASA6B.png",
    "Image/CASA7B.png",
    "Image/CASA8B.png"
};

IPlano[] planos = {
    new Rua("Image/RUA.png", 720, 2000, 300, 5),
    new Moto("Image/moto1.png", 200, 600, 500, 500),
};

var pb = new PictureBox
{
    Dock = DockStyle.Fill,
};

var timer = new Timer
{
    Interval = 20,
};

var form = new Form
{
    WindowState = FormWindowState.Maximized,
    Text = "Dangerous Delivery",
    Controls = { pb }
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

    foreach (var plano in planos)
    {
        plano.Draw(g);
    }

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


