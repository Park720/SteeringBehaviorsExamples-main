using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMaker : MonoBehaviour
{
    public GameObject flockPrefab;

    public float spawnRadius = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < 25; i++)
        {
            GameObject go = GameObject.Instantiate(flockPrefab);
            Vector3 location = new Vector3(Random.value*spawnRadius,0.5f,Random.value*spawnRadius);
            go.transform.position = location;
           
            go.GetComponentInChildren<Persuer>().persued = player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
