using UnityEngine;
using UnityEngine.SceneManagement;
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
	public Canvas highScoreCanvas;

	public float timer;
	public string seconds;
	public bool newHighScore = false;
	public static bool timeStarted = false;

	public void Awake () {
		instance = this;
	}

	public void StartGame () {
		SetGameState (GameState.inGame);
		Player.instance.StartGame ();
		timeStarted = true;
    }

    public void LevelComplete() {
        if (SceneManager.GetActiveScene().name == "scene1")
        {
            if (PlayerPrefs.GetFloat("time1", 0) == 0)
            {
                PlayerPrefs.SetFloat("time1", this.timer);
            }
            else if(PlayerPrefs.GetFloat("time1", 0) > this.timer)
            {
                PlayerPrefs.SetFloat("time1", this.timer);
                newHighScore = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "scene2")
        {
            if (PlayerPrefs.GetFloat("time2", 0) == 0)
            {
                PlayerPrefs.SetFloat("time2", this.timer);
            }
            else if (PlayerPrefs.GetFloat("time2", 0) > this.timer)
            {
                PlayerPrefs.SetFloat("time2", this.timer);
                newHighScore = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "scene3")
        {
            if (PlayerPrefs.GetFloat("time3", 0) == 0)
            {
                PlayerPrefs.SetFloat("time3", this.timer);
            }
            else if (PlayerPrefs.GetFloat("time3", 0) > this.timer)
            {
                PlayerPrefs.SetFloat("time3", this.timer);
                newHighScore = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "scene3")
            YouWin();
        else
            SetGameState (GameState.levelComplete);
	}

	public void GameOver () {
		SetGameState (GameState.gameOver);

	}

	public void RestartLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    public void BackToMenu()
    {
        SceneManager.LoadScene("scene1");
    }

	public void YouWin () {
		SetGameState (GameState.youWin);
	}

	public void NextLevel () {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

	void SetGameState (GameState newGameState) {
		if (newGameState == GameState.menu) {
			menuCanvas.enabled = true;
			inGameCanvas.enabled = false;
			levelCompleteCanvas.enabled = false;
			gameOverCanvas.enabled = false;
			youWinCanvas.enabled = false;
			highScoreCanvas.enabled = false;
		} else if (newGameState == GameState.inGame) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			levelCompleteCanvas.enabled = false;
			gameOverCanvas.enabled = false;
			youWinCanvas.enabled = false;
			highScoreCanvas.enabled = false;
		} else if (newGameState == GameState.levelComplete) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			levelCompleteCanvas.enabled = true;
			youWinCanvas.enabled = false;
			if (this.newHighScore) {
				highScoreCanvas.enabled = true;
			}
		} else if (newGameState == GameState.gameOver) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			levelCompleteCanvas.enabled = false;
			gameOverCanvas.enabled = true;
			youWinCanvas.enabled = false;
			highScoreCanvas.enabled = false;
		} else if (newGameState == GameState.youWin) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
			levelCompleteCanvas.enabled = false;
			youWinCanvas.enabled = true;
			if (this.newHighScore) {
				highScoreCanvas.enabled = true;
			}
		}
		currentGameState = newGameState;
	}

	void Update () {
		if (timeStarted == true) {
			timer += Time.deltaTime;
			seconds = (timer ).ToString ("0000");
		}
	}
}
