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
	// Use this for initialization

	public void StartGame () {
		SetGameState (GameState.inGame);
	}


	void SetGameState (GameState newGameState) {
		if (newGameState == GameState.menu) {
			/*menuCanvas.enabled = true;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
			youWinCanvas.enabled = false;*/
		} else if (newGameState == GameState.inGame) {
			/*menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			gameOverCanvas.enabled = false;
			youWinCanvas.enabled = false;*/
		} else if (newGameState == GameState.gameOver) {
			/*menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = true;
			youWinCanvas.enabled = false;
			EndGame ();*/
		}
		else if (newGameState == GameState.youWin) {
			/*menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
			youWinCanvas.enabled = true;
			EndGame ();*/
		}
		currentGameState = newGameState;
	}
}
