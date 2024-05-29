using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour
{
    private bool selected;
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

    public void CollectItem(string itemName)
    {
        Inventory.items.Add(itemName);

        GameObject obj = Instantiate(collectEffectPrefab, transform.position, Quaternion.identity);
        obj.GetComponent<ItemCollectEffect>().SetPosition(transform.position, itemName);

        obj = Instantiate(collectTextPrefab, new Vector3(0,0,0), Quaternion.identity);
        obj.GetComponentInChildren<ItemCollectText>().SetDisplayName(itemName);
    }

    public void DelayedItemColletion(string itemName, float delay)
    {
        StartCoroutine(CollectItemTimed(itemName, delay));
    }

    IEnumerator CollectItemTimed(string itemName, float delay)
    {
        yield return new WaitForSeconds(delay);
        CollectItem(itemName);
    }

    public virtual void Interact() {}

}
