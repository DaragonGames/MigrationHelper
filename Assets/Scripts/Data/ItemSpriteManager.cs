using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteManager
{

    public static Dictionary<string, Sprite> list = new Dictionary<string, Sprite>();

    public static void LoadSprites() 
    {       
        foreach (string name in GameManager.allItemNames)
        {
            var sprite = Resources.Load<Sprite>(name);
            list.Add(name, sprite);
        }
        Debug.Log("Done loading item sprites");
    }

}
