using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : SteeringBehavior
{
    private Seeker seeker;
    private Arriver arriver;
    public Rigidbody rb;
    public float targetDistance = 1.0f;
    private Queue<Vector3> pathQueue = new Queue<Vector3>();
    private Vector3 currentTarget;
    
    private SteeringBehavior currentBehavior=null;
    
    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        seeker = gameObject.AddComponent<Seeker>();
        seeker.enabled = false;
        seeker.tweaker = 3.0f;
        arriver = gameObject.AddComponent<Arriver>();
        arriver.enabled = false;
        arriver.decelerationConstant = 3;
    }

    public void AddDestination(Vector3 destination)
    {
        pathQueue.Enqueue(destination);
        if (currentBehavior == null)
        {
            seeker.SetSeekPosition(destination);
            currentTarget = destination;
            currentBehavior = seeker;   
        }
        else
        {
            pathQueue.Enqueue(destination);
        }
        
    }

    public void nextBehavior()
    {
        if (pathQueue.Count > 0)
        {
            currentTarget = pathQueue.Dequeue();
            if (pathQueue.Count > 0)
            {
                //have more after dequeue
                currentBehavior = seeker;
                seeker.SetSeekPosition(currentTarget);
                Debug.Log($"Seeking to {currentTarget}");
            }
            else
            {
               
                //last point, use arrival
                currentBehavior = arriver;
                arriver.SetArrivalPosition(currentTarget);
                Debug.Log($"arriving at S {currentTarget}");
            }
        }
    }

    public override Vector3 CalculateSteeringForce(float maxVelocity)
    {
        Vector3 result;
        if (currentBehavior != null)
        {
            result = currentBehavior.CalculateSteeringForce(maxVelocity);
        }
        else
        {
            result = Vector3.zero;
        }

        if ((rb.position - currentTarget).magnitude <= targetDistance)
        {
            nextBehavior();
        }

        return result;
    }
}