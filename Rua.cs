using System.Drawing;

public class Rua : IPlano
{
    private Image Img;
    private int X1;
    private int X2;
    private int Y;
    private int Width;
    private int Height;
    private int Velocidade;

    public Rua(string imagePath, int y, int width, int height, int velocidade)
    {
        this.Img = Image.FromFile(imagePath);
        this.Y = y;
        this.Width = width;
        this.Height = height;
        this.Velocidade = velocidade;
        this.X1 = 0;
        this.X2 = Width;
    }

    public void Draw(Graphics g, float x)
    {
        g.DrawImage(Img, x, Y, Width, Height);
        g.DrawImage(Img, x + Width, Y, Width, Height);

        X1 -= Velocidade;
        X2 -= Velocidade;

        
        if (X1 + Width <= 0)
        {
            X1 = Width;
        }

        if (X2 + Width <= 0)
        {
            X2 = Width;
        }
    }

    public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
        throw new System.NotImplementedException();
    }
}
