using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour, Hittable {
	private int _health;
	// amount of damage inflicted onto the central monster
	public int damage = 10;

	// Use this for initialization
	void Start () {
		_health = 5;
	}

	public int GetHealth() {
		return _health;
	}

	void OnTriggerEnter(Collider other) {
		Hittable hitObject = other.GetComponent<Hittable>();
		if (hitObject != null) {
			hitObject.ReactToHit (damage);
		}
	}

	public void ReactToHit(int damage) {
		_health -= damage;
	}

	public void Hurt(int damage) {
		_health -= damage;
		Debug.Log ("Health: " + _health);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
