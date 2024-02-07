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

            int height = Random.Shared.Next(180, 250 + 1);
            int y =  353 - height;
            
            return new Casa(path, y, 490, height);
        })
    );
}

}
