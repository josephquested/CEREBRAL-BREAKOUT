using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	Rigidbody2D rb;
	bool attachedToPaddle = true;
	public float speed;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void ReceiveFire ()
	{
		if (attachedToPaddle)
		{
			DetachFromPaddle();
		}
	}

	void DetachFromPaddle ()
	{
		attachedToPaddle = false;
		transform.parent = null;
		rb.bodyType = RigidbodyType2D.Dynamic;

		Vector2 force = new Vector2(1, 1);
		rb.AddForce(force * speed, ForceMode2D.Impulse);
	}
}
