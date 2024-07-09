using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour
{
    protected bool selected;
    public float reach = 1;

    public GameObject collectEffectPrefab;
    public GameObject collectTextPrefab;

    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = false;
        }
        if (selected)
        {
            Vector3 positionUsed = new Vector3(transform.position.x,0,transform.position.z);
            Vector3 goalUsed = new Vector3(GameManager.player.transform.position.x,0,GameManager.player.transform.position.z);

            float distance = Vector3.Distance(positionUsed, goalUsed) -reach;
            if (distance <= 0)
            {
                Interact();
                selected = false;
            }
        }
    }

    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonUp(0))
        {
            selected = true;
        }
    }

    public void CollectItem(string itemName, Vector3 position)
    {
        Inventory.items.Add(itemName);

        GameObject obj = Instantiate(collectEffectPrefab, position, Quaternion.identity);
        obj.GetComponent<ItemCollectEffect>().SetPosition(position, itemName);

        
        string displayMessage = "Collected: " + TextHandler.englishItemNames[itemName];
        CreatePopUpMessage(displayMessage);
    }

    public void CreatePopUpMessage(string message) 
    {
        GameObject obj = Instantiate(collectTextPrefab, new Vector3(0,0,0), Quaternion.identity);
        obj.GetComponentInChildren<PopUpText>().SetDisplayName(message);
    }

    public void DelayedItemColletion(string itemName, float delay, Vector3 position)
    {
        StartCoroutine(CollectItemTimed(itemName, delay, position));
    }

    IEnumerator CollectItemTimed(string itemName, float delay, Vector3 position)
    {
        yield return new WaitForSeconds(delay);
        CollectItem(itemName, position);
    }

    public virtual void Interact() {}

}
