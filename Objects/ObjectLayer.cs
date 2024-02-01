using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

public class ObjectLayer : ObjectCollision
{
    public ObjectLayer(float velocidade)
        : base(velocidade)
    {
        List<Image> frames = new List<Image>();
        string[] imagePaths = Directory.GetFiles("./Image/Pneu");

        foreach (string imagePath in imagePaths)
        {
            frames.Add(Image.FromFile(imagePath));
        }
        Object obj = new Object(frames, 700);
        Objects.Add(obj);
    }
}
