using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		paddle = transform.parent.gameObject;
	}

  void Update ()
  {
    ClampBallVelocity();
  }

	// POP //

	Animator anim;

	public float popDelay;

	IEnumerator PopRoutine ()
	{
		anim.SetTrigger("Pop");
		yield return new WaitForSeconds(popDelay);
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
		else
		{
			StartCoroutine(PopRoutine());
		}
	}

	void AttachToPaddle ()
	{
		attachedToPaddle = true;
		transform.parent = paddle.transform;
		transform.position = new Vector2(paddle.transform.position.x, 0.25f);
		rb.bodyType = RigidbodyType2D.Kinematic;
	}

	void DetachFromPaddle ()
	{
		attachedToPaddle = false;
		transform.parent = null;
		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
		InheritPaddleVelocity();
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
