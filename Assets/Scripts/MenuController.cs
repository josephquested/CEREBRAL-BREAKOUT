using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{

	}

	void Update ()
	{
		UpdateInsertCoin();
	}

	// INPUT //

	void UpdateInsertCoin ()
	{
		if (Input.GetButtonDown("Submit"))
		{
			print("lets play");
		}
	}
}
