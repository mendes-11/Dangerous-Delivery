using System.Drawing;

public class ObjBox {

    public RectangleF Box { get; set; }
    
    public void CreateHitbox(float x, float y, float width, float height)
    {
        this.Box = new RectangleF(x, y, width, height);
    }
}