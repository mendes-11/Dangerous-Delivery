using System;
using System.IO;
using System.Linq;

public class  RuasLayer: Layer
{
    public RuasLayer(float velocidade) : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("./Image/Street")
            .Select(path =>
            {
                float height = .3f;
                float y = 1.005f - height;
                return new Rua(path, y, .72f, height);


            })
        );
    }
}