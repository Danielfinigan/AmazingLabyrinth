﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ViewLevelComplete : MonoBehaviour {

	public Text timerLabel;
	public Text fastestLabel;
    public Text newHighScore;

	void Update () {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			//timerLabel.text = ("Your Score:"+GameManager.instance.minutes) + ":" + (GameManager.instance.seconds);
			timerLabel.text = ("Your Time:"+GameManager.instance.seconds);

			if (SceneManager.GetActiveScene().name == "scene1") {
				fastestLabel.text = ("Fastest Time:" + PlayerPrefs.GetFloat ("time1").ToString ("0000"));
			}
			else if (SceneManager.GetActiveScene().name == "scene2") {
				fastestLabel.text = ("Fastest Time:"+PlayerPrefs.GetFloat ("time2").ToString ("0000"));
			}
			else fastestLabel.text = ("Fastest Time:"+PlayerPrefs.GetFloat ("time3").ToString ("0000"));


            Debug.Log("newHighScoreInComplete = " + GameManager.instance.newHighScore.ToString());

            if (GameManager.instance.newHighScore)
            {
                Debug.Log("Why wont you work");
                newHighScore.enabled = true;
            }
		}
	}
}
