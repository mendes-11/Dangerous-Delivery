using System;
using System.Drawing;
using System.IO;
using System.Linq;

public class CasasLayer : Layer
{
   public CasasLayer(float velocidade) : base(velocidade)
{
    this.Planos.AddRange(
        Directory.GetFiles("./Image/Casas")
        .Select(path => 
        {

            float height = Random.Shared.NextSingle() * .1f + .38f;
            float y =  0.65f - height;
            
            return new Casa(path, y, .28f, height);
        })
    );
}

}
