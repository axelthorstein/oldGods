using UnityEngine;
using System.Collections;

public class BearGroundCheck : MonoBehaviour {

	private BearController player;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<BearController> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		player.grounded = true;
	}

	void OnTriggerStay2D(Collider2D col) 
	{
		player.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		player.grounded = false;
	}
}
