using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Movement

	public float speed = 50f;
	public int maxSpeed = 3;
	public float jumpPower = 250f;
	public bool grounded = true; 

	private Rigidbody2D rb2d;
	private Animator anime;

	void Start() {

		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anime = gameObject.GetComponent<Animator> ();
	}

	void Update() {
	
		anime.SetBool ("Grounded", grounded);
		anime.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));

		if (Input.GetAxis("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetAxis("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if (Input.GetButtonDown("Jump") && grounded) 
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
