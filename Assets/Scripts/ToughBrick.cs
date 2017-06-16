using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughBrick : Brick {

	// POP //

	public int hitPoints = 2;
	public Sprite[] sprites;

	public override IEnumerator PopRoutine ()
	{
		hitPoints -= 1;

		if (hitPoints < 0)
		{
			PlayPopAudio();
			anim.enabled = true;
			anim.SetTrigger("Pop");
			if (gameController != null) { gameController.ReceiveScorePoint(5); }
			GetComponent<Collider2D>().enabled = false;
			yield return new WaitForSeconds(popDelay);
			Destroy(gameObject);
		}
		else
		{
			Degrade();
		}
	}

	void Degrade ()
	{
		GetComponent<SpriteRenderer>().sprite = sprites[hitPoints];
	}

	// COLLISION //

  public override void OnCollisionEnter2D (Collision2D collision)
  {
		if (collision.gameObject.tag == "Paddle")
		{
			rb.velocity = Vector2.zero;
			StartCoroutine(PopRoutine());
			if (gameController != null) { gameController.LoseLife(); }
			StartCoroutine(PopRoutine());
			if (gameController != null) { gameController.LoseLife(); }
			StartCoroutine(PopRoutine());
			if (gameController != null) { gameController.LoseLife(); }
		}

		if (collision.gameObject.tag == "TopBoundary")
    {
      Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
  }
}
