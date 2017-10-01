using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public Canvas gameOverCanvas = null;
	public GameObject ball = null;
	public GameObject bricks = null;
	public AudioClip gameOverSound = null;
	public AudioClip youWinSound = null;

	private Text gameOverText;
	private AudioSource audioSource;
	private bool gameEnded = false;
	private string WIN_TEXT = "YOU WIN!";
	private string LOSE_TEXT = "GAME OVER";

	private void Awake () {
		Transform textObject = gameOverCanvas.transform.Find ("GameOverText");
		gameOverText = textObject.GetComponent<Text> ();
		audioSource = GetComponent<AudioSource> ();
	}

	public void GameEnd (bool win) {
		gameEnded = true;
		AudioClip gameEndAudio;
		string gameEndMessage;

		if (win) {
			gameEndMessage = WIN_TEXT;
			gameEndAudio = youWinSound;
		} else {
			gameEndMessage = LOSE_TEXT;
			gameEndAudio = gameOverSound;
		}

		Destroy (ball);
		gameOverText.text = gameEndMessage;
		gameOverCanvas.gameObject.SetActive (true);
		audioSource.clip = gameEndAudio;
		audioSource.Play();
	}

	public void RestartGame () {
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}

	private void Update () {
		if (!gameEnded) {
			CheckGameEnd ();
		}
	}

	private void CheckGameEnd () {
		if (bricks.transform.childCount == 0) {
			GameEnd (true);
		} else if (!ball.activeSelf) {
			GameEnd (false);
		}
	}
}
