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
                float height = Random.Shared.NextSingle() * .05f + .25f;
                float y = 0.655f - height;
                return new Casa(path, y, 0.15f, height);
            })
        );
    }
}