using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;

ApplicationConfiguration.Initialize();

Bitmap bmp = null;
Graphics g = null;
Random random = new Random();
Parallax parallax = new Parallax();

List<IPlano> planosList = new List<IPlano>();
List<string> sidewalkPath = 
    Directory.GetFiles("Image/SideWalk")
    .ToList();

int widthCalcadas = sidewalkPath.Count * 980;
List<Calcada> calcadas = sidewalkPath
    .Select(path => new Calcada(path, 426, 1000, 300, widthCalcadas))
    .ToList();

List<string> homePath = 
    Directory.GetFiles("Image/Casas")
    .ToList();

int lastRandom = -1;
int spacingHome = 420;
List<Casa> casas = new List<Casa>();
int widthHome = homePath.Count * spacingHome;

for (int i = 0; i < homePath.Count; i++)
{
    int randomIndex;
    do
    {
        randomIndex = random.Next(homePath.Count);
    } while (randomIndex == lastRandom);

    lastRandom = randomIndex;
    string caminho = homePath[randomIndex];
    int posX = i * spacingHome;
    casas.Add(new Casa(caminho, 264, 330, 400, 10, posX, widthHome));
}

Moto moto = new Moto("Image/Entregador/moto1.png", 200, 650, 400, 400);
Rua rua = new Rua("Image/Street/RUA21.png", 720, 1930, 300, 20);

planosList.AddRange(casas);
planosList.Add(rua);
planosList.AddRange(calcadas);
planosList.Add(moto);

IPlano[] planos = planosList.ToArray();
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