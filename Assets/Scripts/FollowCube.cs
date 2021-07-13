using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCube : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 70, 0);
    public bool isFollowCube = false;

    public Vector3 Offset
    {
        get;
        set;
    }

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void LateUpdate()
    {
        if (isFollowCube)
            transform.position = player.transform.position + offset;
    }
}
