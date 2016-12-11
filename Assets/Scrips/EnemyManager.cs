using UnityEngine;
using System.Collections.Generic;

/**
 * Responsible for spawning enemies.
 */ 
public class EnemyManager : MonoBehaviour {

	public MonsterBehaviour monster;

	public GameObject enemy;
	public float spawnTime = 6.0f;
	private List<Vector3> spawnPoints;
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		spawnPoints = new List<Vector3> ();
		AddNewSpawnPoint ();
		BeginSpawning ();
	}

	/**
	 * Called (by the start button, for instance) to begin spawning enemies continuously.
	 */
	void BeginSpawning() {
		Debug.Log ("Spawning bugs...");
		InvokeRepeating ("Spawn", 0, spawnTime);
	}

	void Spawn() {
		if (!monster.IsAsleep()) {
			return;
		}

		for (int i = 0; i < spawnPoints.Count; i++) {
			Instantiate (enemy, spawnPoints [i], Quaternion.identity);
		}			
	}

	public void IncreaseLevel() {
		Debug.Log ("Adding new spawn point...");
		AddNewSpawnPoint ();
		CancelInvoke ("Spawn");
		InvokeRepeating ("Spawn", 0, updateSpawnTime ());
	}

	float updateSpawnTime() {
		spawnTime = spawnTime - (levelManager.getLevel () / 10);
		if (spawnTime < 1.0f) {
			AddNewSpawnPoint ();
		}

		Debug.Log ("spawn time: " + spawnTime);
		return spawnTime;
	}

	/**
	 * Add new random spawn location.
	 */
	private void AddNewSpawnPoint() {
		float x = Random.Range (-22.0f, 20.0f);
		float z = Random.Range (-20.0f, 20.0f);
		Vector3 spawnPoint = new Vector3 (x, 2, z);
		spawnPoints.Add (spawnPoint);
	}
}
