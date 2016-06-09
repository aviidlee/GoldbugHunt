﻿using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour, Hittable {
	private int _health;

	// Use this for initialization
	void Start () {
		_health = 5;
	
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