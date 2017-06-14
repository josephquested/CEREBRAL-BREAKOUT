using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverController : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{

	}

	void Update ()
	{
		UpdateHorizontalInput();
	}

	// GAME OVER //

	public void InitGameOver ()
	{
		GetComponent<Animator>().SetTrigger("GameOver");
	}

	// INPUT //

	public Text[] nameFields;
	public int nameFieldIndex = 0;

	void UpdateHorizontalInput ()
	{
		if (Input.GetButtonDown("Horizontal"))
		{
			print(Input.GetAxisRaw("Horizontal"));
		}
	}
}
