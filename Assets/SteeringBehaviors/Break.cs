using UnityEngine;

public class Breaker : SteeringBehavior
{
    public Rigidbody rb;
    public float breakingForce;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override Vector3 CalculateSteeringForce(float maxVelocity)
    {
        // 1. If we aren't moving, don't apply any force
        if (rb.velocity.magnitude < 0.01f)
        {
            return Vector3.zero;
        }

        // 2. Calculate a force that points exactly opposite to current velocity
        // We normalize the velocity to get the direction, then scale by breakingForce
        Vector3 reverseForce = -rb.velocity.normalized * breakingForce;

        // 3. Return the force
        return reverseForce;
    }
}