using System.Drawing;
using System.Collections.Generic;

public class Object : ObjBox
{
    protected List<Image> animationFrames;
    protected int currentFrameIndex = 0;
    public float X;
    public float Y;
    public float Width;
    public float Height;
    public string Type { get; set; }
    public override RectangleF Box { get; set; }

    public Object(List<Image> frames, float y)
    {
        this.Y = y;
        animationFrames = frames;
        Width = animationFrames[0].Width;
        Height = animationFrames[0].Height;
    }

    public void Draw(Graphics g)
    {
        Image currentFrame = animationFrames[currentFrameIndex];
        g.DrawImage(currentFrame, X, Y, Width, Height);
        CreateHitbox(X, Y, Width, Height);
        g.DrawRectangle(Pens.Red, Box);
        Collision.Current.AddObjBox(this);
    }

    public void UpdateAnimation()
    {
        currentFrameIndex = (currentFrameIndex + 1) % animationFrames.Count;
    }
}
