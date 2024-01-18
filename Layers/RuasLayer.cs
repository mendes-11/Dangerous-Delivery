using System.Drawing;

public class RuasLayer : BaseLayer
{
    public override void Draw(Graphics g)
    {
        Brush street = new SolidBrush(Color.FromArgb(21, 33, 55));
        Brush streetLaneYellow = new SolidBrush(Color.FromArgb(226, 149, 37));
        Brush streetLaneWhite = new SolidBrush(Color.FromArgb(220, 239, 226));

        g.FillRectangle(street, 0, 724, g.VisibleClipBounds.Width, 294);
        // g.FillRectangle(streetLaneYellow, -1, 840, 150, 6);
        // g.FillRectangle(streetLaneYellow, 300, 840, 150, 6);
        // g.FillRectangle(streetLaneYellow, 600, 840, 150, 6);
        // g.FillRectangle(streetLaneYellow, 900, 840, 150, 6);
        // g.FillRectangle(streetLaneYellow, 1200, 840, 150, 6);
        // g.FillRectangle(streetLaneYellow, 1500, 840, 150, 6);
        // g.FillRectangle(streetLaneYellow, 1800, 840, 150, 6);
        g.FillRectangle(streetLaneWhite, 0, 730, g.VisibleClipBounds.Width, 6);
        g.FillRectangle(streetLaneWhite, 0, 1005, g.VisibleClipBounds.Width, 6);
    }
}
