using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	// SYSTEM //

	public GameObject brickPrefab;

	void Start ()
	{
		StartCoroutine(SpawnRoutine());
	}

	void Update ()
	{

	}

	// SPAWNING //

	public float spawnRate;

	IEnumerator SpawnRoutine ()
	{
		yield return null;
	}
}
