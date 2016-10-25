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
	public Canvas menuCanvas;  //start menu
	public Canvas inGameCanvas;  //timer
	public Canvas levelCompleteCanvas;  //after every complete level
	public Canvas gameOverCanvas;  //appears when player touches kill trigger
	public Canvas youWinCanvas;  //appears after completing third level

	public float timer;
	public string seconds;
	public static bool timeStarted = false;

	public void Awake () {
		instance = this;
	}

	public void StartGame () {
		SetGameState (GameState.inGame);
		Player.instance.StartGame ();
		timeStarted = true;
        PlayerPrefs.GetFloat("time1", 1000f);
        PlayerPrefs.GetFloat("time2", 1000f);
        PlayerPrefs.GetFloat("time3", 3000f);
       // Debug.Log("scene1 high score = " + PlayerPrefs.GetFloat("time1"));
    }

	/*all this crap handles setting the 
	 * highscore when the level is completed*/
	public void LevelComplete () {
        /* if this is scene 1 and this time 
		 * was faster than 1000 seconds...*/
        
        if (SceneManager.GetActiveScene().name == "scene1" && 
			PlayerPrefs.GetFloat ("time1") > this.timer) {
            /* ...then set the fastest time for 
			 * scene 1 to this time*/
            PlayerPrefs.SetFloat ("time1", this.timer);

            //Debug.Log("scene1 after high score = " + PlayerPrefs.GetFloat("time1"));
        } 
		/* if this is scene 2 and this time 
		 * was faster than 1000 seconds...*/
		else if (SceneManager.GetActiveScene().name == "scene2" && 
			PlayerPrefs.GetFloat ("time2") > this.timer) {
            /* ...then set the fastest time for 
			 * scene 2 to this time*/
            //Debug.Log("set scene2 high score");
            PlayerPrefs.SetFloat ("time2", this.timer);
		}
		/* this must be scene 3.  if this time
		 * was faster than 1000 seconds...*/
		else if (SceneManager.GetActiveScene().name == "scene3" && 
            PlayerPrefs.GetFloat ("time3") > this.timer) {
            /*...then set the fastest time for 
			 * scene 3 to this time*/
            //Debug.Log("set scene3 high score");
			PlayerPrefs.SetFloat ("time3", this.timer);
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
		/*when the button is clicked load the next level
		 * if we are on the last level, go to the 
		 * "You Win" screen*/
		/*if (Application.loadedLevelName == "scene1") {
			Application.LoadLevel ("scene2");
		} else if (Application.loadedLevelName == "scene2") {
			Application.LoadLevel ("scene3");
		} else
			YouWin ();*/
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
		} else if (newGameState == GameState.youWin) {
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
			seconds = (timer ).ToString ("0000");
		}
	}
}
