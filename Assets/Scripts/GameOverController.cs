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
		UpdateVerticalInput();
	}

	// GAME OVER //

	public void InitGameOver ()
	{
		GetComponent<Animator>().SetTrigger("GameOver");
	}

	// HORIZONTAL INPUT //

	int selectorIndex = 0;

	public Text[] nameFields;
	public Text selectedField;

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

	// VERTICAL INPUT //

	public string[] chars = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
	public int[] charIndexes = new int[] {0, 18, 18};

	void UpdateVerticalInput ()
	{
		if (Input.GetButtonDown("Vertical") && selectorIndex != 3)
		{
			if (Input.GetAxisRaw("Vertical") < 0)
			{
				MoveCharDown();
			}
			else
			{
				MoveCharUp();
			}
			ChangeSelectedChar();
		}
	}

	void MoveCharUp ()
	{
		if (charIndexes[selectorIndex] >= 25)
		{
			charIndexes[selectorIndex] = 0;
		}
		else
		{
			charIndexes[selectorIndex]++;
		}
	}

	void MoveCharDown ()
	{
		if (charIndexes[selectorIndex] <= 0)
		{
			charIndexes[selectorIndex] = 25;
		}
		else
		{
			charIndexes[selectorIndex]--;
		}
	}

	void ChangeSelectedChar ()
	{
		nameFields[selectorIndex].text = chars[charIndexes[selectorIndex]];
	}
}
