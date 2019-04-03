using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreList : MonoBehaviour {

	public GameObject scoreEntryPrefab;
	public Scoreboard scoreboard;
	int lastChangeCount = 0;

	// Use this for initialization
	void Start () {
		scoreboard = GameObject.FindObjectOfType<Scoreboard> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreboard.changeCount == lastChangeCount) {
			return;
		} else {
			lastChangeCount = scoreboard.changeCount;
		}
		Debug.Log ("Changes detected");
		while (this.transform.childCount > 0) {
			Transform child = this.transform.GetChild (0);
			child.SetParent (null);
			Destroy (child.gameObject);
		}
		string[] names = scoreboard.GetPlayerNames ("Score");
		foreach (string name in names) {
			GameObject gameObj = (GameObject)Instantiate(scoreEntryPrefab);
			gameObj.transform.SetParent (this.transform);
			gameObj.transform.Find ("Name").GetComponent<Text> ().text = name;
			gameObj.transform.Find ("Score").GetComponent<Text> ().text = scoreboard.GetScore(name, "Score").ToString();
			gameObj.transform.Find ("Knockouts").GetComponent<Text> ().text = scoreboard.GetScore(name, "Knockouts").ToString();
			gameObj.transform.Find ("ItemCount").GetComponent<Text> ().text = scoreboard.GetScore(name, "ItemCount").ToString();

		}
	}
}
