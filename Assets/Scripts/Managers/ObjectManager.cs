using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ObjectManager
{
    static ObjectManager()
    {
        sphereList = new List<Transform>();
    }

    static List<Transform> sphereList;
    public static List<Transform> ObjectListCollection
    {
        get
        {
            return sphereList;
        }
    }
    public static Transform ObjectListHead
    {
        get
        {
            return sphereList.Last();
        }
        set
        {
            sphereList.Add(value);
        }
    }

    public static bool IsEmpty
    {
        get
        {
            // Maybe bad?
            return !sphereList.Any();
        }
    }
}
