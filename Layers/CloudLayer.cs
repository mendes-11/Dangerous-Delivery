using System;
using System.IO;
using System.Linq;

public class  CloudLayer: Layer
{
    public CloudLayer(float velocidade) : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("./Image/Cloud")
            .Select(path => 
            {
                float y = Random.Shared.NextSingle() * .3f + .7f;
                return new Cloud(path, 1f - y, 0.30f);
            })
        );
    }
}