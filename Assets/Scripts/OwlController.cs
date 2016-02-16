using UnityEngine;
using System.Collections;

public class OwlController : MonoBehaviour {
	// Movement

	public float speed = 100f;
	public int maxSpeed = 5;
	public float jumpPower = 1000f;
	public bool grounded = true;
	private bool falling;
	private float currentHeight;
	private float previousHeight;

	private Rigidbody2D rb2d;
	private Animator anime;


	void Start() {

		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anime = gameObject.GetComponent<Animator> ();
		previousHeight = 0;
		falling = false;
	}

	void Update() {

		anime.SetBool ("falling", falling);

		// This set the glid animation if owl is falling.
		currentHeight = transform.position.y;
		float travel = currentHeight - previousHeight;
		previousHeight = currentHeight;

		if (travel < 0) {
			falling = true;
		} else {
			falling = false;
		}
			
		// Flip sprite in direction you are moving. 
		if (Input.GetAxis("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3 (-5, 5, 1);
		}

		if (Input.GetAxis("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3 (5, 5, 1);
		}

		if (Input.GetButtonDown("Jump")) 
		{
			rb2d.AddForce (Vector2.up * jumpPower);
		}
	}


	// Update is called once per frame
	void FixedUpdate () {

		// Set our velocity to 75% to make up for no friction.
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;

		// Retrieve left or right moves
		float horizontalMove = Input.GetAxis ("Horizontal");

		// Fake Friction / easing of our player
		if (grounded) 
		{
			rb2d.velocity = easeVelocity;
		}

		// Moves the player
		rb2d.AddForce ((Vector2.right * speed) * horizontalMove);

		// Limiting the speed of the player
		if (rb2d.velocity.x > maxSpeed) 
		{
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);	
		}

		if (rb2d.velocity.x < -maxSpeed) 
		{
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	}
}
