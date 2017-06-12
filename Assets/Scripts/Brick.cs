using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

  void Update ()
  {

  }

	// MOVEMENT //

	Rigidbody2D rb;

	public float speed;

}
