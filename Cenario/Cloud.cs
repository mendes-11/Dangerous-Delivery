using System.Drawing;

public class Cloud : IPlano
{
    private Image ImgOriginal;
    private Image Img;
    private float Y;
    private float ratio;
    public float Width { get; set; }

    public Cloud(string imagePath, float y, float width)
    {
        this.ImgOriginal = this.Img = Image.FromFile(imagePath);
        this.ratio = ImgOriginal.Height / (float)ImgOriginal.Width;
        this.Y = y;
        this.Width = width;
    }

    Rectangle lastDest = Rectangle.Empty;
    public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
        float wid = parameters.Size.Width;
        float hei = parameters.Size.Height;
        
        Rectangle destiny =
            new(
                (int)(parameters.X * wid),
                (int)(this.Y * hei),
                (int)(this.Width * wid),
                (int)(this.Width * wid * this.ratio)
            );
        
        // if (destiny != lastDest)
        // {
        //     Img = ImgOriginal.GetThumbnailImage(
        //         destiny.Width, destiny.Height, null, nint.Zero
        //     );
        //     lastDest = destiny;
        // }

        g.DrawImage(Img, destiny);
    }
}
