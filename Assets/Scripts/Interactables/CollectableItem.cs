using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectableItem : Interactable
{
    public string itemName;
    public bool isContainer;

    void Start()
    {
        if (Inventory.items.Contains(itemName) && !isContainer)
        {
            Destroy(gameObject);
        }
    }

    public override void Interact() 
    {
        CollectItem(itemName);
        if (!isContainer)
        {
            Destroy(gameObject);
        }
    }



}
