using System.Drawing;

public class Rua : IPlano
{
    private Image img { get; set; }
    private int x1 { get; set; }
    private int x2 { get; set; }
    private int y { get; set; }
    private int width { get; set; }
    private int height { get; set; }
    private int velocidade { get; set; }

    public Rua(string imagePath, int Y, int width, int height, int velocidade)
    {
        this.img = Image.FromFile(imagePath);
        this.y = Y;
        this.width = width;
        this.height = height;
        this.velocidade = velocidade;
        this.x1 = 0;
        this.x2 = width;
    }

    public void Draw(Graphics g)
    {
        g.DrawImage(img, x1, y, width, height);
        g.DrawImage(img, x2, y, width, height);

        x1 -= velocidade;
        x2 -= velocidade;

        
        if (x1 + width <= 0)
        {
            x1 = width;
        }

        if (x2 + width <= 0)
        {
            x2 = width;
        }
    }
}
