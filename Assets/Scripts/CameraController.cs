using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float minimumX = -60.0f;
    private float maximumX = 60.0f;
    private float sensitivityX = 5.0f;
    private float sensitivityY = 5.0f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    public new Camera camera;

    void Update()
    {
        if (!GameController.isGamePaused)
        {
            rotationY += Input.GetAxis("Mouse X") * sensitivityY;
            rotationX += Input.GetAxis("Mouse Y") * sensitivityX;
            rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

            transform.localEulerAngles = new Vector3(0, rotationY, 0);
            camera.transform.localEulerAngles = new Vector3(-rotationX, 0, 0);
        }
    }
}
