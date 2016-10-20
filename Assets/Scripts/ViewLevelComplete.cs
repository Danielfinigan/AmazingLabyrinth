using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewLevelComplete : MonoBehaviour {

	public Text timerLabel;

	void Update () {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			timerLabel.text = ("Your Score:"+GameManager.instance.minutes) + ":" + (GameManager.instance.seconds);
		}
	}
}
