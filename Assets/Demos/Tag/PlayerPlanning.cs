using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlanning : MonoBehaviour
{
    private TagPlayer tagPlayer;
    private Persue playerPursue;
    private GameObject lockedTarget;
    private Evade playerEvade;

    void Awake()
    {
        tagPlayer = GetComponent<TagPlayer>();
        playerPursue = GetComponent<Persue>();
        playerEvade = GetComponent<Evade>();
    }

    void Update()
    {
        if (tagPlayer.isIt)
        {
            // if it pursue the closest target
            if (playerEvade) playerEvade.enabled = false; //check and disable evade
            if (playerPursue)
            {
                playerPursue.enabled = true; 
                lockedTarget = FindClosestTarget(); //target lock closet target to pursue
                if (lockedTarget != null) //if there is a target
                    playerPursue.target = lockedTarget; //set target to pursue
            }
        }else
        {
            // if not it evade from the it 
            if (playerPursue) playerPursue.enabled = false; //check and disable pursue
            if (playerEvade)
            {
                playerEvade.enabled = true; 
                GameObject itTarget = FindItTarget(); //find the it target to evade from
                if (itTarget != null) //if there is an it target
                    playerEvade.target = itTarget; //set target to evade from
            }
        }

    }

    GameObject FindClosestTarget() //find the closest target to pursue
    {
        TagOpponent[] opponents = FindObjectsOfType<TagOpponent>();
        GameObject nearest = null;
        float minDist = float.MaxValue;

        foreach (TagOpponent op in opponents)
        {
            float dist = Vector3.Distance(transform.position, op.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = op.gameObject;
            }
        }
        return nearest; 
    }

    GameObject FindItTarget() //find the it target to evade from
    {
        TagOpponent[] opponents = FindObjectsOfType<TagOpponent>();
        foreach (TagOpponent op in opponents) 
        {
            if (op.isIt) return op.gameObject; //if opponent is it return that target to evade from
        }
        return FindClosestTarget(); //if no it target found return the closest target to evade from
    }
}