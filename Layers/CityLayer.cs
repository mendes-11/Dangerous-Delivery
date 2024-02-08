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
                float height = Random.Shared.NextSingle() * .1f + .42f;
                float y = 0.655f - height;
                return new City(path, y, .20f, height);
            })
        );
    }
}