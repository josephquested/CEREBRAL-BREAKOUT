using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	Rigidbody2D rb;

	public float speed;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
	{
		UpdateMovement();
	}

	void UpdateMovement ()
	{
		Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
		rb.AddForce(movement * speed);
	}
}
