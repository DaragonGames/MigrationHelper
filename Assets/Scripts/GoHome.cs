using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : MonoBehaviour
{
    public void GoHomeClick()
    {
        Enemy.Instance.RunOutOfPatience();
    }
}
