using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject prefabObject;
    private GameObject parentObject;
    public string path;
    const float spawnRadius = 20.0f;

    private void Awake()
    {
        prefabObject = Resources.Load(path, typeof(GameObject)) as GameObject;
        parentObject = new GameObject(prefabObject.name + "s");
    }

    void OnMouseDown()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        GameObject gameObject = Instantiate(prefabObject, parentObject.transform);
        SetPosition(ref gameObject, MyMath.GetRandomVector(-spawnRadius, spawnRadius));
        ObjectManager.ObjectListHead = gameObject.transform;
        PathFinder.FindNearestObject();
    }

    void SetPosition(ref GameObject obj, Vector3 pos)
    {
        obj.transform.position = pos;
    }
}
