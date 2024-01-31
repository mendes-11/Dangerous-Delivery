using System;
using System.Drawing;

public class SkyLayer : BaseLayer
{
    DateTime start = DateTime.Now;

    public override void Draw(Graphics g)
    {
        var time = DateTime.Now - start;
        var secs = (float)time.TotalSeconds;
        var factor = (MathF.Cos(secs * 0.1f) + 1) / 2;

        float[][] colors = new float[][]
        {
        new float[] {200, 50, 95},  
        new float[] {199, 100, 3},
        // new float[] {200, 94, 18},
        // new float[] {240, 94, 10},
        // new float[] {280, 50, 25}
        };

        int currentTransition = (int)(factor * (colors.Length - 1));
        int nextTransition = (currentTransition + 1) % colors.Length;

        float[] currentColor = colors[currentTransition];
        float[] nextColor = colors[nextTransition];

        float hue = Calc(nextColor[0], currentColor[0], factor);
        float saturation = Calc(nextColor[1], currentColor[1], factor);
        float value = Calc(nextColor[2], currentColor[2], factor);

        g.Clear(
             hsvToColor(255 * 200 / 360, (int)(255 * saturation / 100), (int)(255 * value / 100))
        );
    }

    private float Calc(float start, float end, float factor)
    {
        return start + (end - start) * factor;
    }

    private Color hsvToColor(int h, int s, int v)
    {

        h = Math.Max(0, Math.Min(360, h));
        s = Math.Max(0, Math.Min(255, s));
        v = Math.Max(0, Math.Min(255, v));

        int r = 0,
            g = 0,
            b = 0;

        if (s == 0)
        {
            r = v;
            g = v;
            b = v;
            return Color.FromArgb(LimitColor(r), LimitColor(g), LimitColor(b));
        }

        int region = h / 43;
        int remainder = (h - (region * 43)) * 6;

        int p = (v * (255 - s)) >> 8;
        int q = (v * (255 - ((s * remainder) >> 8))) >> 8;
        int t = (v * (255 - ((s * (255 - remainder)) >> 8))) >> 8;

        switch (region)
        {
            case 0:
                r = v;
                g = t;
                b = p;
                break;
            case 1:
                r = q;
                g = v;
                b = p;
                break;
            case 2:
                r = p;
                g = v;
                b = t;
                break;
            case 3:
                r = p;
                g = q;
                b = v;
                break;
            case 4:
                r = t;
                g = p;
                b = v;
                break;
            default:
                r = v;
                g = p;
                b = q;
                break;
        }

        return Color.FromArgb(LimitColor(r), LimitColor(g), LimitColor(b));
    }

    private byte LimitColor(int value)
    {
        return (byte)Math.Max(0, Math.Min(255, value));
    }
}