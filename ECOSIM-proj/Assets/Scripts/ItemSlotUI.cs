using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemSlotUI : Selectable, IPointerClickHandler
{
    [SerializeField] protected Image img;
    [SerializeField] protected Text txt;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected GameObject player;
    public int slotIndex;

   
    // abstract function that will be overrided
    public abstract void OnPointerClick(PointerEventData eventData);
}
