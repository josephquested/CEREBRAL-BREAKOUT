using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

public class Effects : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		backgroundAnim = GameObject.FindWithTag("Background").GetComponent<Animator>();
	}

	// EFFECTS //

	Animator backgroundAnim;

	public void Hit ()
	{
		ProCamera2DShake.Instance.Shake("SmallExplosion");
		backgroundAnim.SetTrigger("Flash");
	}

	public void Death ()
	{
		ProCamera2DShake.Instance.Shake("LargeExplosion");
		backgroundAnim.SetTrigger("Death");
	}
}
