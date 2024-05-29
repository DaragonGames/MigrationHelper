using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;
    public SpeechBubble speechBubble;
    public Image patienceBar;
    private float patience = 100;
    private string currentDemand = "";
    private List<string> demands;

    void Start()
    {
        Enemy.Instance = this;
        switch (GameManager.Instance.currentMission) 
        {
            case GameManager.Mission.ResidentRegistration:
                demands = new List<string>(){"passport", "visa",  "rental_confirmation_letter", "registration_form", };
                DemandSomething();
                break;
            case GameManager.Mission.ResidentPermit:
                demands = new List<string>(){"passport", "visa", "biometric_photo", "certificate_of_enrollment", 
                "livelihood_proof", "health_insurance_proof", "rental_agreement", "application_form"};
                DemandSomething();
                break;
        }
    }

    void Update()
    {
        patience -= Time.deltaTime/6.0f;
        if (patience <= 0)
        {
            RunOutOfPatience();
        }
        patienceBar.rectTransform.sizeDelta = new Vector2(patience*10,20);
    }

    private void DemandSomething() 
    {
        int randomValue = Random.Range(0,demands.Count);
        currentDemand = demands[randomValue];

        string item;
        string sentence;
        if (Random.value < 0.2f)
        {
            item=TextHandler.englishItemNames[currentDemand];
        }
        else
        {
            item=TextHandler.germanItemNames[currentDemand];
        }
        randomValue = Random.Range(0,TextHandler.enemyLinesCount);
        sentence = TextHandler.enemyLines[randomValue].Replace("#item", item);
        speechBubble.SetStatement(sentence);
    }

    public void Receive(string item) 
    {
        if (currentDemand == item)
        {
            demands.Remove(item);
            if (demands.Count == 0)
            {
                RunOutOfDemands();
            }
            else {
                DemandSomething();
            }
        }
        else
        {
            patience-=30;
        }
    }

    private void RunOutOfPatience()
    {
        SceneManager.LoadScene("Home");
    }

    private void RunOutOfDemands()
    {
        if (GameManager.Instance.currentMission == GameManager.Mission.ResidentRegistration)
        {
            GameManager.Instance.currentMission = GameManager.Mission.ResidentPermit;
        }
        SceneManager.LoadScene("Home");
    }

}
