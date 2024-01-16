using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

ApplicationConfiguration.Initialize();

Bitmap bmp = null;
Graphics g = null;
Random random = new Random();
List<IPlano> planosList = new List<IPlano>();
List<string> sidewalkPath = new List<string>
{
    "Image/SideWalk/calcada0.png",
    "Image/SideWalk/calcada1.png",
    "Image/SideWalk/calcada2.png",
    "Image/SideWalk/calcada3.png",
    "Image/SideWalk/calcada4.png",
    "Image/SideWalk/calcada5.png",
};


int lastRandomSide = -1;
int spacingSidewalk = 950;
List<Calcada> calcadas = new List<Calcada>();
int widthCalcadas = sidewalkPath.Count * 980;
int randomIndexSide;
for (int i = 0; i < sidewalkPath.Count; i++)
{
    do
    {
        randomIndexSide = random.Next(sidewalkPath.Count);
    } while (randomIndexSide == lastRandomSide);

    lastRandomSide = randomIndexSide;
    string caminho = sidewalkPath[randomIndexSide];
    int posX = i * 980;
    calcadas.Add(new Calcada(caminho, 426, 1000, 300, 40, posX, widthCalcadas));
}

List<string> homePath = new List<string>
{
    "Image/Casas/CASA1B.png",
    "Image/Casas/CASA2B.png",
    "Image/Casas/CASA3B.png",
    "Image/Casas/CASA4B.png",
    "Image/Casas/CASA5B.png",
    "Image/Casas/CASA6B.png",
    "Image/Casas/CASA7B.png",
    "Image/Casas/CASA8B.png"
};

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
    casas.Add(new Casa(caminho, 264, 330, 400, 20, posX, widthHome));
}

Moto moto = new Moto("Image/Entregador/moto1.png", 200, 700, 400, 400);
Rua rua = new Rua("Image/Street/Rua1.png", 720, 2000, 300, 30);

planosList.AddRange(casas);
planosList.Add(rua);
planosList.AddRange(calcadas);
planosList.Add(moto);

IPlano[] planos = planosList.ToArray();

var pb = new PictureBox { Dock = DockStyle.Fill, };

var timer = new Timer { Interval = 10, };

var form = new Form
{
    WindowState = FormWindowState.Maximized,
    Text = "Dangerous Delivery",
    Controls = { pb },
};

form.Load += (o, e) =>
{
    bmp = new Bitmap(pb.Width, pb.Height);
    using (var gTemp = Graphics.FromImage(bmp))
    {
        gTemp.Clear(Color.Black);
    }
    g = Graphics.FromImage(bmp);
    pb.Image = bmp;
    timer.Start();
};

timer.Tick += (o, e) =>
{
    using (var bufferGraphics = Graphics.FromImage(bmp)) 
    {
        bufferGraphics.Clear(Color.SkyBlue);

        foreach (var plano in planos)
        {
            plano.Draw(bufferGraphics);
        }
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