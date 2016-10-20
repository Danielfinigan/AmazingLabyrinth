using UnityEngine;
using System.Collections;

public enum GameState
{
	menu,
	inGame,
	levelComplete,
	youWin
}
	
public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameState currentGameState = GameState.menu;
	public Canvas menuCanvas;
	public Canvas inGameCanvas;
	public Canvas levelCompleteCanvas;

	public float timer;
	public string minutes;
	public string seconds;
	public static bool timeStarted = false;

	public void Awake () {
		instance = this;
	}

	public void StartGame () {
		SetGameState (GameState.inGame);
		Player.instance.StartGame ();
		timeStarted = true;
	}

	public void levelComplete () {
		SetGameState (GameState.levelComplete);
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
			levelCompleteCanvas.enabled = false;
			//youWinCanvas.enabled = false;
		} else if (newGameState == GameState.inGame) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			levelCompleteCanvas.enabled = false;
			//youWinCanvas.enabled = false;
		} else if (newGameState == GameState.levelComplete) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			levelCompleteCanvas.enabled = true;
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
		if (timeStarted == true) {
			timer += Time.deltaTime;
			minutes = Mathf.Floor (timer / 60).ToString ("00");
			seconds = (timer % 60).ToString ("00");
		}
	}
}
