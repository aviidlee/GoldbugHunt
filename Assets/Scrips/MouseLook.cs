using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	public float minVert = -45.0f;
	public float maxVert = 45.0f;

	private float _rotationX = 0;

	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	// By default, set to rotate on both X and Y
	public RotationAxes axes = RotationAxes.MouseXAndY;

	// Use this for initialization
	void Start () {
		Rigidbody body = GetComponent<Rigidbody> ();
		// Player rotation should be affected only by mouse, not physics.
		if (body != null) {
			body.freezeRotation = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
			// Horizontal rotation 
			transform.Rotate(0, Input.GetAxis("Mouse X")*sensitivityHor, 0);
		} else if (axes == RotationAxes.MouseY) {
			// Vertical rotation
			// Get the vertical angle based on mouse
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			// Clamp vertical angle between min and max values 
			_rotationX = Mathf.Clamp (_rotationX, minVert, maxVert);
			float rotationY = transform.localEulerAngles.y;
			// the vector in transform is read-only so need to create new one
			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		} else {
			// Both horizontal and vertical rotation
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, minVert, maxVert);

			float delta = Input.GetAxis ("Mouse X") * sensitivityHor;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}

	}
}
