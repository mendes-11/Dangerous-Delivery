using System.IO;
using System.Linq;

public class  SkyLayer: Layer
{
    public SkyLayer(float velocidade) : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("./Image/Sky")
            .Select(path => new City(path, 0 , 300, 300))
        );
    }
}