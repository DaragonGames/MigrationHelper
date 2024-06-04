using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyLines {
    public string introduction;  
    public string farewellsGood; 
    public string farewellsBad;  
    public List<string> demandLines;
    public List<string> commonResponsesRight;
    public List<string> commonResponsesWrong;
    public List<Response> uniqueResponses;

    public static EnemyLines LoadResponses(){
        string jsonString = Resources.Load<TextAsset>("EnemyLines").text;
        Debug.Log(jsonString);
        return JsonUtility.FromJson<EnemyLines>(jsonString);
    }

    public string GetResponse(string wantedItem, string givenItem)
    {
        foreach (Response response in uniqueResponses)
        {
            if (response.wantedItem == wantedItem && response.givenItem == givenItem)
            {
                return response.line;
            }
        }
        if (wantedItem == givenItem)
        {
            int randomValue = Random.Range(0,commonResponsesRight.Count);
            return commonResponsesRight[randomValue];
        }
        else
        {
            int randomValue = Random.Range(0,commonResponsesWrong.Count);
            return commonResponsesWrong[randomValue];
        }
    }
}