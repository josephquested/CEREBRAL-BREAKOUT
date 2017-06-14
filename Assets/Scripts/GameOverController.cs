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
	public Text selectedField;
	public int selectorIndex = 0;

	void UpdateHorizontalInput ()
	{
		if (Input.GetButtonDown("Horizontal"))
		{
			UnselectCurrentField();
			if (Input.GetAxisRaw("Horizontal") < 0)
			{
				MoveSelectorLeft();
			}
			else
			{
				MoveSelectorRight();
			}
			SelectNewField();
		}
	}

	// SELECTOR //

	void MoveSelectorRight ()
	{
		if (selectorIndex >= 3)
		{
			selectorIndex = 0;
		}
		else
		{
			selectorIndex++;
		}
	}

	void MoveSelectorLeft ()
	{
		if (selectorIndex <= 0)
		{
			selectorIndex = 3;
		}
		else
		{
			selectorIndex--;
		}
	}

	void UnselectCurrentField ()
	{
		selectedField.color = Color.black;
	}

	void SelectNewField ()
	{
		selectedField = nameFields[selectorIndex];
		selectedField.color = Color.white;
	}
}
