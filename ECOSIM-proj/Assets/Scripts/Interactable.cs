using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Class which cases object and market will derive from

    public float radius = 1.5f; 
    public Transform player;       // Reference to the player transform
    [SerializeField] float distance;

    public bool isInteractable()
    {
        distance = Vector2.Distance(player.position, transform.position);

        if (distance < radius)
        {
            return true;
        }
        else return false;
        
    }

    protected void  Start()
    {
        if (player == null)
        {
            // we make sure to get the player's transform
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

}
