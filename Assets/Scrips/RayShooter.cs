﻿using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {
	private Camera _camera; 
	public int damage = 5;
    public SoundManager sound;

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();

		// Hide cursor 
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}


	void OnGUI() {
		// Debug.Log ("OnGUI called");
		int size = 50;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 2;
		GUI.Label (new Rect (posX, posY, size, size), "+");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
            sound.Shoot();
			// Get middle of screen
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			Ray ray = _camera.ScreenPointToRay (point);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				// Debug.Log ("Hit " + hit.point);
				GameObject hitObject = hit.transform.gameObject;
				// You couldn't hit 2 things at once, could you?
				Hittable target = hitObject.GetComponent<Hittable> ();
				if (target != null) {
					Debug.Log ("inlficting damage!!!");
					target.ReactToHit (damage);
				} else {
					// StartCoroutine (SphereIndicator (hit.point));
				}
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = pos;

		// Yield tells coroutine where to pause
		yield return new WaitForSeconds(1);

		Destroy (sphere);

	}
}
