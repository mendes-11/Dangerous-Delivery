using System;
using System.Drawing;

public class RainLayer : BaseLayer
{
    private Rectangle[] rainRectangles;
    private int velocidade = 5;

    public RainLayer(int numRectangles)
    {
        rainRectangles = new Rectangle[numRectangles];
        InitializeRainRectangles();
    }

    private void InitializeRainRectangles()
    {
        Random random = new Random();
        for (int i = 0; i < rainRectangles.Length; i++)
        {
            int x = random.Next(0, 3000);
            int y = random.Next(-5000, 0);
            int width = 2;
            int height = 10;
            rainRectangles[i] = new Rectangle(x, y, width, height);
        }
    }

    public override void Draw(Graphics g)
    {
        foreach (var rectangle in rainRectangles)
        {
            g.RotateTransform(10);
            g.FillRectangle(Brushes.DodgerBlue, rectangle);
            g.ResetTransform();
        }
    }


    public void Update()
    {
        for (int i = 0; i < rainRectangles.Length; i++)
        {
            rainRectangles[i] = new Rectangle(
                rainRectangles[i].X - velocidade,
                rainRectangles[i].Y + velocidade,
                rainRectangles[i].Width,
                rainRectangles[i].Height
            );

            if (rainRectangles[i].X + rainRectangles[i].Width < 0 || rainRectangles[i].Y > 2000)
            {
                rainRectangles[i] = new Rectangle(
                    3000,
                    new Random().Next(-5000, 0),
                    rainRectangles[i].Width,
                    rainRectangles[i].Height
                );
            }
        }
    }
}
