using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour, Hittable {
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;
	private bool _alive;
	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;
	public int damage = 2;
	public Vector3 monsterPosition;
	UnityEngine.AI.NavMeshAgent nav;
	private Time lastMonsterHit;
	private float runAwayTime = 2.0f;
	private float nextChaseMonster;
	private Vector3 runDirection;
	public MonsterBehaviour monsterBehaviour;
	public int scoreValue = 10;

    AudioSource sound;

	public ScoreManager scoreManager;

	public GameObject monster;

	public int health; 
	public int startingHealth = 5;

	private bool _monsterInRange = false;
	// Time in seconds between each attack
	public float timeBetweenAttacks = 0.5f;
	float timer;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
		_alive = true;
		health = startingHealth;

		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		monster = GameObject.FindWithTag ("Monster");
		monsterPosition = monster.transform.position;
		monsterBehaviour = monster.GetComponent<MonsterBehaviour> ();

		scoreManager = GameObject.FindWithTag ("ScoreManager").GetComponent<ScoreManager>();

		nav.enabled = true;
		nav.SetDestination (monsterPosition);
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && _monsterInRange && _alive) {
			Attack ();
		}
	}

	void OnTriggerEnter(Collider other) {
		Hittable hitObject = other.GetComponent<Hittable>();
		if (hitObject != null) {
			_monsterInRange = true;
			hitObject.ReactToHit (damage);
		} else {
			Debug.Log ("Hit a wall");
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == monster) {
			_monsterInRange = false;
		}
	}

	void Attack() {
		timer = 0f;
		if (monsterBehaviour.IsAsleep ()) {
			monsterBehaviour.ReactToHit (damage);
		}
	}

	void RunFromMonster() {
		// Debug.Log ("Running away...");
		transform.Translate (speed*runDirection * Time.deltaTime);
	}
	
	public void ReactToHit(int damage) {
		if (_alive) {
			health -= damage;
            sound.Play();

			if (health <= 0) {
				_alive = false;
				StartCoroutine (Die ());
			}
		}
	}

	// IEnumerator ~~ iterator?
	private IEnumerator Die() {
		nav.enabled = false;
		this.transform.Rotate (-75, 0, 0);
		Debug.Log ("Bug caught!");
		yield return new WaitForSeconds (1f);
		scoreManager.AddScore (scoreValue);

		Destroy (this.gameObject);
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
