using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		ball = GetComponentInChildren<Ball>();
	}

	void FixedUpdate ()
	{
		UpdateMovement();
	}

	void Update ()
	{
		UpdateRelease();
	}

	// MOVEMENT //

	Rigidbody2D rb;

	public float speed;

	void UpdateMovement ()
	{
		Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
		rb.AddForce(movement * speed);
	}

	// BASH //

	Ball ball;

	void UpdateRelease ()
	{
		if (Input.GetButtonDown("Release"))
		{
			ball.ReceiveRelease();
		}
	}
}
