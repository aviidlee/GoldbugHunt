using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;
	public LevelManager levelManager;
	public static int multiplier = 1;

	// Use this for initialization
	void Start () {

		score = 0;
	}
		
	public void AddScore(int addMe) {
		multiplier = levelManager.getLevel ();
		score += (addMe * multiplier);
		Debug.Log ("Score: " + score);
	}

	public int GetScore() {
		return score;
	}
}
