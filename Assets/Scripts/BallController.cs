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
		print("detached from paddle");
	}
}
