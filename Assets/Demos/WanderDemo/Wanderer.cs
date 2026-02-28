using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        SteeringObject so = GetComponent<SteeringObject>();
        Wander wander = so.GetComponent<Wander>();
        if (wander == null)
        {
            wander = so.gameObject.AddComponent<Wander>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}