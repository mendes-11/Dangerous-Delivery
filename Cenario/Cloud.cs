using System.Drawing;

public class Cloud : IPlano
{
    private Image Img;
    private float Y;
    private float Height;

    public Cloud(string imagePath, float y, float width, float height)
    {
        this.Img = Image.FromFile(imagePath)
            .GetThumbnailImage((int)width, (int)height, null, nint.Zero);
        this.Y = y;
        this.Width = (int)width;
        this.Height = (int)height;
    }

    public float Width { get; set; }

     public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
        float temp = 0.2f;
        float temp2 = parameters.X * 2 / 1920;
        float temp3 = Y  / 1080;
        float ratio = parameters.Size.Width / parameters.Size.Height;
        RectangleF destiny =
            new(
                parameters.Size.Width * temp2,
                parameters.Size.Height * temp3,
                parameters.Size.Width * temp * ratio,
                Height * ratio
            );
        g.DrawImage(Img, destiny);
    }
}
