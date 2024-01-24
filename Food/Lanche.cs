using System.Drawing;

public class Lanche
{

    private Image Img;
    private float Y;
    private float Height;
    public float Width { get; set; }
    public string Type { get; set; } 

    public Lanche(string imagePath, float y)
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