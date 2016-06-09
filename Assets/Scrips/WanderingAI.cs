using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;
	private bool _alive;
	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;
	public int damage = 2;
	public Vector3 monsterPosition;
	NavMeshAgent nav;
	private Time lastMonsterHit;
	private float runAwayTime = 2.0f;
	private float nextChaseMonster;
	private Vector3 runDirection;

	// Use this for initialization
	void Start () {
		_alive = true;
		nav = GetComponent<NavMeshAgent> ();
		nav.SetDestination(monsterPosition);
		monsterPosition = GameObject.FindWithTag ("Monster").transform.position;
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}

	// Update is called once per frame
	void Update () {
		if (_alive) {
			// If we haven't hit the monster, go towards it.
			if (Time.time  < nextChaseMonster) {
				Debug.Log ("Running away from monster");
				RunFromMonster ();
			} else {
				Debug.Log ("Re-enabling the nav mesh");
				nav.enabled = true;
				nav.SetDestination (monsterPosition);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Bug collided into something");
		Hittable hitObject = other.GetComponent<Hittable>();
		if (hitObject != null) {
			hitObject.ReactToHit (damage);
		}

		nav.enabled = false;
		nextChaseMonster = Time.time + runAwayTime;
		runDirection = transform.position - monsterPosition;
		runDirection.y = 0; // Don't fly
		Vector3.Normalize (runDirection);
		// Run away from monster
		RunFromMonster();
	}

	void RunFromMonster() {
		Debug.Log ("Running away...");
		transform.Translate (speed*runDirection * Time.deltaTime);
	}

	// For attacking the player with ray casting. Probably won't use. 
	void Fire() {
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.SphereCast (ray, 0.75f, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			if (hitObject.GetComponent<PlayerCharacter> ()) {
				if (_fireball == null) {
					_fireball = Instantiate (fireballPrefab) as GameObject;
					_fireball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
					_fireball.transform.rotation = transform.rotation;
				}
			} else if (hit.distance < obstacleRange) {
				float angle = Random.Range (-110, 110);
				transform.Rotate (0, angle, 0);
			}
		}
	}
}
