using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    public GameObject doorUI;
    public override void Interact()
    {
        doorUI.SetActive(true);
    }

    void Update()
    {
        base.Update();

        Vector3 positionUsed = new Vector3(transform.position.x,0,transform.position.z);
        Vector3 goalUsed = new Vector3(GameManager.player.transform.position.x,0,GameManager.player.transform.position.z);
        float distance = Vector3.Distance(positionUsed, goalUsed) -reach;
        if (distance > 0.5f)
        {
            doorUI.SetActive(false);
        }
    }

    public void GetPost()
    {
        if (GameManager.Instance.currentMission == GameManager.Mission.ResidentPermit 
        && !Inventory.items.Contains("health_insurance_proof"))
        {
            CollectItem("health_insurance_proof");
        }
        doorUI.SetActive(false);
    } 

    public void GoToOffice()
    {
        doorUI.SetActive(false);
        SceneManager.LoadScene("WaitingRoom");
    }

    public void GoHome()
    {
        doorUI.SetActive(false);
        SceneManager.LoadScene("Home");
    }

    public void EnterOffice()
    {
        doorUI.SetActive(false);
        SceneManager.LoadScene("Office");
    }
}
