using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToAttack : MonoBehaviour
{
    public Transform target;

    private Vector3 startingPos;
    private Vector3 currPos;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        currPos = transform.position;
        
        if (currPos.y > startingPos.y)
        {
            float amountDown = Mathf.Abs(currPos.y - startingPos.y);

            //Zeroing out math to new position for next frame
            startingPos = currPos;

            //Moving handaAimAngle based on camera movement
            Vector3 newPos = target.position;
            newPos.y -= amountDown;
            target.position = newPos;
        }
        else if (currPos.y < startingPos.y)
        {
            float amountUp = Mathf.Abs(currPos.y - startingPos.y);

            //Zeroing out math to new position for next frame
            startingPos = currPos;

            //Moving handaAimAngle based on camera movement
            Vector3 newPos = target.position;
            newPos.y += amountUp;
            target.position = newPos;
        }
    }
}