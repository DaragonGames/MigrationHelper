using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public Sprite selectedSprite;
    public static List<String> items = new List<String>(){ "visa", "passport"};
    private string selectedItem ="";
    public void ToggleUI() 
    {
        gameObject.SetActive(!gameObject.activeSelf);
        selectedItem ="";
        SetItemSprites();
    }
    public void CloseUI() 
    {
        selectedItem ="";
        gameObject.SetActive(false);
    }

    public void UseItem()
    {
        // Give the enemy the item string
        if (selectedItem == "")
        {
            return;
        }
        else {
            Enemy.Instance.Receive(selectedItem);
            gameObject.SetActive(false);
        }
    }  

    public void SelectItem(int index)
    {
        if(index >= items.Count)
        {
            selectedItem = "";
            ResetInfo();
        }
        else
        {
            selectedItem = items[index];
            SetInfo();
        }        
    } 

    public void SetItemSprites()
    {
        SpriteState selectableState = new SpriteState
        {
            selectedSprite = selectedSprite,
            pressedSprite = selectedSprite
        };

        for (int i = 0;i<items.Count; i++)
        {
            Transform button = transform.GetChild(i+1);
            button.GetChild(0).GetComponent<Image>().sprite = ItemSpriteManager.list[items[i]];
            button.GetComponent<Button>().spriteState = selectableState;
        }
        ResetInfo();
    }

    public void ClickOutsideTheWindow()
    {
        selectedItem = "";
    }

    public void SetInfo()
    {
        itemName.text = TextHandler.englishItemNames[selectedItem];
        itemDescription.text = TextHandler.itemDescriptions[selectedItem];
    }

    public void ResetInfo()
    {
        itemName.text = "No item selected";
        itemDescription.text = "Select an item to see a description.";
    }
}
