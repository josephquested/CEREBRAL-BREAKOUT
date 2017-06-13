using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
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

	// AUDIO //

	AudioSource audioSource;

	public AudioClip bounceClip;

	void RandomisePitch (float min, float max)
	{
		audioSource.pitch = Random.Range(min, max);
	}

	void PlayBounceAudio ()
	{
		audioSource.clip = bounceClip;
		RandomisePitch(0.8f, 1f);
		audioSource.Play();
	}

	// COLLISION //

	void OnCollisionEnter2D (Collision2D collision)
  {
		if (collision.gameObject.tag == "Boundary")
		{
			PlayBounceAudio();
		}
  }
}
