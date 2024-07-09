using System.Collections;
using TMPro;
using UnityEngine;

public class Npc : Interactable
{
    public GameObject speechBubble;

    public override void Interact()
    {
        if (!speechBubble.activeSelf)
        {
            string sentence = TextHandler.npcLines[Random.Range(0,TextHandler.npcLines.Count)];
            speechBubble.GetComponentInChildren<SpeechBubble>().SetStatement(sentence);
            speechBubble.SetActive(true);
            StartCoroutine(CloseText());
        }
    }

    IEnumerator CloseText() {
        yield return new WaitForSeconds(6f);
        speechBubble.SetActive(false);
    }   

}
