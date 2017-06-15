using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	// SYSTEM //

	protected GameController gameController;

	void Start ()
	{
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		audioSource = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		RandomizeGravityScale();
	}

	// BALL INTERACTION //

	public void ReceiveHit ()
	{
		StartCoroutine(PopRoutine());
	}

	// POP //

	protected Animator anim;

	public float popDelay;

	public virtual IEnumerator PopRoutine ()
	{
		PlayPopAudio();
		anim.SetTrigger("Pop");
		if (gameController != null) { gameController.ReceiveScorePoint(1); }
		GetComponent<Collider2D>().enabled = false;
		yield return new WaitForSeconds(popDelay);
		Destroy(gameObject);
	}

	// AUDIO //

	AudioSource audioSource;

	public AudioClip popClip;

	void RandomisePitch (float min, float max)
	{
		audioSource.pitch = Random.Range(min, max);
	}

	protected void PlayPopAudio ()
	{
		audioSource.clip = popClip;
		RandomisePitch(0.8f, 1.2f);
		audioSource.Play();
	}

	// MOVEMENT //

	protected Rigidbody2D rb;

	public float gravityMin;
	public float gravityMax;

	void RandomizeGravityScale ()
	{
		rb.gravityScale = (Random.Range(gravityMin, gravityMax));
	}

	// COLLISION //

  public virtual void OnCollisionEnter2D (Collision2D collision)
  {
		GameObject obj = collision.gameObject;

		if (obj.tag == "BottomBoundary")
		{
			rb.velocity = Vector2.zero;
			StartCoroutine(PopRoutine());
			if (gameController != null) { gameController.LoseLife(); }
		}

		if (obj.tag == "TopBoundary")
    {
      Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
  }
}
