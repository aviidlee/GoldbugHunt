using UnityEngine;
using System.Collections.Generic;

/**
 * Responsible for spawning enemies.
 */ 
public class EnemyManager : MonoBehaviour {

	public MonsterBehaviour monster;
	public GameObject enemy;
	public float spawnTime = 3.0f;
	private List<Vector3> spawnPoints;
	public LevelManager levelManager;

    // Add a new spawn point whenever spawn time is less than this number
    public float newPointFreq = 1.0f;
    
    // Number of enemies to spawn per call to spawn.
    private int numToSpawn = 1;

	// Use this for initialization
	void Start () {
		spawnPoints = new List<Vector3> ();
		BeginSpawning ();
	}

	/**
	 * Called (by the start button, for instance) to begin spawning enemies continuously.
	 */
	void BeginSpawning() {
		Debug.Log ("Spawning bugs...");
		InvokeRepeating ("Spawn", 0, spawnTime);
	}

    /*
     * Spawn numToSpawn new bugs, each at a randomised location.
     */
	void Spawn() {
		if (!monster.IsAsleep()) {
			return;
		}

        for (int i = 0; i < numToSpawn; i++)
        {
            SpawnAt(RandomSpawnPoint());
        }
        	
	}

    //Spawn one enemy at the given point.
    void SpawnAt(Vector3 point)
    {
        Instantiate(enemy, point, Quaternion.identity);
    }

	public void IncreaseLevel() {
		CancelInvoke ("Spawn");
		InvokeRepeating ("Spawn", 0, updateSpawnTime ());
	}

	float updateSpawnTime() {
        // Make spawning faster, and add new spawn point if spawn times are less than a second apart.
		spawnTime = spawnTime - (levelManager.getLevel () / 8);
		if (spawnTime < newPointFreq) {
            numToSpawn++;
		}

		Debug.Log ("spawn time: " + spawnTime);
		return spawnTime;
	}

	/**
	 * Return a new spawn location.
	 */
	private Vector3 RandomSpawnPoint() {
		float x = Random.Range (-22.0f, 20.0f);
		float z = Random.Range (-20.0f, 20.0f);
		return new Vector3 (x, 2, z);
	}
}
