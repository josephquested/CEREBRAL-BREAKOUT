using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
			StartCoroutine(InsertCoinRoutine());
		}
	}

	// START GAME //

	IEnumerator InsertCoinRoutine ()
	{
		GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(0.4f);
		SceneManager.LoadScene("Main");
	}
}
