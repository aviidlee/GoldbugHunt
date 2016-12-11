using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public MonsterBehaviour monster;

	Animator anim;

	void Awake() {
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!monster.IsAsleep ()) {
			anim.SetTrigger ("GameOver");
		}
	}
}
