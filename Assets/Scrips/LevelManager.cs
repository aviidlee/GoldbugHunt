using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	private static int currentLevel = 1;
	public EnemyManager enemyManager;

	// Duration of each level in seconds
	public float levelTime = 30f;
	private float timer = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// Determine whether or not to increase level
		timer += Time.deltaTime;
		if (timer >= levelTime) {
			currentLevel++;
			enemyManager.IncreaseLevel ();

			timer = 0;
			Debug.Log ("LEvel increased to " + currentLevel);
		}
	}

	public int getLevel() {
		return currentLevel;
	}
		
}
