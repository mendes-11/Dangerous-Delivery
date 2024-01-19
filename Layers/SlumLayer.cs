using System.IO;
using System.Linq;

public class  SlumLayer: Layer
{
    public SlumLayer(float velocidade) : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("./Image/Favelas")
            .Select(path => new Slum(path, 330, 330, 500))
        );
    }
}