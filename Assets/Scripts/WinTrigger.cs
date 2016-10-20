using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {


	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			GameManager.instance.LevelComplete();
		}
	}
}
