using System;
using System.IO;
using System.Linq;

public class  SlumLayer: Layer
{
    public SlumLayer(float velocidade) : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("./Image/Favelas")
            .Select(path => 
            {
                int height = Random.Shared.Next(170, 220 + 1);
                int y = 380 - height;
                return new Casa(path, y, 390, height);
            })
        );
    }
}