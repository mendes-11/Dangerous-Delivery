using System.IO;
using System.Linq;

public class CalcadasLayer : Layer
{
    public CalcadasLayer(float velocidade)
        : base(velocidade)
    {
        this.Planos.AddRange(
            Directory.GetFiles("./Image/Sidewalk").Select(path => new Calcada(path, 466, 1000, 150))
        );
    }
}
