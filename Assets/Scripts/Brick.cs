using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
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

	Animator anim;

	public float popDelay;

	IEnumerator PopRoutine ()
	{
		GetComponent<Collider2D>().enabled = false;
		anim.SetTrigger("Pop");
		audioSource.Play();
		yield return new WaitForSeconds(popDelay);
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
