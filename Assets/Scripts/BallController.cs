using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	Rigidbody2D rb;

	public float speed;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
}
