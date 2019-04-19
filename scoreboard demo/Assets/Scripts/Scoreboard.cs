using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Scoreboard : MonoBehaviour {

	Dictionary<string, Dictionary<string, int>> playerScores;
	public int changeCount = 0;

	// Use this for initialization
	void Start () {
		SetScore ("Mia", "Score", 1000);
		SetScore ("Mia", "Knockouts", 3);
		SetScore ("Mia", "ItemCount", 10);

		SetScore ("Kyle", "Score", 1000);
		SetScore ("Kyle", "Knockouts", 3);
		SetScore ("Kyle", "ItemCount", 10);

		SetScore ("Tom", "Score", 1000);
		SetScore ("Tom", "Knockouts", 3);
		SetScore ("Tom", "ItemCount", 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Init(){
		if (playerScores != null)
			return;
		playerScores = new Dictionary<string, Dictionary<string, int>> ();
	}

	public int GetScore(string username, string scoreType){
		Init ();
		if (playerScores.ContainsKey (username) == false || playerScores[username].ContainsKey(scoreType) == false) {
			return 0;
		}
		return playerScores [username] [scoreType];
	}

	public void SetScore(string username, string scoreType, int value){
		Init ();
		if (playerScores.ContainsKey (username) == false)
			playerScores [username] = new Dictionary<string, int> ();
		playerScores [username] [scoreType] = value;
		changeCount++;
	}

	public void IncrementScore(string username, string scoreType, int value){
		Init ();
		SetScore (username, scoreType, GetScore (username, scoreType) + value);
		changeCount++;
	}

	public string[] GetPlayerNames (string sortBy){
		Init ();
		return playerScores.Keys.OrderByDescending(n=>GetScore(n, sortBy)).ToArray();
	}	

	public void DEBUG_ADD_PLAYER(){
		SetScore ("Rose", "Score", 2000);
		SetScore ("Rose", "Knockouts", 12);
		SetScore ("Rose", "ItemCount", 130);
	}
	public void DEBUG_ADD_SCORE(){
		IncrementScore ("Tom", "Score", 100);
	}
	public void DEBUG_ADD_KO(){
		IncrementScore ("Tom", "Knockouts", 1);
	}
	public void DEBUG_ADD_ITEM(){
		IncrementScore ("Tom", "ItemCount", 1);
	}
}
