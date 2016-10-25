using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public static CameraFollow instance;

    public Transform followObject;
    public bool isTwist = false;

    void Awake ()
    {
        instance = this;
    }

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
        {
            CameraTwist(isTwist);
        }

        else
            transform.position = new Vector3(followObject.position.x, followObject.position.y + 30, followObject.position.z - 25);
    }

    void CameraTwist(bool twist)
    {
        if (!twist)
            transform.position = new Vector3(followObject.position.x, followObject.position.y + 10, followObject.position.z - 5);
        else
            transform.position = new Vector3(followObject.position.x, followObject.position.y + 10, followObject.position.z + 5);
    }

    public void CameraRotate()
    {
        float yRotation = transform.eulerAngles.y;
        Vector3 rotation = new Vector3(45, yRotation + 180, 0);
        transform.eulerAngles = rotation;
    }
}
