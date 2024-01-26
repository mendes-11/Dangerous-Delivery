using System.Drawing;

public class Lanche : ObjBox
{
    private Image Img;
    public float Y;
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
        g.DrawImage(Img, parameters.X, Y, Width, Height);
        CreateHitbox(parameters.X, Y, this.Width, this.Height);
        g.DrawRectangle(Pens.Red, Box);
        Collision.Current.AddObjBox(this);
    }
}
