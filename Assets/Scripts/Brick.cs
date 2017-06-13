using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		RandomizeGravityScale();
	}

	// BALL INTERACTION //

	public void ReceiveHit ()
	{
		StartCoroutine(PopRoutine());
	}

	// POP //

	Animator anim;

	public float popDelay;

	IEnumerator PopRoutine ()
	{
		GetComponent<Collider2D>().enabled = false;
		anim.SetTrigger("Pop");
		PlayPopAudio();
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

	void PlayPopAudio ()
	{
		audioSource.clip = popClip;
		RandomisePitch(0.8f, 1.2f);
		audioSource.Play();
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
