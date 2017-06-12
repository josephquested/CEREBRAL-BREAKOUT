using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		ballController = GetComponentInChildren<BallController>();
	}

	void FixedUpdate ()
	{
		UpdateMovement();
	}

	void Update ()
	{
		UpdateFire();
	}

	// MOVEMENT //

	Rigidbody2D rb;

	public float speed;

	void UpdateMovement ()
	{
		Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
		rb.AddForce(movement * speed);
	}

	// BALL INTERACTION //

	BallController ballController;

	void UpdateFire ()
	{
		if (Input.GetButtonDown("Fire"))
		{
			ballController.ReceiveFire();
		}
	}
}
