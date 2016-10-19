using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {


	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			Debug.Log ("Player has touched KillTrigger"); 
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
