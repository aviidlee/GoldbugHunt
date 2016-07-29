using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

	public MonsterBehaviour monster;

	public GameObject enemy;
	public float spawnTime = 3f;
	public List<Transform> spawnPoints;

	// Use this for initialization
	void Start () {
		Debug.Log ("Spawnnn meeee");
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn() {
		Debug.Log ("Calling Spawn method");

		if (!monster.IsAsleep()) {
			return;
		}

		for (int i = 0; i < spawnPoints.Count; i++) {
			Instantiate (enemy, spawnPoints [i].position, spawnPoints [i].rotation);
			Debug.Log ("Spawning...");
		}
	}
}
