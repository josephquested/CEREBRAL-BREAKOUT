using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
	// SYSTEM //

	protected GameController gameController;
	public GameObject smokePrefab;

	void Start()
	{
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		rb = GetComponent<Rigidbody2D>();
		RandomizeGravityScale();
	}

	// COLLISION //

	void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Brick")
		{
			collider.gameObject.GetComponent<Brick>().ReceiveHit();
		}
	}

	// MOVEMENT //

	protected Rigidbody2D rb;

	public float gravityMin;
	public float gravityMax;

	void RandomizeGravityScale()
	{
		rb.gravityScale = (Random.Range(gravityMin, gravityMax));
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject obj = collider.gameObject;

		if (obj.tag == "BottomBoundary")
		{
			Instantiate(smokePrefab, transform.position, transform.rotation);
			Destroy(gameObject);
		}

		if (obj.tag == "Paddle")
		{
			GameObject.FindWithTag("Effects").GetComponent<Effects>().BigHit();

			if (gameController != null) { gameController.LoseLife(); }
			if (gameController != null) { gameController.LoseLife(); }
			if (gameController != null) { gameController.LoseLife(); }

			Instantiate(smokePrefab, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}