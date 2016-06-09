using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour, Hittable {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReactToHit(int damage) {
		WanderingAI behaviour = GetComponent<WanderingAI> ();
		if (behaviour != null) {
			behaviour.SetAlive (false);
		}
		StartCoroutine (Die ());
	}

	// IEnumerator ~~ iterator?
	private IEnumerator Die() {
		this.transform.Rotate (-75, 0, 0);
		yield return new WaitForSeconds (1.5f);

		Destroy (this.gameObject);
	}
}
