using UnityEngine;
using System.Collections;

public class WolfGroundCheck : MonoBehaviour {

	private WolfController player;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<WolfController> ();
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
