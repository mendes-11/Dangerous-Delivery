using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

ApplicationConfiguration.Initialize();

Bitmap bmp = null;
Graphics g = null;
List<string> caminhosCasas = new List<string>
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

List<IPlano> planosList = new List<IPlano>();

int espacamento = 400;
List<Casa> casas = new List<Casa>();
int totalWidth = caminhosCasas.Count * (330 + 400);

for (int i = 0; i < caminhosCasas.Count; i++)
{
    string caminho = caminhosCasas[i];
    int posX = i * espacamento;
    casas.Add(new Casa(caminho, 320, 330, 400, 5, posX, totalWidth));
}
planosList.AddRange(casas);

Moto moto = new Moto("Image/Entregador/moto1.png", 200, 700, 400, 400);
Rua rua = new Rua("Image/Street/Rua1.png", 720, 2000, 300, 40);
planosList.Add(rua);
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


