using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="graines")]
public class Seed : Item
{
    [SerializeField] string variety;
    [SerializeField] float growthTime;
    public Sprite[] pousseSprite;
    


    
    public string getVariety()
    {
        return variety;
    }

    public float getGrowthTime ()
    {
        return growthTime;
    }
    
}
