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

  void Update ()
  {
    if (!attachedToPaddle)
    {
      ClampBallVelocity();
    }
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
    rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    ReceivePaddleVelocity(GameObject.FindWithTag("Paddle"));
	}

  void ReceivePaddleVelocity (GameObject paddle)
  {
    Rigidbody2D paddleRb = paddle.GetComponent<Rigidbody2D>();
    rb.velocity += paddleRb.velocity;
  }

  void ClampBallVelocity ()
  {
    rb.velocity = speed * (rb.velocity.normalized);
  }

  void OnCollisionEnter2D (Collision2D collision)
  {
    if (collision.gameObject.tag == "Paddle" && !attachedToPaddle)
    {
      ReceivePaddleVelocity(collision.gameObject);
    }
  }
}
