using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		StartCoroutine(SpawnRoutine());
	}

	void Update ()
	{

	}

	// SPAWNING //

	public GameObject brickPrefab;
	public float spawnDelay;

	IEnumerator SpawnRoutine ()
	{
		SpawnBrickRow();
		yield return new WaitForSeconds(spawnDelay);
		StartCoroutine(SpawnRoutine());
	}

	void SpawnBrickRow ()
	{
		SpawnBrickAtPosition(-7);
		SpawnBrickAtPosition(-5);
		SpawnBrickAtPosition(-3);
		SpawnBrickAtPosition(-1);
		SpawnBrickAtPosition(1);
		SpawnBrickAtPosition(3);
		SpawnBrickAtPosition(5);
		SpawnBrickAtPosition(7);
	}

	void SpawnBrickAtPosition (float xPos)
	{
		Vector2 position = new Vector2(xPos, 10f);
		Instantiate(brickPrefab, position, transform.rotation);
	}
}
