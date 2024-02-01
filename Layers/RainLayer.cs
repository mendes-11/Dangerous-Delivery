using System;
using System.IO;
using System.Linq;

public class RainLayer : Layer
{  
    public RainLayer(float velocidade) : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("./Image/Rain")
            .Select(path =>
            {
                return new Rain(path, -1100, 2000, 1000, velocidade);
            })

        );
    }

  
}



