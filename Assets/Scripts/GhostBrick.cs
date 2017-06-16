using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBrick : Brick {

	// POP //

	public override IEnumerator PopRoutine ()
	{
		PlayPopAudio();
		anim.enabled = true;
		anim.SetTrigger("Pop");
		rb.velocity = Vector2.zero;
		if (gameController != null) { gameController.ReceiveScorePoint(3); }
		GetComponent<Collider2D>().enabled = false;
		yield return new WaitForSeconds(popDelay);
		Destroy(gameObject);
	}

	// COLLISION //

  void OnTriggerEnter2D (Collider2D collider)
  {
		GameObject obj = collider.gameObject;

		if (obj.tag == "BottomBoundary")
		{
			rb.velocity = Vector2.zero;
			StartCoroutine(PopRoutine());
			if (gameController != null) { gameController.LoseLife(); }
		}

		if (obj.tag == "Ball")
    {
      StartCoroutine(PopRoutine());
    }
  }
}
