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
                int x = Random.Shared.Next(1, 10 + 1);
                int width = (100 - x) + 2000;
                float verticalSpeed = 1; 
                return new Rain(path, x, width, 900, verticalSpeed);
            })

        );
    }
}
