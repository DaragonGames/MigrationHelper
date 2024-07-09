using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectableItem : Interactable
{
    public string itemName;
    public bool isContainer;
    public GameObject glow;

    void Start()
    {
        if (Inventory.items.Contains(itemName) && !isContainer)
        {
            Destroy(glow);
            Destroy(gameObject);
        }
    }

    public override void Interact() 
    {
        CollectItem(itemName, transform.position);
        if (!isContainer)
        {
            Destroy(glow);
            Destroy(gameObject);
        }
    }



}
