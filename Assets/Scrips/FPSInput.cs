using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float moveSpeed = 10.0f;
	public float gravity = -9.8f;
	private CharacterController _charController;

	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * moveSpeed;
		float deltaZ = Input.GetAxis ("Vertical") * moveSpeed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		// Limit diagonal movement to same magnitude as that along an axis.
		movement = Vector3.ClampMagnitude (movement, moveSpeed);
		movement.y = gravity;
		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		// Move method expects a *global* vector
		_charController.Move (movement);
	}
}
