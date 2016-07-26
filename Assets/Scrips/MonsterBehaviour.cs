using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterBehaviour : MonoBehaviour, Hittable {
	private int _sleepiness; 
	private bool _asleep;
	public Material awakeMaterial;
	public Slider awakeSlider;

	// Use this for initialization
	void Start () {
		_sleepiness = 10;
		_asleep = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetAsleep(bool asleep) {
		_asleep = asleep;
	}

	public bool IsAsleep() {
		return _asleep;
	}

	// From Hittable interface
	public void ReactToHit(int damage) {
		if (_asleep) {
			Debug.Log ("Monster has been hit.");
			_sleepiness -= damage;
			// Remember, have to use StartCoroutine; can't just call the co-routine.
			StartCoroutine (Startle ());
			awakeSlider.value = _sleepiness;

			if (_sleepiness < 0) {
				WakeUp ();
			}
		}
	}

	/*
	 * Make the monster look a little startled to let player know 
	 * that it's been hit and is waking up.
	 */
	private IEnumerator Startle() {
		Debug.Log ("Monster is startled.");
		this.transform.Rotate (-30, 0, 0);
		yield return new WaitForSeconds (0.2f);
		this.transform.Rotate (30, 0, 0);
	}

	private void WakeUp() {
		Debug.Log ("Monster woke up!");
		_asleep = false;
		Renderer renderer = GetComponent<Renderer> ();

		// Change the way the monster looks to let player know it's awake.
		if (awakeMaterial != null) {
			renderer.material = awakeMaterial;
		}

	}
}