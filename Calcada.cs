using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

public class Calcada : IPlano
{
    private Image Img;
    private int Y;
    private int Width;
    private int Height;
 

    public Calcada(string path, int y, int width, int height)
    {
        this.Img = Image.FromFile(path);
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }

    public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
        g.DrawImage(Img, parameters.X, Y, Width, Height);
    }
}
