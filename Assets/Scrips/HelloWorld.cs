using UnityEngine;
using System.Collections;

public class HelloWorld : MonoBehaviour {
	public float rotSpeed = 3.0f;

	// Use this for initialization
	void Start () {
		Debug.Log ("Hello world");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, rotSpeed, 0);	
	}
}
