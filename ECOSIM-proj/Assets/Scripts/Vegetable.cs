using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "legumes")]
public class Vegetable : Item
{
   [SerializeField] string variety;

    public void init(string variete, Sprite spr)
    {
        variety = variete;
        icon = spr;
    }

    public string getVariety()
    {
        return variety;
    }
}
