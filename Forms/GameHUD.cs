using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

public class GameHUD
{
    private string playerName;
    public int pizzaCount = 0;
    public int sushiCount = 0;
    public int sorveteCount = 0;
    public int macarraoCount = 0;
    public int boloCount = 0;
    public int frangoCount = 0;
    private Font hudFont;

    public GameHUD(Control parent)
    {
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
        g.DrawString("Frango: " + frangoCount + "/5", hudFont, brush, 10, 100);
        g.DrawString("Macarrão: " + macarraoCount + "/5", hudFont, brush, 10, 130);
        g.DrawString("Bolo: " + boloCount + "/5", hudFont, brush, 10, 160);
        g.DrawString("Sorvete: " + sorveteCount + "/5", hudFont, brush, 10, 190);
    }

    public void Player(string playerName)
    {
        this.playerName = playerName;
    }

    public void IncrementPizzaCount() => pizzaCount++;
    public void IncrementSushiCount() => sushiCount++; 
    public void IncrementSorveteCount() => sorveteCount++; 
    public void IncrementMacarraoCount() => macarraoCount++; 
    public void IncrementBoloCount() => boloCount++;
    public void IncrementFrangoCount() => frangoCount++;
    public void DecrementPizzaCount() => pizzaCount--;
    public void DecrementSushiCount() => sushiCount--;
    public void DecrementSorveteCount() => sorveteCount--;
    public void DecrementMacarraoCount() => macarraoCount--;
    public void DecrementBoloCount() => boloCount--; 
    public void DecrementFrangoCount() => frangoCount--; 
    
}
