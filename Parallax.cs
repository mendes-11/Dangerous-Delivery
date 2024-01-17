using System.Collections.Generic;
using System.Drawing;

public class Parallax
{
    public List<BaseLayer> Layers { get; set; } = new();

    public void Draw(Graphics g)
    {
        foreach (var layer in Layers)
            layer.Draw(g);
    }
}