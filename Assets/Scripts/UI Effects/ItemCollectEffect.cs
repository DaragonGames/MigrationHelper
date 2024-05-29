using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollectEffect : MonoBehaviour
{
    // We have 0,0 in the bottom left corner of the screen and expand to the screen size from there
    // Also our canvas starts in the same corner
    // The goal is the position of the UI Element and hast to be handel manualy

    private Vector3 goal = new Vector3 (120, 760, 5);
    private Vector3 direction = Vector3.zero;
    private float secondsTillGoal = 1f;

    void Update()
    {
        transform.GetChild(0).position += direction * Time.deltaTime/secondsTillGoal;
    }

    public void SetPosition(Vector3 pos, string itemName)
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(pos);
        transform.GetChild(0).position = screenPoint;
        transform.GetChild(0).GetComponent<Image>().sprite = ItemSpriteManager.list[itemName];
        direction = goal - screenPoint;
        Destroy(gameObject, secondsTillGoal);
    }
}
