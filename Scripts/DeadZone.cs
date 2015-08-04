using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {
	
	void OnTriggerEnter (Collider col)
	{
	// A trigger is fired when it hits this (the water) and this activates the code in GM class - Loselife
		GM.instance.LoseLife();
	}
}
