using System;
using TMPro;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    public TMP_Text mainText;
    public static string goal;
    public static string toLoad;
    private String displayText = "Loading...";


    // Start is called before the first frame update
    void Start()
    {
        displayText = Resources.Load<TextAsset>(toLoad).text;
    }

    // Update is called once per frame
    void Update()
    {
        mainText.text = displayText;
    }

    public void Continue()
    {
        SceneManager.LoadScene(goal);
    }

    public static void Load(string toLoad, string goal) 
    {
        TransitionScene.toLoad = toLoad;
        TransitionScene.goal = goal;
        SceneManager.LoadScene("Transition");
    }
}
