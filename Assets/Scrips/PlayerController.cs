using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float rotSpeed = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, rotSpeed, 0);	
	}
}
