using System.Drawing;

public class GameHUD
{
    private string playerName;
    private int pizzaCount;
    private int sushiCount;
    private int hamburgerCount;
    private Font hudFont;

    public GameHUD(string playerName)
    {
        this.playerName = playerName;
        this.pizzaCount = 0;
        this.sushiCount = 0;
        this.hamburgerCount = 0;

        hudFont = new Font("Broken Console", 14, FontStyle.Bold);
    }

    public void Draw(Graphics g)
    {
        
        Brush brush = Brushes.White;

        g.DrawString("Jogador: " + playerName, hudFont, brush, 10, 10);
        g.DrawString("Pizza: " + pizzaCount + "/5", hudFont, brush, 10, 40);
        g.DrawString("Sushi: " + sushiCount + "/5", hudFont, brush, 10, 70);
        g.DrawString("Hambúrguer: " + hamburgerCount + "/5", hudFont, brush, 10, 100);
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
