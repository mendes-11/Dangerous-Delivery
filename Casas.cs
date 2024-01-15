using System.Drawing;

public class Casa : IPlano
{
    private Image img { get; set; }
    private int x { get; set; }
    private int y { get; set; }
    private int width { get; set; }
    private int height { get; set; }
    private int velocidade { get; set; }

    public Casa(string imagePath, int Y, int width, int height, int velocidade, int startX)
    {
        this.img = Image.FromFile(imagePath);
        this.y = Y;
        this.width = width;
        this.height = height;
        this.velocidade = velocidade;
        this.x = startX;
    }

    public void Draw(Graphics g)
    {
        g.DrawImage(img, x, y, width, height);
        x -= velocidade; // Move a casa para a esquerda

        // Se a casa sair completamente da tela, reposiciona no lado direito
        if (x + width < 0)
        {
            x = (int)g.VisibleClipBounds.Width;
        }
    }
}
