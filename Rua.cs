using System.Drawing;

public class Rua : IPlano
{
    private Image Img;

    private int Y;
    private int Width;
    private int Height;

    public Rua(string imagePath, int y, int width, int height)
    {
        this.Img = Image.FromFile(imagePath);
        this.Y = y;
        this.Width = width;
        this.Height = height;

    }

    public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
        throw new System.NotImplementedException();
    }
}
