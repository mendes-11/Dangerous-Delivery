using System.Drawing;

public class Rua : IPlano
{
    private Image Img;
    private int X1;
    private int X2;
    private int Y;
    private int Width;
    private int Height;

    public Rua(string imagePath, int y, int width, int height, int velocidade)
    {
        this.Img = Image.FromFile(imagePath);
        this.Y = y;
        this.Width = width;
        this.Height = height;
        this.X1 = 0;
        this.X2 = Width;
    }

    public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
        throw new System.NotImplementedException();
    }
}
