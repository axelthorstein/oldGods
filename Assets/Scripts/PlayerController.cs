using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Movement

	public float speed;
	public float jump;
	float moveVelocity;

	// Ground Variables

	bool grounded = true; 
	
	// Update is called once per frame
	void Update () {
		// Jumping 
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Z) || Input.GetKeyUp (KeyCode.W)) {
			if (grounded) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
			}
		}

		moveVelocity = 0;


		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {

			moveVelocity = -speed;

		}
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {

			moveVelocity = speed;

		}
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
	

		}
		
		// check if grounded
		void OnTriggerEnter2D() {
		grounded = true;
		}
		void OnTriggerExit2D() {
		grounded = false;
	}
}
