using UnityEngine;
using System.Collections;

public enum GameState
{
	menu,
	inGame,
	gameOver,
	youWin
}
	
public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameState currentGameState = GameState.menu;
	public Canvas menuCanvas;
	public Canvas inGameCanvas;

	public float timer;
	public static bool timeStarted = false;

	// Use this for initialization

	public void StartGame () {
		SetGameState (GameState.inGame);
	}

	public void GameOver () {
		SetGameState (GameState.gameOver);
	}

	public void BackToMenu () {
		Application.LoadLevel ("scene1");
		SetGameState (GameState.menu);
	}

	public void YouWin () {
		SetGameState (GameState.youWin);
	}

	void SetGameState (GameState newGameState) {
		if (newGameState == GameState.menu) {
			menuCanvas.enabled = true;
			inGameCanvas.enabled = false;
			//gameOverCanvas.enabled = false;
			//youWinCanvas.enabled = false;
		} else if (newGameState == GameState.inGame) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			//gameOverCanvas.enabled = false;
			//youWinCanvas.enabled = false;
		} else if (newGameState == GameState.gameOver) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			//gameOverCanvas.enabled = true;
			//youWinCanvas.enabled = false;
			//EndGame ();
		}
		else if (newGameState == GameState.youWin) {
			menuCanvas.enabled = false;
			//inGameCanvas.enabled = false;
			//gameOverCanvas.enabled = false;
			//youWinCanvas.enabled = true;
			//EndGame ();
		}
		currentGameState = newGameState;
	}

	void Update () {
		if (timeStarted) {
			timer += Time.deltaTime;
		}
	}
}
