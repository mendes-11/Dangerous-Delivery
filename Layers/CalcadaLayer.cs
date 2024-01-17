using System.IO;
using System.Linq;

public class calcadasLayer : Layer
{
    public calcadasLayer(float velocidade) : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("Image/SideWalk")
            .Select(path => new Calcada(path, 426, 1000, 300))
        );
    }
}