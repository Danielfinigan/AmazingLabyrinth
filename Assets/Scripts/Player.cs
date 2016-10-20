using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static Player instance;

    [SerializeField] private float speed = 0f;
    public Rigidbody rb = new Rigidbody();

	void Awake () {
		instance = this;
	}

	public void StartGame() {
		speed = 15f;
	}

    void FixedUpdate()
    {
        rb.AddForce(Input.GetAxis("Horizontal") * speed, 0, 0);
        rb.AddForce(0, 0, Input.GetAxis("Vertical") * speed);
    }
}
