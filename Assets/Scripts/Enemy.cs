using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;
    public SpeechBubble speechBubble;
    public RectTransform patienceBar;
    private float patience = 100;
    private string currentDemand = "";
    private List<string> demands;
    private EnemyLines responseHandler;

    void Start()
    {
        Enemy.Instance = this;
        switch (GameManager.Instance.currentMission) 
        {
            case GameManager.Mission.ResidentRegistration:
                demands = new List<string>(){"passport", "visa",  "rental_confirmation_letter", "registration_form", };
                break;
            case GameManager.Mission.ResidentPermit:
                demands = new List<string>(){"passport", "visa", "biometric_photo", "certificate_of_enrollment", 
                "livelihood_proof", "health_insurance_proof", "rental_agreement", "application_form"};
                break;
        }
        int randomValue = Random.Range(0,demands.Count);
        currentDemand = demands[randomValue];
        responseHandler = GameManager.Instance.responseHandler;
        speechBubble.SetStatement(responseHandler.introduction);
        StartCoroutine(DelayedDemandSomething(3f));
    }

    void Update()
    {
        patienceBar.sizeDelta = new Vector2(40,(100-patience)*1.44f);
    }

    private void DemandSomething() 
    {
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
        int randomValue = Random.Range(0,responseHandler.demandLines.Count);
        sentence = responseHandler.demandLines[randomValue].Replace("#item", item);
        speechBubble.SetStatement(sentence);
    }

    IEnumerator DelayedDemandSomething(float delay)
    {
        yield return new WaitForSeconds(delay);
        DemandSomething();
    }

    public void Receive(string item) 
    {
        string response = responseHandler.GetResponse(currentDemand,item);
        speechBubble.SetStatement(response);
        if (currentDemand == item)
        {
            demands.Remove(item);
            if (demands.Count == 0)
            {
                RunOutOfDemands();
            }
            else {
                int randomValue = Random.Range(0,demands.Count);
                currentDemand = demands[randomValue];
                StartCoroutine(DelayedDemandSomething(3f));
            }
        }
        else
        {
            patience-=35;
            if (patience <= 0)
            {
                RunOutOfPatience();
            }
            StartCoroutine(DelayedDemandSomething(3f));
        }
    }

    private void RunOutOfPatience()
    {
        speechBubble.SetStatement(responseHandler.farewellsBad);
        StartCoroutine(DelayedLoadScene(3f,"Home",false));
    }

    private void RunOutOfDemands()
    {
        GameManager.NextMission();
        speechBubble.SetStatement(responseHandler.farewellsGood);
        StartCoroutine(DelayedLoadScene(3f,"Home",true));
    }

    IEnumerator DelayedLoadScene(float delay, string scene, bool succes)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
        if (succes)
        {
            if (GameManager.Instance.gameOver)
            {
                TransitionScene.Load("GotPermitText",scene);
            }
            else
            {
                TransitionScene.Load("DoneRegistrationText",scene);
            }
        }
        else
        {
            TransitionScene.Load("SentHomeText",scene);
        }        
    }

}
