using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

public class GameHUD
{
    private string playerName;
    private int pizzaCount = 0;
    private int sushiCount = 0;
    private int hamburgerCount = 0;
    private Font hudFont;

    public GameHUD()
    {
        this.pizzaCount = 0;
        this.sushiCount = 0;
        this.hamburgerCount = 0;
        var pFontCollection = new PrivateFontCollection();
        pFontCollection.AddFontFile("Fonts/BrokenConsole.ttf");
        FontFamily family = pFontCollection.Families[0];
        // hudFont = new Font(family, 14f, FontStyle.Bold);
        hudFont = new Font("Arial", 14, FontStyle.Bold);
    }

    public void Draw(Graphics g)
    {
        Brush brush = Brushes.White;

        g.DrawString("Jogador: " + playerName, hudFont, brush, 10, 10);
        g.DrawString("Pizza: " + pizzaCount + "/5", hudFont, brush, 10, 40);
        g.DrawString("Sushi: " + sushiCount + "/5", hudFont, brush, 10, 70);
        g.DrawString("Hambúrguer: " + hamburgerCount + "/5", hudFont, brush, 10, 100);
    }


    public void Player(string playerName)
    {
        this.playerName = playerName;
    }

    public void IncrementPizzaCount()
    {
        if (pizzaCount < 5)
        {
            pizzaCount++;
        }
    }

    public void IncrementSushiCount()
    {
        if (sushiCount < 5)
        {
            sushiCount++;
        }
    }

    public void IncrementHamburgerCount()
    {
        if (hamburgerCount < 5)
        {
            hamburgerCount++;
        }
    }
}
