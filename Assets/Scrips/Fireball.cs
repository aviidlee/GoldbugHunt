using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public float speed = 10.0f;
	public int damage = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		// Debug.Log ("Fireball hit something");
		PlayerCharacter player = other.GetComponent<PlayerCharacter> ();
		if (player != null) {
			player.Hurt (damage);
		} 

		// If monster was hit, make it more awake. 
		MonsterBehaviour monster = other.GetComponent<MonsterBehaviour> ();

		if (monster != null) {
			monster.ReactToHit (damage);
		}

		Destroy (this.gameObject);
	}

}
