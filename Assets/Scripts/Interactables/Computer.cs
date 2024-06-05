using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Interactable
{
    public override void Interact() 
    {
        Vector3 printerPosition = new Vector3(0,0,2.5f);
        if (GameManager.Instance.currentMission == GameManager.Mission.ResidentPermit)
        {
            float delay = 0f;
            if (!Inventory.items.Contains("livelihood_proof"))
            {
                DelayedItemColletion("livelihood_proof",delay,printerPosition);
                delay += 0.3f;
            }
            if (!Inventory.items.Contains("certificate_of_enrollment"))
            {
                DelayedItemColletion("certificate_of_enrollment",delay,printerPosition);
                delay += 0.3f;
            }
            if (!Inventory.items.Contains("application_form"))
            {
                DelayedItemColletion("application_form",delay,printerPosition);
                delay += 0.3f;
            }
        }
        if (GameManager.Instance.currentMission == GameManager.Mission.ResidentRegistration)
        {
            if (!Inventory.items.Contains("registration_form"))
            {
                CollectItem("registration_form",printerPosition);
            }
        }
    }
}
