using System.Drawing;

public class Calcada : IPlano
{
    private Image Img;
    private int X;
    private int Y;
    private int Width;
    private int Height;
    private int Velocidade;

    private int TotalWidth;

    public Calcada(string imagePath, int y, int width, int height, int velocidade, int startX, int totalWidth)
    {
        this.Img = Image.FromFile(imagePath);
        this.Y = y;
        this.Width = width;
        this.Height = height;
        this.Velocidade = velocidade;
        this.X = startX;
        this.TotalWidth = totalWidth;
    }

    public void Draw(Graphics g)
    {
        g.DrawImage(Img, X, Y, Width, Height);
        X -= Velocidade;

        if (X + Width < 0)
        {
            X += TotalWidth; 
        }
    }
}
