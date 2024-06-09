using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1.0f;

    [SerializeField]
    private float sensitivity = 1.0f;

    [SerializeField]
    private bool isCameraLocked = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCameraLocked = false;
    }

    private void Update()
    {
        HandleLock();
        if (!isCameraLocked)
        {
            HandleMovement();
        }



    }

    private void HandleLock()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isCameraLocked = !isCameraLocked;
            if (isCameraLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    private void HandleMovement()
    {

        // Rotation
        float rotX = Input.GetAxis("Mouse Y");
        float rotY = Input.GetAxis("Mouse X");


        var oldRotation = this.transform.rotation.eulerAngles;
        this.transform.rotation = Quaternion.Euler(oldRotation + new Vector3(-rotX, rotY, 0) * (sensitivity * Time.deltaTime));


        // Movement
        bool up = Input.GetKey(KeyCode.E);
        bool down = Input.GetKey(KeyCode.Q);

        if (up)
        {
            this.transform.position += Vector3.up * (movementSpeed * Time.deltaTime);
        }
        if (down)
        {
            this.transform.position += Vector3.down * (movementSpeed * Time.deltaTime);
        }


        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        var forward = this.transform.forward;
        var delta = new Vector3(x, 0, y) * (movementSpeed * Time.deltaTime);

        this.transform.Translate(delta);
    }
}
