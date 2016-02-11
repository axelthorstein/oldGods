using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

	public float smoothTimeY;
	public float smoothTimeX;
	private Vector2 velocity;
	public GameObject player;

	// Initialize the variable to point to the player
	void Start() {
		
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}

	// Update is called once per frame
	// Set the x and y coords for the player and then set camera to follow. 
	void Update () 
	{
		float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);
	}
}

