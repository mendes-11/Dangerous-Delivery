using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

ApplicationConfiguration.Initialize();

Bitmap bmp = null;
Graphics g = null;
List<IPlano> planosList = new List<IPlano>();
List<string> sidewalkPath = new List<string>
{
    "Image/SideWalk/calcada.png",
    "Image/SideWalk/calcada.png",
    "Image/SideWalk/calcada.png",
};

int spacingSidewalk = 950;
List<Calcada> calcadas = new List<Calcada>();
int widthCalcadas = sidewalkPath.Count * (330 + 400);

for (int i = 0; i < sidewalkPath.Count; i++)
{
    string caminho = sidewalkPath[i];
    int posX = i * spacingSidewalk;
    calcadas.Add(new Calcada(caminho, 426, 1000, 300, 5, posX, widthCalcadas));
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


int spacingHome = 400;
List<Casa> casas = new List<Casa>();
int widthHome = homePath.Count * (330 + 400);

for (int i = 0; i < homePath.Count; i++)
{
    string caminho = homePath[i];
    int posX = i * spacingHome;
    casas.Add(new Casa(caminho, 264, 330, 400, 5, posX, widthHome));
}

Moto moto = new Moto("Image/Entregador/moto1.png", 200, 700, 400, 400);
Rua rua = new Rua("Image/Street/Rua1.png", 720, 2000, 300, 20);



planosList.AddRange(casas);
planosList.Add(rua);
planosList.AddRange(calcadas);
planosList.Add(moto);

IPlano[] planos = planosList.ToArray();

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


