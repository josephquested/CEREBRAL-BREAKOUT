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
		UpdateBash();
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

	public float bashForce;

	void UpdateBash ()
	{
		if (Input.GetButtonDown("Bash"))
		{
			Bash();
		}
	}

	void Bash ()
	{
		rb.AddForce(Vector2.up * bashForce, ForceMode2D.Impulse);
		ball.ReceiveFire();
	}
}
