using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    float smoothTime = .1f;
    public Transform target;

    //RotationHoldingVar's
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    //MultipliersForCameraRotation
    int spinX = 2;
    int spinY = 1;

    void Start()
    {
        transform.position = target.transform.position;
    }

    void Update()
    {
        //MoveTowardPlayerWithSmoothing
        Vector3 direction = target.position;
        transform.position = Vector3.SmoothDamp(transform.position, direction, ref velocity, smoothTime / PlayerController.isRun);

        //CameraRotationCode
        yaw += spinX * Input.GetAxis("Mouse X");
        pitch -= spinY * Input.GetAxis("Mouse Y");
        //LockCamBetweenTheseAngles
        if (pitch < -30) pitch = -30;
        if (pitch > 12) pitch = 12;

        transform.eulerAngles = new Vector3(pitch, yaw, .0f);

    }
}