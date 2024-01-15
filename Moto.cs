using System.Drawing;

public class Moto : IPlano
{
    private Image img { get; set; }  
    private int x { get; set; }  
    private int y { get; set; }  
    private int width { get; set; }  
    private int height { get; set; }  

    public Moto(string imagePath, int X, int Y, int width, int height)
    {
        this.img = Image.FromFile(imagePath);
        this.x = X;
        this.y = Y;
        this.width = width;
        this.height = height;
    }

    public void Draw(Graphics g)
    {
        g.DrawImage(img, x, y, width, height);
    }
}