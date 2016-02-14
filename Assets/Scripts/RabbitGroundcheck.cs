using UnityEngine;
using System.Collections;

public class RabbitGroundcheck : MonoBehaviour {

	private RabbitController player;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<RabbitController> ();
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
