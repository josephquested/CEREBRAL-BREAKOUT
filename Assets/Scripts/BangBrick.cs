using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangBrick : Brick {

	// POP //

	public GameObject explodePrefab;

	public override IEnumerator PopRoutine ()
	{
		Instantiate(explodePrefab, transform.position, transform.rotation);
		rb.velocity = Vector2.zero;
		PlayPopAudio();
		anim.enabled = true;
		anim.SetTrigger("Pop");
		if (gameController != null) { gameController.ReceiveScorePoint(1); }
		GetComponent<Collider2D>().enabled = false;
		yield return new WaitForSeconds(popDelay);
		Destroy(gameObject);
	}
}
