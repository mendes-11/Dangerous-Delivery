using System.Drawing;

public class Lanche : ObjBox
{
    private Image Img;
    public float Y;
    public float X;
    public float Height;
    public float Width { get; set; }
    public string Type { get; set; }
    public override RectangleF Box { get; set; }

    public Lanche(string imagePath, float y)
    {
        this.Img = Image.FromFile(imagePath);
        this.Y = y;
        this.Width = Img.Width;
        this.Height = Img.Height;
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


        g.DrawImage(Img, destiny);
        CreateHitbox(X, Y, this.Width, this.Height);
        // g.DrawRectangle(Pens.Red, Box);
        Collision.Current.AddObjBox(this);
    }
}
