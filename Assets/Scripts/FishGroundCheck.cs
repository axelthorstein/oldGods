using UnityEngine;
using System.Collections;

public class FishGroundCheck : MonoBehaviour {

	private FishController player;

	void Start () {
		player = gameObject.GetComponentInParent<FishController> ();
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
