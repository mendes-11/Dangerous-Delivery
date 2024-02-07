using System;
using System.IO;
using System.Linq;

public class  CityLayer: Layer
{
    public CityLayer(float velocidade) : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("./Image/City")
            .Select(path => 
            {
                int height = Random.Shared.Next(230, 310 + 1);
                int y = 500 - height;
                return new City(path, y, 315, height);
            })
        );
    }
}