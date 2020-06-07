using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VegUI : ItemSlotUI
{
    [SerializeField] Text timeLeft;
    public int vegSlotIndex;
    public Case farmTile;
    new void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        vegSlotIndex = transform.GetSiblingIndex();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();   
        UpdateNull();
    }
    void Update()
    {
        interactable = !player.GetComponent<Farmer>().interactForUI; // to disable the button while shopping (market)
        if(interactable)
        {
            farmTile = player.GetComponent<Farmer>().targetedCase;
            if (farmTile != null && farmTile.seed != null)
            {
                UpdateSlot(farmTile);         
            }
            if (farmTile == null)
            {
                UpdateNull();
            }
        } 
        else { UpdateMarket(); }
    }
   public void UpdateMarket()
    {
        txt.text = inventory.vegSlot[vegSlotIndex].item.name;
        img.sprite = inventory.vegSlot[vegSlotIndex].item.icon;
        timeLeft.text = inventory.vegSlot[vegSlotIndex].quantity.ToString();
    }
    public void UpdateSlot(Case c)
    {
        txt.text = c.seed.getVariety();
        img.sprite = c.seed.icon;
        if (c.seed.getGrowthTime() - c.actualTime > 0)
        {
            timeLeft.text = ((int)(c.seed.getGrowthTime() - c.actualTime)).ToString() + " sec";
        }
        else timeLeft.text = "Click to harvest "+ c.seed.getVariety();
    }
    public void UpdateNull()
    {
        txt.text = null;
        img.sprite = null;
        timeLeft.text = null;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if(interactable)
        {
            if (farmTile.readyToHarvest)
            {
                Debug.Log("harvest");
                foreach (ItemSlot itm in inventory.vegSlot)
                {
                    if (itm.item.name == farmTile.seed.getVariety())
                    {
                        itm.quantity++;
                    }
                }
                farmTile.harvest();
                UpdateMarket();
                player.GetComponent<Farmer>().closeBesace();
            }
        }
    }
}
