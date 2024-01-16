using System.Drawing;

public class Calcada : IPlano
{
    private Image Img;
    private int Y;
    private int Width;
    private int Height;

    private int TotalWidth;

    public Calcada(string imagePath, int y, int width, int height, int totalWidth)
    {
        this.Img = Image.FromFile(imagePath);
        this.Y = y;
        this.Width = width;
        this.Height = height;
        this.TotalWidth = totalWidth;
    }

    public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
        g.DrawImage(Img, parameters.X, Y, Width, Height);
    }
}
