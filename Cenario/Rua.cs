using System.Drawing;

public class Rua : IPlano
{
     private Image Img;
    private float Y;
    private float Height;
    public float Width { get; set; }

    public Rua(string imagePath, float y, float width, float height)
    {
        this.Img = Image.FromFile(imagePath)
            .GetThumbnailImage((int)width, (int)height, null, nint.Zero);
        this.Y = y;
        this.Width = (int)width;
        this.Height = (int)height;
    }

    public void Draw(Graphics g, DrawPlanoParameters parameters)
{
    float scaleX = parameters.Size.Width / 1920f;
    float scaleY = parameters.Size.Height / 1080f;

    float temp = 3f;

    RectangleF destino = new(
        parameters.X * scaleX,
        Y * scaleY,
        temp * parameters.Size.Width * scaleX,
        Height * scaleY);

    g.DrawImage(Img, destino);
}

}
