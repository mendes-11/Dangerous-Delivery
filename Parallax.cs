using System.Drawing;
using System.Collections.Generic;

public class Parallax
{
    public List<BaseLayer> Layers { get; set; } = new();

    public void Draw(Graphics g, SizeF size)
    {
        foreach (var layer in Layers)
            layer.Draw(g, size);
    }
}