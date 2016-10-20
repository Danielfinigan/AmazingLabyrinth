using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform followObject;
    public float distance = 2f;
    void Start()
    {
        Vector3 rotation = new Vector3(45, 0, 0);
        transform.eulerAngles = rotation;
        transform.position = new Vector3(followObject.position.x, followObject.position.y + 20, followObject.position.z - 30);
    }

    void Update()
    {        
        transform.position = new Vector3(followObject.position.x, followObject.position.y + 20, followObject.position.z - 30);
    }
}
