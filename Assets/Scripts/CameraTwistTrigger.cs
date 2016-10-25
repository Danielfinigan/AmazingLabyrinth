using UnityEngine;
using System.Collections;

public class CameraTwistTrigger : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
       /* Vector3 rotation = new Vector3(45, 90, 0);
        transform.eulerAngles = rotation;
        transform.position = new Vector3(followObject.position.x +5, followObject.position.y + 10, followObject.position.z);*/
        if(other.tag == "Player")
        {
            Player.instance.controlReverse = true;
            CameraFollow.instance.cameraTwist = true;
            Debug.Log("Camera Twist");
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
