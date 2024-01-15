using System.Drawing;

public class Calcada : IPlano
{
    private int X { get; set; }
    private Image img;
    private int velocidade;

    public Calcada(string imagePath, int velocidade)
    {
        this.img = Bitmap.FromFile(imagePath);
        this.velocidade = velocidade;
    }

    public void Draw(Graphics g, int width, int height)
    {
        g.DrawImage(img, 0 - X, 600);
        X += velocidade;
        if (X > img.Width) X = 0;
    }
}