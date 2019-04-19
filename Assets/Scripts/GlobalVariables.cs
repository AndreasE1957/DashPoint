using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static bool active;
    public static float inputScore;
    public static Dictionary<string, Dictionary<string, int>> playerScores;
    public static int changeCount;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        changeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
