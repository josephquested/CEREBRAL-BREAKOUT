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
	public GameObject toughBrickPrefab;
	public float spawnDelay;

	IEnumerator SpawnRoutine ()
	{
		SpawnBrickRow();
		yield return new WaitForSeconds(spawnDelay);
		StartCoroutine(SpawnRoutine());
	}

	void SpawnBrickRow ()
	{
		SpawnAtPosition(-7);
		SpawnAtPosition(-5);
		SpawnAtPosition(-3);
		SpawnAtPosition(-1);
		SpawnAtPosition(1);
		SpawnAtPosition(3);
		SpawnAtPosition(5);
		SpawnAtPosition(7);
	}

	void SpawnAtPosition (float xPos)
	{
		Vector2 position = new Vector2(xPos, 10f);
		GameObject obj = GetSpawnObject();
		Instantiate(obj, position, transform.rotation);
	}

	GameObject GetSpawnObject ()
	{
		int brickRoll = Random.Range(0, 30);
		if (brickRoll < 28)
		{
			return brickPrefab;
		}
		else
		{
			return toughBrickPrefab;
		}
	}
}
