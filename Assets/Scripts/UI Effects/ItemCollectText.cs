using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollectText : MonoBehaviour
{

    private int positionID;
    public static int counter=0;

    // Start is called before the first frame update
    void Start()
    {              
        counter++;
        positionID=counter;
        Destroy(transform.parent.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        float ygoal = 150*(counter-positionID);
        if (transform.position.y < ygoal)
        {
            transform.position += Vector3.up * Time.deltaTime * 450;
            if (transform.position.y > ygoal)
            {
                transform.position = new Vector3(960,ygoal,0);
            }
        }
    }

    public void SetDisplayName(string displayName)
    {
        TMP_Text tmpText = GetComponentInChildren<TMP_Text>();
        tmpText.text = "Collected: " + TextHandler.englishItemNames[displayName];
    }
}
