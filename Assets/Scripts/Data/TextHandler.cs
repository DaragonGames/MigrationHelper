
using System.Collections.Generic;
using UnityEngine;

public class TextHandler : MonoBehaviour
{
    public static Dictionary<string, string> englishItemNames = new Dictionary<string, string>(){
        {"registration_form","Form for registration of residence"},
        {"passport","Passport"},
        {"visa","Visa"},
        {"rental_confirmation_letter","Rental confirmation letter"},
        {"application_form","Application for a residence permit"},
        {"biometric_photo","Biometric photo"},
        {"certificate_of_enrollment","Certificate of enrollment"},
        {"livelihood_proof","Proof of financial stability"},
        {"health_insurance_proof","Proof of health insurance"},
        {"rental_agreement","Rental agreement"}
    };

    public static Dictionary<string, string> germanItemNames = new Dictionary<string, string>(){
        {"registration_form","Anmeldeformular für die Wohnungsanmeldung"},
        {"passport","Reisepass"},
        {"visa","gültiges Visum"},
        {"rental_confirmation_letter","Wohnungsgeber\u00ADbestätigung"},
        {"application_form","Antrag auf Aufenthaltserlaubnis"},
        {"biometric_photo","biometrisches Passfoto"},
        {"certificate_of_enrollment","Immatrikulations\u00ADbescheinigung "},
        {"livelihood_proof","Nachweise bezüglich der Sicherstellung des Lebensunterhaltes"},
        {"health_insurance_proof","Nachweis über einen Kranken\u00ADversicherungs\u00ADschutz"},
        {"rental_agreement","Mietvertrag"}
    };

    public static Dictionary<string, string> itemDescriptions = new Dictionary<string, string>();
    public static List<string> npcLines = new List<string>();
    private static int npcLinesCount = 13;

    public static void LoadTexts()
    {
        foreach (string name in GameManager.allItemNames)
        {
            string text = Resources.Load<TextAsset>(name+"-description").text;
            text = text.Replace("#lb", "\u00AD");
            itemDescriptions.Add(name, text);
        }
        Debug.Log("Done loading item Descriptions");

        for (int i = 0;i < npcLinesCount; i++)
        {
            string text = Resources.Load<TextAsset>("npc-line-"+i).text;
            text = text.Replace("#lb", "\u00AD");
            npcLines.Add(text);
        }
        Debug.Log("Done loading npc lines");

    }
}
