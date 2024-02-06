using System.Drawing;
using System.Collections.Generic;

public class ObjectsLayers
{
    public List<BaseLayer> Objects { get; set; } = new();

    public void Draw(Graphics g, SizeF size)
    {
        foreach (var objects in Objects)
            objects.Draw(g, size);
    }
}