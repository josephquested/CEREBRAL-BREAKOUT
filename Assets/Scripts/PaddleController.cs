using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	Rigidbody2D rb;
	BallController ballController;
	public float speed;

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

	void UpdateMovement ()
	{
		Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
		rb.AddForce(movement * speed);
	}

	void UpdateFire ()
	{
		if (Input.GetButtonDown("Fire"))
		{
			ballController.ReceiveFire();
		}
	}
}
