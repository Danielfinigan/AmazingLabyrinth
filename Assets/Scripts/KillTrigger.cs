using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {


	void OnTriggerEnter (Collider other)
	{
        if (other.tag == "Player")
        {
            GameManager.instance.GameOver();
            Player.instance.rb.constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("Freeze Constraints");
        }
	}
}
