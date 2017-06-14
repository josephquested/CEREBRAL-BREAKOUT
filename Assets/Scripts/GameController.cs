using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// SYSTEM //

	void Awake ()
	{
		Cursor.visible = false;
	}

	void Update ()
	{

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

	// HEART ICONS //

	public GameObject[] heartIcons;

	void DestroyHeartIcon (int index)
	{
		if (index >= 0)
		{
			Destroy(heartIcons[index]);
		}
	}

	// GAME //

	public GameObject gameoverUI;

	void GameOver ()
	{
		gameoverUI.GetComponent<Animator>().SetTrigger("GameOver");
	}
}
