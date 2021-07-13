using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyMath
{
    public static Vector3 GetRandomVector(float minRange, float maxRange)
    {
        float randomX = Random.Range(minRange, maxRange);
        float randomZ = Random.Range(minRange, maxRange);
        Vector3 vec = new Vector3(randomX, 0.5f, randomZ);

        return vec;
    }
}
