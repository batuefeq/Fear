using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform transformcamera;

   
    void Update()
    {
        transform.position = transformcamera.position;
    }
}
