﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewLevelComplete : MonoBehaviour {

	public Text timerLabel;
	public Text fastestLabel;

	void Update () {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			//timerLabel.text = ("Your Score:"+GameManager.instance.minutes) + ":" + (GameManager.instance.seconds);
			timerLabel.text = ("Your Time:"+GameManager.instance.seconds);

			if (Application.loadedLevelName == "scene1") {
				fastestLabel.text = ("Fastest Time:"+PlayerPrefs.GetFloat ("time1").ToString ("0000"));
			}
			else if (Application.loadedLevelName == "scene2") {
				fastestLabel.text = ("Fastest Time:"+PlayerPrefs.GetFloat ("time2").ToString ("0000"));
			}
			else fastestLabel.text = ("Fastest Time:"+PlayerPrefs.GetFloat ("time2").ToString ("0000"));
			
		}
	}
}