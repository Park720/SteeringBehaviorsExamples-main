using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAvoider : MonoBehaviour
{
    // Start is called before the first frame update
    private Seeker seeker;
    private ObstacleAvoider avoider;
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
        
        avoider = so.GetComponent<ObstacleAvoider>();
        if (avoider == null)
        {
            avoider = so.gameObject.AddComponent<ObstacleAvoider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("GOT CLICK");
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