using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	// For linking to prefab object without exposing it to other scripts.
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_enemy == null) {
			_enemy = Instantiate (enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3 (-16, 1, 1);
			float angle = Random.Range (0, 360);
			_enemy.transform.Rotate (0, angle, 0);
	
		}
	}
}
