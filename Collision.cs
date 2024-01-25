using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Collision
{
    private static Collision current;
    public static Collision Current => current;
    public List<ObjBox> objectsBox { get; private set; }
    private Collision()
    {
        objectsBox = new List<ObjBox>();
        current = this;
    }
    public void AddObjBox(ObjBox boxObject)
        => this.objectsBox.Add(boxObject);

    public void RemoveObgBox(ObjBox boxObject)
        => this.objectsBox.Remove(boxObject);
}
