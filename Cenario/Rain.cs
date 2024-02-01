using System;
using System.Drawing;

public class Rain : IPlano
{
    private Image Img;
    public float Y { get; private set; }
    private float VerticalSpeed;

    public Rain(string imagePath, float y, float width, float height, float verticalSpeed)
    {
        this.Img = Image.FromFile(imagePath);
        this.Y = y;
        this.Width = width;
        this.Height = height;
        this.VerticalSpeed = verticalSpeed;
    }

    public float Width { get; set; }
    public float Height { get; set; }

    public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
        Y += VerticalSpeed;
        g.DrawImage(Img, parameters.X, Y, Width, Height);
    }
}
