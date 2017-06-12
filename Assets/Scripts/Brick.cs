using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		RandomizeGravityScale();
	}

  void Update ()
  {

  }

	// BALL INTERACTION //

	public void ReceiveHit ()
	{
		Destroy(gameObject);
	}

	// MOVEMENT //

	Rigidbody2D rb;

	public float gravityMin;
	public float gravityMax;

	void RandomizeGravityScale ()
	{
		rb.gravityScale = (Random.Range(gravityMin, gravityMax));
	}
}
