using System.Drawing;

public class City : IPlano
{
    private Image Img;
    private Image ImgOriginal;
    private float Y;
    private float Height;
    public float Width { get; set; }
    Rectangle lastDest = Rectangle.Empty;

    public City(string imagePath, float y, float width, float height)
    {
        this.ImgOriginal = this.Img = Image.FromFile(imagePath);
        this.Y = y;
        this.Width = width;
        this.Height = height;
    }


     public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
        float wid = parameters.Size.Width;
        float hei = parameters.Size.Height;
        
        Rectangle destiny =
            new(
                (int)(parameters.X * wid),
                (int)(this.Y * hei),
                (int)(this.Width * wid),
                (int)(this.Height * hei)
            );
        
        if (destiny != lastDest)
        {
            Img = ImgOriginal.GetThumbnailImage(
                destiny.Width, destiny.Height, null, nint.Zero
            );
            lastDest = destiny;
        }

        g.DrawImage(Img, destiny);
    }
}
