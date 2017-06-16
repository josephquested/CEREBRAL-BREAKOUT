using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

public class Effects : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		backgroundAnim = GameObject.FindWithTag("Background").GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	// EFFECTS //

	Animator backgroundAnim;
	AudioSource audioSource;

	public void Hit ()
	{
		audioSource.Play();
		ProCamera2DShake.Instance.Shake("SmallExplosion");
		backgroundAnim.SetTrigger("Flash");
	}

	public void BigHit ()
	{
		audioSource.Play();
		ProCamera2DShake.Instance.Shake("LargeExplosion");
		backgroundAnim.SetTrigger("LongFlash");
	}

	public void Death ()
	{
		audioSource.Play();
		ProCamera2DShake.Instance.Shake("LargeExplosion");
		backgroundAnim.SetTrigger("Death");
	}
}
