using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		paddle = transform.parent.gameObject;
	}

  void Update ()
  {
    ClampBallVelocity();
  }

	// POP //

	Animator anim;

	bool canPop;
	public float popDelay;

	IEnumerator PopRoutine ()
	{
		canPop = false;
		GetComponent<Collider2D>().enabled = false;
		anim.SetTrigger("Pop");
		yield return new WaitForSeconds(popDelay);
		rb.velocity = Vector2.zero;
		AttachToPaddle();
	}

	// PADDLE INTERACTION //

	GameObject paddle;

	bool attachedToPaddle = true;

	public void ReceiveRelease ()
	{
		if (attachedToPaddle)
		{
			DetachFromPaddle();
		}
		else if (!attachedToPaddle && canPop)
		{
			StartCoroutine(PopRoutine());
		}
	}

	void AttachToPaddle ()
	{
		attachedToPaddle = true;
		transform.parent = paddle.transform;
		transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y + 0.25f);
		GetComponent<Collider2D>().enabled = true;
		rb.bodyType = RigidbodyType2D.Kinematic;
		anim.SetTrigger("Idle");
	}

	void DetachFromPaddle ()
	{
		canPop = true;
		attachedToPaddle = false;
		transform.parent = null;
		rb.bodyType = RigidbodyType2D.Dynamic;
		InheritPaddleVelocity();
		rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
	}

	void InheritPaddleVelocity ()
	{
		rb.velocity += paddle.GetComponent<Rigidbody2D>().velocity;
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
		GameObject obj = collision.gameObject;

    if (obj == paddle && !attachedToPaddle)
    {
      InheritPaddleVelocity();
    }

		if (obj.tag == "Brick")
		{
			obj.GetComponent<Brick>().ReceiveHit();
		}
  }
}
