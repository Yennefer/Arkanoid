using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public Canvas gameOverCanvas = null;
	public GameObject ball = null;
	public GameObject bricks = null;

	private Text gameOverText;
	private string WIN_TEXT = "YOU WIN!";
	private string LOSE_TEXT = "GAME OVER";

	private void Awake () {
		Transform textObject = gameOverCanvas.transform.Find ("GameOverText");
		gameOverText = textObject.GetComponent<Text> ();
	}

	public void GameOver (bool win) {
		if (win) {
			gameOverText.text = WIN_TEXT;
		} else {
			gameOverText.text = LOSE_TEXT;
		}

		gameOverCanvas.gameObject.SetActive (true);
	}

	public void RestartGame () {
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}

	private void Update () {
		if (bricks.transform.childCount == 0) {
			GameOver (true);
		} else if (!ball.activeSelf) {
			GameOver (false);
		}
	}
}
