using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour {

	public Text timerLabel;

	void Update () {
		if (GameManager.instance.currentGameState == GameState.inGame) {
			Debug.Log ("kill me");
		}
	}

}
