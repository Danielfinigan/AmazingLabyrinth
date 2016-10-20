using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewLevelComplete : MonoBehaviour {

	public Text timerLabel;
	public Text fastestLabel;
	private string fastest;

	void Update () {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			//timerLabel.text = ("Your Score:"+GameManager.instance.minutes) + ":" + (GameManager.instance.seconds);
			timerLabel.text = ("Your Time:"+GameManager.instance.seconds);

			if (Application.loadedLevelName == "scene1") {
				fastest = PlayerPrefs.GetFloat ("time1").ToString ("0000");
				fastestLabel.text = ("Fastest Time:"+fastest);
			}
		}
	}
}
