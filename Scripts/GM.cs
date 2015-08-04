using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	
	// Setup the public adjustable variables
	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	// Create public variables that display as boxes to place game objects into
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;
	
	private GameObject clonePaddle;
	
	// This is good practice in Unity. YOu only need one instance of the game you don't want it to generate extra instances.
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		Setup();
		
	}


	// A set-up function to instantiate the brick, paddle and ball prefab's
	public void Setup()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, transform.position, Quaternion.identity);
	}
	
	void CheckGameOver()
	{
		if (bricks < 1) {
			Debug.Log ("You Won!");
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
		if (lives < 1) {
			Debug.Log ("Game Over");
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
	}
	
	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void LoseLife()
	{
		lives--;
		//Debug.Log("Lives:" + lives);
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
	}
	
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}
	
	public void DestroyBrick()
	{
		bricks--;
		//Debug.Log("Bricks:" + bricks);
		CheckGameOver();
	}
}