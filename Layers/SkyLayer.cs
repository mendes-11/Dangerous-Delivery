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

        float initialSaturation = 50;
        float initialValue = 95;

        float finalSaturation = 94;
        float finalValue = 18;

        float saturation = Interpolate(finalSaturation, initialSaturation, factor);
        float value = Interpolate(finalValue, initialValue, factor);

        g.Clear(
            hsvToColor(255 * 200 / 360, (int)(255 * saturation / 100), (int)(255 * value / 100))
        );
    }

    private float Interpolate(float start, float end, float factor)
    {
        return start + (end - start) * factor;
    }

    private Color hsvToColor(int h, int s, int v)
    {
        // Garantindo que os valores de entrada estejam nos limites esperados
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
            return Color.FromArgb(ClampToByte(r), ClampToByte(g), ClampToByte(b));
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

        // Usando ClampToByte para garantir que os valores de r, g e b estejam entre 0 e 255
        return Color.FromArgb(ClampToByte(r), ClampToByte(g), ClampToByte(b));
    }

    // Método auxiliar para garantir que os valores de cor estejam dentro do intervalo de byte (0-255)
    private byte ClampToByte(int value)
    {
        return (byte)Math.Max(0, Math.Min(255, value));
    }
}
