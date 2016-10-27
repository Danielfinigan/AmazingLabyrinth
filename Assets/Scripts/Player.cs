using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

public static Player instance;

    [SerializeField] private float speed = 15f;
    public bool controlReverse = false;
    public Rigidbody rb = new Rigidbody();

	void Awake () {
		instance = this;
	}

	public void StartGame() {
        if(GameManager.instance.currentGameState == GameState.inGame)
		    speed = 15f;
        //PlayerPrefs.DeleteAll();

    }

    void FixedUpdate()
    {        
        if(!controlReverse)
        {
            rb.AddForce(Input.GetAxis("Horizontal") * speed, 0, 0);
            rb.AddForce(0, 0, Input.GetAxis("Vertical") * speed);
        }
        else
        {
            rb.AddForce(Input.GetAxis("Horizontal") * speed * -1, 0, 0);
            rb.AddForce(0, 0, Input.GetAxis("Vertical") * speed * -1);
        }
    }
}
