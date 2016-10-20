using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour {

	public Text timerLabel;

	void Update () {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			Debug.Log ("game state is ingame");
			timerLabel.text = (GameManager.instance.minutes) + (GameManager.instance.seconds);
			Debug.Log ("timer label is set to " + GameManager.instance.seconds);
		}
	}
}
