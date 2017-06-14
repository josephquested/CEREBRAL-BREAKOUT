using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

	// SYSTEM //

	void Awake ()
	{
		Cursor.visible = false;
	}

	void Update ()
	{
		UpdateScoreText();
	}

	// LIFE //

	int lifeCount = 7;

	public void LoseLife ()
	{
		DestroyHeartIcon(lifeCount);
		lifeCount--;
		CheckForGameOver();
	}

	void CheckForGameOver ()
	{
		if (lifeCount < 0)
		{
			GameOver();
		}
	}

	// SCORE //

	public int score = 0;
	public Text scoreField;

	void UpdateScoreText ()
	{
		scoreField.text = score.ToString();
	}

	// HEART ICONS //

	public GameObject[] heartIcons;

	void DestroyHeartIcon (int index)
	{
		if (index >= 0)
		{
			Destroy(heartIcons[index]);
		}
	}

	// GAME OVER //

	void GameOver ()
	{
		GameObject.FindWithTag("GameOverController").GetComponent<GameOverController>().InitGameOver();
	}
}
