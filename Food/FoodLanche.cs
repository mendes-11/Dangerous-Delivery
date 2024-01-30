using System;
using System.IO;
using System.Linq;

public class  FoodLanche: Food
{
    public FoodLanche()
    {
        this.Lanches.AddRange(
            Directory.GetFiles("./Image/Food")
            .Select(path => 
            {
                int y = Random.Shared.Next(735, 950);
                Lanche lanche = new Lanche(path, y);
                lanche.Type = ExtractFoodTypeFromPath(path);
                return lanche;
            })
        );
    }

    private string ExtractFoodTypeFromPath(string path)
    {
        string fileName = Path.GetFileNameWithoutExtension(path).ToLower();
        if (fileName.Contains("1") || fileName.Contains("2") || fileName.Contains("3")) return "pizza";
        if (fileName.Contains("4") || fileName.Contains("5") || fileName.Contains("6")) return "sushi";
        return null;
    }
}