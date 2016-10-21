using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform followObject;
    public float distance = 2f;
    void Start()
    {
        Vector3 rotation = new Vector3(60, 0, 0);
        transform.eulerAngles = rotation;
        transform.position = new Vector3(followObject.position.x, followObject.position.y + 20, followObject.position.z - 15);
    }

    void Update()
    {        
        transform.position = new Vector3(followObject.position.x, followObject.position.y + 10, followObject.position.z - 5);
    }
}
