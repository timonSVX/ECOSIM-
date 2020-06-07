using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : Interactable
{
    public bool readyToHarvest = false;
    public Seed seed = null;
    public float actualTime = 0f;
    [SerializeField] float newTime;
    [SerializeField] int ind;


    new void Start()
    {
        base.Start();
       // transform.GetComponent<SpriteRenderer>().sortingOrder = -(int)Mathf.Pow(transform.position.y, 2); // so the closest case in y is in front of the others
        //transform.GetComponentInChildren<SpriteRenderer>().sortingOrder = -(int)Mathf.Pow(transform.position.y, 2); ;  // for the plant
        transform.GetComponent<SpriteRenderer>().sortingOrder = -(int)(4*transform.position.y); // so the closest case in y is in front of the others
        transform.GetComponentInChildren<SpriteRenderer>().sortingOrder = -(int)(4*transform.position.y);  // for the plant
    }
    void Update()
    {
        growVeg();
    }
    public void plantSeed(Seed s)
    {
        seed = s;
        Debug.Log("on plante " + seed.name);
    }

    public void growVeg()
    {
        if(seed != null)
        {
            if (actualTime < seed.getGrowthTime())
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = seed.pousseSprite[ind];
                actualTime += Time.deltaTime;
                newTime += Time.deltaTime;
                if(newTime > (seed.getGrowthTime()/3)-0.1)  // -0.1 is to be sure that we reach the 3rd stage before (actualTime < seed.getGrowthTime())
                {
                    ind++;
                    newTime = 0f; 
                }
            }
            readyToHarvest = true;
        }
    }
  
   
    public void harvest()
    {
        if (seed != null && readyToHarvest)
        {
            seed = null;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
            readyToHarvest = false;
            actualTime = 0f;
            ind = 0;
        }
    }
   
}

