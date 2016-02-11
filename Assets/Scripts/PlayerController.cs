using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Movement

	public float speed = 50f;
	public int maxSpeed = 10;
	public float jumpPower = 150f;
	public bool grounded = true; 

	private Rigidbody2D rd2d;
	private Animator anime;

	void Start() {

		rd2d = gameObject.GetComponent<Rigidbody2D> ();
		anime = gameObject.GetComponent<Animator> ();
	}

	void Update() {
	
		anime.SetBool ("Grounded", grounded);
		anime.SetFloat ("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

		if (Input.GetAxis("Horizontal") < -0.1f) {

			transform.localScale = new Vector3 (-1, 1, 1);

		}

		if (Input.GetAxis("Horizontal") > 0.1f) {

			transform.localScale = new Vector3 (1, 1, 1);

		}
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
	}
}
