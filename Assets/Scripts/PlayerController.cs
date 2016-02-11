using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Movement

	public float speed = 50f;
	public int maxSpeed = 10;
	public float jumpPower = 150f;


	//float moveVelocity;

	// Ground Variables

	public bool grounded = true; 

	//float moveRight = 0;
	//bool facingLeft = true;

	private Rigidbody2D rd2d;
	private Animator anime;

	void Start() {

		rd2d = gameObject.GetComponent<Rigidbody2D> ();
		anime = gameObject.GetComponent<Animator> ();
	}

	void Update() {
	
		anime.SetBool ("Grounded", grounded);
		anime.SetFloat ("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
	
	}


	// Update is called once per frame
	void FixedUpdate () {


		float horizontalMove = Input.GetAxis ("Horizontal");

		rd2d.AddForce ((Vector2.right * speed) * horizontalMove);

		if (rd2d.velocity.x > maxSpeed) {

			rd2d.velocity = new Vector2 (maxSpeed, rd2d.velocity.y);
			
		}

		if (rd2d.velocity.x < -maxSpeed) {

			rd2d.velocity = new Vector2 (-maxSpeed, rd2d.velocity.y);

		}
		// Jumping 
//		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyUp (KeyCode.UpArrow)) {
//			if (grounded) {
//				GetComponent<Rigidbody2D> ().velocity = 
//					new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
//			}
//		}




//		moveVelocity = 0;
//
//
//		if (Input.GetKey (KeyCode.LeftArrow)) {
//
//			moveVelocity = -speed;
//			//transform.forward = new Vector3(1f, 0f, 0f);
//		}
//		if (Input.GetKey (KeyCode.RightArrow)) {
//
//			moveVelocity = speed;
//			//transform.forward = new Vector3(-1f, 0f, 0f);
//		}
//		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
//	
	

		

	}
	// check if grounded
//	void OnTriggerEnter2D() {
//		grounded = true;
//	}
//	void OnTriggerExit2D() {
//		grounded = false;
//	}
}
