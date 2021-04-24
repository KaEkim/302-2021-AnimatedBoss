using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRig : MonoBehaviour
{

    public Transform camTarget;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = camTarget.transform.position;

        Quaternion targetRot = camTarget.transform.rotation;

        targetRot.x = 0;
        targetRot.z = 0;

        transform.rotation = targetRot;
    }
}
