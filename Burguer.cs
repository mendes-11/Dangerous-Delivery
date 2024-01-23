using System.Drawing;

public class Burguer : ILanche
{

    private Image Img;
    private float Y;
     private float Width;
    private float Height;

    public Burguer(string imagePath, float y)
    {
        this.Img = Image.FromFile(imagePath);
        this.Y = y;
        this.Width = Img.Width;
        this.Height = Img.Height;
    }

    public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
         g.DrawImage(Img, parameters.X, Y, Width, Height);
    }
}