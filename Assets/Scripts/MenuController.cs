using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour {

	// SYSTEM //

	void Awake ()
	{
		SetHighscoreField();
	}

	void Update ()
	{
		UpdateInsertCoin();
		UpdateEscInput();
	}

	// INPUT //

	void UpdateInsertCoin ()
	{
		if (Input.GetButtonDown("Submit"))
		{
			StartCoroutine(InsertCoinRoutine());
		}
	}

	void UpdateEscInput ()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			Application.Quit();
		}
	}

	// HIGHSCORE //

	public Text highscoreField;
	public Text nameField;

	void SetHighscoreField ()
	{
		if (PlayerPrefs.GetInt("High Score") == 0)
		{
			nameField.text = "NUL";
			highscoreField.text = "0";
		}
		else
		{
			nameField.text = PlayerPrefs.GetString("Player Name");
			highscoreField.text = PlayerPrefs.GetInt("High Score").ToString();
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
