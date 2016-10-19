using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {


	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("xxxxxxxxxxxxxxxxxxxx"); 
		if (other.tag == "Player") {
			Debug.Log ("Player has touched KillTrigger"); 
		}
	}
}
