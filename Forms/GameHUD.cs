using System;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

public class GameHUD
{
    private string playerName;
    public int pizzaCount = 0;
    public int sushiCount = 0;
    public int sorveteCount = 0;
    public int score = 0;
    public int macarraoCount = 0;
    public int boloCount = 0;
    public int frangoCount = 0;
    private List<PlayerScore> rankings = new List<PlayerScore>();
    private Timer scoreTimer;
    private Font hudFont;

    public GameHUD(Control parent)
    {
        var pFontCollection = new PrivateFontCollection();
        pFontCollection.AddFontFile("Fonts/BrokenConsole.ttf");
        FontFamily family = pFontCollection.Families[0];
        // hudFont = new Font(family, 14f, FontStyle.Bold);
        hudFont = new Font("Arial", 14, FontStyle.Bold);

        scoreTimer = new Timer();
        scoreTimer.Interval = 1000;
        scoreTimer.Tick += ScoreTimer_Tick;
        scoreTimer.Start();
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
        g.DrawString("Score: " + score, hudFont, brush, 700, 10);
    }

    public void Player(string playerName)
    {
        this.playerName = playerName;
    }

    private void ScoreTimer_Tick(object sender, EventArgs e)
    {
        score++;
    }

    public void SaveRankingsToFile(string filePath)
    {
        var jsonString = JsonConvert.SerializeObject(rankings, Formatting.Indented);
        File.WriteAllText(filePath, jsonString);
    }

    public void LoadRankingsFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            var jsonString = File.ReadAllText(filePath);
            rankings = JsonConvert.DeserializeObject<List<PlayerScore>>(jsonString);
        }
    }

    public void UpdateRanking(string playerName, int score)
    {
        var player = rankings.Find(p => p.Name == playerName);
        if (player != null)
        {
            if (player.Score < score)
            {
                player.Score = score;
            }
        }
        else
        {
            rankings.Add(new PlayerScore(playerName, score));
        }
    }

    public List<PlayerScore> GetSortedRankings()
    {
        rankings.Sort((x, y) => y.Score.CompareTo(x.Score));
        return rankings;
    }

    public void Save()
    {
        UpdateRanking(this.playerName, this.score);
        SaveRankingsToFile("rankings.json");
    }

    public void IncrementFoodScore() => score += 5;

    public void IncrementPizzaCount() => pizzaCount++;

    public void IncrementSushiCount() => sushiCount++;

    public void IncrementSorveteCount() => sorveteCount++;

    public void IncrementMacarraoCount() => macarraoCount++;

    public void IncrementBoloCount() => boloCount++;

    public void IncrementFrangoCount() => frangoCount++;

    public void DecrementFoodScore() => score += 10;

    public void DecrementPizzaCount() => pizzaCount--;

    public void DecrementSushiCount() => sushiCount--;

    public void DecrementSorveteCount() => sorveteCount--;

    public void DecrementMacarraoCount() => macarraoCount--;

    public void DecrementBoloCount() => boloCount--;

    public void DecrementFrangoCount() => frangoCount--;
}
