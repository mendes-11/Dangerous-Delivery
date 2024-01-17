using System.IO;
using System.Linq;

public class CasasLayer : Layer
{
    public CasasLayer(float velocidade) : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("../Image/Casas")
            .Select(path => new Calcada(path, 250, 300, 200))
        );
    }
}