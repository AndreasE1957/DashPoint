using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreList : MonoBehaviour {

	public GameObject scoreEntryPrefab;
	public Scoreboard scoreboard;
	int lastChangeCount = 0;

	// Use this for initialization. Make sure scoreboard exists in the Scene or bad things
    // may happen.
    // TODO: Error check
	void Start () {
		scoreboard = GameObject.FindObjectOfType<Scoreboard> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVariables.changeCount == lastChangeCount) {
			return;
		} else {
			lastChangeCount = GlobalVariables.changeCount;
		}
		// Debug.Log ("Changes detected");
		while (this.transform.childCount > 0) {
			Transform child = this.transform.GetChild (0);
			child.SetParent (null);
			Destroy (child.gameObject);
		}
		string[] names = Scoreboard.GetPlayerNames ("Score");
		foreach (string name in names) {
			GameObject gameObj = (GameObject)Instantiate(scoreEntryPrefab);
			gameObj.transform.SetParent (this.transform);
			gameObj.transform.Find ("Name").GetComponent<Text> ().text = name;
			gameObj.transform.Find ("Score").GetComponent<Text> ().text = Scoreboard.GetScore(name, "Score").ToString();
			gameObj.transform.Find ("Knockouts").GetComponent<Text> ().text = Scoreboard.GetScore(name, "Knockouts").ToString();
			gameObj.transform.Find ("ItemCount").GetComponent<Text> ().text = Scoreboard.GetScore(name, "ItemCount").ToString();

		}
	}
    public void returnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
