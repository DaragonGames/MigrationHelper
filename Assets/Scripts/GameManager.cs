using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static List<string> allItemNames = new List<string>(){"passport", "visa", "biometric_photo", "certificate_of_enrollment", "livelihood_proof", 
    "health_insurance_proof", "rental_agreement", "application_form", "rental_confirmation_letter", "registration_form"};

    public enum Mission {ResidentRegistration , ResidentPermit};
    public Mission currentMission = Mission.ResidentRegistration;
    public static GameObject player;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (Instance != this)
        {
            Destroy(gameObject);
        }        
    }

    void Start()
    {
        if (Instance != this)
        {
           return;
        }  

        SetMission(Mission.ResidentRegistration);

        if (ItemSpriteManager.list.Count == 0)
        {
            ItemSpriteManager.LoadSprites();
        }
        if (TextHandler.itemDescriptions.Count == 0)
        {
            TextHandler.LoadTexts();
        }
    }

    public List<Objective> objectives = new List<Objective>();

    public bool checkRequirements(string requirement)
    {
        return Inventory.items.Contains(requirement);
    }

    public void SetMission(Mission mission)
    {
        if (mission == Mission.ResidentRegistration)
        {
            objectives = Objective.GetRegistration();
            currentMission = mission;
        }
        if (mission == Mission.ResidentPermit)
        {
            objectives = Objective.GetPermit();
            currentMission = mission;
        }
    }

    public static void NextMission()
    {
        GameManager.Instance.SetMission(Mission.ResidentPermit);
    }

}
