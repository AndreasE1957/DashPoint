using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSubmittion : MonoBehaviour
{

    public InputField inA;


    private void Start()
    {
        inA.ActivateInputField();

        inA.enabled = true;
    }
    public void Submit()
    {
        if(inA.text.Length > 0)
        {
            Scoreboard.SetScore(inA.text, "Score", Mathf.CeilToInt(GlobalVariables.inputScore));
            SceneManager.LoadScene("Scoreboard", LoadSceneMode.Single);
        }
    }
}
