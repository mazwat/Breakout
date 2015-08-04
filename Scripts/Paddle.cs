using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {


	//This means we can adjust the speed that the paddle moves from the inspector
	public float paddleSpeed = 1f;

	//Initial position of the paddle
	private Vector3 playerPos = new Vector3 (0, -9.5f, 0);


	// Update is called once per frame
	void Update () {
		// Create a variable that defines the x position of the paddle that adds the player input from the "horizontal"
		// which is the left/right cursor keys, A & D keys or the joystick controls on an Xbox controller
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * paddleSpeed);
		//Limits how far the paddle can move along the x axis, Y axis is set to it's current and yz is 0
		playerPos = new Vector3 (Mathf.Clamp (xPos, -8f, 8f), -9.5f, 0f);
		transform.position = playerPos;
	}
}
