using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class LavaBrick : Brick {

	// POP //

	public GameObject lavaPrefab;
	public GameObject lavaExplodePrefab;

	public override IEnumerator PopRoutine ()
	{
		PlayPopAudio();
		anim.enabled = true;
		anim.SetTrigger("Pop");
		rb.velocity = Vector2.zero;
		Instantiate(lavaPrefab, transform.position, transform.rotation);
		Instantiate(lavaExplodePrefab, transform.position, transform.rotation);
		ProCamera2DShake.Instance.Shake("SmallExplosion");
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
			GameObject.FindWithTag("Effects").GetComponent<Effects>().Hit();

			if (gameController != null) { gameController.LoseLife(); }
		}

		if (obj.tag == "TopBoundary")
    {
      Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
  }
}
