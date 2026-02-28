using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSeeker : MonoBehaviour
{
    // Start is called before the first frame update
    private Seeker seeker;
    private Breaker breaker;
    public float breakingForce = 0;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        SteeringObject so = GetComponent<SteeringObject>();
        seeker = so.GetComponent<Seeker>();
        if (seeker == null)
        {
            seeker = so.gameObject.AddComponent<Seeker>();
        }
        
        if (breakingForce > 0)
        {
            breaker = so.GetComponent<Breaker>();
            if (breaker == null)
            {
                breaker = so.gameObject.AddComponent<Breaker>();
            }
            breaker.breakingForce = breakingForce;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(
                Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                seeker.SetSeekPosition(hit.point);
            }
        }
        
    }
}