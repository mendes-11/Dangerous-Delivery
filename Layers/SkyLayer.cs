using System;
using System.Drawing;

public class SkyLayer: BaseLayer
{
    DateTime start = DateTime.Now;
    public override void Draw(Graphics g)
    {
        var time = DateTime.Now - start;
        var secs = (float)time.TotalSeconds;
        var factor = (MathF.Cos(secs) + 1) / 2;

        float saturation = 31; // ??
        float value = 95; // ??

        g.Clear(hsvToColor(255 * 200 / 360, (int)(255 * saturation / 100), (int)(255 * value / 100)));
    }

    private Color hsvToColor(int h, int s, int v)
    {
        int r = 0, g  = 0, b = 0;
        if (s == 0)
        {
            r = v;
            g = v;
            b = v;
            return Color.FromArgb(r, g, b);
        }
        
        int region = h / 43;
        int remainder = (h - (region * 43)) * 6; 
        
        int p = (v * (255 - s)) >> 8;
        int q = (v * (255 - ((s * remainder) >> 8))) >> 8;
        int t = (v * (255 - ((s * (255 - remainder)) >> 8))) >> 8;
        
        switch (region)
        {
            case 0:
                r = v; g = t; b = p;
                break;
            case 1:
                r = q; g = v; b = p;
                break;
            case 2:
                r = p; g = v; b = t;
                break;
            case 3:
                r = p; g = q; b = v;
                break;
            case 4:
                r = t; g = p; b = v;
                break;
            default:
                r = v; g = p; b = q;
                break;
        }
        
        return Color.FromArgb(r, g, b);
    }
}