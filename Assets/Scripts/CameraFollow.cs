using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform followObject;
    void Start()
    {

        if (SceneManager.GetActiveScene().name == "scene3")
            transform.position = new Vector3(followObject.position.x, followObject.position.y + 10, followObject.position.z - 5);
        else
            transform.position = new Vector3(followObject.position.x, followObject.position.y + 30, followObject.position.z - 25);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "scene3")
            transform.position = new Vector3(followObject.position.x, followObject.position.y + 10, followObject.position.z - 5);
        else
            transform.position = new Vector3(followObject.position.x, followObject.position.y + 30, followObject.position.z - 25);
    }
}
