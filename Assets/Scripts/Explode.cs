using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		StartCoroutine(ExplodeRoutine());
	}

	// EXPLODE //

	public float lifetime;

	IEnumerator ExplodeRoutine ()
	{
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
	}

	// COLLISION //

	void OnTriggerStay2D (Collider2D collider)
	{
		if (collider.gameObject.tag == "Brick")
		{
			collider.gameObject.GetComponent<Brick>().ReceiveHit();
		}
	}
}
