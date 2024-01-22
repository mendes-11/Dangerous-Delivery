using System;
using System.IO;
using System.Linq;

public class  SkyLayer: Layer
{
    public SkyLayer(float velocidade) : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("./Image/Sky")
            .Select(path => 
            {
                int y = Random.Shared.Next(30, 70 + 1);
                int height = (50 - y) + 400;
                return new Sky(path, y, 1300, height);
            })
        );
    }
}