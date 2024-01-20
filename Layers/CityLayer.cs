using System.IO;
using System.Linq;

public class  CityLayer: Layer
{
    public CityLayer(float velocidade) : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("./Image/City")
            .Select(path => new City(path, 200 , 330, 500))
        );
    }
}