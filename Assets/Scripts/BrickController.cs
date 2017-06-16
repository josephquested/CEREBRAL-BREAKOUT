using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		StartCoroutine(SpawnRoutine());
		StartCoroutine(SpecialBrickDelayRoutine());
	}

	// SPAWNING //

	bool canSpawnSpecialBricks;

	public GameObject brickPrefab;
	public GameObject toughBrickPrefab;
	public GameObject bangBrickPrefab;

	public float spawnDelay;
	public float specialbrickSpawnDelay;
	public float specialBrickLikelyhood;

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
		if (Random.Range(0, 30) > specialBrickLikelyhood || !canSpawnSpecialBricks)
		{
			return brickPrefab;
		}
		else
		{
			if (Random.Range(0, 10) > 3) return toughBrickPrefab;
			else return bangBrickPrefab;
		}
	}

	IEnumerator SpecialBrickDelayRoutine ()
	{
		yield return new WaitForSeconds(specialbrickSpawnDelay);
		canSpawnSpecialBricks = true;
		StartCoroutine(IncreaseSpecialBrickLikelyhoodRoutine());
	}

	IEnumerator IncreaseSpecialBrickLikelyhoodRoutine ()
	{
		print("more likely");
		yield return new WaitForSeconds(30f);
		specialBrickLikelyhood += 1;
		StartCoroutine(IncreaseSpecialBrickLikelyhoodRoutine());
	}
}
