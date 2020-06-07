using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemSlot[] slots;
    public ItemSlot[] vegSlot;

    public void endOfGame()
    {
        int i = 0;
        foreach(ItemSlot itm in vegSlot)
        {
            if(itm.quantity >= 10) { i++; }
        }
        if(i > 4) { GameObject.FindGameObjectWithTag("Player").GetComponent<Farmer>().win(); }
    }

    private void Update()
    {
        endOfGame();
    }
}
