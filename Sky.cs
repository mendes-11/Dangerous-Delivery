using System.Drawing;

public class Sky : IPlano
{
    public float Width { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
        g.Clear(Color.SkyBlue);
    }
}