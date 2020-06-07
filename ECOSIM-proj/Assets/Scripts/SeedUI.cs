using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SeedUI : ItemSlotUI
{    
    [SerializeField] Text nbrUI;

    public ItemSlot itemSlotSelected;
    public Case farmTile;

    new void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        slotIndex = transform.GetSiblingIndex();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        UpdateSlotsSeed();
    }

    //will be used to plant or to buy seeds
    public override void OnPointerClick(PointerEventData eventData)   // this is a right click
    {
        if(!player.GetComponent<Farmer>().besace.gameObject.transform.GetChild(0).GetChild(2).gameObject.activeSelf) // if market is closed
        {
            farmTile = player.GetComponent<Farmer>().targetedCase;
            if (farmTile.seed == null) // we wheck wheteher there is already a seed in the case
            {
                if (eventData.button == PointerEventData.InputButton.Left) //on left click
                {
                    itemSlotSelected = inventory.slots[slotIndex];
                    if (itemSlotSelected.item is Seed && itemSlotSelected.quantity > 0)
                    {
                        farmTile.plantSeed((Seed)itemSlotSelected.item); // we plant
                        itemSlotSelected.quantity -= 1; // we decrease the quantity in the inventory
                        farmTile = null; // remove the target
                        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Farmer>().closeBesace(); // close the besace
                        UpdateSlotsSeed();
                    }
                }
            }
        }
        else // we want to trade the seeds 
        {
            UpdateMarketSeeds();
            if (eventData.button == PointerEventData.InputButton.Left) //on left click
            {
                itemSlotSelected = inventory.slots[slotIndex];
                if(slotIndex > 0)
                {
                    if(inventory.vegSlot[slotIndex - 1].quantity > 0)
                    {
                        itemSlotSelected.quantity += 1;
                        inventory.vegSlot[slotIndex - 1].quantity -= 1;
                    }
                    else { Debug.Log("No more " + inventory.vegSlot[slotIndex - 1].item.name + " in your bag"); }
                }
                UpdateSlotsSeed();
            }
        }
        
    }
    // Update is called once per frame
    void UpdateSlotsSeed()
    {
        img.sprite = inventory.slots[slotIndex].item.icon;
        txt.text = inventory.slots[slotIndex].item.name;   // text.text  to access the text of the object Text 
        nbrUI.text = inventory.slots[slotIndex].quantity.ToString();     // to show the numbers of element in each ItemSlot
    }


   void UpdateMarketSeeds()
    {
        img.sprite = inventory.slots[slotIndex].item.icon;
        txt.text = inventory.slots[slotIndex].item.name;
        nbrUI.text = null;
    }
}
