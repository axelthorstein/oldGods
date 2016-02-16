using UnityEngine;
using System.Collections;

public class FishController : MonoBehaviour {

	public float speed = 10f;
	public float jumpPower = 450f;
	public bool grounded = true; 

	private Rigidbody2D rb2d;

	void Start() {

		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update() {

		// Flip the sprite based on which direction you are moving.
		if (Input.GetAxis("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3 (-5, 5, 1);
		}

		if (Input.GetAxis("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3 (5, 5, 1);
		}

		if (Input.GetButtonDown("Jump") && grounded) 
		{
			rb2d.AddForce (Vector2.up * jumpPower);
		}
			
		// Retrieve left or right moves
		float horizontalMove = Input.GetAxis ("Horizontal");
		// Moves the player
		rb2d.AddForce ((Vector2.right * speed) * horizontalMove);

		// Set our velocity to 75% to make up for no friction.
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;
	    
		// Fake Friction / easing of our player
		if (grounded) {
			rb2d.velocity = easeVelocity;
		}
	}
}
