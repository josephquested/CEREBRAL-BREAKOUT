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
	public GameObject ghostBrickPrefab;
	public GameObject speedBrickPrefab;

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
		GameObject obj = GetBrickObject();
		Instantiate(obj, position, transform.rotation);
	}

	GameObject GetBrickObject ()
	{
		if (Random.Range(0, 30) > specialBrickLikelyhood || !canSpawnSpecialBricks)
		{
			return brickPrefab;
		}
		else
		{
			return GetSpecialBrickObject();
		}
	}

	GameObject GetSpecialBrickObject ()
	{
		if (Random.Range(0, 10) > 4) return toughBrickPrefab;
		else
		{
			if (Random.Range(0, 10) > 3) return bangBrickPrefab;
			else
			{
				if (Random.Range(0, 10) > 5) return speedBrickPrefab;
				else return ghostBrickPrefab;
			}
		}
	}

	IEnumerator SpecialBrickDelayRoutine ()
	{
		yield return new WaitForSeconds(specialbrickSpawnDelay);
		canSpawnSpecialBricks = true;
		StartCoroutine(IncreaseSpecialBrickLikelyhoodRoutine());
	}

	public float increaseSpecialLikelyhoodDelay;

	IEnumerator IncreaseSpecialBrickLikelyhoodRoutine ()
	{
		yield return new WaitForSeconds(increaseSpecialLikelyhoodDelay);
		specialBrickLikelyhood += 1;
		StartCoroutine(IncreaseSpecialBrickLikelyhoodRoutine());
	}
}
