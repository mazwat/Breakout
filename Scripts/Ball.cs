using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 650f;

	private Rigidbody rb;

	private bool ballInPlay;

	// Use his to establish the rigidbody of the ball so we can add force to the object
	void Awake () {

		rb = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1") && ballInPlay == false) {
			transform.parent =null;
			ballInPlay = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		}
			
	}
}
