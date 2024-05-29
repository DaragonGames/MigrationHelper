using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    private TMP_Text tmpText;
    private string statement;
    private float counter = 0;
    private float speakingSpeed = 15;

    void Start()
    {
        tmpText = GetComponentInChildren<TMP_Text>();
        speakingSpeed += Random.value*10;
    }


    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        int progress = (int) (counter * speakingSpeed);
        if (progress > statement.Length)
        {
            progress = statement.Length;
        }

        tmpText.text = statement.Substring(0,progress);
    }

    public void SetStatement(string statement)
    {
        this.statement = statement;
        counter = 0;
    }

}
