using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;
using System.Linq;



/*
 *  Scoreboard class
 *  Scores are held in global variables. 
 */

public class Scoreboard : MonoBehaviour {



	// Use this for initialization
	void Start () {
        GlobalVariables.changeCount = 0;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Called at the beginning of methods to ensure that the object exists before adding to it.
    // This isn't done in the Start() method because order of GameObject start calls can be unpredictable.
    // After object is created this essentially does nothing.
    static void Init(){
		if (GlobalVariables.playerScores != null)
			return;
        GlobalVariables.playerScores = new Dictionary<string, Dictionary<string, int>> ();
	}

    // Get method. Username and scoreType are case sensitive. Make sure both are consistent across
    // all uses. If the player doesn't exist or no score of that type exists, return value will be 0.
	public static int GetScore(string username, string scoreType){
		Init ();
		if (GlobalVariables.playerScores.ContainsKey (username) == false || GlobalVariables.playerScores[username].ContainsKey(scoreType) == false) {
			return 0;
		}
		return GlobalVariables.playerScores[username] [scoreType];
	}

    // Set method. Make sure the values used for username and scoreType are consistent across all
    // method calls. If the player does not exist then this method will act as an "Add Player" function,
    // and set their score to whatever value is passed in. 
    public static void SetScore(string username, string scoreType, int value){
		Init ();
		if (GlobalVariables.playerScores.ContainsKey (username) == false)
            GlobalVariables.playerScores[username] = new Dictionary<string, int> ();
        GlobalVariables.playerScores[username] [scoreType] = value;
        GlobalVariables.changeCount++;
	}

    // Increase a player's score by value. Value may be negative if you wish to decrement for some reason. 
    // Username and scoreType must be consistent across all uses. If the player doesn't exist, then they will
    // be added with whatever score is passed in as value. 
	public static void IncrementScore(string username, string scoreType, int value){
		Init ();
		SetScore (username, scoreType, GetScore (username, scoreType) + value);
		GlobalVariables.changeCount++;
	}

    // Returns an array of player names, sorted by whatever score value you wish. This is used for sorting scores
    // in the UI.
	public static string[] GetPlayerNames (string sortBy){
		Init ();
		return GlobalVariables.playerScores.Keys.OrderByDescending(n=>GetScore(n, sortBy)).ToArray();
	}

 //   // SQL calls for High Score server. This isn't working. SqlCommand object will throw a NullReferenceException when
 //   // attempting to access it. I dug around for about 2 days trying to find some way to make this work but all solutions 
 //   // I can find are beyond the scope of this project. These functions are still hardcoded, so making them more generalized 
 //   // is next on the TODO list if by some miracle it works.
    //   public void readSQL()
    //   {
    //       string connectionString = @"Data Source=tcp:68.183.196.164/DashPoint;Initial Catalog=High Scores;User ID=User;Password=password";
    //       string commandString = "SELECT * FROM `High Scores`";
    //       SqlConnection cnn;
    //       cnn = new SqlConnection(connectionString);
    //
    //       SqlCommand command;
    //       command = new SqlCommand(commandString, cnn);    
    //
    //       cnn.Open();
    //       SqlDataReader dataReader;
    //       dataReader = command.ExecuteReader();
    //       string output = "";
    //       while (dataReader.Read())
    //       {
    //           output = output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
    //       }
    //       dataReader.Close();
    //   }
    //   public void postScoresSQL()
    //   {
    //       string connectionString = @"Data Source=tcp:68.183.196.164/DashPoint;Initial Catalog=High Scores;User ID=User;Password=password";
    //       string commandString = "INSERT INTO `High Scores`(`Name`, `Score`, `Time`) VALUES ('Joe',10002,null)";
    //       using (SqlConnection cnn = new SqlConnection(connectionString))
    //       {
    //            SqlCommand command = new SqlCommand(commandString, cnn);
    //            command.Parameters.AddWithValue("@name", "Joe");
    //            command.Parameters.AddWithValue("@score", 1000);
    //            cnn.Open();
    //            command.ExecuteNonQuery();
    //            cnn.Close();
    //       }
    //       
    //   }

    // DEBUG 
    public void DEBUG_ADD_PLAYER(){
		SetScore ("Rose", "Score", 2000);
		SetScore ("Rose", "Knockouts", 12);
		SetScore ("Rose", "ItemCount", 130);
	}
	public void DEBUG_ADD_SCORE(){
		IncrementScore ("Tom", "Score", 100);
	}

//	public void DEBUG_OPEN_CONNECTION(){
//       readSQL();
//    }
}
