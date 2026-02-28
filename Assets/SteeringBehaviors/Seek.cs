using UnityEngine;
using System.Collections;

public class Seeker : SteeringBehavior {
    Vector3 targetPosition;
    bool unset = true;
    private Rigidbody rb;
    public float tweaker = 1.0f;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetSeekPosition(Vector3 targetPosition)
    {
            this.targetPosition = targetPosition;
            unset = false;
    }

    public override Vector3 CalculateSteeringForce(float maxVelocity)
    {
        if (!unset)
        {
            Vector3 currentPosition = rb.position;
            Vector3 desiredVelocity =
                (targetPosition - currentPosition).normalized * maxVelocity;
            Vector3 result = (desiredVelocity - rb.velocity)*tweaker;
            return result;
        }
        else
        {
            //no force}
            return new Vector3(0, 0, 0);
        }
    }

}