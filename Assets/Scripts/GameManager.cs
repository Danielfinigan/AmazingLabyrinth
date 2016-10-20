using UnityEngine;
using System.Collections;

public enum GameState
{
	menu,
	inGame,
	gameOver,
	levelComplete,
	youWin
}
	
public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameState currentGameState = GameState.menu;
	public Canvas menuCanvas;
	public Canvas inGameCanvas;
	public Canvas levelCompleteCanvas;
	public Canvas gameOverCanvas;
	public Canvas youWinCanvas;

	public float timer;
	//public string minutes;
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

	public void LevelComplete () {
		/* if this is scene1 and the faster time for 
		 * this time was faster than 1000 seconds...*/
		if (Application.loadedLevelName == "scene1" && 
			PlayerPrefs.GetFloat ("time1", 1000f) > this.timer) {
			/* ...then set the fastest time for 
			 * scene 1 to this time*/
			PlayerPrefs.SetFloat ("time1", this.timer);
		}
		SetGameState (GameState.levelComplete);
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

	public void NextLevel () {
		if (Application.loadedLevelName == "scene1") {
			Application.LoadLevel ("scene2");
		} else if (Application.loadedLevelName == "scene2") {
			Application.LoadLevel ("scene3");
		} else
			YouWin ();
	}

	void SetGameState (GameState newGameState) {
		if (newGameState == GameState.menu) {
			menuCanvas.enabled = true;
			inGameCanvas.enabled = false;
			levelCompleteCanvas.enabled = false;
			gameOverCanvas.enabled = false;
			//youWinCanvas.enabled = false;
		} else if (newGameState == GameState.inGame) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			levelCompleteCanvas.enabled = false;
			gameOverCanvas.enabled = false;
			youWinCanvas.enabled = false;
		} else if (newGameState == GameState.levelComplete) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			levelCompleteCanvas.enabled = true;
			youWinCanvas.enabled = false;
		} else if (newGameState == GameState.gameOver) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			levelCompleteCanvas.enabled = false;
			gameOverCanvas.enabled = true;
			youWinCanvas.enabled = false;
		}
		else if (newGameState == GameState.youWin) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
			levelCompleteCanvas.enabled = false;
			youWinCanvas.enabled = true;
		}
		currentGameState = newGameState;
	}

	void Update () {
		if (timeStarted == true) {
			timer += Time.deltaTime;
			//minutes = Mathf.Floor (timer / 60).ToString ("00");
			seconds = (timer ).ToString ("0000");
		}
	}
}
