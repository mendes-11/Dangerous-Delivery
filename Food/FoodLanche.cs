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
                return new Lanche(path, y);
            })
        );
    }
}