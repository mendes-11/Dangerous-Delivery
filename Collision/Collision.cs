using System.Collections.Generic;

public class Collision
{
    private static readonly Collision current = new Collision();
    public static Collision Current => current;

    public List<ObjBox> ObjectsBox { get; private set; }

    private Collision()
    {
        ObjectsBox = new List<ObjBox>();
    }

    public void AddObjBox(ObjBox boxObject)
        => ObjectsBox.Add(boxObject);

    public void RemoveObjBox(ObjBox boxObject)
        => ObjectsBox.Remove(boxObject);
}
