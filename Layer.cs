using System.Collections.Generic;
using System.Drawing;

public class Layer
{
    public List<IPlano> Planos { get; set; }
    private Queue<IPlano> queue = new();
    public void Draw(Graphics g)
    {

    }

    public void AddPlano(IPlano plano)
        => this.Planos.Add(plano);
}