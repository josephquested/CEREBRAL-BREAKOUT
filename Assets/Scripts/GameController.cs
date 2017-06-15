using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

	// SYSTEM //

	Effects effects;

	void Awake ()
	{
		Cursor.visible = false;
		effects = GameObject.FindWithTag("Effects").GetComponent<Effects>();
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
		effects.Hit();
		CheckForGameOver();
	}

	void CheckForGameOver ()
	{
		if (lifeCount < 0)
		{
			StartCoroutine(GameOverRoutine());
		}
	}

	// SCORE //

	public int score = 0;
	public Text scoreField;
	public Text finalScoreField;

	public void ReceiveScorePoint (int quantity)
	{
		score += quantity;
	}

	void UpdateScoreText ()
	{
		scoreField.text = score.ToString();
		finalScoreField.text = score.ToString();
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

	IEnumerator GameOverRoutine ()
	{
		effects.Death();
		GameObject.FindWithTag("GameOverController").GetComponent<GameOverController>().InitGameOver();
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}
