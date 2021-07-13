using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathFinder
{
    static PathFinder()
    {
        cube = GameObject.Find("Cube").transform;
        closestTarget = new Vector3(0.0f, 0.5f, 0.0f);
    }

    private static KdTree<Transform> objectsPos;
    private static Transform cube;

    private static float closestTargetDistance;
    public static float ClosestTargetDistance
    {
        get
        {
            return closestTargetDistance;
        }
        private set
        {
            closestTargetDistance = value;
        }
    }

    private static Vector3 closestTarget;
    public static Vector3 ClosestTarget
    {
        get
        {
            return closestTarget;
        }
        private set
        {
            closestTarget = value;
        }
    }

    public static void FindNearestObject()
    {
        objectsPos = new KdTree<Transform>();
        objectsPos.AddAll(ObjectManager.ObjectListCollection);
        Vector3 cubePos = cube.transform.position;
        Transform nearestObject = objectsPos.FindClosest(cubePos);
        if (nearestObject != null)
        {
            ClosestTarget = nearestObject.position;
            ClosestTargetDistance = Vector3.Distance(cube.transform.position, ClosestTarget);
        }
        objectsPos.Clear();
    }
}
