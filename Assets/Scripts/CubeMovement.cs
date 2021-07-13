using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private float rotateVelocity = 0.0f;
    private float velocity = 0.0f;
    private float Velocity
    {
        get
        {
            return velocity;
        }
        set
        {
            if (value <= speed)
            {
                velocity = value;
            }
            else
            {
                velocity = speed;
            }
        }
    }
    [SerializeField]
    private float speed;
    public float Speed
    {
        get
        {
            return speed * Time.deltaTime;
        }
        set
        {
            speed = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObjectManager.IsEmpty)
        {
            MoveToPosByAngle(PathFinder.ClosestTarget);
        }
        else if(velocity != 0.0f)
        {
            StopMoving();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            ObjectManager.ObjectListCollection.Remove(collision.gameObject.transform);
            Destroy(collision.gameObject);
            ParticleManager.PlayRandomParticle(collision.gameObject.transform);
            ScoreManager.AddPoints();
            PathFinder.FindNearestObject();
            rotateVelocity = 0.0f;
        }
    }

    void MoveToPosInAnyDirection(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Speed);
    }
    void MoveToPosByAngle(Vector3 target)
    {
        RotateToTarget(target);
        MoveToTarget(target);
    }
    void RotateToTarget(Vector3 target)
    {
        target.y = transform.position.y;
        Quaternion rotateTarget = Quaternion.LookRotation(target - transform.position);
        rotateVelocity = Mathf.Lerp(rotateVelocity, 3.0f, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotateTarget, rotateVelocity * Time.deltaTime);
    }
    void MoveToTarget(Vector3 target)
    {
        float curDist = Vector3.Distance(transform.position, target);
        Velocity = Mathf.Lerp(velocity, curDist, Time.deltaTime);
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
    void StopMoving()
    {
        Velocity = Mathf.Lerp(velocity, 0.0f, Time.deltaTime);
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
}
