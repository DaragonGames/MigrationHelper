using System.Collections;
using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    public GameObject glow;

    public void CreateGlow()
    {
        if (glow.activeSelf)
        {
            glow.SetActive(false);
        }
        else
        {
            glow.SetActive(true);
            StartCoroutine(endGlow());
        }
    }

    IEnumerator endGlow()
    {
        yield return new WaitForSeconds(2);
        glow.SetActive(false);
    }
    
}
