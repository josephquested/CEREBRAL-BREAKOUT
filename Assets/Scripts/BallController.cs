using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

  void Update ()
  {
    ClampBallVelocity();
  }

	// PADDLE INTERACTION //

	bool attachedToPaddle = true;

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
		rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
		InheritPaddleVelocity(GameObject.FindWithTag("Paddle"));
	}

	void InheritPaddleVelocity (GameObject paddle)
	{
		Rigidbody2D paddleRb = paddle.GetComponent<Rigidbody2D>();
		rb.velocity += paddleRb.velocity;
	}

	// MOVEMENT //

	Rigidbody2D rb;

	public float speed;

	void ClampBallVelocity ()
	{
		rb.velocity = speed * (rb.velocity.normalized);
	}

	// COLLISION //

  void OnCollisionEnter2D (Collision2D collision)
  {
    if (collision.gameObject.tag == "Paddle" && !attachedToPaddle)
    {
      InheritPaddleVelocity(collision.gameObject);
    }
  }
}
