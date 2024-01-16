using System.Drawing;

public class Sky : IPlano
{
    public void Draw(Graphics g, DrawPlanoParameters parameters)
    {
        g.Clear(Color.SkyBlue);
    }
}