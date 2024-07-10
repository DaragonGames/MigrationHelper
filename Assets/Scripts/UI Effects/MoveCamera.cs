using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.OnScreen)
        {
            transform.position = new Vector3(-0.3f, 1.2f,1.88f);
            //transform.
        }
        else
        {
            transform.position = new Vector3(1.5f, 4.5f,4);
        }
    }
}
