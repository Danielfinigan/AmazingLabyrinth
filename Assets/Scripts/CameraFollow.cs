using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform followObject;
    public float distance = 2f;
    void Start()
    {
        Vector3 rotation = new Vector3(45, 0, 0);
        transform.eulerAngles = rotation;
    }

    void Update()
    {        
        //Vector3 direction = followObject.GetComponent<Rigidbody>().velocity.normalized;
        //Vector3 offset = distance * direction * rotation;
        transform.position = new Vector3(0, followObject.position.y + 20, followObject.position.z - 30);
    }
}
