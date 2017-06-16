using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangBrick : Brick {

	// POP //

	public GameObject explodePrefab;

	public override IEnumerator PopRoutine ()
	{
		PlayPopAudio();
		anim.enabled = true;
		anim.SetTrigger("Pop");
		rb.velocity = Vector2.zero;
		Instantiate(explodePrefab, transform.position, transform.rotation);
		if (gameController != null) { gameController.ReceiveScorePoint(1); }
		GetComponent<Collider2D>().enabled = false;
		yield return new WaitForSeconds(popDelay);
		Destroy(gameObject);
	}

	// COLLISION //

  public override void OnCollisionEnter2D (Collision2D collision)
  {
		GameObject obj = collision.gameObject;

		if (obj.tag == "BottomBoundary" || obj.tag == "Paddle")
		{
			rb.velocity = Vector2.zero;
			StartCoroutine(PopRoutine());
			GameObject.FindWithTag("Effects").GetComponent<Effects>().BigHit();
			if (gameController != null) { gameController.LoseLife(); }
			if (gameController != null) { gameController.LoseLife(); }
			if (gameController != null) { gameController.LoseLife(); }
			if (gameController != null) { gameController.LoseLife(); }
			if (gameController != null) { gameController.LoseLife(); }
		}

		if (obj.tag == "TopBoundary")
    {
      Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
  }
}
