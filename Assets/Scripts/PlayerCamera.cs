using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private float sensitivity = 400f;
    private float x_input, y_input;
    public Transform orientation;
    public Transform body;
    private float xRotation;
    private float yRotation;


    private void Movement()
    {
        x_input = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        y_input = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        yRotation += x_input;
        xRotation -= y_input;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        body.transform.rotation = Quaternion.Euler(0, yRotation, 0f);
    }

 
    void Update()
    {
        Movement();
    }
}
