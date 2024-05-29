using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public void ToggleUI() 
    {
        gameObject.SetActive(!gameObject.activeSelf);
        UpdateDisplay();
    }
    public void CloseUI() 
    {
        gameObject.SetActive(false);
    }

    public void UpdateDisplay()
    {
        List<Objective> objectives = GameManager.Instance.objectives;
        for (int i = 0;i<7;i++)
        {
            Transform objectiveTransform = transform.GetChild(i+4);
            if (objectives.Count <= i)
            {
                objectiveTransform.gameObject.SetActive(false);
            }
            else
            {
                objectiveTransform.gameObject.SetActive(true);                
                Objective objectiveData = objectives[i];
                objectiveTransform.GetComponentInChildren<TMP_Text>().text = objectiveData.displayText;
                bool done = GameManager.Instance.checkRequirements(objectiveData.requirement);
                objectiveTransform.GetChild(1).gameObject.SetActive(done);
            }            
        }
    }
}

