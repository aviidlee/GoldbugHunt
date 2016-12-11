using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateLevel : MonoBehaviour
{
	public LevelManager levelManager;
	Text levelText;

	// Use this for initialization
	void Start ()
	{
		levelText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		levelText.text = "Level: " + levelManager.getLevel ();
	}
}

