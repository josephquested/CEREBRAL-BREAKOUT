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
}
