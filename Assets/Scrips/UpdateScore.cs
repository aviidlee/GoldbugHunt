using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
	public ScoreManager scoreManager;
	Text scoreText;

	// Use this for initialization
	void Start ()
	{
		scoreText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		int score = scoreManager.GetScore ();
		scoreText.text = "Score: " + score;
	}
}

